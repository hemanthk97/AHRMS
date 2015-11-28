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
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.btnaddexp);
            if (!IsPostBack)
            {
                TextBox1.Text = "";
                lbladdexpsucess.Text = "";
                addexpfrdate.Attributes.Add("readonly", "readonly");
                addexpenddate.Attributes.Add("readonly", "readonly");
                CalendarExtender2.EndDate = DateTime.Now;
                string nm, add;
                string hrid = Session["hrid"].ToString();
                getemployername(hrid, "spsgetemployername", out nm, out add);
                addexpcompname.Text = nm;
                addexpcomploc.Text = add;
                viewnot.Visible = false;
            }
        }

        private void getemployername(string hrid, string p,out string name,out string addr)
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






private string getuserid(int uniq,string p)
{
 	try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ui", uniq);
                 SqlParameter outp = new SqlParameter("@id", SqlDbType.VarChar,50){Direction = ParameterDirection.Output};
                cmd.Parameters.Add(outp);

                con.Open();

                 cmd.ExecuteNonQuery();
               string id = outp.Value.ToString();
                return id;
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            lbladdexpsucess.Text = "";
            viewnot.Visible = false;
        }

        protected void btnaddexp_Click(object sender, EventArgs e)
        {

            Int32 uniexpid = getuniexperinceid("addexper", TextBox1.Text.ToString());
            QRCodeEncoder qe = new QRCodeEncoder();
            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            System.Drawing.Image im = qe.Encode(uniexpid.ToString());
            MemoryStream ms = new MemoryStream();
            im.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bt = ms.ToArray();

            string type = ".png";
            string name = addexperuserid.Text.ToString();
            string path = "c:\\" + name + type;

            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = AHRMS1.specueopag.MimeType(Path.GetExtension(path));
            Response.AddHeader("content-disposition", "attachment;filename=" + name + type);
            Response.BinaryWrite(bt);
            Response.Flush();
            Response.End();

            lbladdexpsucess.Text = "Experience Succesfully Added (Please paste the QR Code on Experience Letter)";
         
        }

        private Int32 getuniexperinceid(string p,string qr)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(p, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@uniqid", Convert.ToInt32(qr));
                cmd.Parameters.AddWithValue("@comworked", addexpcompname.Text.ToString());
                cmd.Parameters.AddWithValue("@comloc", addexpcomploc.Text.ToString());
                cmd.Parameters.AddWithValue("@empdes", empdesg.Text.ToString());
                cmd.Parameters.AddWithValue("@from", Convert.ToDateTime(addexpfrdate.Text));
                cmd.Parameters.AddWithValue("@to", Convert.ToDateTime(addexpenddate.Text));
                cmd.Parameters.AddWithValue("@skills", addexpskills.Text.ToString());
                cmd.Parameters.AddWithValue("@rating", DropDownList1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@comments", addexpcomm.Text.ToString());
                cmd.Parameters.AddWithValue("uploaddate", DateTime.Now);

                SqlParameter expid = new SqlParameter("@uniexpid", SqlDbType.Int) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(expid);

                con.Open();

                cmd.ExecuteNonQuery();

                Int32 ss = Convert.ToInt32(expid.Value);

                return ss;
            }
            catch (Exception dbb)
            {
                string ss1 = dbb.Message.ToString();
                string sw = dbb.Source.ToString();
                string su = dbb.Data.ToString();
                string sd = dbb.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss1, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return 0;
            }
        }

        protected void addexpfrdate_TextChanged1(object sender, EventArgs e)
        {
            CalendarExtender2.StartDate = Convert.ToDateTime(addexpfrdate.Text);
            CalendarExtender2.EndDate = DateTime.Now;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (getstatusnumberorchar(TextBox1.Text))
            {
                Int32 uniq = Convert.ToInt32(TextBox1.Text);
                lab.Text = "";
                bool datavailable = checkdataavailable(uniq, "spgetuseriddetails");
                if (datavailable)
                {
                    addexperuserid.Text = getuserid(uniq, "spgetuseridforexp");
                    viewnot.Visible = true;

                }
                else
                {
                    viewnot.Visible = false;
                    lab.Text = "Inavlid QR Code or Data not avaibale";
                    TextBox1.Text = "";
                }
            }
            else
            {
                viewnot.Visible = false;
                lab.Text = "Inavlid QR Code or Data not avaibale";
                TextBox1.Text = "";
            }
        }
    }
}