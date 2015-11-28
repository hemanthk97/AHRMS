<%@ Page Title="" Language="C#" MasterPageFile="~/ms/spehrpag.Master" AutoEventWireup="true" CodeBehind="spechrverdelpag.aspx.cs" Inherits="AHRMS1.ms.spechrverdelpag" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
              <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script src="js/html-qrcode.js"></script>
        <script src="js/jquery.min.js"></script>
        <script src="js/jquery.webcamqrcode.js"></script>
        <script src="js/jquery.webcamqrcode.min.js"></script>
        <script src="js/qrcode.js"></script>
         <link href="Hr.css" rel="stylesheet" />
        <script type="text/javascript">
             (function ($) {
                 $('document').ready(function () {
                     $('#<%= TextBox1.ClientID %>').hide();
                     $('#qrcodebox').WebcamQRCode({
                         onQRCodeDecode: function (p_data) {
                             $('#qrcode_result').html(p_data);
                             $('#<%= TextBox1.ClientID %>').hide();
                             $('#<%= TextBox1.ClientID %>').val(p_data);
                             $('#<%= TextBox1.ClientID %>').change();
                             $('#<%= TextBox1.ClientID %>').hide();
                             $find("m1").hide();

                         }
                     });
                 });
                 })(jQuery);
        </script>
        <div style="text-align: center;">
            <p style="color: green; font-size: 1.8em; text-decoration: underline; text-decoration-color: azure">Verify Candiate Documents</p>
        </div>
        <center>
        <asp:ImageButton ID="ImageButton3" Height="128px" Width="128px" ImageUrl="~/Images/checklist-128.png" runat="server"></asp:ImageButton>
         </center>
                        <cc1:modalpopupextender ID="ModalPopupExtender1" CancelControlID="hel" PopupControlID="Panel1" BehaviorID="m1"  TargetControlID="ImageButton3" BackgroundCssClass="modalBackground" runat="server"></cc1:modalpopupextender>
        <asp:Panel ID="Panel1" CssClass="modalPopup" align="center" style = "display:none" runat="server">
<button id="hel" data-dismiss="modal" style="text-align:right" class="close">X</button>
              <div style="width: 250px; height: 250px;padding-right: 0; padding-top: 0; padding-bottom: 0;" id="qrcodebox">
              </div>
            <br />
          
        </asp:Panel>

                             <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">   
                     <ProgressTemplate>
                         <center>
<div id="loader-wrapper" style="background-color:black;opacity:0.95;z-index:1000">
    <div id="loader" style="margin-right:100%;"></div>
</div>
                             </center>
                        </ProgressTemplate>
                    </asp:UpdateProgress> 
       
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <asp:Label ID="lab" runat="server" Font-Size="Larger" ForeColor="#dd7267" Font-Bold="true" Text=""></asp:Label>
                    </center>
 <asp:TextBox ID="TextBox1"  BorderStyle="None"  runat="server" Width="0px" Height="0px" OnTextChanged="answer1_TextChanged" ></asp:TextBox>
              
             
        <div>
        </div>
       
        <div id="verdelcol"   runat="server">
            <div class="personalcol">
                <center style="font-size:1.5em;">
                <span style="color:green">Below is the details of <asp:Label ID="lblverdelusrname" ForeColor="Purple" runat="server" Text="Label"></asp:Label> </span>
               </center>
                     <br />
                <br />
                <table style="margin-left: 10%; background-color: white;text-align:center">

                    <tr class="tdv" style="background-color: white">
                        <td class="tdv" style="background-color: white; padding: 8px">Details</td>
                        <td class="tdv" style="background-color: white; padding: 8px">Verification</td>
                        <td class="tdv" style="background-color: white; padding: 8px">Verified BY</td>
                        <td class="tdv" style="background-color: white; padding: 8px">Comments</td>
                    </tr>


                    <tr class="tdv" style="background-color: white">
                        <td class="tdv" style="background-color: white; padding: 8px">10th/SSLC</td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:DropDownList ID="dd10verdel"  CssClass="textbox1" runat="server">
                                <asp:ListItem Text="NA" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Verified" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Not Verified" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Not Genuine" Value="3"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:Label ID="lbl10verdel" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:TextBox ID="txt10verdel" CssClass="textbox1" Height="50px"  TextMode="MultiLine" Wrap="true" Font-Size="Small" runat="server"></asp:TextBox>
                            <asp:Label ID="upsslc" runat="server" ></asp:Label>
                              </td>
                    </tr>
                    <tr class="tdv" style="background-color: white">
                        <td class="tdv" style="background-color: white; padding: 8px">12th/PU</td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:DropDownList ID="ddpuverdel" CssClass="textbox1" runat="server">
                                <asp:ListItem Text="NA" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Verified" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Not Verified" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Not Genuine" Value="3"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:Label ID="lblpuverdel" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:TextBox ID="txtpuverdel" CssClass="textbox1" Height="50px" TextMode="MultiLine" Wrap="true" Font-Size="Small" runat="server"></asp:TextBox>
                        <asp:Label ID="uppuc" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr class="tdv" style="background-color: white">
                        <td class="tdv" style="background-color: white; padding: 8px">Diploma</td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:DropDownList ID="dddipveredel" CssClass="textbox1" runat="server">
                                <asp:ListItem Text="NA" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Verified" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Not Verified" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Not Genuine" Value="3"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:Label ID="lbldipveredel" runat="server"  Text="Label"></asp:Label>
                        </td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:TextBox ID="txtdipveredel" CssClass="textbox1" Height="50px" TextMode="MultiLine" Wrap="true" Font-Size="Small" runat="server"></asp:TextBox>
                       <asp:Label ID="updip" runat="server" ></asp:Label>
                             </td>
                    </tr>
                    <tr class="tdv" style="background-color: white">
                        <td class="tdv" style="background-color: white; padding: 8px">Graduation</td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:DropDownList ID="ddgradverdel" CssClass="textbox1" runat="server">
                                <asp:ListItem Text="NA" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Verified" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Not Verified" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Not Genuine" Value="3"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:Label ID="lblgradverdel" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:TextBox ID="txtgradverdel" CssClass="textbox1" Height="50px" TextMode="MultiLine" Wrap="true" Font-Size="Small" runat="server"></asp:TextBox>
                        <asp:Label ID="upgrad" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr class="tdv" style="background-color: white">
                        <td class="tdv" style="background-color: white; padding: 8px">Post Graduation</td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:DropDownList ID="ddpgverdel" CssClass="textbox1" runat="server">
                                <asp:ListItem Text="NA" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Verified" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Not Verified" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Not Genuine" Value="3"></asp:ListItem>
                            </asp:DropDownList></td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:Label ID="lblpgverdel" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="tdv" style="background-color: white; padding: 8px">
                            <asp:TextBox ID="txtpgverdel" CssClass="textbox1" Height="50px" TextMode="MultiLine" Wrap="true" Font-Size="Small" runat="server"></asp:TextBox>
                        <asp:Label ID="uppg" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr class="tdv"  style="background-color: white;border:none">
                        <td  class="tdv" colspan="5" style="background-color: white; padding: 8px;border:none;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                              
                                    <asp:Button ID="updateverdelusr" CssClass="btn btn-primary" Width="100px" runat="server" Text="update" OnClick="updateverdelusr_Click" />
                         <asp:Button ID="refresh" CssClass="btn btn-danger" Width="100px" runat="server" Text="clear" OnClick="refresh_Click" />
                                </ContentTemplate>
                                    </asp:UpdatePanel>
                                 </td>
                    </tr>
                </table>
            </div>
        </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
<br />
         <br />
         <br />
         <br />

         <br />

    </form>
</asp:Content>
