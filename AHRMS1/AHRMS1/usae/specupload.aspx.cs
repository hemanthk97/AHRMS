using System;
using System.IO;
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
    public partial class specupload : System.Web.UI.Page
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


                if (getstatus(uniqueid, "spgetimageidstatus"))
                {
                    FileUpload1.Enabled = false;
                    lblfileupload1.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                    lblfileupload1.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblfileupload1.Text = "Details Filled please upload document";
                    lblfileupload1.ForeColor = System.Drawing.Color.Red;
                }

                if (getstatus(uniqueid, "spgetimageaddstatus"))
                {
                    FileUpload2.Enabled = false;
                    lblfileupload2.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                    lblfileupload2.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblfileupload2.Text = "Details Filled please upload document";
                    lblfileupload2.ForeColor = System.Drawing.Color.Red;
                }

                if (getstatus(uniqueid, "spchecksslc") == false)
                {
                    sslcmarkscard.Enabled = false;
                    lblsslc.Text = "Fill sslc Details to Upload Documents";
                    lblsslc.ForeColor = System.Drawing.Color.Blue;

                }
                else
                {
                    if (getstatus(uniqueid, "spgetimagesslcstatus") == true)
                    {
                        sslcmarkscard.Enabled = false;
                        lblsslc.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                        lblsslc.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblsslc.Text = "Details Filled please upload document";
                        lblsslc.ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (getstatus(uniqueid, "spcheckpuc") == false)
                {
                    pumarkscard.Enabled = false;
                    lblpuc.Text = "Fill puc/12th Details to Upload Documents";
                    lblpuc.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    if (getstatus(uniqueid, "spgetimagepucstatus") == true)
                    {
                        pumarkscard.Enabled = false;
                        lblpuc.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                        lblpuc.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblpuc.Text = "Details Filled please upload document";
                        lblpuc.ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (getstatus(uniqueid, "spcheckdip") == false)
                {
                    diplomacertificate.Enabled = false;
                    lbldip.Text = "Fill diploma Details to Upload Documents";
                    lbldip.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    if (getstatus(uniqueid, "spgetimagedipstatus") == true)
                    {
                        diplomacertificate.Enabled = false;
                        lbldip.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                        lbldip.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lbldip.Text = "Details Filled please upload document";
                        lbldip.ForeColor = System.Drawing.Color.Red;
                    }

                }
                if (getstatus(uniqueid, "spcheckgrad") == false)
                {
                    degreecertificate.Enabled = false;
                    lblgrad.Text = "Fill graduation Details to Upload Documents";
                    lblgrad.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    if (getstatus(uniqueid, "spgetimagegradstatus") == true)
                    {
                        degreecertificate.Enabled = false;
                        lblgrad.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                        lblgrad.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblgrad.Text = "Details Filled please upload document";
                        lblgrad.ForeColor = System.Drawing.Color.Red;
                    }
                }
                if (getstatus(uniqueid, "spcheckpg") == false)
                {
                    pgcertificate.Enabled = false;
                    lblpg.Text = "Fill graduation Details to Upload Documents";
                    lblpg.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    if (getstatus(uniqueid, "spgetimagepgstatus") == true)
                    {
                        pgcertificate.Enabled = false;
                        lblpg.Text = "File Already Uploaded Go to View Profile to View/Re-upload";
                        lblpg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblpg.Text = "Details Filled please upload document";
                        lblpg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        protected void uploaddoc_Click(object sender, EventArgs e)
        {

            bool id = FileUpload1.HasFile;
            bool add = FileUpload2.HasFile;
            bool sslc = sslcmarkscard.HasFile;
            bool puc = pumarkscard.HasFile;
            bool dip = diplomacertificate.HasFile;
            bool grad = degreecertificate.HasFile;
        
            bool pg = pgcertificate.HasFile;
            if (id)
            {

                Int32 unidsslc = AHRMS1.usae.specpersonusr.getuniid();
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = FileUpload1.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = FileUpload1.FileName;
                    string filetype = Path.GetExtension(this.FileUpload1.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimageidproof");
                    if (uploadidproof)
                    {
                        lblfileupload1.Text = "File Successfully Uploaded";
                        lblfileupload1.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblfileupload1.Text = "Something Went Wrong";
                        lblfileupload1.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    Label1.Text = "Error try again";
                    lblfileupload1.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblfileupload1.Text = "Please upload file";
                lblfileupload1.ForeColor = System.Drawing.Color.Red;
            }
            if (add)
            {
                Int32 unidsslc = AHRMS1.usae.specpersonusr.getuniid();
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = FileUpload2.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = FileUpload2.FileName;
                    string filetype = Path.GetExtension(this.FileUpload2.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimageaddproof");

                    if (uploadidproof)
                    {
                        lblfileupload2.Text = "File Successfully Uploaded";
                        lblfileupload2.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblfileupload2.Text = "Something Went Wrong";
                        lblfileupload2.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblfileupload2.Text = "Error try again";
                    lblfileupload2.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblfileupload2.Text = "Please upload file";
                lblfileupload2.ForeColor = System.Drawing.Color.Red;
            }
            if (sslc)
            {
                string lun1 = Session["userid"].ToString();
                Int32 unidsslc = getuniid(lun1, "spgetsslcid");
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = sslcmarkscard.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = sslcmarkscard.FileName;
                    string filetype = Path.GetExtension(this.sslcmarkscard.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimagsslcdproof");
                    if (uploadidproof)
                    {
                        lblsslc.Text = "File Successfully Uploaded";
                        lblsslc.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblsslc.Text = "Something Went Wrong!!";
                        lblsslc.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblsslc.Text = "Error try again";
                    lblsslc.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblsslc.Text = "Please upload file";
                lblsslc.ForeColor = System.Drawing.Color.Red;
            }
            if (puc)
            {
                string lun1 = Session["userid"].ToString();
                Int32 unidsslc = getuniid(lun1, "spgetpucid");
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = pumarkscard.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = pumarkscard.FileName;
                    string filetype = Path.GetExtension(this.pumarkscard.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimagpucproof");
                    if (uploadidproof)
                    {
                        lblpuc.Text = "File Successfully Uploaded";
                        lblpuc.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblpuc.Text = "Something Went Wrong";
                        lblpuc.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblpuc.Text = "Error try again";
                    lblpuc.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblpuc.Text = "Please upload file";
                lblpuc.ForeColor = System.Drawing.Color.Red;
            }
            if (dip)
            {
                string lun1 = Session["userid"].ToString();
                Int32 unidsslc = getuniid(lun1, "spgetdipid");
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = diplomacertificate.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = diplomacertificate.FileName;
                    string filetype = Path.GetExtension(this.diplomacertificate.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimagdipproof");
                    if (uploadidproof)
                    {
                        lbldip.Text = "File Successfully Uploaded";
                        lbldip.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lbldip.Text = "Something Went  Wrong";
                        lbldip.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lbldip.Text = "Error try again";
                    lbldip.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lbldip.Text = "Please upload file";
                lbldip.ForeColor = System.Drawing.Color.Red;
            }
            if (grad)
            {
                string lun1 = Session["userid"].ToString();
                Int32 unidsslc = getuniid(lun1, "spgetgradid");
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = degreecertificate.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = degreecertificate.FileName;
                    string filetype = Path.GetExtension(this.degreecertificate.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimaggradproof");
                    if (uploadidproof)
                    {
                        lblgrad.Text = "File Successfully Uploaded";
                        lblgrad.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblgrad.Text = "Something Went Wrong";
                        lblgrad.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblgrad.Text = "Error try again";
                    lblgrad.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblgrad.Text = "Please upload file";
                lblgrad.ForeColor = System.Drawing.Color.Red;
            }
            if (pg)
            {
                string lun1 = Session["userid"].ToString();
                Int32 unidsslc = getuniid(lun1, "spgetpgid");
                if (unidsslc != 0)
                {
                    byte[] imgByte = null;
                    HttpPostedFile File = pgcertificate.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                    string filename = pgcertificate.FileName;
                    string filetype = Path.GetExtension(this.pgcertificate.PostedFile.FileName);
                    DateTime dd = DateTime.Now;
                    bool uploadidproof = uploaddocument(unidsslc, imgByte, dd, filename, filetype, "uploadimagpgproof");
                    if (uploadidproof)
                    {
                        lblpg.Text = "File Successfully Uploaded";
                        lblpg.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblpg.Text = "Something Went Wrong";
                        lblpg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {

                    lblpg.Text = "Please upload file";
                    lblpg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        public static Int32 getuniid(string lun, string sp)
        {
            try
            {


                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@userid", lun);
                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@unisslc";
                outpara.SqlDbType = SqlDbType.Int;
                outpara.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                Int32 fn = outpara.Value == DBNull.Value ? 0 : Convert.ToInt32(outpara.Value);
                return fn;
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
               HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return 0;
            }
        }

        public bool uploaddocument(Int32 un, byte[] img, DateTime dt, string fn, string ft, string sp)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();

                SqlCommand cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uniq", un);
                cmd.Parameters.AddWithValue("@img", img);
                cmd.Parameters.AddWithValue("@dd", dt);
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@ft", ft);

                SqlDataReader dr = cmd.ExecuteReader();
                int ss = dr.RecordsAffected;
                if (ss == 1)
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
        public static bool getstatus(Int32 uni, string sp)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(sp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uni", uni);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                bool dd = dr.HasRows;
                con.Close();
                if (dd)
                {
                    return dd;

                }
                else
                {
                    return dd;

                }

            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sd);
                HttpContext.Current.Response.Redirect("~/error.aspx", true);
                return false;
            }

        }

    }
}