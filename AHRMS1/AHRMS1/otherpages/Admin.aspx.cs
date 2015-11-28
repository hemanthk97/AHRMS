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
using System.Text.RegularExpressions;

namespace AHRMS1.otherpages
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string GetRandomAlphaNumeric()
        {
            Random adomRng = new Random();
            string rndString = string.Empty;
            char c;

            for (int i = 0; i < 8; i++)
            {
                while (!Regex.IsMatch((c = Convert.ToChar(adomRng.Next(48, 128))).ToString(), "[A-Za-z0-9]")) ;
                rndString += c;
            }
            return rndString;
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

        public bool sendmail(string ema,string ema1, string uni)
        {
            try
            {

                MailMessage mess = new MailMessage("hemanthk080080@outlook.com", ema);
                mess.CC.Add(ema1);
                mess.Subject = "AHRMS::Registration Completion";
                mess.Body = "Hi," + Environment.NewLine + Environment.NewLine +


                    "AHRMS" + Environment.NewLine +
                        "Advance Human Resource Management Systems" + Environment.NewLine + Environment.NewLine +

                     "You Have successfully completed your registration" + Environment.NewLine +
                     "Click Below link to create your new password" + "   " + "   " + "" + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     Environment.NewLine + Environment.NewLine + Environment.NewLine +
                     "This is your employer id:" + uni + Environment.NewLine + Environment.NewLine + Environment.NewLine +
                    "http://localhost:61438/otherpages/empChangePassword.aspx?unid=" + uni + Environment.NewLine
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
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;

            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
          bool ss =  getstatusnumberorchar(hridandpass.Text);

          if (ss)
          {
             bool dd =  checkdataavailable(Convert.ToInt32(hridandpass.Text), "hridandpass");
             bool ss1 = checkdataavailable(Convert.ToInt32(hridandpass.Text), "hridandpass1");
             if (dd)
             {
                 if (!ss1)
                 {
                   bool gen =  genrate("insertdata",Convert.ToInt32(hridandpass.Text),GETMD5(GetRandomAlphaNumeric()),hridandpass.Text);
                   if (gen)
                   {
                       string emm,emm2;
                       getmailid("getemailid",hridandpass.Text,out emm,out emm2);
                      bool mail = sendmail(emm,emm2,hridandpass.Text);
                      if (mail)
                      {
                          lblhridandpass.Text = "Id And Password Generated and Link Sent to User";
                      }
                   }
                   }
                 else
                 {
                     lblhridandpass.Text = "Already Userid and Password Generated";
                 }
             }
             else
             {
                 lblhridandpass.Text = "Data Not Availbale";
             }
          }
        }

        private void getmailid(string p1, string p2, out string emm, out string emm2)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p1, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", p2);
                SqlParameter email = new SqlParameter("@id", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter email1 = new SqlParameter("@id1", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(email1);

                con.Open();

                cmd.ExecuteNonQuery();
                emm = email.Value.ToString();
                emm2 = email1.Value.ToString();
               
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                emm = "";
                emm2 = "";
            }
        }

        private bool genrate(string p1, int p2, string pass,string id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p1, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", p2);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pass", pass);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                int ss = dr.RecordsAffected;
                if (ss == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;
            }
        }

        private bool checkdataavailable(Int32 uniq1, string spname)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uniq1);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                bool s = dr.HasRows;
                return s;
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;
            }
        }
        private bool getstatusnumberorchar(string p)
        {
            try
            {
                Int32 uniq2 = Convert.ToInt32(p);
                return true;
            }
            catch
            {
                lblhridandpass.Text = "Invalid ID";
                return false;
            }
        }
    }
}