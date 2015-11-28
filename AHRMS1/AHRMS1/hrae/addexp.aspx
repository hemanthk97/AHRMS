<%@ Page Title="" Language="C#" MasterPageFile="~/ms/spehrpag.Master" AutoEventWireup="true" CodeBehind="addexp.aspx.cs" Inherits="AHRMS1.ms.WebForm5" %>

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




        <div>
            <p style="text-align: center; color: blue; font-size: 2em; text-decoration: underline">Add Experience details for candiate</p>

        </div>
        <center>
        <p id="note" style="text-align:left">
           <img src="../Images/1435946368_circle_green.png" style="height:10px ;width:10px" /> On successful insertion of experience details <br />
           <img src="../Images/1435946368_circle_green.png" style="height:10px ;width:10px" /> A QR code will be download on to your system <br />
           <img src="../Images/1435946368_circle_green.png"  style="height:10px ;width:10px"   /> Please the  print specific Qr Code at back of the candiate Experince letter 
           </p>
            </center>
        <br />
        <center>
       
            <asp:ImageButton ID="ImageButton3" Height="128px" Width="128px" ImageUrl="~/Images/1435947044_data_recovery.png" runat="server"></asp:ImageButton>
             
         
        </center>
        <br />
        <center>

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
            <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">   
                     <ProgressTemplate>
                         <center>
<div id="loader-wrapper" style="background-color:black;opacity:0.95;z-index:1000">
    <div id="loader" style="margin-right:100%;"></div>
</div>
                             </center>
                        </ProgressTemplate>
                    </asp:UpdateProgress> 
                    <br />

                    <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <center>
                        <asp:Label ID="lab" runat="server" Font-Size="Larger" ForeColor="#dd7267" Font-Bold="true" Text=""></asp:Label>
                    </center>
 <asp:TextBox ID="TextBox1" AutoPostBack="true"  BorderStyle="None" runat="server" Width="0px" Height="0px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
              </ContentTemplate>
            </asp:UpdatePanel>
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                          <table id="viewnot" style="background-color:white" runat="server">
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">UserID</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox ID="addexperuserid" Enabled="false" CssClass="textbox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">Company Worked For</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox ID="addexpcompname" CssClass="textbox1" runat="server" Enabled="false"></asp:TextBox></td>
                </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">Company Location</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox ID="addexpcomploc" CssClass="textbox1" Enabled="false" runat="server"></asp:TextBox></td>
                </tr>
                 <tr class="tdv" style="background-color:white">

                    <td class="tdv" style="background-color:white;padding:10px">Employee Designation</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox CssClass="textbox1" ID="empdesg" EnableViewState="false"   runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="add" runat="server" Text="Please Enter desgination" ForeColor="Red" Display="Dynamic" ControlToValidate="empdesg" ErrorMessage="Please Enter desgination"></asp:RequiredFieldValidator>
                    </td>
 </tr>

                <tr class="tdv" style="background-color:white">

                    <td class="tdv" style="background-color:white;padding:10px">From</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox CssClass="textbox1" ID="addexpfrdate"   AutoPostBack="true"    TextMode="DateTime"  OnTextChanged="addexpfrdate_TextChanged1" runat="server" ></asp:TextBox><asp:ImageButton ID="ImageButton1" ImageUrl="~/hrae/1434648033_calendar.png" Height="20px" Width="20px" runat="server"></asp:ImageButton>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="Please select date" ValidationGroup="add" ForeColor="Red" Display="Dynamic" ControlToValidate="addexpfrdate" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton1"  TargetControlID="addexpfrdate" Format="dd/MM/yyyy"   runat="server"></cc1:CalendarExtender>

                    </td>
 </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">To</td>
                    <td class="tdv" style="background-color:white;padding:10px"><asp:TextBox CssClass="textbox1"   TextMode="DateTime" ID="addexpenddate"   runat="server"></asp:TextBox><asp:ImageButton ID="ImageButton2" ImageUrl="~/hrae/1434648033_calendar.png" Height="20px" Width="20px" runat="server"></asp:ImageButton>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="add" Text="Please select date" ForeColor="Red" Display="Dynamic" ControlToValidate="addexpenddate" ErrorMessage="Please select date"></asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2"  PopupButtonID="ImageButton2" TargetControlID="addexpenddate" Format="dd/MM/yyyy" runat="server"></cc1:CalendarExtender>

                    </td>
                </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">Skills</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox ID="addexpskills" TextMode="MultiLine" Wrap="true" EnableViewState="false" cssClass="textbox1" Height="50px" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">Candidate Rating</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                <asp:DropDownList ID="DropDownList1"  Width="70px" CssClass="textbox1" runat="server">
                    <asp:ListItem Text="0.5" Value="1" ></asp:ListItem>
                    <asp:ListItem Text="1" Value="2"></asp:ListItem>
                    <asp:ListItem Text="1.5" Value="3"></asp:ListItem>
                    <asp:ListItem Text="2" Value="4"></asp:ListItem>
                    <asp:ListItem Text="2.5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="3" Value="6"></asp:ListItem>
                    <asp:ListItem Text="3.5" Value="7"></asp:ListItem>
                    <asp:ListItem Text="4" Value="8"></asp:ListItem>
                    <asp:ListItem Text="4.5" Value="9"></asp:ListItem>
                    <asp:ListItem Text="5" Value="10"></asp:ListItem>
                </asp:DropDownList><span style="font-size:2.3em">  /</span><strong style="font-size:1.8em">5</strong>
                    </td>
                </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px">Comments</td>
                    <td class="tdv" style="background-color:white;padding:10px">
                        <asp:TextBox ID="addexpcomm" CssClass="textbox1" Height="50px" EnableViewState="false" TextMode="MultiLine" Wrap="true" runat="server"></asp:TextBox></td>
                </tr>
                <tr class="tdv" style="background-color:white">
                    <td class="tdv" style="background-color:white;padding:10px" colspan="2">
                        <center>
                        <asp:Button ID="btnaddexp" CssClass="btn btn-primary"  ValidationGroup="add" runat="server" Width="150px" Text="Add Experience" OnClick="btnaddexp_Click" />
                        <asp:Label ID="lbladdexpsucess" runat="server" Text="Label"></asp:Label>
                  
                        <asp:Button ID="Button3" CssClass="btn btn-primary2" runat="server" Width="70px" Text="Clear" OnClick="Button3_Click" />
                                </center>      
                    </td>
                </tr>
            </table>
                    
       </ContentTemplate>
            </asp:UpdatePanel>
        </center>
            
    </form>
</asp:Content>
