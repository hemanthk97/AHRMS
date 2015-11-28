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
    public partial class specusredu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 uniqueid = getuniid();
      
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("~/ms/access.aspx", true);
                }
                yearcompleted.DataSource = getyear("getyear", null);
                yearcompleted.DataBind();
                ListItem liyear = new ListItem("Select Year", "-1");
                yearcompleted.Items.Insert(0, liyear);
                puyearcompleted.DataSource = getyear("getyear", null);
                puyearcompleted.DataBind();
                ListItem liyear1 = new ListItem("Select Year", "-1");
                puyearcompleted.Items.Insert(0, liyear1);
                diplomastartyear.DataSource = getyear("getyear", null);
                diplomastartyear.DataBind();
                ListItem liyear2 = new ListItem("Select Year", "-1");
                diplomastartyear.Items.Insert(0, liyear2);
                gradstartyear.DataSource = getyear("getyear", null);
                gradstartyear.DataBind();
                ListItem liyear3 = new ListItem("Select Year", "-1");
                gradstartyear.Items.Insert(0, liyear3);
                pgstartyear.DataSource = getyear("getyear", null);
                pgstartyear.DataBind();
                ListItem liyear4 = new ListItem("Select Year", "-1");
                pgstartyear.Items.Insert(0, liyear4);
                diplomaendyear.Enabled = false;
                gradendyear.Enabled = false;
                pgendyear.Enabled = false;
                ListItem liyear5 = new ListItem("Select Year", "-1");
                diplomaendyear.Items.Insert(0, liyear5);
                ListItem liyear6 = new ListItem("Select Year", "-1");
                gradendyear.Items.Insert(0, liyear6);
                ListItem liyear7 = new ListItem("Select Year", "-1");
                pgendyear.Items.Insert(0, liyear7);
                diplomaspec.DataSource = getyear("dipspec", null);
                diplomaspec.DataBind();
                ListItem li = new ListItem("Select Specialization", "-1");
                diplomaspec.Items.Insert(0, li);
                gradspec.DataSource = getyear("gardspec", null);
                gradspec.DataBind();
                gradspec.Items.Insert(0, li);
                pgspec.DataSource = getyear("gardspec", null);
                pgspec.DataBind();
                pgspec.Items.Insert(0,li);
                graddegree1.DataSource = getyear("degree", null);
                graddegree1.DataBind();
                ListItem li1 = new ListItem("Select Degree", "-1");
                graddegree1.Items.Insert(0, li1);
                pgdegree1.DataSource = getyear("degree", null);
                pgdegree1.DataBind();
                pgdegree1.Items.Insert(0, li1);


                if (AHRMS1.usae.specupload.getstatus(uniqueid, "spchecksslc"))
                {
                    CheckBox1.Enabled = false;
                    sslcdis(false);
                    sslcstatus.Text = "10th Details saved, Verify details in Verification tab";
                    sslcstatus.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    sslcstatus.Text = "10th Details Not Filled";
                    sslcstatus.ForeColor = System.Drawing.Color.Blue;
                    sslcdis(false);
                }
                if (AHRMS1.usae.specupload.getstatus(uniqueid, "spcheckpuc"))
                {
                    CheckBox2.Enabled = false;
                    pudis(false);
                    pucstatus.Text = "PUC Details saved, Verify details in Verification tab";
                    pucstatus.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    pucstatus.Text = "PUC/12th Details Not Filled";
                    pucstatus.ForeColor = System.Drawing.Color.Blue;
                    pudis(false);
                }
                if (AHRMS1.usae.specupload.getstatus(uniqueid, "spcheckdip"))
                {
                    chkdiploma.Enabled = false;
                    dipdis(false);
                    dipstatus.Text = "Diploma Details saved, Verify details in Verification tab";
                    dipstatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    dipstatus.Text = "Diploma Details Not Filled";
                    dipstatus.ForeColor = System.Drawing.Color.Blue;
                    dipdis(false);
                }
                if (AHRMS1.usae.specupload.getstatus(uniqueid, "spcheckgrad"))
                {
                    CheckBox3.Enabled = false;
                    graddis(false);
                    gradstatus.Text = "Gradution Details saved, Verify details in Verification tab";
                    gradstatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    gradstatus.Text = "Gradution Details Not Filled";
                    gradstatus.ForeColor = System.Drawing.Color.Blue;
                    graddis(false);
                }
                if (AHRMS1.usae.specupload.getstatus(uniqueid, "spcheckpg"))
                {
                    CheckBox4.Enabled = false;
                    pgdis(false);
                    pgstatus.Text = "Post Gradution Details saved, Verify details in Verification tab";
                    pgstatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    pgstatus.Text = "Post Gradution Details Not Filled";
                    pgstatus.ForeColor = System.Drawing.Color.Blue;
                    pgdis(false);
                }
            }
        }
        public void sslcdis(bool ss)
        {
            schoolname.Enabled = ss;
            locationschool.Enabled = ss;
            yearcompleted.Enabled = ss;
            boardsslc.Enabled = ss;
            Persslc.Enabled = ss;
            gradesslc.Enabled = ss;


            RequiredFieldValidator19.Enabled = ss;
            RequiredFieldValidator20.Enabled = ss;
            RequiredFieldValidator21.Enabled = ss;
            RequiredFieldValidator22.Enabled = ss;
            RequiredFieldValidator23.Enabled = ss;
            RangeValidator1.Enabled = ss;   

        }
        public void pudis(bool ss)
        {
            pucollegename.Enabled = ss;
            pulocation.Enabled = ss;
            puyearcompleted.Enabled = ss;
            puboard.Enabled = ss;
            perpu.Enabled = ss;
            gradepu.Enabled = ss;

            RequiredFieldValidator24.Enabled = ss;
            RequiredFieldValidator25.Enabled = ss;
            RequiredFieldValidator26.Enabled = ss;
            RequiredFieldValidator27.Enabled = ss;
            RequiredFieldValidator28.Enabled = ss;
            RangeValidator2.Enabled = ss;


        }
        public void dipdis(bool ss)
        {
            dipcollegename.Enabled = ss;
            diplomaboard.Enabled = ss;
            diplomaendmonth.Enabled = ss;
            diplomaendyear.Enabled = ss;
            diplomaspec.Enabled = ss;
            diplomastartmonth.Enabled = ss;
            diplomastartyear.Enabled = ss;
            diplomauniregnum.Enabled = ss;
            universitynamediploma.Enabled = ss;
            perdiploma.Enabled = ss;
            gradediploma.Enabled = ss;
            coursetypediploma.Enabled = ss;

            RequiredFieldValidator29.Enabled = ss;
            RequiredFieldValidator30.Enabled = ss;
            RequiredFieldValidator31.Enabled = ss;
            RequiredFieldValidator1.Enabled = ss;
            RequiredFieldValidator2.Enabled = ss;
            RequiredFieldValidator3.Enabled = ss;
            RequiredFieldValidator4.Enabled = ss;
            RequiredFieldValidator5.Enabled = ss;
            RequiredFieldValidator6.Enabled = ss;
            RangeValidator3.Enabled = ss;
            RequiredFieldValidator40.Enabled = ss;

        }
        public void graddis(bool ss)
        {
            gradcoursetype.Enabled = ss;
            gradcollegename.Enabled = ss;
            gradendmonth.Enabled = ss;
            gradendyear.Enabled = ss;
            gradgrade.Enabled = ss;
            gradstartmonth.Enabled = ss;
            gradstartyear.Enabled = ss;
            graduniname.Enabled = ss;
            graduniregnum.Enabled = ss;
            gradspec.Enabled = ss;
            graddegree1.Enabled = ss;
            gradperc.Enabled = ss;

            RequiredFieldValidator38.Enabled = ss;
            RequiredFieldValidator32.Enabled = ss;
            RequiredFieldValidator33.Enabled = ss;
            RequiredFieldValidator7.Enabled = ss;
            RequiredFieldValidator8.Enabled = ss;
            RequiredFieldValidator9.Enabled = ss;
            RequiredFieldValidator10.Enabled = ss;
            RequiredFieldValidator11.Enabled = ss;
            RequiredFieldValidator12.Enabled = ss;
            RequiredFieldValidator34.Enabled = ss;
            RangeValidator4.Enabled = ss;
        }
        public void pgdis(bool ss)
        {
            pgcollegename.Enabled = ss;
            pgcoursetype.Enabled = ss;
            pgendmonth.Enabled = ss;
            pgendyear.Enabled = ss;
            pggrade.Enabled = ss;
            pgpercentage.Enabled = ss;
            pgregnum.Enabled = ss;
            pgspec.Enabled = ss;
            pgstartmonth.Enabled = ss;
            pgstartyear.Enabled = ss;
            pguniname.Enabled = ss;
            pgdegree1.Enabled = ss;


            RequiredFieldValidator39.Enabled = ss;
            RequiredFieldValidator35.Enabled = ss;
            RequiredFieldValidator36.Enabled = ss;
            RequiredFieldValidator13.Enabled = ss;
            RequiredFieldValidator14.Enabled = ss;
            RequiredFieldValidator15.Enabled = ss;
            RequiredFieldValidator16.Enabled = ss;
            RequiredFieldValidator17.Enabled = ss;
            RequiredFieldValidator18.Enabled = ss;
            RequiredFieldValidator37.Enabled = ss;
            RangeValidator5.Enabled = ss;

        }

        public Int32 getuniid()
        {
            try
            {

                string lun1 = Session["userid"].ToString();
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
                Response.Redirect("~/error.aspx", true);
                return 0;
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool ss = CheckBox1.Checked;
            if (ss)
            {
                sslcdis(true);
            }
            else
            {
                sslcdis(false);
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            bool ss = CheckBox2.Checked;
            if (ss)
            {
                pudis(ss);
            }
            else
            {
                pudis(ss);
            }

        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            bool ss = CheckBox3.Checked;
            if (ss)
            {
                graddis(ss);
            }
            else
            {
                graddis(ss);
            }
        }

        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            bool ss = CheckBox4.Checked;
            if (ss)
            {
                pgdis(ss);
            }
            else
            {
                pgdis(ss);
            }

        }
        protected void chkdiploma_CheckedChanged(object sender, EventArgs e)
        {
            bool ss = chkdiploma.Checked;
            if (ss)
            {
                dipdis(ss);
            }
            else
            {
                dipdis(ss);
            }
        }

        
        public bool getparsslcpuc(Int32 uni, string sc, Int32 yc, string sb, Decimal per, string loc, string grade, string spname,out Int32 id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uni", uni);
                cmd.Parameters.AddWithValue("@schoolname", sc);
                cmd.Parameters.AddWithValue("@loc", loc);
                cmd.Parameters.AddWithValue("@yc", yc);
                cmd.Parameters.AddWithValue("@sslcboard", sb);
                cmd.Parameters.AddWithValue("@per", per);
                cmd.Parameters["@per"].Precision = 18;
                cmd.Parameters["@per"].Scale = 3;
                cmd.Parameters.AddWithValue("@grade", grade);
                SqlParameter idd = new SqlParameter("@Newid", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(idd);

                con.Open();
                cmd.ExecuteScalar();

                Int32 value = Convert.ToInt32(idd.Value);
                if (value != 0)
                {
                    id = value;
                    return true;
                }
                else
                {
                    id = 0;
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
                id = 0;
                return false;
            }
        }
        public bool getpardipgradpg(Int32 un, Int32 ct, string una, string cn, string bd, Int32 sp, string unireg, string sd, string ed, Decimal p, string grad1, string spname,out Int32 ids)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@uni", un);
                cmd.Parameters.AddWithValue("@ct", ct);
                cmd.Parameters.AddWithValue("@uniname", una);
                cmd.Parameters.AddWithValue("@collegename", cn);
                cmd.Parameters.AddWithValue("@board", bd);
                cmd.Parameters.AddWithValue("@spe", sp);
                cmd.Parameters.AddWithValue("@unireg", unireg);
                cmd.Parameters.AddWithValue("@startdate", sd);
                cmd.Parameters.AddWithValue("@enddate", ed);
                cmd.Parameters.AddWithValue("@per", p);
                cmd.Parameters["@per"].Precision = 18;
                cmd.Parameters["@per"].Scale = 3;
                cmd.Parameters.AddWithValue("@grade", grad1);
                SqlParameter idd = new SqlParameter("@id", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(idd);
                con.Open();
                cmd.ExecuteScalar();
                Int32 sdd = Convert.ToInt32(idd.Value);
                if (sdd != null)
                {
                    ids = sdd;
                    return true;
                }
                else
                {
                    ids = 0;
                    return false;
                }
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sdww = db.HResult.ToString();
                errorlog(ss, sw, sdww);
                Response.Redirect("~/error.aspx", true);
                ids = 0;
                return false;
            }
        }
        public bool getpardipgradpg1(Int32 un, Int32 ct, string una,string degree, string cn, Int32 sp, string unireg, string sd, string ed, Decimal p, string grad1, string spname,out Int32 id3)
        {
             try
            {
            string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(spname, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@uni",un);
            cmd.Parameters.AddWithValue("@ct", ct);
            cmd.Parameters.AddWithValue("@degree", degree);
            cmd.Parameters.AddWithValue("@uniname", una);
            cmd.Parameters.AddWithValue("@collegename", cn);
            cmd.Parameters.AddWithValue("@spe", sp);
            cmd.Parameters.AddWithValue("@unireg", unireg);
            cmd.Parameters.AddWithValue("@startdate", sd);
            cmd.Parameters.AddWithValue("@enddate", ed);
          
            cmd.Parameters.AddWithValue("@per", p);
            cmd.Parameters["@per"].Precision = 18;
            cmd.Parameters["@per"].Scale = 3;
            cmd.Parameters.AddWithValue("@grade", grad1);
            SqlParameter idd = new SqlParameter("@Newid", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(idd);
                con.Open();
                cmd.ExecuteScalar();
                Int32 ssdsd = Convert.ToInt32(idd.Value);
                 if (ssdsd != 0)
                {
                    id3 = ssdsd;
                    return true;
                }
                else
                {
                    id3 = 0;
                    return false;
                }
             }
                catch (Exception db)
                 {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sdww = db.HResult.ToString();
                errorlog(ss, sw, sdww);
                Response.Redirect("~/error.aspx", true);
                id3 = 0;
                    return false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(7000);
            bool sslc = CheckBox1.Checked;
            bool puc = CheckBox2.Checked;
            bool dip = chkdiploma.Checked;
            bool gard = CheckBox3.Checked;
            bool pg = CheckBox4.Checked;
            Int32 uniqueid = getuniid();
            if (sslc)
            {
                Int32 id;
                bool par = getparsslcpuc(uniqueid, schoolname.Text.ToString(), Convert.ToInt32(yearcompleted.SelectedValue), boardsslc.Text.ToString(), Convert.ToDecimal(Persslc.Text), locationschool.Text.ToString(), gradesslc.Text.ToString(), "spinsertsslc",out id);
                if (par)
                {
                    sslcdis(false);
                    CheckBox1.Enabled = false;
                    sslcstatus.Text = "10th Details saved, Verify details in Verification tab";
                    sslcstatus.ForeColor = System.Drawing.Color.Green;
                    insertverdetailsstatus(id, "insertsslcver");
                }
                else
                {
                    sslcstatus.Text = "10th Details not saved, Verify details in Verification tab";
                    sslcstatus.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                sslcstatus.Text = "Verify details in Verification tab";
                sslcstatus.ForeColor = System.Drawing.Color.Blue;
            }
            if (puc)
            {
                Int32 id1;
                bool par = getparsslcpuc(uniqueid, pucollegename.Text.ToString(), Convert.ToInt32(puyearcompleted.SelectedValue), puboard.Text.ToString(), Convert.ToDecimal(perpu.Text), pulocation.Text.ToString(), gradepu.Text.ToString(), "spinsertpuc",out id1);
                if (par)
                {
                    pudis(false);
                    CheckBox2.Enabled = false;
                    pucstatus.Text = "PUC Details saved, Verify details in Verification tab";
                    pucstatus.ForeColor = System.Drawing.Color.Green;
                    insertverdetailsstatus(id1, "insertpucver");
                }
                else
                {
                    pucstatus.Text = "PUC Details not saved, Verify details in Verification tab";
                    pucstatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                pucstatus.Text = "Verify details in Verification tab";
                pucstatus.ForeColor = System.Drawing.Color.Blue;
            }
            if (dip)
            {
                Int32 id2;
                string startdate = diplomastartmonth.SelectedValue.ToString() + "/" + diplomastartyear.SelectedValue.ToString();
                string endate = diplomaendmonth.SelectedItem.Text.ToString() + "/" + diplomaendyear.SelectedValue.ToString();
                bool par = getpardipgradpg(uniqueid, Convert.ToInt32(coursetypediploma.SelectedValue), universitynamediploma.Text.ToString(), dipcollegename.Text.ToString(), diplomaboard.Text.ToString(), Convert.ToInt32(diplomaspec.SelectedValue), diplomauniregnum.Text.ToString(), startdate, endate, Convert.ToDecimal(perdiploma.Text), gradediploma.Text.ToString(), "spinsertdip",out id2);
                if (par)
                {
                    dipdis(false);
                    chkdiploma.Enabled = false;
                    dipstatus.Text = "Diploma Details saved, Verify details in Verification tab";
                    dipstatus.ForeColor = System.Drawing.Color.Green;
                    insertverdetailsstatus(id2, "insertdipver");

                }
                else
                {
                    dipstatus.Text = "Diploma Details not saved, Verify details in Verification tab";
                    dipstatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                dipstatus.Text = "Verify details in Verification tab";
                dipstatus.ForeColor = System.Drawing.Color.Blue;
            }
            if (gard)
            {
                Int32 id4;
                string startdate = gradstartmonth.SelectedValue.ToString() + "/" + gradstartyear.SelectedValue.ToString();
                string enddate = gradendmonth.SelectedValue.ToString() + "/" + gradendyear.SelectedValue.ToString();
                bool par = getpardipgradpg1(uniqueid, Convert.ToInt32(gradcoursetype.SelectedValue), graduniname.Text.ToString(),graddegree1.SelectedValue.ToString(), gradcollegename.Text.ToString(), Convert.ToInt32(gradspec.SelectedValue), graduniregnum.Text.ToString(), startdate, enddate, Convert.ToDecimal(gradperc.Text), gradgrade.Text.ToString(), "spinsertgrad",out id4);
                if (par)
                {
                    graddis(false);
                    CheckBox3.Enabled = false;
                    gradstatus.Text = "Gradution Details saved, Verify details in Verification tab";
                    gradstatus.ForeColor = System.Drawing.Color.Green;
                    insertverdetailsstatus(id4, "insertgradver");
                }
                else
                {
                    gradstatus.Text = "Gradution Details not saved, Verify details in Verification tab";
                    gradstatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                gradstatus.Text = "Verify details in Verification tab";
                gradstatus.ForeColor = System.Drawing.Color.Blue;
            }
            if (pg)
            {
                Int32 id5;
                string startdate = pgstartmonth.SelectedValue.ToString() + "/" + pgstartyear.SelectedValue.ToString();
                string enddate = pgendmonth.SelectedValue.ToString() + "/" + pgendyear.SelectedValue.ToString();
                bool par = getpardipgradpg1(uniqueid, Convert.ToInt32(pgcoursetype.SelectedValue), pguniname.Text.ToString(), pgdegree1.SelectedValue.ToString(), pgcollegename.Text.ToString(), Convert.ToInt32(pgspec.SelectedValue), pgregnum.Text.ToString(), startdate, enddate, Convert.ToDecimal(pgpercentage.Text), pggrade.Text.ToString(), "spinsertpg", out id5);
                if (par)
                {
                    pgdis(false);
                    CheckBox4.Enabled = false;
                    pgstatus.Text = "Post Gradution Details saved, Verify details in Verification tab";
                    pgstatus.ForeColor = System.Drawing.Color.Green;
                    insertverdetailsstatus(id5, "insertpgver");
                }
                else
                {
                    pgstatus.Text = "post gardution Details not saved, Verify details in Verification tab";
                    pgstatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                pgstatus.Text = "Verify details in Verification tab";
                pgstatus.ForeColor = System.Drawing.Color.Blue;
            }
        }



        public void insertverdetailsstatus(Int32 uid, string spname)
        {
            try
            {
                    string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(cs);
                    SqlCommand cmd = new SqlCommand(spname, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ui", uid);
                cmd.Parameters.AddWithValue("@ver", "2");
                cmd.Parameters.AddWithValue("@verby", "Not Viewed by any Employer to verify");
                cmd.Parameters.AddWithValue("@com", "Not Available");

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int ss = dr.RecordsAffected;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sdww = db.HResult.ToString();
                errorlog(ss, sw, sdww);
                Response.Redirect("~/error.aspx", true);
            }

        }


        private DataSet getyear(string spname, SqlParameter sparameter)
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

        protected void gradstartyear_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 ss = Convert.ToInt32(gradstartyear.SelectedValue)+3;

            gradendyear.DataSource = getendyear("getendyear", ss, null);
            gradendyear.DataBind();
            ListItem li = new ListItem("Select Year", "-1");
            gradendyear.Items.Insert(0, li);
            gradendyear.Enabled = true;

        }

        private DataSet getendyear(string spname,Int32 ui, SqlParameter sparameter)
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
                da.SelectCommand.Parameters.AddWithValue("@ui", ui);
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

        protected void pgstartyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 ss = Convert.ToInt32(pgstartyear.SelectedValue);
            pgendyear.DataSource = getendyear("getendyear", ss, null);
            pgendyear.DataBind();
            ListItem li = new ListItem("Select Year", "-1");
            pgendyear.Items.Insert(0, li);
            pgendyear.Enabled = true;

        }
        protected void dip_details(object sender, EventArgs e)
        {
            Int32 ss = Convert.ToInt32(diplomastartyear.SelectedValue);
            diplomaendyear.DataSource = getendyear("getendyear", ss, null);
            diplomaendyear.DataBind();
            ListItem li = new ListItem("Select Year", "-1");
            diplomaendyear.Items.Insert(0, li);
            diplomaendyear.Enabled = true;

        }

        protected void yearcompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 ss = Convert.ToInt32(yearcompleted.SelectedValue);
            puyearcompleted.DataSource = getendyear("getendyear", ss, null);
            puyearcompleted.DataBind();
            ListItem li = new ListItem("Select year", "-1");
            puyearcompleted.Items.Insert(0, li);

        }

        protected void puyearcompleted_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 ss = Convert.ToInt32(puyearcompleted.SelectedValue);
            diplomastartyear.DataSource = getendyear("getendyear", ss, null);
            diplomastartyear.DataBind();
            ListItem li = new ListItem("Select year", "-1");
            diplomastartyear.Items.Insert(0,li);
            gradstartyear.DataSource = getendyear("getendyear", ss, null);
            gradstartyear.DataBind();
            gradstartyear.Items.Insert(0, li);
            pgstartyear.DataSource = getendyear("getendyear", ss, null);
            pgstartyear.DataBind();
            pgstartyear.Items.Insert(0, li);
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count)
        {

            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("getuniname", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@par", "%" + prefixText + "%");
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
             
            dt = ds.Tables[0];
            List<string> txtItems = new List<string>();
            string dbValues;

            foreach (DataRow row in dt.Rows)
            {
                dbValues = row["name"].ToString();
                dbValues = dbValues.ToUpper();
                txtItems.Add(dbValues);
            }
            return txtItems.ToArray();

        }
        catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
               AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
            HttpContext.Current.Response.Redirect("~/error.aspx", true);
                string[] ds1 = { "0", "1"};
                return ds1;
            }
        
        }


    }
}