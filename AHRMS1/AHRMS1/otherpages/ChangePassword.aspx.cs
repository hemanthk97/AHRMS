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
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace AHRMS1
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            txtcnpass.TextMode = TextBoxMode.Password;
            txtcnpassconf.TextMode = TextBoxMode.Password;
            }
            }

        protected void cnpass_Click(object sender, EventArgs e)
        {
            string u = Request.QueryString["unid"];
            bool s = up(u);
            if (s)
            {
                lblcnpas.Text = "Password Changed go a head and login";
                HyperLink1.Visible = true;
            }
            else
            {
                lblcnpas.Text = "Password not changed";
                HyperLink1.Visible = false;
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


        public bool up(string uu)
        {
            string ps = GETMD5(txtcnpass.Text.ToString());

            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("chnpp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@userd", uu);
                cmd.Parameters.AddWithValue("@ps", ps);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int ff = dr.RecordsAffected;
                con.Close();
                if (ff == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                Response.Redirect("~/error.aspx");
                return false;
            }
            }
            
        }
       
    }
