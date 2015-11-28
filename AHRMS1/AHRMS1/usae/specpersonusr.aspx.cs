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

namespace AHRMS1.usae
{
    public partial class specpersonusr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("~/ms/access.aspx", true);
                }

                Int32 uniqueid = getuniid();
                bool checkun = checkuni(uniqueid, "checkui", "@uni");
                if (checkun)
                {

                    firstnamespusr.Text = getvalue1(uniqueid, "getfn1", "@ui", "@fn", SqlDbType.VarChar, 50).ToString();
                    lastnamespusr.Text = getvalue1(uniqueid, "getln1", "@ui", "@ln", SqlDbType.VarChar, 50).ToString();
                    middlename.Text = getvalue1(uniqueid, "getmdn", "@ui", "@mdn", SqlDbType.VarChar, 50).ToString();
                    fathername.Text = getvalue1(uniqueid, "getfatn", "@ui", "@fatn", SqlDbType.VarChar, 50).ToString();
                    dateofbirth.Text = getvalue1(uniqueid, "getdob", "@ui", "@dob", SqlDbType.Date, 0).ToString().Remove(10, 9);
                    gender.SelectedValue = getvalue1(uniqueid, "getgn", "@ui", "@gn", SqlDbType.Int, 0).ToString();
                    usrperaddress.Text = getvalue1(uniqueid, "getadd", "@ui", "@add", SqlDbType.VarChar, 250).ToString();
                    string st = getvalue1(uniqueid, "getstate", "@ui", "@state", SqlDbType.Int, 0).ToString();
                    string ct = getvalue1(uniqueid, "getcity", "@ui", "@city", SqlDbType.Int, 0).ToString();
                    pincode.Text = getvalue1(uniqueid, "getpen", "@ui", "@pen", SqlDbType.Int, 0).ToString();
                    usrnumber.Text = getvalue1(uniqueid, "getmob", "@ui", "@mob", SqlDbType.VarChar, 50).ToString();
                    int s = Convert.ToInt32(st) + 1;
                    int c = Convert.ToInt32(ct) + 1;
                    string stn = getvalue1(s, "getstatename", "@st", "@stna", SqlDbType.VarChar, 50).ToString();
                    string ctn = getvalue1(c, "getcityename", "@st", "@stna", SqlDbType.VarChar, 50).ToString();
                    dropstate.DataSource = getstate("spgetname", null);
                    dropstate.DataBind();

                    dropstate.SelectedValue = st;
                    SqlParameter par = new SqlParameter("@stateid", st);
                    DataSet ds = getstate("spgetcityname", par);
                    dropcity.DataSource = ds;
                    dropcity.DataBind();
                    dropcity.SelectedValue = ct;
                    dropcity.Enabled = true;


                    btnupdateperdel.Visible = true;
                    btnpersonaldet.Visible = false;
                    btnpersonaldet.CausesValidation = false;
                    heading.InnerText = "Details Already Entered,Do correction if any";
                    message1.InnerText = "Details Already Entered,Do correction if any";
                    message2.InnerText = "Click on update to for changes done";

                }
                else
                {

                    btnupdateperdel.Visible = false;
                    string fn = getvalue(uniqueid, "getfn", "@ui", "@fn");
                    string ln = getvalue(uniqueid, "getln", "@ui", "@ln");
                    string mn = getvalue(uniqueid, "getmn", "@ui", "@mn");
                    firstnamespusr.Text = fn;
                    lastnamespusr.Text = ln;
                    usrnumber.Text = mn;
                    if (!IsPostBack)
                    {
                        dropstate.DataSource = getstate("spgetname", null);
                        dropstate.DataBind();
                        ListItem liState = new ListItem("Select State", "-1");
                        dropstate.Items.Insert(0, liState);
                        ListItem licity = new ListItem("Select City", "-1");
                        dropcity.Items.Insert(0, licity);
                        dropcity.Enabled = false;
                        btnupdateperdel.Visible = false;
                        btnupdateperdel.CausesValidation = false;
                        btnpersonaldet.Visible = true;
                        btnpersonaldet.CausesValidation = true;
                    }
                }
            }
        }

        public bool checkuni(Int32 un, string spname, string par)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@uni", un);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                bool s = dr.HasRows;
                if (s)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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



      
        public static Int32 getuniid()
        {
            try
            {

                string lun1 = HttpContext.Current.Session["userid"].ToString();
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("uniqueid", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ui", lun1);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@uniqueid";
                outpara.SqlDbType = SqlDbType.Int;
                outpara.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                Int32 fn = Convert.ToInt32(outpara.Value);
                return fn;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return 0;
            }
        }
        public string getvalue1(Int32 uniquid, string spname, string inpara, string outpara1, SqlDbType type, int size)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue(inpara, uniquid);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = outpara1;
                outpara.SqlDbType = type;
                outpara.Direction = ParameterDirection.Output;
                outpara.Size = size;
                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                string res = outpara.Value.ToString();
                return res;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return "NA";
            }
        }






        public string getvalue(Int32 uniquid, string spname, string inpara, string outpara1)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue(inpara, uniquid);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = outpara1;
                outpara.SqlDbType = SqlDbType.VarChar;
                outpara.Direction = ParameterDirection.Output;
                outpara.Size = 50;
                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                string res = outpara.Value.ToString();
                return res;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return "NA";
            }
        }

        private DataSet getstate(string spname, SqlParameter sparameter)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter(spname, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (sparameter != null)
                {
                    da.SelectCommand.Parameters.Add(sparameter);
                }
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                DataSet ds = new DataSet();
                return ds;
            }
        }

        protected void dropstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(8000);
            if (dropstate.SelectedIndex == 0)
            {
                ListItem licity = new ListItem("Select City", "-1");
                dropcity.Items.Insert(0, licity);
                dropcity.SelectedIndex = 0;
                dropcity.Enabled = false;
            }
            else
            {
                dropcity.Enabled = true;
                SqlParameter par = new SqlParameter("@stateid", dropstate.SelectedValue);
                DataSet ds = getstate("spgetcityname", par);
                dropcity.DataSource = ds;
                dropcity.DataBind();
                ListItem licity = new ListItem("Select City", "-1");
                dropcity.Items.Insert(0, licity);

            }
        }

        protected void btnpersonaldet_Click(object sender, EventArgs e)
        {
            Int32 ui = getuniid();
            bool success = insertdata(ui, "insertperdata");
            if (success)
            {
                Label1.Text = "Personal Details Updated, Click on start to fill Qualification details";
                Label1.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/usae/specusredu.aspx", true);
            }
            else
            {
                Label1.Text = "Went wrong";
                Label1.ForeColor = System.Drawing.Color.Red;
            }

        }
        public bool insertdata(Int32 u, string spname)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter par = new SqlParameter();
                par.ParameterName = "@dob";

                String dt = dateofbirth.Text.ToString();
                par.SqlDbType = SqlDbType.Date;
                par.Value = dt;

                cmd.Parameters.AddWithValue("@ui", u);
                cmd.Parameters.AddWithValue("@fn", firstnamespusr.Text.ToString());
                cmd.Parameters.AddWithValue("@mn", middlename.Text.ToString());
                cmd.Parameters.AddWithValue("@ln", lastnamespusr.Text.ToString());
                cmd.Parameters.AddWithValue("@fathn", fathername.Text.ToString());
                cmd.Parameters.AddWithValue("@add", usrperaddress.Text.ToString());
                cmd.Parameters.Add(par);
                cmd.Parameters.AddWithValue("@gn", gender.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@state", dropstate.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@city", dropcity.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@pincode", Convert.ToInt32(pincode.Text.ToString()));
                cmd.Parameters.AddWithValue("@mobnum", usrnumber.Text.ToString());

                con.Open();
                Int32 rowaffected = cmd.ExecuteNonQuery();

                if (rowaffected == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        protected void btnupdateperdel_Click(object sender, EventArgs e)
        {
            Int32 ui = getuniid();
            bool success = insertdata(ui, "spupdatepersonaldel");
            if (success)
            {
                Label1.Text = "Correction Done, check in verify tab";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Label1.Text = "Correction Not done try again";
                Label1.ForeColor = System.Drawing.Color.Red;
            }


        }

        public static void errorlog(string mess, string source, string hres)
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
                HttpContext.Current.Response.Redirect("~/error.aspx");
            }
        }

        public static void senderrormail(string ema, string mess1, string source, string hres, string data, string target, string inner)
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
               HttpContext.Current.Response.Redirect("~/error.apsx");
            }


        }



    }
}