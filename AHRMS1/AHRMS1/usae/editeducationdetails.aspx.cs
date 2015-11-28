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


namespace AHRMS1
{
    public partial class editeducationdetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("~/ms/access.aspx", true);
                }

                Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
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

                diplomaendyear.DataSource = getyear("getyear", null);
                diplomaendyear.DataBind();
                gradendyear.DataSource = getyear("getyear", null);
                gradendyear.DataBind();
                pgendyear.DataSource = getyear("getyear", null);
                pgendyear.DataBind();

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
                pgspec.Items.Insert(0, li);
                graddegree1.DataSource = getyear("degree", null);
                graddegree1.DataBind();
                ListItem li1 = new ListItem("Select Degree", "-1");
                graddegree1.Items.Insert(0, li1);
                pgdegree1.DataSource = getyear("degree", null);
                pgdegree1.DataBind();
                pgdegree1.Items.Insert(0, li1);


                string ssbb, slocc, sycc, ssbbb, sperr, sgradee;
                string pn, ploc, pyc, pb, pper, pgrade;
                bool sslc = AHRMS1.ms.WebForm2.getsslcdetailsview(uniqueid, "spgetsslcdetailsview", out ssbb, out slocc, out sycc, out ssbbb, out sperr, out sgradee);
                if (sslc)
                {
                    schoolname.Text = ssbb;
                    locationschool.Text = slocc;
                    yearcompleted.SelectedValue = sycc;
                    boardsslc.Text = ssbbb;
                    Persslc.Text = sperr;
                    gradesslc.Text = sgradee;
                }
                else
                {
                    updatesslc.Enabled = false;
                    sucesssslc.Text = "Not Entered details to Edit";
                 }
                bool puc = AHRMS1.ms.WebForm2.getsslcdetailsview(uniqueid, "spgetpucdetailsview", out pn, out ploc, out pyc, out pb, out pper, out pgrade);
                if (puc)
                {
                    pucollegename.Text = pn;
                    pulocation.Text = ploc;
                    puyearcompleted.SelectedValue = pyc;
                    puboard.Text = pb;
                    perpu.Text = pper;
                    gradepu.Text = pgrade;
                }
                else
                {
                    btnsuccesspu.Enabled = false;
                    successpu.Text = "Not Entered details to Edit";
                }
                string duni, dcn, db, dureg, dsd, ded, dper, dgade;
                Int32 dct, dspc;
                bool diploma = AHRMS1.ms.WebForm2.getdetails(uniqueid, "spgetdiplomadetailsview", out dct, out duni, out dcn, out db, out dspc, out dureg, out dsd, out ded, out dper, out dgade);
                if (diploma)
                {

                    coursetypediploma.SelectedValue = dct.ToString();
                    universitynamediploma.Text = duni;
                    diplomaboard.Text = db;
                    dipcollegename.Text = dcn;
                    diplomaspec.SelectedValue = dspc.ToString();
                    diplomauniregnum.Text = dureg;
                    diplomastartmonth.SelectedValue = dsd.Split('/')[0];
                    diplomastartyear.SelectedValue = dsd.Split('/')[1];
                    diplomaendyear.SelectedValue = ded.Split('/')[1];
                    diplomaendmonth.SelectedValue = ded.Split('/')[0];
                    perdiploma.Text = dper;
                    gradediploma.Text = dgade;
                }
                else
                {
                    btnupdatediploma.Enabled = false;
                    lblsuccessdiploma.Text = "Not Entered details to Edit";
                }
                Int32 gct, gspc;
                string gdeg, guni, gcn, gureg, gdsd, gded, gdper, ggrade;
                bool Degree = AHRMS1.ms.WebForm2.getdetails1(uniqueid, "spgetdegreedetailsview", out gct, out gdeg, out guni, out gcn, out gspc, out gureg, out gdsd, out gded, out gdper, out ggrade);
                if (Degree)
                {


                    gradcoursetype.SelectedValue = gct.ToString();
                    graddegree1.SelectedValue = gdeg.ToString();
                    graduniname.Text = guni.ToString();
                    gradcollegename.Text = gcn.ToString();
                    gradspec.SelectedValue = gspc.ToString();
                    graduniregnum.Text = gureg.ToString();
                    gradstartmonth.SelectedValue = gdsd.Split('/')[0];
                    gradstartyear.SelectedValue = gdsd.Split('/')[1];
                    gradendmonth.SelectedValue = gded.Split('/')[0];
                    gradendyear.SelectedValue = gded.Split('/')[1];
                    gradperc.Text = gdper.ToString();
                    gradgrade.Text = ggrade.ToString();

                }
                else
                {
                    btngradeupdate.Enabled = false;
                    lblsucessgrade.Text = "Not Entered details to Edit";
                }
                Int32 pgct, pgspc;
                string pgdeg, pguni, pgcn, pgureg, pgdsd, pgded, pgdper, pggrade;
                bool pg = AHRMS1.ms.WebForm2.getdetails1(uniqueid, "spgetpgdetailsview", out pgct, out pgdeg, out pguni, out pgcn, out pgspc, out pgureg, out pgdsd, out pgded, out pgdper, out pggrade);
                if (pg)
                {

                    pgcoursetype.SelectedValue = pgct.ToString();
                    pgdegree1.SelectedValue = pgdeg.ToString();
                    pguniname.Text = pguni.ToString();
                    pgcollegename.Text = pgcn.ToString();
                    pgspec.SelectedValue = pgspc.ToString();
                    pgregnum.Text = pgureg.ToString();
                    pgstartmonth.SelectedValue = pgdsd.Split('/')[0];
                    pgstartyear.SelectedValue = pgdsd.Split('/')[1];
                    pgendmonth.SelectedValue = pgded.Split('/')[0];
                    pgendyear.SelectedValue = pgded.Split('/')[1];
                    pgpercentage.Text = pgdper.ToString();
                    pggrade1.Text = pggrade.ToString();

                }
                else
                {
                    btnpgupdate.Enabled = false;
                    lblpgsucess.Text = "Not Entered details to Edit";
                }

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
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                DataSet ds = new DataSet();
                return ds;
            }
        }

        protected void updatesslc_Click(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(7000);
            Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
            bool ss = updatepucsslc(uniqueid, "updatesslcdeatils", schoolname.Text.ToString(), locationschool.Text.ToString(), Convert.ToInt32(yearcompleted.SelectedValue), boardsslc.Text.ToString(),Convert.ToDecimal(Persslc.Text), gradesslc.Text.ToString());
            if (ss)
            {
                sucesssslc.Text = "SSLC Details Successfully Updated";
                sucesssslc.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                sucesssslc.Text = "Something Went Wrong!!";
                sucesssslc.ForeColor = System.Drawing.Color.Red;
            }
        }
        public bool updatepucsslc(Int32 uni, string spname,string sc,string loc,Int32 yc,string bo,decimal dd,string grd)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uni);
                cmd.Parameters.AddWithValue("@scn", sc);
                cmd.Parameters.AddWithValue("@loc", loc);
                cmd.Parameters.AddWithValue("@yc", yc);
                cmd.Parameters.AddWithValue("@bo", bo);
                cmd.Parameters.AddWithValue("@per", dd);
                cmd.Parameters["@per"].Precision = 18;
                cmd.Parameters["@per"].Scale = 3;
                cmd.Parameters.AddWithValue("@grade", grd);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.RecordsAffected == 1)
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
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return false;
            }
        }

        protected void btnsuccesspu_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(7000);
            Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
            bool ss = updatepucsslc(uniqueid, "updatepucdeatils",pucollegename.Text.ToString(),pulocation.Text.ToString(),Convert.ToInt32(puyearcompleted.SelectedValue),puboard.Text.ToString(),Convert.ToDecimal(perpu.Text),gradepu.Text.ToString());
            if (ss)
            {
                successpu.Text = "PUC/12th Details Successfully Updated";
                successpu.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                successpu.Text = "Something Went Wrong!!";
                successpu.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void btn_dip(object sender, EventArgs e)
        {
            Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
            bool ss = updatedip(uniqueid, "updatepucdeatils");
            if (ss)
            {
                lblsuccessdiploma.Text = "Diploma Details Successfully Updated";
                lblsuccessdiploma.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblsuccessdiploma.Text = "Something Went Wrong!!";
                lblsuccessdiploma.ForeColor = System.Drawing.Color.Red;
            }
        }
        public bool updatedip(Int32 uni, string spname)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uni);
                cmd.Parameters.AddWithValue("@ct", Convert.ToInt32(coursetypediploma.SelectedValue));
                cmd.Parameters.AddWithValue("@uniname", universitynamediploma.Text.ToString());
                cmd.Parameters.AddWithValue("@scn", schoolname.Text.ToString());
                cmd.Parameters.AddWithValue("@sp", Convert.ToInt32(diplomaspec.SelectedValue));
                cmd.Parameters.AddWithValue("@sd",diplomastartmonth.SelectedValue.ToString()+"/"+diplomastartyear.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@ed", diplomaendmonth.SelectedValue.ToString() + "/" + diplomaendyear.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@unireg", diplomauniregnum.Text.ToString());
                cmd.Parameters.AddWithValue("@bo", diplomaboard.Text.ToString());
                cmd.Parameters.AddWithValue("@per", Persslc.Text.ToString());
                cmd.Parameters.AddWithValue("@grade", gradesslc.Text.ToString());

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.RecordsAffected == 1)
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
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return false;
            }
        }

        protected void btngradeupdate_Click(object sender, EventArgs e)
        {
            Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
            bool ss = updategradpg(uniqueid, "updategraddeatils", Convert.ToInt32(gradcoursetype.SelectedValue), Convert.ToInt32(graddegree1.SelectedValue), graduniname.Text.ToString(), gradcollegename.Text.ToString(), Convert.ToInt32(gradspec.SelectedValue), gradstartmonth.SelectedValue.ToString() + "/" + gradstartyear.SelectedValue.ToString(), gradendmonth.SelectedValue.ToString() + "/" + gradendyear.SelectedValue.ToString(), graduniregnum.Text.ToString(), Convert.ToDecimal(gradperc.Text), gradgrade.Text.ToString());
            if (ss)
            {
                lblsucessgrade.Text = "Gradution Details Successfully Updated";
                lblsucessgrade.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblsucessgrade.Text = "Something Went Wrong!!";
                lblsucessgrade.ForeColor = System.Drawing.Color.Red;
            }

        }
        public bool updategradpg(Int32 uni, string spname,Int32 ct,Int32 dg,string uniname,string cn,Int32 sp,string sd,string ed,string ureg,Decimal per,string gr)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uni);
                cmd.Parameters.AddWithValue("@ct", ct);
                cmd.Parameters.AddWithValue("@Degree", dg);
                cmd.Parameters.AddWithValue("@uniname", uniname);
                cmd.Parameters.AddWithValue("@scn", cn);
                cmd.Parameters.AddWithValue("@sp", sp);
                cmd.Parameters.AddWithValue("@sd",sd);
                cmd.Parameters.AddWithValue("@ed", ed);
                cmd.Parameters.AddWithValue("@unireg", ureg);
                cmd.Parameters.AddWithValue("@per", per);
                cmd.Parameters["@per"].Precision = 18;
                cmd.Parameters["@per"].Scale = 3;
                cmd.Parameters.AddWithValue("@grade", gr);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.RecordsAffected == 1)
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
                string sddd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sddd);
                Response.Redirect("~/error.aspx", true);
                return false;
            }
        }

        protected void btnpgupdate_Click(object sender, EventArgs e)
        {
            Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
            bool ss = updategradpg(uniqueid, "updatepgdeatils", Convert.ToInt32(pgcoursetype.SelectedValue), Convert.ToInt32(pgdegree1.SelectedValue), pguniname.Text.ToString(), pgcollegename.Text.ToString(), Convert.ToInt32(pgspec.SelectedValue), pgstartmonth.SelectedValue.ToString() + "/" + pgstartyear.SelectedValue.ToString(), pgendmonth.SelectedValue.ToString() + "/" + pgendyear.SelectedValue.ToString(), pgregnum.Text.ToString(), Convert.ToDecimal(pgpercentage.Text), pggrade1.Text.ToString());
            if (ss)
            {
                lblpgsucess.Text = "Post Gradution Details Successfully Updated";
                lblpgsucess.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblpgsucess.Text = "Something Went Wrong!!";
                lblpgsucess.ForeColor = System.Drawing.Color.Red;
            }

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
                string[] ds1 = { "0", "1" };
                return ds1;
            }

        }

    }
}