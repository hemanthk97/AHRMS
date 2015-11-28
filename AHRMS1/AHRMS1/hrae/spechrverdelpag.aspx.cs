using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Web.Services;

namespace AHRMS1.ms
{
    public partial class spechrverdelpag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string nm, add;
                string hrid = Session["hrid"].ToString();
                getemployername(hrid, "spsgetemployername", out nm, out add);
                lbl10verdel.Text =  nm;
                lblpuverdel.Text =  nm;
                lbldipveredel.Text = nm;
                lblgradverdel.Text = nm;
                lblpgverdel.Text = nm;
                verdelcol.Visible = false;
                TextBox1.AutoPostBack = true;
            }
        }


        private void getemployername(string hrid, string p, out string name, out string addr)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", hrid);

                SqlParameter outpara = new SqlParameter("@emp", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter outpara1 = new SqlParameter("@empadd", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outpara1);
                cmd.Parameters.Add(outpara);

                con.Open();

                cmd.ExecuteNonQuery();

                name = outpara.Value.ToString();

                addr = outpara1.Value.ToString();

            }

            catch (Exception dbb)
            {
                string ss = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                Response.Redirect("~/error.aspx", true);
                name = "";
                addr = "";
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

        protected void answer1_TextChanged(object sender, EventArgs e)
        {
            if (getstatusnumberorchar(TextBox1.Text))
            {
                Int32 uniq = Convert.ToInt32(TextBox1.Text);
                string userid, name;
                getuserid(uniq, "spgetuseridfordisplay", out userid, out name);
                lblverdelusrname.Text = name;
                bool sslc = checkstatus("spchkversslcdel", uniq);
                bool puc = checkstatus("spchkverpucdel", uniq);
                bool dip = checkstatus("spchkverdipdel", uniq);
                bool grad = checkstatus("spchkvergraddel", uniq);
                bool pg = checkstatus("spchkverpgdel", uniq);
                verdelcol.Visible = true;
                TextBox1.AutoPostBack = false;

                if (sslc)
                {
                    string ver, verby, com;
                    getdetails("spgetversslcdel", out  ver, out verby, out  com,uniq);
                    dd10verdel.SelectedValue = ver;
                    if (verby == "Not Viewed by any Employer to verify")
                    {
                        lbl10verdel.Text = "Not Viewed by any Employer to verify";
                    }
                    else
                    {

                        lbl10verdel.Text = "Was verifeid by" + verby;
                    }

                    txt10verdel.Text = com;

                }
                else
                {
                    dd10verdel.SelectedValue = "-1";
                    dd10verdel.Enabled = false;
                    lbl10verdel.Text = "Data Not Available";
                    txt10verdel.Text = "Data Not Available";
                    txt10verdel.ReadOnly = true;
                }
                if (puc)
                {
                    string ver, verby, com;
                    getdetails("spgetverpucdel", out  ver, out verby, out  com,uniq);
                    ddpuverdel.SelectedValue = ver;
                    if (verby == "Not Viewed by any Employer to verify")
                    {
                        lblpuverdel.Text = "Not Viewed by any Employer to verify";
                    }
                    else
                    {

                        lblpuverdel.Text = "Was verifeid by" + verby;
                    }
                    txtpuverdel.Text = com;

                }
                else
                {
                    ddpuverdel.SelectedValue = "-1";
                    ddpuverdel.Enabled = false;
                    lblpuverdel.Text = "Data Not Available";
                    txtpuverdel.Text = "Data Not Available";
                    txtpuverdel.ReadOnly = true;
                }
                if (dip)
                {
                    string ver, verby, com;
                    getdetails("spgetverdipdel", out  ver, out verby, out  com,uniq);
                    dddipveredel.SelectedValue = ver;
                    if (verby == "Not Viewed by any Employer to verify")
                    {
                        lbldipveredel.Text = "Not Viewed by any Employer to verify";
                    }
                    else
                    {
                        lbldipveredel.Text = "Was verifeid by" + verby;
                    }
                    txtdipveredel.Text = com;

                }
                else
                {
                    dddipveredel.SelectedValue = "-1";
                    dddipveredel.Enabled = false;
                    lbldipveredel.Text = "Data Not Available";
                    txtdipveredel.Text = "Data Not Available";
                    txtdipveredel.ReadOnly = true;
                }
                if (grad)
                {
                    string ver, verby, com;
                    getdetails("spgetvergraddel", out  ver, out verby, out  com,uniq);
                    ddgradverdel.SelectedValue = ver;
                    if (verby == "Not Viewed by any Employer to verify")
                    {
                        lblgradverdel.Text = "Not Viewed by any Employer to verify";
                    }
                    else
                    {
                        lblgradverdel.Text = "Was verifeid by" + verby;
                    }
                    txtgradverdel.Text = com;

                }
                else
                {
                    ddgradverdel.SelectedValue = "-1";
                    ddgradverdel.Enabled = false;
                    lblgradverdel.Text = "Data Not Available";
                    txtgradverdel.Text = "Data Not Available";
                    txtgradverdel.ReadOnly = true;
                }

                if (pg)
                {
                    string ver, verby, com;
                    getdetails("spgetverpgdel", out  ver, out verby, out  com,uniq);
                    ddpgverdel.SelectedValue = ver;
                    if (verby == "Not Viewed by any Employer to verify")
                    {
                        lblpgverdel.Text = "Not Viewed by any Employer to verify";
                    }
                    else
                    {
                        lblpgverdel.Text = "Was verifeid by" + verby;
                    }
                    txtpgverdel.Text = com;

                }
                else
                {
                    ddpgverdel.SelectedValue = "-1";
                    ddpgverdel.Enabled = false;
                    lblpgverdel.Text = "Data Not Available";
                    txtpgverdel.Text = "Data Not Available";
                    txtpgverdel.ReadOnly = true;
                }


            }
            else
            {
                verdelcol.Visible = false;
                lab.Text = "Inavlid QR Code";
                TextBox1.Text = "";
            }

        }

        private void getdetails(string p, out string ver, out string verby, out string com,Int32 uni)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uniq", uni);
                SqlParameter ver1 = new SqlParameter("@ver", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter verby1 = new SqlParameter("@verby", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter com1 = new SqlParameter("@comm", SqlDbType.VarChar, -1) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(ver1);
                cmd.Parameters.Add(verby1);
                cmd.Parameters.Add(com1);

                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                ver = ver1.Value.ToString();
                verby = verby1.Value.ToString();
                com = com1.Value.ToString();


                
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                ver = "";
                verby = "";
                com = "";
            }
        }

        private bool checkstatus(string p, int uniq)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uniq", uniq);

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
                Int32 uniq2 = Convert.ToInt32(TextBox1.Text);
                return true;
            }
            catch
            {

                return false;
            }
        }

        protected void updateverdelusr_Click(object sender, EventArgs e)
        {
            string nm, add;
            string hrid = Session["hrid"].ToString();
            getemployername(hrid, "spsgetemployername", out nm, out add);
            lbl10verdel.Text = nm;
            lblpuverdel.Text = nm;
            lbldipveredel.Text = nm;
            lblgradverdel.Text = nm;
            lblpgverdel.Text = nm;

            Int32 uniq = Convert.ToInt32(TextBox1.Text);
            bool sslc = checkstatus("spchkversslcdel", uniq);
            bool puc = checkstatus("spchkverpucdel", uniq);
            bool dip = checkstatus("spchkverdipdel", uniq);
            bool grad = checkstatus("spchkvergraddel", uniq);
            bool pg = checkstatus("spchkverpgdel", uniq);
            if (sslc)
            {
                bool ss = insertdata("spinsertsslcverdel",uniq, Convert.ToInt32(dd10verdel.SelectedValue.ToString()), lbl10verdel.Text.ToString(), txt10verdel.Text.ToString());
                if (ss)
                {
                    upsslc.Text = "Successfully Updated";
                }
                else
                {
                    upsslc.Text = "Not Updated";
                }
            }
            else
            {
                upsslc.Text = "Data Not Available to Verify";
            }
            if (puc)
            {
                bool ss1 = insertdata("spinsertpucverdel",uniq, Convert.ToInt32(ddpuverdel.SelectedValue.ToString()), lblpuverdel.Text.ToString(), txtpuverdel.Text.ToString());
                if (ss1)
                {
                    uppuc.Text = "Successfully Updated";
                }
                else
                {
                    uppuc.Text = "Not Updated";
                }
            }
            else
            {
                uppuc.Text = "Data Not Available to Verify";
            }
            if (dip)
            {
                bool ss2 = insertdata("spinsertdipverdel",uniq, Convert.ToInt32(dddipveredel.SelectedValue.ToString()), lbldipveredel.Text.ToString(), txtdipveredel.Text.ToString());
                if (ss2)
                {
                    updip.Text = "Successfully Updated";
                }
                else
                {
                    updip.Text = "Not Updated";
                }
            }
            else
            {
                updip.Text = "Data Not Available to Verify";
            }
            if (grad)
            {
                bool ss3 = insertdata("spinsertgradverdel", uniq,Convert.ToInt32(ddgradverdel.SelectedValue.ToString()), lblgradverdel.Text.ToString(), txtgradverdel.Text.ToString());
                if (ss3)
                {
                    upgrad.Text = "Successfully Updated";
                }
                else
                {
                    upgrad.Text = "Not Updated";
                }
            }
            else
            {
                upgrad.Text = "Data Not Available to Verify";
            }
            if (pg)
            {
                bool ss4 = insertdata("spinsertpgverdel", uniq,Convert.ToInt32(ddpgverdel.SelectedValue.ToString()), lblpgverdel.Text.ToString(), txtpgverdel.Text.ToString());
                if (ss4)
                {
                    uppg.Text = "Successfully Updated";
                }
                else
                {
                    uppg.Text = "Not Updated";
                }
            }
            else
            {
                uppg.Text = "Data Not Available to Verify";
            }
        }

        private bool insertdata(string p1,Int32 uniq, int p2, string p3, string p4)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p1, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uniq",uniq);
                SqlParameter u = new SqlParameter("@uni",SqlDbType.Int){Direction = ParameterDirection.Output};
                cmd.Parameters.Add(u);
                cmd.Parameters.AddWithValue("@ver", p2);
                cmd.Parameters.AddWithValue("@verby", p3);
                cmd.Parameters.AddWithValue("@comm", p4);


                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                int s = dr.RecordsAffected;
                if (s >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
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

        protected void refresh_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            lab.Text = "";
            lblverdelusrname.Text = "";
            Response.Redirect(Request.RawUrl);
        }

    }
}