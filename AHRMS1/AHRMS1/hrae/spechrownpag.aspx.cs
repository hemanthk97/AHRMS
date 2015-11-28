using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AHRMS1.ms
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string sun = username();
            int un = Convert.ToInt32(sun);
            string companyname = getcompanyname(un);
            if (companyname == "oooooo")
            {
                Response.Redirect("~/acess.aspx");
            }
            else
            {
                lblhrname.Text = companyname;
                lblhrname.Font.Size = 0;
                lblhrname.Width = 0;
                lblhrname.Height = 0;
            }
        }
        public string username()
        {
            try
            {
                string lun1 = Session["hrid"].ToString();
            }
            catch
            {
                Response.Redirect("~/acess.aspx");
            }

            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("gethrid", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string lun2 = Session["hrid"].ToString();
                cmd.Parameters.AddWithValue("@ui", lun2);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@un";
                outpara.SqlDbType = SqlDbType.Int;
                outpara.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                string fn = outpara.Value.ToString();
                return fn;
            }
            catch
            {
                Response.Redirect("~/error.aspx");
                return "1";
            }
        }

        public string getcompanyname(int un)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("getempname", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ui", un);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@un";
                outpara.SqlDbType = SqlDbType.VarChar;
                outpara.Direction = ParameterDirection.Output;
                outpara.Size = 100;
                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                string fn = outpara.Value.ToString();
                return fn;
            }
            catch
            
            {
                Response.Redirect("~/error.aspx");
                return "oooooo";
            }

        }
    }
}