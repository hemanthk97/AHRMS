<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ms/specusrmas.Master" CodeBehind="edituploaddoc.aspx.cs" Inherits="AHRMS1.ms.edituploaddoc" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="Form1" runat="server">

               <script src="../usae/jquery.fancybox.js"></script>
         <link href="../usae/jquery.fancybox.css" rel="stylesheet" />
           <script>
               $(document).ready(function () {
                   $('#dddd').hide();
                   return false;
               });

               $(document).ready(function () {

                   $(".fancybox").fancybox();

               });

               function Confirmbox(no1) {


                   smoke.confirm("Are you sure wanna delete this file?", function (e) {
                       if (e) {

                           $.ajax({
                               type: "POST",
                               url: "http://localhost:61438/usae/edituploaddoc.aspx/deleteRecord",
                               data: "{id1:'" + no1 + "'}",
                               contentType: "application/json; charset=utf-8",
                               datatype: "jsondata",
                               async: "true",
                               success: function (serverResponse) {
                                   //=== rebind data to remove delete record from the table.
                                   smoke.alert('File successfully deleted');

                               },
                               error: function (serverResponse) {
                                   smoke.alert('File already deleted');
                               }
                           });

                       }

                       else {
                           smoke.alert('Deletion cancelled');
                       }
                   }, {
                       ok: "Yep",
                       cancel: "Nope",
                       classname: "custom-class",
                       reverseButtons: true
                   });

               }
    </script>

       
   
        <div class="clearfix">
            <br />
            <div style="margin-top: 1%; margin-left: 10%; margin-bottom: 1%; padding: 0 0 0 0; font-size: 1.5em; color: Green">
                <p style="text-align:center">View Uploaded Documents</p>
                <p style="text-align:center">If not valid delete and upload again</p>
                <asp:Label ID="Label1" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Label ID="Label2" runat="server" Visible="false" Text=""></asp:Label>
            </div>
            
                <table class="zui-table zui-table-horizontal zui-table-highlight" style="height: 500px;margin-left:20%; width: 800px">
                    <tr >
                        <td  style="text-align:center;font-weight:bold;font-size:1.5em;" colspan="2">Documents</td>
                    </tr>
                    <tr >
                        <td id="tablesslc" runat="server" style="font-size:1.2em" >10th/SSLC Marks Card</td>
                        <td id="tablesslc1" runat="server">
                           
                           <a class="fancybox" rel="group" id="A11" runat="server" ><asp:ImageButton ID="btnviewimagesslc" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" OnClientClick="Confirmbox(1); return false" Width="20px" ToolTip="Delete" ImageUrl="~/fonts/1427980039_delete-32.png" ID="btndeleteimagesslc" runat="server"/>
                            <asp:ImageButton ID="btndownloadsslc" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloadsslc_Click" />
                       
                                    </td>
                    </tr>
                    <tr >
                        <td id="tablepuc" runat="server" style="font-size:1.2em" >12th/PU Marks Card</td>
                        <td id="tablepuc1" runat="server">
                           <a class="fancybox" rel="group" id="A2" runat="server"><asp:ImageButton ID="btnviewimagepu" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" Width="20px" OnClientClick="Confirmbox(2); return false" ToolTip="Delete" ImageUrl="~/fonts/1427980039_delete-32.png" ID="btndeleteimagepu" runat="server" />
                            <asp:ImageButton ID="btndownloadpu" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloadpu_Click" />
                        </td>
                    </tr>
                    <tr >
                        <td id="tabledip" runat="server" style="font-size:1.2em" >Diploma Marks Card</td>
                        <td id="tabledip1" runat="server">
                           <a class="fancybox" rel="group" id="A3" runat="server"  href=""> <asp:ImageButton ID="btnviewimagediploma" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" Width="20px" OnClientClick="Confirmbox(3); return false" ToolTip="Delete" ImageUrl="~/fonts/1427980039_delete-32.png" ID="btndeleteimagediploma" runat="server" />
                            <asp:ImageButton ID="btndownloaddiploma" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloaddiploma_Click" />
                        </td>
                    </tr>
                    <tr >
                        <td id="tablegrad" runat="server" style="font-size:1.2em">Graduation Marks Card</td>
                        <td id="tablegrad1" runat="server">
                           <a class="fancybox" rel="group" id="A4" runat="server"  href=""> <asp:ImageButton ID="btnviewimagegrad" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" Width="20px" ToolTip="Delete" OnClientClick="Confirmbox(4); return false" ImageUrl="~/fonts/1427980039_delete-32.png" ID="btndeleteimagegrad" runat="server" />
                            <asp:ImageButton ID="btndownloadgrad" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloadgrad_Click" />
                        </td>
                    </tr>
                    <tr >
                        <td id="tablepg" runat="server" style="font-size:1.2em" >Post Graduation Marks Card</td>
                        <td id="tablepg1" runat="server">
                           <a class="fancybox" rel="group" id="A5" runat="server"  href=""> <asp:ImageButton ID="btnviewimagepg" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" Width="20px" ToolTip="Delete" OnClientClick="Confirmbox(5); return false" ImageUrl="~/fonts/1427980039_delete-32.png" ID="btndeleteimagepg" runat="server" />
                            <asp:ImageButton ID="btndownloadpg" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloadpg_Click" />
                        </td>
                    </tr>
                    <tr >
                        <td id="tableid" runat="server" style="font-size:1.2em" >Pan Card/Other ID Proof</td>
                        <td id="tableid1" runat="server">
                            <a class="fancybox" rel="group" id="A6" runat="server"  href=""><asp:ImageButton ID="btnviewimagepancard" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" Width="20px" ToolTip="Delete" ImageUrl="~/fonts/1427980039_delete-32.png" OnClientClick="Confirmbox(6); return false" ID="btndeleteimagepancaard" runat="server" />
                            <asp:ImageButton ID="btndownloadpancard" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloadpancard_Click" />
                        </td>
                    </tr>
                    <tr >
                        <td id="tableadd" runat="server" style="font-size:1.2em" >Passport/Other Address Proof</td>
                        <td id="tableadd1" runat="server">
                           <a class="fancybox" rel="group" id="A7" runat="server"  href=""> <asp:ImageButton ID="btnviewimagepassport" ToolTip="View" Height="20px" Width="20px" ImageUrl="~/fonts/1427980160_eye-32.png" runat="server" /></a>
                            <asp:ImageButton Height="20px" Width="20px" ToolTip="Delete" ImageUrl="~/fonts/1427980039_delete-32.png" ID="btndeleteimagepassport" OnClientClick="Confirmbox(7); return false" runat="server" />
                            <asp:ImageButton ID="btndownloadpassport" ToolTip="Download" ImageUrl="~/fonts/1427980107_download-32.png" Height="20px" Width="20px" runat="server" OnClick="btndownloadpassport_Click" />
                        </td>
                    </tr>
                </table>
            
            <span class="dipover" style="font-size: 1.3em; color: Gray; margin-left: 20%; margin-bottom: 2%">
                <asp:HyperLink ID="A1" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:HyperLink></span>
        </div>

    </form>

</asp:Content>
