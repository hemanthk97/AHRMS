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
using System.Net;
using System.Net.Configuration;
using System.Web.Configuration;
using System.Text;
using System.Web.Security;
using System.Security.Cryptography;



namespace AHRMS1.ms
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void regbtnhr_Click(object sender, EventArgs e)
        {
            string ee = txtemailreghr.Text.ToString();
            string al = txtaltemail.Text.ToString();
            Int32 sss;
            bool s = reghr(out sss);
            if (s)
            {
                lblreghr.Text = "Loading....";
                bool sm = sendmail(ee, al,sss);
                if (sm)
                {
                    lblreghr.Text = "Thank You for registering will get back to shortly";
                }
                else
                {
                    lblreghr.Text = "OOps!!! Something went wrong try again";
                }
            }
            else
            {
                lblreghr.Text = "OOps!!! Something went wrong try again";
            }
        }

        public bool reghr(out Int32 dddd)
        {

            string empname = txtcomname.Text.ToString();
            string empadd = txtadd.Text.ToString();
            string name = txtname.Text.ToString();
            string mn = txtcontactno.Text.ToString();
            string ld = txtlandlinenum.Text.ToString();
            string offmail1 = txtemailreghr.Text.ToString();
            string altmail = txtaltemail.Text.ToString();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("hreg", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@en", empname);
                cmd.Parameters.AddWithValue("@ed", empadd);
                cmd.Parameters.AddWithValue("@nm", name);
                cmd.Parameters.AddWithValue("@mn", mn);
                cmd.Parameters.AddWithValue("@ld", ld);
                cmd.Parameters.AddWithValue("@om", offmail1);
                cmd.Parameters.AddWithValue("@am", altmail);
                SqlParameter id = new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(id);

                con.Open();
                cmd.ExecuteNonQuery();
                dddd = Convert.ToInt32(id.Value.ToString());
                con.Close();
                return true;
            }
           catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                dddd = 0;
                return false;
            }

        }
        public bool sendmail(string ema, string al,Int32 sss)
        {
            string co = txtcomname.Text.ToString();
            try
            {

                MailMessage mess = new MailMessage("hemi8095481467@outlook.com", ema);
                mess.CC.Add(al);
                mess.Subject = "AHRMS welcomes " + co + "";
                mess.Body = "Hi," + Environment.NewLine + Environment.NewLine +


                    "AHRMS" + Environment.NewLine +
                        "Advance Human Resource Management Systems" + Environment.NewLine + Environment.NewLine +

                     "Thank you for registring with AHRMS" + Environment.NewLine +
                     "Will get back to you shortly with your id and password" + "   " + "   " + "" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     "This is registration Number"+sss.ToString()+ Environment.NewLine+ Environment.NewLine+ Environment.NewLine+
                    "for any further communication contact on below mentioned mail id" + Environment.NewLine
                     + Environment.NewLine
                     + "adminahrms@ahrs.com"
                     + Environment.NewLine + Environment.NewLine +
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
        protected void logbtnhr_Click(object sender, EventArgs e)
        {
            bool log = checklogin();
            if (log)
            {

                Session["hrid"] = txthrid.Text.ToString();
                Session.Timeout = 60;
                Response.Redirect("~/hrae/spechrownpag.aspx", false);
            }
            else
            {
                lblhrstatus.Text = "Invalid HR ID or Password";
            }

        }
        public bool checklogin()
        {


            string ui = txthrid.Text.ToString();
            string ps = GETMD5(txtpasshr.Text.ToString());

            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("loghr", con);
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
                Response.Redirect("~/error.aspx");
                return false;
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
                senderrormail(em, ss, sw, sd, sr, tr, innerex);
                Response.Redirect("~/error.aspx");
            }
        }

        public void senderrormail(string ema, string mess1, string source, string hres, string data, string target, string inner)
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


    }
}














