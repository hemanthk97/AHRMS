using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Ecc;
using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec.Util;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Web.Services;


namespace AHRMS1.otherpages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("Username");
            Session.RemoveAll();
            if (IsPostBack)
            {
                Session.Remove("Username");
                Session.RemoveAll();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("cont", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@email", TextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@com", TextBox1.Text.ToString());

                con.Open();

                cmd.ExecuteNonQuery();
                Label1.Text = "We will contact you shortly";
            
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                
            }
        }
    }
}