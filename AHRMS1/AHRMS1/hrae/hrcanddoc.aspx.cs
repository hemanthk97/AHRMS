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

namespace AHRMS1.ms
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloadid);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloadadd);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloadsslc);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloadpu);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloaddiploma);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloadgraduation);
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.downloadpost);              
                hrviewcanddel.Visible = false;
                viewnot.Visible = false;
            if (IsPostBack)
            {

                lblviewdelsuccessstate.Text = "";
                }   
        }
             public bool getverdetails(Int32 uni, String spname, out  Int32 ve, out string verb, out string verc)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ui", uni);
                SqlParameter verfi = new SqlParameter("@ver", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter verby = new SqlParameter("@verby", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter comm = new SqlParameter("@vercomm", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(verfi);
                cmd.Parameters.Add(verby);
                cmd.Parameters.Add(comm);

                con.Open();
                cmd.ExecuteNonQuery();
                try
                {
                    ve = Convert.ToInt32(verfi.Value);
                    verb = verby.Value.ToString();
                    verc = comm.Value.ToString();
                    return true;
                }
                catch
                {
                    ve = 0;
                    verb = "not available";
                    verc = "not available";
                    return false;

                }
            }
            catch (Exception dbb)
            {
                string ss = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                ve = 0;
                verb = " ";
                verc = " ";
                return false;

            }

        }





        public bool spgetstatusofdetails(Int32 uni, string spname, out Int32 unidspc)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uni);
                SqlParameter ui = new SqlParameter("@ui", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(ui);
                con.Open();
                cmd.ExecuteReader();
                string ss = ui.Value.ToString();
                if (ss == "")
                {
                    unidspc = 0;
                    return false;
                }
                else
                {
                    unidspc = Convert.ToInt32(ui.Value);
                    return true;
                }
            }
            catch (Exception dbb)
            {
                string ss = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                unidspc = 0;
                return false;
            }

        }






        public static bool getdetails(int un, string spname, out Int32 dct, out string duni, out string dcn, out string db, out Int32 dspc, out string dureg, out string dsd, out string ded, out string dper, out string dgrade)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", un);
                SqlParameter ct = new SqlParameter("@ct", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter uname = new SqlParameter("@un", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter cname = new SqlParameter("@cn", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter board = new SqlParameter("@db", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter special = new SqlParameter("@spec", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter regnum = new SqlParameter("@unireg", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter sd = new SqlParameter("@sd", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter ed = new SqlParameter("@ed", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter per = new SqlParameter("@per", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                per.Precision = 18;
                per.Scale = 3;
                SqlParameter grade = new SqlParameter("@grade", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(ct);
                cmd.Parameters.Add(uname);
                cmd.Parameters.Add(cname);
                cmd.Parameters.Add(board);
                cmd.Parameters.Add(special);
                cmd.Parameters.Add(regnum);
                cmd.Parameters.Add(sd);
                cmd.Parameters.Add(ed);
                cmd.Parameters.Add(per);
                cmd.Parameters.Add(grade);

                con.Open();
                cmd.ExecuteNonQuery();
                try
                {
                    dct = Convert.ToInt32(ct.Value);
                    duni = uname.Value.ToString();
                    dcn = cname.Value.ToString();
                    db = board.Value.ToString();
                    dspc = Convert.ToInt32(special.Value);
                    dureg = regnum.Value.ToString();
                    dsd = sd.Value.ToString();
                    ded = ed.Value.ToString();
                    dper = per.Value.ToString();
                    dgrade = grade.Value.ToString();
                    return true;
                }
                catch
                {
                    dct = 0;
                    duni = "Not Available";
                    dcn = "Not Available";
                    db = "Not Available";
                    dspc = 0;
                    dureg = "Not Available";
                    dsd = "Not Available";
                    ded = "Not Available";
                    dper = "Not Available";
                    dgrade = "Not Available";
                    return false;
                }

            }
            catch (Exception dbb)
            {
                string ss = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                dct = 0;
                duni = null;
                dcn = null;
                db = null;
                dspc = 0;
                dureg = null;
                dsd = null;
                ded = null;
                dper = null;
                dgrade = null;
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;

            }
        }
        public void getvaluepersonaldetails(Int32 un)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("spgetpersonadetail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", un);
                SqlParameter fn = new SqlParameter("@fn", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter mn = new SqlParameter("@mn", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter ln = new SqlParameter("@ln", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter gn = new SqlParameter("@gn", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter date = new SqlParameter("@date", SqlDbType.Date) { Direction = ParameterDirection.Output };
                SqlParameter gen = new SqlParameter("@gender", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter stateid = new SqlParameter("@state", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter cityid = new SqlParameter("@city", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter pin = new SqlParameter("@pin", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter add = new SqlParameter("@add", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output };
                SqlParameter cont = new SqlParameter("@contactnum", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };


                cmd.Parameters.Add(fn);
                cmd.Parameters.Add(mn);
                cmd.Parameters.Add(ln);
                cmd.Parameters.Add(gn);
                cmd.Parameters.Add(date);
                cmd.Parameters.Add(gen);
                cmd.Parameters.Add(stateid);
                cmd.Parameters.Add(cityid);
                cmd.Parameters.Add(pin);
                cmd.Parameters.Add(add);
                cmd.Parameters.Add(cont);


                con.Open();
                cmd.ExecuteNonQuery();

                try
                {

                    lblnameview.Text = fn.Value.ToString() + " " + mn.Value.ToString() + " " + ln.Value.ToString();
                    lblfathernameview.Text = gn.Value.ToString();
                    lbldobmonthview.Text = date.Value.ToString().Remove(10, 9);
                    if (Convert.ToInt32(gen.Value) == 1)
                    {
                        lblgenderview.Text = "Male";

                    }
                    else
                    {
                        lblgenderview.Text = "Female";

                    }
                    lblstateview.Text = getstatename(Convert.ToInt32(stateid.Value), "getstatenameview");
                    lblcityview.Text = getstatename(Convert.ToInt32(cityid.Value), "getcitynameview");
                    lblpincodeview.Text = pin.Value.ToString();
                    lbladdressview.Text = add.Value.ToString();
                    lblcontactview.Text = cont.Value.ToString();

                }
                catch
                {

                    lblnameview.Text = "Not Available";
                    lblfathernameview.Text = "Not Available";
                    lbldobmonthview.Text = "Not Available";
                    lblgenderview.Text = "Not Available";
                    lblgenderview.Text = "Not Available";
                    lblstateview.Text = "Not Available";
                    lblcityview.Text = "Not Available";
                    lblpincodeview.Text = "Not Available";
                    lbladdressview.Text = "Not Available";
                    lblcontactview.Text = "Not Available";
                }
            }


            catch (Exception db)
            {
                string ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string su = db.Data.ToString();

                string sd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);

            }

        }
        public static bool getsslcdetailsview(int un, string spname, out string scn, out string sloc, out string syc, out string ssb, out string sper, out string sgrade)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", un);
                SqlParameter sn = new SqlParameter("@sn", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter loc = new SqlParameter("@loc", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter yc = new SqlParameter("@yc", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter sb = new SqlParameter("@sb", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter per = new SqlParameter("@per", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                per.Precision = 18;
                per.Scale = 3;
                SqlParameter grade = new SqlParameter("@grade", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(sn);
                cmd.Parameters.Add(loc);
                cmd.Parameters.Add(yc);
                cmd.Parameters.Add(sb);
                cmd.Parameters.Add(per);
                cmd.Parameters.Add(grade);
                con.Open();
                cmd.ExecuteNonQuery();

                try
                {
                    scn = sn.Value.ToString();
                    sloc = loc.Value.ToString();
                    syc = yc.Value.ToString();
                    ssb = sb.Value.ToString();
                    sper = per.Value.ToString();
                    sgrade = grade.Value.ToString();
                    return true;
                }
                catch
                {
                    scn = "Not Available";
                    sloc = "Not Available";
                    syc = "Not Available";
                    ssb = "Not Available";
                    sper = "Not Available";
                    sgrade = "Not Available";
                    return false;
                }
            }
            catch (Exception db)
            {
                string ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                scn = null;
                sloc = null;
                syc = null;
                ssb = null;
                sper = null;
                sgrade = null;
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;

            }

        }

        public string getstatename(int id, string sp)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                SqlParameter name = new SqlParameter("@name", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(name);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return name.Value.ToString();

            }
            catch (Exception db)
            {
                string ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                return "NA";
            }

        }
        public static bool getdetails1(int un, string spname, out Int32 dct, out string deg1, out string duni, out string dcn, out Int32 dspc, out string dureg, out string dsd, out string ded, out string dper, out string dgrade)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", un);
                SqlParameter ct = new SqlParameter("@ct", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter deg = new SqlParameter("@degree", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter uname = new SqlParameter("@un", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter cname = new SqlParameter("@cn", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter special = new SqlParameter("@spec", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter regnum = new SqlParameter("@unireg", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter sd = new SqlParameter("@sd", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter ed = new SqlParameter("@ed", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter per = new SqlParameter("@per", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                per.Precision = 18;
                per.Scale = 3;
                SqlParameter grade = new SqlParameter("@grade", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(ct);
                cmd.Parameters.Add(uname);
                cmd.Parameters.Add(deg);
                cmd.Parameters.Add(cname);
                cmd.Parameters.Add(special);
                cmd.Parameters.Add(regnum);
                cmd.Parameters.Add(sd);
                cmd.Parameters.Add(ed);
                cmd.Parameters.Add(per);
                cmd.Parameters.Add(grade);

                con.Open();
                cmd.ExecuteNonQuery();
                try
                {
                    dct = Convert.ToInt32(ct.Value);
                    duni = uname.Value.ToString();
                    dcn = cname.Value.ToString();
                    deg1 = deg.Value.ToString();
                    dspc = Convert.ToInt32(special.Value);
                    dureg = regnum.Value.ToString();
                    dsd = sd.Value.ToString();
                    ded = ed.Value.ToString();
                    dper = per.Value.ToString();
                    dgrade = grade.Value.ToString();
                    return true;
                }
                catch
                {
                    dct = 0;
                    duni = "Not Available";
                    dcn = "Not Available";
                    deg1 = "Not Available";
                    dspc = 0;
                    dureg = "Not Available";
                    dsd = "Not Available";
                    ded = "Not Available";
                    dper = "Not Available";
                    dgrade = "Not Available";
                    return false;
                }

            }
            catch (Exception dbb)
            {
                string ss = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                dct = 0;
                duni = null;
                dcn = null;
                deg1 = null;
                dspc = 0;
                dureg = null;
                dsd = null;
                ded = null;
                dper = null;
                dgrade = null;
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;

            }
        }
   
        public static string getvalueyear(string ss, string spname)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ui", ss);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@vale";
                outpara.SqlDbType = SqlDbType.VarChar;
                outpara.Size = 50;
                outpara.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                String fn = outpara.Value.ToString();
                return fn;
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return "";

            }

        }

        public static string month(string ss)
        {
            switch (ss)
            {
                case "1":
                    return "Jan";
                case "2":
                    return "Feb";
                case "3":
                    return "Mar";
                case "4":
                    return "Apr";
                case "5":
                    return "May";
                case "6":
                    return "Jun";
                case "7":
                    return "Jul";
                case "8":
                    return "Aug";
                case "9":
                    return "Sep";
                case "10":
                    return "Oct";
                case "11":
                    return "Nov";
                case "12":
                    return "Dec";
             }
            return "";
            }

        protected void TextBox1_TextChanged1(object sender, EventArgs e)
        {

            lblviewdelsuccessstate.Text = "";
            
            if (getstatusnumberorchar(TextBox1.Text))
            {
                lblviewdelsuccessstate.Text = "";
                Int32 uniq = Convert.ToInt32(TextBox1.Text);
                bool datavailable = checkdataavailable(uniq, "checkui");

                if (datavailable)
                {
                    Int32 uniqueid = Convert.ToInt32(TextBox1.Text.ToString());
                    lblverdelusrname.Text = getusername(uniqueid);
                    hrviewcanddel.Visible = true;
                    getvaluepersonaldetails(Convert.ToInt32(TextBox1.Text));
                    string ssbb, slocc, sycc, ssbbb, sperr, sgradee;
                    string pn, ploc, pyc, pb, pper, pgrade;
                    bool sslc = getsslcdetailsview(uniqueid, "spgetsslcdetailsview", out ssbb, out slocc, out sycc, out ssbbb, out sperr, out sgradee);
                    if (sslc)
                    {
                        lblverschoolname.Text = ssbb;
                        lblverlocation.Text = slocc;
                        lblveryearcompleted.Text = getvalueyear(sycc, "getyearname");
                        lblverboard.Text = ssbbb;
                        lblverpercentage.Text = sperr;
                        lblvergrade.Text = sgradee;
                    }
                    bool puc = getsslcdetailsview(uniqueid, "spgetpucdetailsview", out pn, out ploc, out pyc, out pb, out pper, out pgrade);
                    if (puc)
                    {
                        lblverpuname.Text = pn;
                        lblverpulocation.Text = ploc;
                        lblverpuyercompleted.Text = getvalueyear(pyc, "getyearname");
                        lblverpuboard.Text = pb;
                        lblverpupercentage.Text = pper;
                        lblverpugrade.Text = pgrade;
                    }
                    string duni, dcn, db, dureg, dsd, ded, dper, dgade;
                    Int32 dct, dspc;
                    bool diploma = getdetails(uniqueid, "spgetdiplomadetailsview", out dct, out duni, out dcn, out db, out dspc, out dureg, out dsd, out ded, out dper, out dgade);
                    if (diploma)
                    {
                        string coursetype = "";
                        if (dct == 1)
                        {
                            coursetype = "Full-Time";
                        }
                        else if (dct == 2)
                        {
                            coursetype = "Part-Time";
                        }
                        else
                        {
                            coursetype = "Correspondance";
                        }
                        lblvercoursetypediploma.Text = coursetype;
                        lblveruniversitydiploma.Text = duni + "   " + db;
                        lblvercollegenamediploma.Text = dcn;
                        lblverspecializationdiploma.Text = getvalueyear(dspc.ToString(), "getspecilizationname");
                        lblveruniregnumdiploma.Text = dureg;
                        string dipsmonth = month(dsd.Split('/')[0]);
                        string dipsyear = getvalueyear(dsd.Split('/')[1], "getyearname");
                        lblverstartdatediploma.Text = dipsmonth + "/" + dipsyear;
                        string dipemonth = month(ded.Split('/')[0]);
                        string dipeyear = getvalueyear(ded.Split('/')[1], "getyearname");
                        lblverenddatediploma.Text = dipemonth + "/" + dipeyear;
                        lblverpercentagediploma.Text = dper;
                        lblvergradediploma.Text = dgade;
                    }
                    Int32 gct, gspc;
                    string gdeg, guni, gcn, gureg, gdsd, gded, gdper, ggrade;
                    bool Degree = getdetails1(uniqueid, "spgetdegreedetailsview", out gct, out gdeg, out guni, out gcn, out gspc, out gureg, out gdsd, out gded, out gdper, out ggrade);
                    if (Degree)
                    {
                        string degreecoursetype = "";
                        if (gct == 1)
                        {
                            degreecoursetype = "Full-Time";
                        }
                        else if (gct == 2)
                        {
                            degreecoursetype = "Part-Time";
                        }
                        else
                        {
                            degreecoursetype = "Correspondance";
                        }
                        lblvercoursegrad.Text = degreecoursetype;
                        lblverdegreegrad.Text = getvalueyear(gdeg.ToString(), "getnamedegree");
                        lblveruniversitygrad.Text = guni.ToString();
                        lblvercollegegrad.Text = gcn.ToString();
                        lblverspecializationgrad.Text = getvalueyear(gspc.ToString(), "getspecilizationnamedegree");
                        lblveruniregnumgrad.Text = gureg.ToString();
                        string gradsmonth = month(gdsd.Split('/')[0]);
                        string gradsyear = getvalueyear(gdsd.Split('/')[1], "getyearname");
                        lblverstartgrad.Text = gradsmonth + "/" + gradsyear;
                        string grademonth = month(gded.Split('/')[0]);
                        string gradeyear = getvalueyear(gded.Split('/')[1], "getyearname");
                        lblverendgrad.Text = grademonth + "/" + gradeyear;
                        lblverpercentagegrad.Text = gdper.ToString();
                        lblvergradegrad.Text = ggrade.ToString();

                    }
                    Int32 pgct, pgspc;
                    string pgdeg, pguni, pgcn, pgureg, pgdsd, pgded, pgdper, pggrade;
                    bool pg = getdetails1(uniqueid, "spgetpgdetailsview", out pgct, out pgdeg, out pguni, out pgcn, out pgspc, out pgureg, out pgdsd, out pgded, out pgdper, out pggrade);
                    if (pg)
                    {
                        string pgcoursetype = "";
                        if (pgct == 1)
                        {
                            pgcoursetype = "Full-Time";
                        }
                        else if (pgct == 2)
                        {
                            pgcoursetype = "Part-Time";
                        }
                        else
                        {
                            pgcoursetype = "Correspondance";
                        }
                        lblvercoursepg.Text = pgcoursetype;
                        lblverdegreepg.Text = getvalueyear(pgdeg.ToString(), "getnamedegree");
                        lblveruniversitypg.Text = pguni.ToString();
                        lblvercollegenamepg.Text = pgcn.ToString();
                        lblverspecilizationpg.Text = getvalueyear(pgspc.ToString(), "getspecilizationnamedegree");
                        lblveruniregnumpg.Text = pgureg.ToString();
                        string pgsmonth = month(pgdsd.Split('/')[0]);
                        string pgsyear = getvalueyear(pgdsd.Split('/')[1], "getyearname");
                        lblverstartpg.Text = pgsmonth + "/" + pgsyear;
                        string pgemonth = month(pgded.Split('/')[0]);
                        string pgeyear = getvalueyear(pgded.Split('/')[1], "getyearname");
                        lblverendpg.Text = pgemonth + "/" + pgeyear;
                        lblverpercentagepg.Text = pgdper.ToString();
                        lblvergradepg.Text = pggrade.ToString();

                    }
                    Int32 unidsslc, unidpuc, unidgrad, unidpg, uniddip;
                    bool sslcverification = spgetstatusofdetails(uniqueid, "spgetstatusofsslc", out unidsslc);
                    bool pucverification = spgetstatusofdetails(uniqueid, "spgetstatusofpuc", out unidpuc);
                    bool diplomaverification = spgetstatusofdetails(uniqueid, "spgetstatusofdip", out uniddip);
                    bool gardverification = spgetstatusofdetails(uniqueid, "spgetstatusofgrad", out unidgrad);
                    bool pgverification = spgetstatusofdetails(uniqueid, "spgetstatusofpg", out unidpg);
                    bool sslcimage = getstatusofimage(uniqueid, "spdownstatussslc");
                    bool pucimage = getstatusofimage(uniqueid, "spdownstatuspuc");
                    bool dipimage = getstatusofimage(uniqueid, "spdownstatusdip");
                    bool gradimage = getstatusofimage(uniqueid, "spdownstatusgrad");
                    bool pgimage = getstatusofimage(uniqueid, "spdownstatuspg");
                    bool idimage = getstatusofimage(uniqueid, "spdownstatusid");
                    bool addimage = getstatusofimage(uniqueid, "spdownstatusadd");
                    if (!sslcimage)
                    {
                        downloadsslc.Enabled = false;
                        downloadsslc.ToolTip = "Data not available";
                    }
                    if (!pucimage)
                    {
                        downloadpu.Enabled = false;
                        downloadpu.ToolTip = "Data not available";
                    }
                    if(!gradimage)
                    {
                        downloadgraduation.Enabled = false;
                        downloadgraduation.ToolTip = "Data not available";
                    }
                    if(!dipimage)
                    {
                        downloaddiploma.Enabled = false;
                        downloaddiploma.ToolTip = "Data not available";
                    }
                    if(!pgimage)
                    {
                        downloadpost.Enabled = false;
                        downloadpost.ToolTip = "Data not available";
                    }
                    if(!idimage)
                    {
                        downloadid.Enabled = false;
                        downloadid.ToolTip = "Data not available";
                    }
                    if(!addimage)
                    {
                        downloadadd.Enabled = false;
                        downloadadd.ToolTip = "Data not available";
                    }
                    if (sslcverification)
                    {
                        Int32 veri;
                        string svrb, scom;
                        bool gt = getverdetails(unidsslc, "getverdetailsofsslc", out veri, out svrb, out  scom);
                        if (gt)
                        {
                            if (veri == 1)
                            {
                                lbldocversslc.Text = "Verified";
                            }
                            else
                            {
                                lbldocversslc.Text = "Not Verified";
                            }
                            lbldocverbysslc.Text = svrb;
                            lbldoccommsslc.Text = scom;
                        }
                        else
                        {
                            lbldocversslc.Text = "Details Not Available to Verify";
                            lbldocverbysslc.Text = "Details Not Available to Verify";
                            lbldoccommsslc.Text = "Details Not Available to Verify";
                        }
                    }
                    else
                    {
                        lbldocversslc.Text = "Details Not Available to Verify";
                        lbldocverbysslc.Text = "Details Not Available to Verify";
                        lbldoccommsslc.Text = "Details Not Available to Verify";
                    }

                    if (pucverification)
                    {
                        Int32 pveri;
                        string pvrb, pcom;
                        bool gt = getverdetails(unidpuc, "getverdetailsofpuc", out pveri, out pvrb, out  pcom);
                        if (gt)
                        {
                            if (pveri == 1)
                            {
                                lbldocverpu.Text = "Verified";
                            }
                            else
                            {
                                lbldocverpu.Text = "Not Verified";
                            }
                            lbldocverbypu.Text = pvrb;
                            lbldoccompu.Text = pcom;
                        }
                        else
                        {
                            lbldocverpu.Text = "Details Not Available to Verify";
                            lbldocverbypu.Text = "Details Not Available to Verify";
                            lbldoccompu.Text = "Details Not Available to Verify";
                        }
                    }
                    else
                    {
                        lbldocverpu.Text = "Details Not Available to Verify";
                        lbldocverbypu.Text = "Details Not Available to Verify";
                        lbldoccompu.Text = "Details Not Available to Verify";
                    }

                    if (diplomaverification)
                    {
                        Int32 dveri;
                        string dvrb, dcom;
                        bool gt = getverdetails(uniddip, "getverdetailsofdip", out dveri, out dvrb, out  dcom);
                        if (gt)
                        {
                            if (dveri == 1)
                            {
                                lbldocverdiploma.Text = "Verified";
                            }
                            else
                            {
                                lbldocverdiploma.Text = "Not Verified";
                            }
                            lbldocverbydiploma.Text = dvrb;
                            lbldoccomdiploma.Text = dcom;
                        }
                        else
                        {
                            lbldocverdiploma.Text = "Details Not Available to Verify";
                            lbldocverbydiploma.Text = "Details Not Available to Verify";
                            lbldoccomdiploma.Text = "Details Not Available to Verify";
                        }
                    }
                    else
                    {
                        lbldocverdiploma.Text = "Details Not Available to Verify";
                        lbldocverbydiploma.Text = "Details Not Available to Verify";
                        lbldoccomdiploma.Text = "Details Not Available to Verify";
                    }
                    if (gardverification)
                    {
                        Int32 gveri;
                        string gvrb, gcom;
                        bool gt = getverdetails(unidgrad, "getverdetailsofgrad", out gveri, out gvrb, out  gcom);
                        if (gt)
                        {
                            if (gveri == 1)
                            {
                                lbldocvergrad.Text = "Verified";
                            }
                            else
                            {
                                lbldocvergrad.Text = "Not Verified";
                            }
                            lbldocverbygard.Text = gvrb;
                            lbldoccomgrad.Text = gcom;
                        }
                        else
                        {
                            lbldoccomgrad.Text = "Details Not Available to Verify";
                            lbldocverbygard.Text = "Details Not Available to Verify";
                            lbldocvergrad.Text = "Details Not Available to Verify";
                        }
                    }
                    else
                    {
                        lbldoccomgrad.Text = "Details Not Available to Verify";
                        lbldocverbygard.Text = "Details Not Available to Verify";
                        lbldocvergrad.Text = "Details Not Available to Verify";
                    }
                    if (pgverification)
                    {
                        Int32 pgveri;
                        string pgvrb, pgcom;
                        bool gt = getverdetails(unidpg, "getverdetailsofpg", out pgveri, out pgvrb, out  pgcom);
                        if (gt)
                        {
                            if (pgveri == 1)
                            {
                                lbldocverpg.Text = "Verified";
                            }
                            else
                            {
                                lbldocverpg.Text = "Not Verified";
                            }
                            lbldocverbypg.Text = pgvrb;
                            lbldoccompg.Text = pgcom;
                        }
                        else
                        {
                            lbldoccompg.Text = "Details Not Available to Verify";
                            lbldocverbypg.Text = "Details Not Available to Verify";
                            lbldocverpg.Text = "Details Not Available to Verify";
                        }
                    }

                    else
                    {
                        lbldoccompg.Text = "Details Not Available to Verify";
                        lbldocverbypg.Text = "Details Not Available to Verify";
                        lbldocverpg.Text = "Details Not Available to Verify";
                    }
                  
                }
                   
                else
                {
                    Int32 uniq1 = Convert.ToInt32(TextBox1.Text);
                    bool datavailable1 = checkdataavailable(uniq1, "checkuiexp");
                    if (datavailable1)
                    {
                        viewnot.Visible = true;
                        Int32 us;
                        string com, loc, deg, frdate, todate, skill, rating, comm;
                        bool exper = getsslcdetailsview(uniq, "spgetexpdetails", out us, out com, out loc, out deg, out frdate, out todate, out skill, out rating, out comm);
                        string userid, username;
                        getuserid(us, "spgetuseridfordisplay", out userid, out username);
                        addexperuserid.Text = userid;
                        addexpcompname.Text = com;
                        addexpcomploc.Text = loc;
                        empdesg.Text = deg;
                        addexpfrdate.Text = frdate.Remove(10,9);
                        addexpenddate.Text = todate.Remove(10, 9);
                        addexpskills1.Text = skill;
                        ratingvalue.Text = rating;
                        Double ssss = Convert.ToDouble(rating);
                        if (ssss <= 2.5)
                        {
                            ratingvalue.ForeColor = System.Drawing.Color.Red;
                        }
                        else if (ssss > 2.5 && ssss <= 4)
                        {
                            ratingvalue.ForeColor = System.Drawing.Color.Orange;
                        }
                        else
                        {
                            ratingvalue.ForeColor = System.Drawing.Color.Green;
                        }


                        addexpcomm1.Text = comm;
                        lblviewdelsuccessstate.Text = "Below is the Experience details of   ";
                        nameuser.Text = username;
                    }
                    else
                    {
                    lblviewdelsuccessstate.Text = "Oops Data Not avaiable !!!!";
                    }
                    }
            }
            else
            {
                
                lblviewdelsuccessstate.Text = "Oops Invalid QR code or Data not avaibale !!!!";
            }
        }

        public static bool getsslcdetailsview(int un, string spname, out Int32 userid, out string company, out string loc, out string des, out string frdate, out string todate, out string skill, out string rating, out string comm)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", un);
                SqlParameter userid1 = new SqlParameter("@userid", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter company1 = new SqlParameter("@company", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter loc1 = new SqlParameter("@loc", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter des1 = new SqlParameter("@des", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter frdate1 = new SqlParameter("@frdate", SqlDbType.Date) { Direction = ParameterDirection.Output };
                SqlParameter todate1 = new SqlParameter("@todate", SqlDbType.Date) { Direction = ParameterDirection.Output };
                SqlParameter skill1 = new SqlParameter("@skill", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                SqlParameter rating1 = new SqlParameter("@rating", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter comm1 = new SqlParameter("@comm", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(userid1);
                cmd.Parameters.Add(company1);
                cmd.Parameters.Add(loc1);
                cmd.Parameters.Add(des1);
                cmd.Parameters.Add(frdate1);
                cmd.Parameters.Add(todate1);
                cmd.Parameters.Add(skill1);
                cmd.Parameters.Add(rating1);
                cmd.Parameters.Add(comm1);
                con.Open();
                cmd.ExecuteNonQuery();

                try
                {
                    userid = Convert.ToInt32(userid1.Value);
                    company = company1.Value.ToString();
                    loc = loc1.Value.ToString();
                    des = des1.Value.ToString();
                    frdate = frdate1.Value.ToString();
                    todate = todate1.Value.ToString();
                    skill = skill1.Value.ToString();
                    rating = rating1.Value.ToString();
                    comm = comm1.Value.ToString();
                    return true;
                }
                catch
                {
                    userid = 0;
                    company = "Not Available";
                    loc = "Not Available";
                    des = "Not Available";
                    frdate = "Not Available";
                    todate = "Not Available";
                    skill = "Not Available";
                    rating = "Not Available";
                    comm = "Not Available";

                    return false;
                }
            }
            catch (Exception db)
            {
                string ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                userid = 0;
                company = "Not Available";
                loc = "Not Available";
                des = "Not Available";
                frdate = "Not Available";
                todate = "Not Available";
                skill = "Not Available";
                rating = "Not Available";
                comm = "Not Available";
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;

            }

        }
        private void getuserid(int uniq, string p, out string usr, out string name)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uniq);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@userid";
                outpara.SqlDbType = SqlDbType.VarChar;
                outpara.Size = 50;
                outpara.Direction = ParameterDirection.Output;

                SqlParameter out1 = new SqlParameter("@username", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(outpara);
                cmd.Parameters.Add(out1);
                con.Open();
                cmd.ExecuteNonQuery();
                usr = outpara.Value.ToString();
                name = out1.Value.ToString();
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                usr = "";
                name = "";

            }

        }
        private bool getstatusofimage(int uniqueid, string p)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uni", uniqueid);

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

        public void downloadmages(string spname, Int32 id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter imgdata = new SqlParameter("@imd", SqlDbType.VarBinary, -1) { Direction = ParameterDirection.Output };
                SqlParameter imgnam = new SqlParameter("@imgn", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter imgty = new SqlParameter("@imgt", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(imgdata);
                cmd.Parameters.Add(imgnam);
                cmd.Parameters.Add(imgty);

                cmd.Parameters.AddWithValue("@uni", id);

                con.Open();
                cmd.ExecuteScalar();

                byte[] img = (byte[])(imgdata.Value);
                string type = imgty.Value.ToString();
                string name = imgnam.Value.ToString().ToLower().Replace(".jpg", "").Replace(".png", "").Replace(".gif", "").Replace(".jpeg", "");

                string path = "c:\\" + name + type;


                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = AHRMS1.specueopag.MimeType(Path.GetExtension(path));
                Response.AddHeader("content-disposition", "attachment;filename=" + name + type);
                Response.BinaryWrite(img);
                Response.Flush();
                Response.End();

            }
            catch (System.Threading.ThreadAbortException lException)
            {

            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sddd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sddd);
                Response.Redirect("~/error.aspx", true);

            }

        }


        private string getusername(int uniqueid)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("spgetusername", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uni", uniqueid);

                SqlParameter outpar = new SqlParameter("@name", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outpar);

                con.Open();
                cmd.ExecuteNonQuery();
                string sss = outpar.Value.ToString();
                return sss;
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return "";
            }

        }

        private bool getstatusnumberorchar(string p)
        {
            try
            {
                Int32 uniq2 = Convert.ToInt32(TextBox1.Text);
                return true;
            }
            catch
            {
                lblviewdelsuccessstate.Text = "Invalid QR code";
                return false;
            }
        }

        private bool checkdataavailable(Int32 uniq1,string spname)
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

        protected void downloadadd_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatusadd1", Convert.ToInt32(TextBox1.Text.ToString()));
        }

        protected void downloadid_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatusid1", Convert.ToInt32(TextBox1.Text));
        }

        protected void downloadsslc_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatussslc1", Convert.ToInt32(TextBox1.Text));
        }

        protected void downloadpu_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatuspuc1", Convert.ToInt32(TextBox1.Text));
        }

        protected void downloaddiploma_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatusdip1", Convert.ToInt32(TextBox1.Text));
        }

        protected void downloadgraduation_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatusgrad1", Convert.ToInt32(TextBox1.Text));
        }

        protected void downloadpost_Click(object sender, ImageClickEventArgs e)
        {
            downloadmages("spdownstatuspg1", Convert.ToInt32(TextBox1.Text));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            hrviewcanddel.Visible = false;
            hrviewcanddel.Visible = false;
            viewnot.Visible = false;
            lblviewdelsuccessstate.Text = "";
            TextBox1.Text = "";
            nameuser.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            hrviewcanddel.Visible = false;
            viewnot.Visible = false;
            lblviewdelsuccessstate.Text = "";
            TextBox1.Text = "";
            nameuser.Text = "";
            ratingvalue.Text = "";
            ratingvalue.ForeColor = System.Drawing.Color.Black;
        }
        }
    }