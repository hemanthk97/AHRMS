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

namespace AHRMS1
{
    public partial class specueopag : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] == null)
            {
                Response.Redirect("~/ms/access.aspx", true);
            }

            string fn = username();
            lblusername.Text = fn + "!!!!";
            Int32 uniqid = AHRMS1.usae.specpersonusr.getuniid();
            QRcodeimageload(uniqid, fn);


        }
        public string username()
        {
            try
            {
                string lun1 = Session["userid"].ToString();
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("username", con);
                cmd.CommandType = CommandType.StoredProcedure;

                string lun2 = Session["userid"].ToString();
                cmd.Parameters.AddWithValue("@ui", lun2);

                SqlParameter outpara = new SqlParameter();
                outpara.ParameterName = "@fn";
                outpara.SqlDbType = SqlDbType.VarChar;
                outpara.Direction = ParameterDirection.Output;
                outpara.Size = 50;
                cmd.Parameters.Add(outpara);
                con.Open();
                cmd.ExecuteNonQuery();
                string fn = outpara.Value.ToString();
                return fn;
            }
            catch (Exception db)
            {
              String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sddd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sddd);
                Response.Redirect("~/error.aspx", true);
                return "not avail";
            }



        }

        public void QRcodeimageload(Int32 un, string ff)
        {

            string path = "C:\\Users\\Geetha\\documents\\visual studio 2012\\Projects\\AHRMS1\\AHRMS1\\QRImages\\";
            QRCodeEncoder encoder = new QRCodeEncoder();
          
            encoder.QRCodeBackgroundColor = System.Drawing.Color.White;
            encoder.QRCodeForegroundColor = System.Drawing.Color.Black;
            encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H; // 30%
            encoder.QRCodeScale = 4;
            string ss = un.ToString();
            System.Drawing.Image img = encoder.Encode(ss);
            

            img.Save(path +ff+".png", ImageFormat.Png);

            QRImag.ImageUrl = "~//QRImages//"+ff+".png";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string ff = username();
            string fname = @"C:\Users\Geetha\documents\visual studio 2012\Projects\AHRMS1\AHRMS1\QRImages\" + ff + ".png";
            FileInfo fi = new FileInfo(fname);
            long sz = fi.Length;

            Response.ClearContent();
            Response.ContentType = MimeType(Path.GetExtension(fname));
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(fname)));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.TransmitFile(fname);
            Response.End();
        }

        public static string MimeType(string Extension)
        {
            string mime = "application/octetstream";
            if (string.IsNullOrEmpty(Extension))
                return mime;
            string ext = Extension.ToLower();
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        }

        protected void startfill_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/usae/specpersonusr.aspx");
        }
    }
}
