using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Configuration;
using System.Web.Security;
using System.Web.Configuration;
using System.Net;
using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AHRMS1.ms
{
    public partial class specusrmas : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["userid"] == null)
            {
                Response.Redirect("~/ms/access.aspx",true);
            }

            try
            {

                specloggedname.Text = "Logged in as" + " " + Session["userid"].ToString();
                cplink.NavigateUrl = "http://localhost:61438/otherpages/ChangePassword.aspx?unid=" + Session["userid"];
 
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/ms/access.aspx", false);

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