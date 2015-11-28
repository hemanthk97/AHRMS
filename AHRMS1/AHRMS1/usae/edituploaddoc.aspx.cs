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
    public partial class edituploaddoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("~/ms/access.aspx", true);
                }

                Label1.Text = Session["userid"].ToString();
                string uii2 = Label1.Text.ToString();
                
                string ui = Label1.Text.ToString();
                Int32 uniqueid = AHRMS1.usae.specpersonusr.getuniid();
                Int32 unisslc = AHRMS1.usae.specupload.getuniid(ui, "spgetsslcid");
                if (unisslc == 0)
                {
                    tablesslc.Visible = false;
                    tablesslc1.Visible = false;
                    btnviewimagesslc.Enabled = false;
                    btndeleteimagesslc.Enabled = false;
                    btndownloadsslc.Enabled = false;
                    btnviewimagesslc.ToolTip = "Image was not uploaded";
                    btndownloadsslc.ToolTip = "Image was not uploaded";
                    btndeleteimagesslc.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatussslc", AHRMS1.usae.specupload.getuniid(uii2, "spgetsslcid"));
                    if (a12)
                    {
                        viewimages("downloadsslc", AHRMS1.usae.specupload.getuniid(uii2, "spgetsslcid"),A11);
                    }
                    else
                    {
                        tablesslc.Visible = false;
                        tablesslc1.Visible = false;
                        btnviewimagesslc.Enabled = false;
                        btndeleteimagesslc.Enabled = false;
                        btndownloadsslc.Enabled = false;
                        btnviewimagesslc.ToolTip = "Image was not uploaded";
                        btndownloadsslc.ToolTip = "Image was not uploaded";
                        btndeleteimagesslc.ToolTip = "Image was not uploaded";
                    }
                    }
                Int32 unipuc = AHRMS1.usae.specupload.getuniid(ui, "spgetpucid");
                if (unipuc == 0)
                {
                    tablepuc.Visible = false;
                    tablepuc1.Visible = false;
                    btnviewimagepu.Enabled = false;
                    btndeleteimagepu.Enabled = false;
                    btndownloadpu.Enabled = false;
                    btnviewimagepu.ToolTip = "Image was not uploaded";
                    btndownloadpu.ToolTip = "Image was not uploaded";
                    btndeleteimagepu.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatuspuc", AHRMS1.usae.specupload.getuniid(uii2, "spgetpucid"));
                    if (a12)
                    {
                        viewimages("downloadpuc", AHRMS1.usae.specupload.getuniid(uii2, "spgetpucid"),A2);
                    }
                    else
                    {
                        tablepuc.Visible = false;
                        tablepuc1.Visible = false;
                        btnviewimagepu.Enabled = false;
                        btndeleteimagepu.Enabled = false;
                        btndownloadpu.Enabled = false;
                        btnviewimagepu.ToolTip = "Image was not uploaded";
                        btndownloadpu.ToolTip = "Image was not uploaded";
                        btndeleteimagepu.ToolTip = "Image was not uploaded";
                    }

                }
                Int32 uidip = AHRMS1.usae.specupload.getuniid(ui, "spgetdipid");
                if (uidip == 0)
                {
                    tabledip.Visible = false;
                    tabledip1.Visible = false;
                    btnviewimagediploma.Enabled = false;
                    btndeleteimagediploma.Enabled = false;
                    btndownloaddiploma.Enabled = false;
                    btnviewimagediploma.ToolTip = "Image was not uploaded";
                    btndeleteimagediploma.ToolTip = "Image was not uploaded";
                    btndownloaddiploma.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatusdip", AHRMS1.usae.specupload.getuniid(uii2, "spgetdipid"));
                    if (a12)
                    {
                        viewimages("downloaddip", AHRMS1.usae.specupload.getuniid(uii2, "spgetdipid"),A3);
                    }
                    else
                    {
                        tabledip.Visible = false;
                        tabledip1.Visible = false;
                        btnviewimagediploma.Enabled = false;
                        btndeleteimagediploma.Enabled = false;
                        btndownloaddiploma.Enabled = false;
                        btnviewimagediploma.ToolTip = "Image was not uploaded";
                        btndeleteimagediploma.ToolTip = "Image was not uploaded";
                        btndownloaddiploma.ToolTip = "Image was not uploaded";
                    }

                }
                Int32 uigrad = AHRMS1.usae.specupload.getuniid(ui, "spgetgradid");
                if (uigrad == 0)
                {
                    tablegrad.Visible = false;
                    tablegrad1.Visible = false;
                    btnviewimagegrad.Enabled = false;
                    btndeleteimagegrad.Enabled = false;
                    btndownloadgrad.Enabled = false;
                    btnviewimagegrad.ToolTip = "Image was not uploaded";
                    btndeleteimagegrad.ToolTip = "Image was not uploaded";
                    btndownloadgrad.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatusgrad", AHRMS1.usae.specupload.getuniid(uii2, "spgetgradid"));
                    if (a12)
                    {
                        viewimages("downloadgrad", AHRMS1.usae.specupload.getuniid(uii2, "spgetgradid"),A4);
                    }
                    else
                    {
                        tablegrad.Visible = false;
                        tablegrad1.Visible = false;
                        btnviewimagegrad.Enabled = false;
                        btndeleteimagegrad.Enabled = false;
                        btndownloadgrad.Enabled = false;
                        btnviewimagegrad.ToolTip = "Image was not uploaded";
                        btndeleteimagegrad.ToolTip = "Image was not uploaded";
                        btndownloadgrad.ToolTip = "Image was not uploaded";
                    }
                }
                Int32 uipg = AHRMS1.usae.specupload.getuniid(ui, "spgetpgid");
                if (uipg == 0)
                {
                    tablepg.Visible = false;
                    tablepg1.Visible = false;
                    btnviewimagepg.Enabled = false;
                    btndeleteimagepg.Enabled = false;
                    btndownloadpg.Enabled = false;
                    btnviewimagepg.ToolTip = "Image was not uploaded";
                    btndeleteimagepg.ToolTip = "Image was not uploaded";
                    btndownloadpg.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatuspg", AHRMS1.usae.specupload.getuniid(uii2, "spgetpgid"));
                    if (a12)
                    {
                        viewimages("downloadpg", AHRMS1.usae.specupload.getuniid(uii2, "spgetpgid"),A5);
                    }
                    else
                    {
                        tablepg.Visible = false;
                        tablepg1.Visible = false;
                        btnviewimagepg.Enabled = false;
                        btndeleteimagepg.Enabled = false;
                        btndownloadpg.Enabled = false;
                        btnviewimagepg.ToolTip = "Image was not uploaded";
                        btndeleteimagepg.ToolTip = "Image was not uploaded";
                        btndownloadpg.ToolTip = "Image was not uploaded";
                    }

                }
                Int32 uiadd = AHRMS1.usae.specupload.getuniid(uniqueid.ToString(), "spgetimaddproof");
                if (uiadd == 0)
                {
                    tableadd.Visible = false;
                    tableadd1.Visible = false;
                    btnviewimagepassport.Enabled = false;
                    btndeleteimagepassport.Enabled = false;
                    btndownloadpassport.Enabled = false;
                    btnviewimagepassport.ToolTip = "Image was not uploaded";
                    btndeleteimagepassport.ToolTip = "Image was not uploaded";
                    btndownloadpassport.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatusid", AHRMS1.usae.specupload.getuniid(AHRMS1.usae.specpersonusr.getuniid().ToString(), "spgetimidproof"));
                    if (a12)
                    {
                        viewimages("downloadid", AHRMS1.usae.specupload.getuniid(AHRMS1.usae.specpersonusr.getuniid().ToString(), "spgetimidproof"),A6);
                    }
                    else
                    {
                        tableadd.Visible = false;
                        tableadd1.Visible = false;
                        btnviewimagepassport.Enabled = false;
                        btndeleteimagepassport.Enabled = false;
                        btndownloadpassport.Enabled = false;
                        btnviewimagepassport.ToolTip = "Image was not uploaded";
                        btndeleteimagepassport.ToolTip = "Image was not uploaded";
                        btndownloadpassport.ToolTip = "Image was not uploaded";
                    }

                }
                Int32 uiid = AHRMS1.usae.specupload.getuniid(uniqueid.ToString(), "spgetimidproof");
                if (uiid == 0)
                {
                    tableid.Visible = false;
                    tableid1.Visible = false;
                    btnviewimagepancard.Enabled = false;
                    btndeleteimagepancaard.Enabled = false;
                    btndownloadpancard.Enabled = false;
                    btnviewimagepancard.ToolTip = "Image was not uploaded";
                    btndeleteimagepancaard.ToolTip = "Image was not uploaded";
                    btndownloadpancard.ToolTip = "Image was not uploaded";
                }
                else
                {
                    bool a12 = imagestatus("imgstatusadd", AHRMS1.usae.specupload.getuniid(AHRMS1.usae.specpersonusr.getuniid().ToString(), "spgetimaddproof"));
                    if (a12)
                    {
                        viewimages("downloadadd", AHRMS1.usae.specupload.getuniid(AHRMS1.usae.specpersonusr.getuniid().ToString(), "spgetimaddproof"),A7);
                    }
                    else
                    {
                        tableid.Visible = false;
                        tableid1.Visible = false;
                        btnviewimagepancard.Enabled = false;
                        btndeleteimagepancaard.Enabled = false;
                        btndownloadpancard.Enabled = false;
                        btnviewimagepancard.ToolTip = "Image was not uploaded";
                        btndeleteimagepancaard.ToolTip = "Image was not uploaded";
                        btndownloadpancard.ToolTip = "Image was not uploaded";
                    }
                }
            }
        }
        protected void btndownloadsslc_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
             downloadmages("downloadsslc", AHRMS1.usae.specupload.getuniid(ui, "spgetsslcid"));
        }

        public void downloadmages(string spname, Int32 id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter imgdata = new SqlParameter("@imgdata", SqlDbType.VarBinary, -1) { Direction = ParameterDirection.Output };
                SqlParameter imgnam = new SqlParameter("@imgname", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter imgty = new SqlParameter("@imgty", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(imgdata);
                cmd.Parameters.Add(imgnam);
                cmd.Parameters.Add(imgty);

                cmd.Parameters.AddWithValue("@id", id);

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
                Response.AddHeader("content-disposition", "attachment;filename=" + name+type);
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

        protected void btndownloadpu_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
            downloadmages("downloadpuc", AHRMS1.usae.specupload.getuniid(ui, "spgetpucid"));
        }

        protected void btndownloaddiploma_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
            downloadmages("downloaddip", AHRMS1.usae.specupload.getuniid(ui, "spgetdipid"));
        }

        protected void btndownloadgrad_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
            downloadmages("downloadgrad", AHRMS1.usae.specupload.getuniid(ui, "spgetgradid"));
        }

        protected void btndownloadpg_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
            downloadmages("downloadpg", AHRMS1.usae.specupload.getuniid(ui, "spgetpgid"));
        }

        protected void btndownloadpancard_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
            downloadmages("downloadid", AHRMS1.usae.specupload.getuniid(AHRMS1.usae.specpersonusr.getuniid().ToString(), "spgetimidproof"));
        }

        protected void btndownloadpassport_Click(object sender, ImageClickEventArgs e)
        {
            string ui = Label1.Text.ToString();
            downloadmages("downloadadd", AHRMS1.usae.specupload.getuniid(AHRMS1.usae.specpersonusr.getuniid().ToString(), "spgetimaddproof"));

        }

        public static bool deleteimage(string spname, string id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Int32 ra = dr.RecordsAffected;
                if (ra == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                   
                }
            }
            catch (Exception db)
            {
                String ss = db.Message.ToString();
                string sw = db.Source.ToString();
                string sddd = db.HResult.ToString();
                AHRMS1.usae.specpersonusr.errorlog(ss, sw, sddd);
             HttpContext.Current.Response.Redirect("~/error.aspx", true);
             return false;

            }

        }



        [WebMethod]
        public static int deleteRecord(string id1)
        {

            edituploaddoc ed = new edituploaddoc();
            int rv;
            int zero = 0;
            string id = HttpContext.Current.Session["userid"].ToString();
            if (id1 == "1")
            {
                bool ss = deleteimage("delsslc", AHRMS1.usae.specupload.getuniid(id, "spgetsslcid").ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {
                  
                    rv = 1 / zero;
                }
                return rv;
            }
            if (id1 == "2")
            {
                bool ss = deleteimage("delpuc", AHRMS1.usae.specupload.getuniid(id, "spgetpucid").ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {
                    
                    rv = 1 / zero;
                }
                return rv;
            }
            if (id1 == "3")
            {
                bool ss = deleteimage("deldip", AHRMS1.usae.specupload.getuniid(id, "spgetdipid").ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {
                    rv = 1 / zero;
                }
                return rv;
            }
            if (id1 == "4")
            {
                bool ss = deleteimage("delgrad", AHRMS1.usae.specupload.getuniid(id, "spgetgradid").ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {
                    rv = 1 / zero;
                }
                return rv;
            }
            if (id1 == "5")
            {
                bool ss = deleteimage("delpg", AHRMS1.usae.specupload.getuniid(id, "spgetpgid").ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {
                    rv = 1 / zero;
                }
                return rv;
            }
            if (id1 == "6")
            {
                bool ss = deleteimage("delid", AHRMS1.usae.specpersonusr.getuniid().ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {

                    rv = 1 / zero;
                }
                return rv;
            }
            if (id1 == "7")
            {
                bool ss = deleteimage("deladd", AHRMS1.usae.specpersonusr.getuniid().ToString());
                if (ss)
                {
                    ed.hidedetails(id1);
                    rv = 1 / 1;
                }
                else
                {
                    rv = 1 / zero;
                }
                return rv;
            }
            return 1;
        }

        public bool imagestatus(string spname, Int32 id)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                bool ss = dr.HasRows;
                return ss;
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

        public void viewimages(string spname, Int32 id, System.Web.UI.HtmlControls.HtmlAnchor sss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand(spname, con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter imgdata = new SqlParameter("@imgdata", SqlDbType.VarBinary, -1) { Direction = ParameterDirection.Output };
                SqlParameter imgnam = new SqlParameter("@imgname", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter imgty = new SqlParameter("@imgty", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(imgdata);
                cmd.Parameters.Add(imgnam);
                cmd.Parameters.Add(imgty);

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteScalar();

                byte[] img = (byte[])(imgdata.Value);
                string type = imgty.Value.ToString();
                string name = imgnam.Value.ToString().ToLower().Replace(".jpg", "").Replace(".png", "").Replace(".gif", "").Replace(".jpeg", ""); 
                string ty = type.Split('.')[1].ToLower();

                
 
                string base64String = Convert.ToBase64String(img, 0, img.Length);
                
                sss.HRef = "data:image/" + ty + ";base64," + base64String;
             

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

        public void hidedetails(string id2)
        {
            edituploaddoc ff = new edituploaddoc();
            Table tt = new Table();
            if (id2 == "1")
            {
              ff.tablesslc.Visible = false;
               ff.tablesslc1.Visible = false;
            }
            else if (id2 == "2")
            {
                ff.tablepuc.Visible = false;
                ff.tablepuc1.Visible = false;
            }
            else if (id2 == "3")
            {
                ff.tabledip.Visible = false;
                ff.tabledip1.Visible = false;
            }
            else if (id2 == "4")
            {
                ff.tablegrad.Visible = false;
                ff.tablegrad1.Visible = false;
            }
            else if (id2 == "5")
            {
                ff.tablepg.Visible = false;
                ff.tablepg1.Visible = false;
            }
            else if (id2 == "6")
            {
                ff.tableid.Visible = false;
                ff.tableid1.Visible = false;
            }
            else
            {
                ff.tableadd.Visible = false;
                ff.tableadd1.Visible = false;
            }
        }
    }
}