using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Configuration;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Web.Services;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Ecc;
using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec.Util;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;

namespace AHRMS1.otherpages
{
    public partial class userlogreg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void regbtn_Click(object sender, EventArgs e)
        {
            
            lblreg.Text = "wait";
            lblmailwel.Text = "Loading!!!!";
            string fnn = txtfirstname.Text.ToString();
            string ui = txtuseridreg.Text.ToString();
            string em = txtemailreg.Text.ToString();
            bool tt = checkusr();
          
            if (tt)
            {
                lblreg.Text = "User Already Exists Please try with different Details";
                lblmailwel.Text = "";
            }

            else
            {
                Int32 iii;
                bool ss = regusr(out iii);

                if (ss)
                {

                    bool suc = sendmail1(fnn, ui, em, iii);
                    if (suc)
                    {
                        lblmailwel.Text = "Welcome Mail has been sent to your mail ID";
                        lblreg.ForeColor = System.Drawing.Color.Green;
                        lblreg.Text = "Thank You For Registration!!!!";
                        lblmailwel.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        deldel(ui);
                        lblreg.Text = "Not Registered!!!!!!!!";
                        lblreg.ForeColor = System.Drawing.Color.Red;
                        lblmailwel.Text = "Mail Not sent";
                        lblmailwel.ForeColor = System.Drawing.Color.Red;

                    }

                }
                else
                {
                    lblmailwel.Text = "Mail not sent, something went wrong!!!!";
                    lblreg.Text = "You Are not Registerd!!!!!!";
                    lblreg.ForeColor = System.Drawing.Color.Red;
                    lblmailwel.ForeColor = System.Drawing.Color.Red;

                }
            }
        }

        public void deldel(string uni)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("deldel", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uni);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);

            }

        }
        public void errorlog(string mess, string source, string hres)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("sperrorlog", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@mes", mess);
                cmd.Parameters.AddWithValue("@so", source);
                cmd.Parameters.AddWithValue("@hres", hres);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                string sr = db.Data.ToString();
                string tr = db.TargetSite.ToString();
                string innerex = db.InnerException.ToString();
                string em = "hemantherrork97@gmail.com";
                senderrormail(em, ss, sw, sd, sr, tr,innerex);
                Response.Redirect("~/error.aspx");
            }
        }

        public void senderrormail(string ema, string mess1, string source, string hres, string data, string target,string inner)
        {
            try
            {

                MailMessage mess = new MailMessage("hemanthk080080@outlook.com", ema);
                mess.Subject = "Exception Num" + hres;
                mess.Body = "Admin" + Environment.NewLine + Environment.NewLine +

     "There was following exceptions" +
     Environment.NewLine + Environment.NewLine +
     "Source" + Environment.NewLine + Environment.NewLine +
     source + Environment.NewLine + Environment.NewLine +
     mess1 + Environment.NewLine + Environment.NewLine +
     data + Environment.NewLine + Environment.NewLine +
     target + Environment.NewLine + Environment.NewLine +
     inner + Environment.NewLine + Environment.NewLine +

     "Regards," + Environment.NewLine +
         "AHRMS System";


                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                SmtpClient sc = new SmtpClient();
                sc.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                sc.EnableSsl = true;
                sc.Send(mess);
            }
            catch
            {
                Response.Redirect("~/error.apsx");
            }


        }

        public string GETMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] res = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < res.Length; i++)
            {
                str.Append(res[i].ToString("x2"));
            }
            return str.ToString();
        }


        public bool regusr(out Int32 ii)
        {

            string fn = txtfirstname.Text.ToString();
            string ln = txtlastname.Text.ToString();
            string ui = txtuseridreg.Text.ToString();
            string em = txtemailreg.Text.ToString();
            string pass1 = GETMD5(txtpassreg.Text.ToString());
            string mn = txtcontactnousr.Text.ToString();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("usrreg", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@ui", ui);
                cmd.Parameters.AddWithValue("@em", em);
                cmd.Parameters.AddWithValue("@ps", pass1);
                cmd.Parameters.AddWithValue("@mn", mn);
                SqlParameter out1 = new SqlParameter("@uni", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(out1);


                con.Open();
                cmd.ExecuteNonQuery();
                ii = Convert.ToInt32(out1.Value);
                con.Close();
                return true;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                ii = 0;
                return false;
            }

        }
        public bool checkusr()
        {


            string ui = txtuseridreg.Text.ToString();
            string em = txtemailreg.Text.ToString();
            string mn = txtcontactnousr.Text.ToString();

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("checkusr", con);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@ui", ui);
                cmd.Parameters.AddWithValue("@em", em);
                cmd.Parameters.AddWithValue("@mn", mn);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                bool s1 = dr.HasRows;

                con.Close();
                return s1;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return false;
            }



        }

        public bool checklogin()
        {


            string ui = txtuserid.Text.ToString();
            string ps = GETMD5(txtpass.Text.ToString());

            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("loginusr", con);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@ui", ui);
                cmd.Parameters.AddWithValue("@ps", ps);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                bool s1 = dr.HasRows;
                con.Close();
                return s1;

            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return false;
            }
        }




        protected void logbtn_Click(object sender, EventArgs e)
        {

            bool log = checklogin();
            if (log)
            {
                Session["userid"] = txtuserid.Text.ToString();
                Session.Timeout = 800;
                Response.Redirect("~/usae/specueopag.aspx", false);
            }
            else
            {
                lblloginstatus.Text = "Invalid Userid or Password";
            }
        }

        protected void fpbtn_Click(object sender, EventArgs e)
        {
            string unid = getuni();
            bool sm = search();
            if (sm)
            {
                string emal = fpemailid.Text.ToString();
                bool kk = sendmail(emal, unid);
                if (kk)
                {
                    fplbl.Text = "Mail Sent Check your Mail Id for password";
                    fplbl.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    fplbl.Text = "OOPS Something went wrong try again!!!!";
                    fplbl.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                fplbl.Text = "Mail Id does not exist";
                fplbl.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected string getuni()
        {
            string em = fpemailid.Text.ToString();
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("getuni", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@em", em);

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@uni";
                par.SqlDbType = SqlDbType.VarChar;
                par.Size = 50;
                par.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(par);

                con.Open();
                cmd.ExecuteNonQuery();

                string uni = par.Value.ToString();
                return uni;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return "";

            }

        }
        public bool search()
        {


            string em = fpemailid.Text.ToString();
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("search", con);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@em", em);


                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                bool s1 = dr.HasRows;
                con.Close();
                return s1;

            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return false;
            }

        }

        public bool sendmail(string ema, string uni)
        {
            try
            {

                MailMessage mess = new MailMessage("hemanthk080080@outlook.com", ema);
                mess.Subject = "AHRMS Request for Password";
                mess.Body = "Hi User," + Environment.NewLine + Environment.NewLine +


                    "AHRMS" + Environment.NewLine +
                        "Advance Human Resource Management Systems" + Environment.NewLine + Environment.NewLine +

                     "Your Request for Password recovery is successfull" + Environment.NewLine +
                     "Click Below link to change password" + "   " + "   " + "" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     Environment.NewLine + Environment.NewLine + Environment.NewLine +
                    "http://localhost:61438/otherpages/ChangePassword.aspx?unid=" + uni + Environment.NewLine
                     + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     "Regards" + Environment.NewLine + "AHRMS" + Environment.NewLine + "Admin" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     "Note:- This is System generated mail Please do not reply to this mail id" + Environment.NewLine + Environment.NewLine +
                     "Thank You for visiting AHRMS";
                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                SmtpClient sc = new SmtpClient();
                sc.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                sc.EnableSsl = true;
                sc.Send(mess);

                return true;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                return false;

            }
        }

        public bool sendmail1(string name, string userid, string em,Int32 iii)
        {
            try
            {
                QRCodeEncoder qe = new QRCodeEncoder();
                qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                System.Drawing.Image im = qe.Encode(iii.ToString());
                
                MemoryStream ms = new MemoryStream();
                im.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                byte[] bt = ms.ToArray();

                MemoryStream da = new MemoryStream(bt);

                MailMessage mess = new MailMessage("hemanthk080080@outlook.com", em);
                mess.Subject = "AHRMS welcomes you " + name + "";
               
               
                Attachment data = new Attachment(da,"myimage.jpeg","image/jpeg");
                 System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.DateTime.Now;
                disposition.ModificationDate = System.DateTime.Now;
                disposition.DispositionType = DispositionTypeNames.Attachment; 

                mess.Attachments.Add(data);
                mess.Body = "Hi" + "," + name + "" + Environment.NewLine + Environment.NewLine +


                    "AHRMS" + Environment.NewLine +
                        "Advance Human Resource Management Systems" + Environment.NewLine + Environment.NewLine +

                     "Thank You for regiserting with AHRMS" + Environment.NewLine +
                     "Your USERID is" + "     " + userid + "   " + "   " + "" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     "For any further details please contact on the below mailID" + Environment.NewLine +
                     Environment.NewLine +
                     "ahrmssupport@yahoo.com" + Environment.NewLine + Environment.NewLine +
                     "Your QR code is attached in the mail please download it" + Environment.NewLine + Environment.NewLine +
                     "Regards" + Environment.NewLine + "AHRMS" + Environment.NewLine + "Admin" + Environment.NewLine +
                     @"<img  src=""../Images/logo.png"" />"+
                     Environment.NewLine + Environment.NewLine +
                     "Note:- This is System generated mail Please do not reply to this mail id" + Environment.NewLine + Environment.NewLine +
                     "Thank You for visiting AHRMS";

                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");

                SmtpClient sc = new SmtpClient();
                sc.Credentials = new NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
                sc.EnableSsl = true;

                sc.EnableSsl = true;
                sc.Send(mess);
                return true;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                return false;
            }
        }

        protected void txtuseridreg_TextChanged(object sender, EventArgs e)
        {
            available.Visible = false;
            notavail.Visible = false;
            
            System.Threading.Thread.Sleep(7000);
            if (!string.IsNullOrEmpty(txtuseridreg.Text.ToString()))
            try
            {
              
                string uii = txtuseridreg.Text.ToString();
                string qrr = "select * from tbl_Registrattion where userid=@ui";

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(qrr, con);
                cmd.CommandType = CommandType.Text;
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@ui";
                par.Value = uii;
                cmd.Parameters.Add(par);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                bool s = dr.HasRows;
                con.Close();
                if (s)
                {

                    available.Visible = false;
                    notavail.Visible = true;
                   


                }
                else
                {
                    available.Visible = true;
                    notavail.Visible = false;
                    
                }
               
            }

            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                 Response.Redirect("~/error.aspx", true);
              

            }

        }
    }
}