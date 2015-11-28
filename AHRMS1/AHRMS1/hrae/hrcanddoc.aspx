<%@ Page Title="" Language="C#" MasterPageFile="~/ms/spehrpag.Master" AutoEventWireup="true" CodeBehind="hrcanddoc.aspx.cs" Inherits="AHRMS1.ms.WebForm4" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server">
      
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <script src="js/html-qrcode.js"></script>
        <script src="js/jquery.min.js"></script>
        <script src="js/jquery.webcamqrcode.js"></script>
        <script src="js/jquery.webcamqrcode.min.js"></script>
        <script src="js/qrcode.js"></script>
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

                    $('#btn_start').click(function () {
                        $('#qrcodebox').WebcamQRCode().start();
                    });

                    $('#btn_stop').click(function () {
                        $('#qrcodebox').WebcamQRCode().stop();
                    });
                });
            })(jQuery);
        </script>
        <link href="Hr.css" rel="stylesheet" />
    <div style="text-align:center;">
<p style="color:green;font-size:1.8em;text-decoration:underline;text-decoration-color:azure">Candidate Details And Documents</p>
    <br />
        <p style="color:#cf4132;font-size:1.8em;text-decoration-color:azure" >Click on QR Code to scan</p>    
    </div>

        <center>
        <asp:ImageButton ID="Scandetails" ImageUrl="~/hrae/qr_code-128.png"  Height="90px" Width="90px" runat="server" />
        </center>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" CancelControlID="hel" PopupControlID="Panel1" BehaviorID="m1"  TargetControlID="Scandetails" BackgroundCssClass="modalBackground" runat="server"></cc1:ModalPopupExtender>
        <asp:Panel ID="Panel1" CssClass="modalPopup" align="center" style = "display:none" runat="server">
       <button id="hel" data-dismiss="modal" style="text-align:right" class="close">X</button>
               <div style="width: 250px; height: 250px;padding-right: 0; padding-top: 0; padding-bottom: 0;" id="qrcodebox">
              </div>
            <br />
                        
            
        </asp:Panel>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate> 
                      <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                        <ProgressTemplate>
<div id="loader-wrapper" style="background-color:black;opacity:0.95;z-index:1000">
    <div id="loader"></div>
</div>
                        </ProgressTemplate>
                    </asp:UpdateProgress> 
                    <br />
                    <div style="text-align:center">
                    <span style="font-size:1.5em; color:red;margin-left:10%">
                      <asp:Label ID="lblviewdelsuccessstate"  Font-Size="Larger" ForeColor="#dd7267" Font-Bold="true" runat="server" Text=""></asp:Label>
                         <asp:Label ID="nameuser"  Font-Size="Larger" Font-Underline="true" ForeColor="#4378a7"  Font-Bold="true" runat="server" ></asp:Label>
                    </span>   
                    <asp:TextBox ID="TextBox1" BorderStyle="None" AutoPostBack="true" Width="0px" runat="server" OnTextChanged="TextBox1_TextChanged1"></asp:TextBox>
                    </div>
                   
                        <div id="hrviewcanddel" style="text-align:center" runat="server" >
            
            <span style="text-decoration:underline; font-size: 2em;color:#49d149">Below is the details of <asp:Label ID="lblverdelusrname" runat="server" Text="Label"></asp:Label> </span>
                <br />
        <div class="personcol" style="width:80%;height:70%; padding-left:2% ; text-align:start; padding-right:5%;">
            
            <br />
                <ol style="border-bottom: 0.2em double grey;">
                    <li style="text-align:center"><span class="dipover" style="font-size: 1.3em; text-align:center; "><a id="A1" class="hvr-underline-from-center" style="color:black;text-decoration:none" onclick="$('#HHH').slideToggle(800);; return true;"  runat="server">Candiate personal Details</a></span></li>
                </ol>
                <div id="HHH" >
                    <table class="zui-table zui-table-horizontal zui-table-highlight" style="margin:0 auto 0 auto">
                        <tr>
                            <td colspan="2" style="text-align: center; background-color: #e9b5b5; font-weight: bold">Personal Details</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Name</td>
                            <td>
                                <asp:Label ID="lblnameview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Father Name</td>
                            <td>
                                <asp:Label ID="lblfathernameview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Date of birth</td>
                            <td>
                                <asp:Label ID="lbldobmonthview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Gender</td>
                            <td>
                                <asp:Label ID="lblgenderview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">State</td>
                            <td>
                                <asp:Label ID="lblstateview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">City</td>
                            <td>
                                <asp:Label ID="lblcityview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Pincode</td>
                            <td>
                                <asp:Label ID="lblpincodeview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Address</td>
                            <td>
                                <asp:Label ID="lbladdressview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Contact Number</td>
                            <td>
                                <asp:Label ID="lblcontactview" runat="server" Text="Not Available"></asp:Label></td>
                        </tr>
                    </table>
                    <ol style="border-bottom: 0.2em double grey;">
                        <br />
                        <li><span class="dipover" style="font-size: 1.3em; color: white"><a id="A4" class="hvr-underline-from-center diploma" style="color:black;text-decoration:none" onclick="$('#HHH').slideToggle(800);; return true;" runat="server">Go Back</a></span></li>
                    </ol>
                </div>
                <br />
                <br />
                <div>
                    <ol style="border-bottom: 0.2em double grey; margin-bottom: 50px">
                        <li style="text-align:center"><span class="dipover" style="font-size: 1.3em; color: grey"><a id="A2" class="hvr-underline-from-center diploma" style="color:black;text-decoration:none" onclick="$('#verifyeducationdetails').slideToggle(800);; return true;" runat="server">Candiate education details</a></span></li>
                    </ol>
                </div>
                <div id="verifyeducationdetails" style="display: none">
                 <table class="zui-table zui-table-horizontal zui-table-highlight" style="margin:0 auto 0 auto">
                        <tr>
                            <td colspan="2" style="text-align: center; background-color: #e9b5b5; font-weight: bold">10th/SSLC</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">School Name</td>
                            <td>
                                <asp:Label ID="lblverschoolname" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Location</td>
                            <td>
                                <asp:Label ID="lblverlocation" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Year Completed</td>
                            <td>
                                <asp:Label ID="lblveryearcompleted" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">Board</td>
                            <td>
                                <asp:Label ID="lblverboard" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Percentage</td>
                            <td>
                                <asp:Label ID="lblverpercentage" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Grade</td>
                            <td>
                                <asp:Label ID="lblvergrade" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center; background-color: #e9b5b5; font-weight: bold">12th/PU</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">College Name</td>
                            <td>
                                <asp:Label ID="lblverpuname" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Location</td>
                            <td>
                                <asp:Label ID="lblverpulocation" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Year Completed</td>
                            <td>
                                <asp:Label ID="lblverpuyercompleted" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">Board</td>
                            <td>
                                <asp:Label ID="lblverpuboard" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Percentage</td>
                            <td>
                                <asp:Label ID="lblverpupercentage" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Grade</td>
                            <td>
                                <asp:Label ID="lblverpugrade" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center; background-color: #e9b5b5; font-weight: bold">Diploma</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Course Type</td>
                            <td>
                                <asp:Label ID="lblvercoursetypediploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">University</td>
                            <td>
                                <asp:Label ID="lblveruniversitydiploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">College Name</td>
                            <td>
                                <asp:Label ID="lblvercollegenamediploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Specialization</td>
                            <td>
                                <asp:Label ID="lblverspecializationdiploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">University Register Number</td>
                            <td>
                                <asp:Label ID="lblveruniregnumdiploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Start Date</td>
                            <td>
                                <asp:Label ID="lblverstartdatediploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">End Date</td>
                            <td>
                                <asp:Label ID="lblverenddatediploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Percentage</td>
                            <td>
                                <asp:Label ID="lblverpercentagediploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Grade</td>
                            <td>
                                <asp:Label ID="lblvergradediploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center; background-color: #e9b5b5; font-weight: bold">Graduation</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Course Type</td>
                            <td>
                                <asp:Label ID="lblvercoursegrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Degree</td>
                            <td>
                                <asp:Label ID="lblverdegreegrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">University</td>
                            <td>
                                <asp:Label ID="lblveruniversitygrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">College Name</td>
                            <td>
                                <asp:Label ID="lblvercollegegrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Specialization</td>
                            <td>
                                <asp:Label ID="lblverspecializationgrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">University Register Number</td>
                            <td>
                                <asp:Label ID="lblveruniregnumgrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Start Date</td>
                            <td>
                                <asp:Label ID="lblverstartgrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">End Date</td>
                            <td>
                                <asp:Label ID="lblverendgrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Percentage</td>
                            <td>
                                <asp:Label ID="lblverpercentagegrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Grade</td>
                            <td>
                                <asp:Label ID="lblvergradegrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center; background-color: #e9b5b5; font-weight: bold">Post Graduation</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Course Type</td>
                            <td>
                                <asp:Label ID="lblvercoursepg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Degree</td>
                            <td>
                                <asp:Label ID="lblverdegreepg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">University</td>
                            <td>
                                <asp:Label ID="lblveruniversitypg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">College Name</td>
                            <td>
                                <asp:Label ID="lblvercollegenamepg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Specialization</td>
                            <td>
                                <asp:Label ID="lblverspecilizationpg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">University Register Number</td>
                            <td>
                                <asp:Label ID="lblveruniregnumpg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Start Date</td>
                            <td>
                                <asp:Label ID="lblverstartpg" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">End Date</td>
                            <td>
                                <asp:Label ID="lblverendpg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Percentage</td>
                            <td>
                                <asp:Label ID="lblverpercentagepg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Grade</td>
                            <td>
                                <asp:Label ID="lblvergradepg" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                    </table>
                    <ol style="border-bottom: 0.2em double grey;">
                        <li><span class="dipover" style="font-size: 1.3em; color: grey"><a id="A5" class="hvr-underline-from-center diploma" style="color:black;text-decoration:none" onclick="$('#verifyeducationdetails').slideToggle(800);; return true" runat="server">Go Back</a></span></li>
                    </ol>
                </div>
                <div>
                    <ol style="border-bottom: 0.2em double grey; margin-bottom: 50px">
                        <li style="text-align:center"><span class="dipover" style="font-size: 1.3em; color: grey"><a id="A6" class="hvr-underline-from-center diploma" style="color:black;text-decoration:none" onclick="$('#documentveridet').slideToggle(800);; return true;" runat="server">Verified Details By Previous Employer</a></span></li>
                    </ol>
                </div>
                <div id="documentveridet" style="display:none">
                    <table class="zui-table zui-table-horizontal zui-table-highlight" style="margin:0 auto 0 auto">

                        <tr>
                            <td style=" background-color: #e9b5b5; font-weight: bold">Details</td>
                            <td style=" background-color: #e9b5b5; font-weight: bold">Verifiction</td>
                            <td style=" background-color: #e9b5b5; font-weight: bold">Verrified BY</td>
                            <td style=" background-color: #e9b5b5; font-weight: bold">Comments</td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">10th/SSLC</td>
                            <td>
                                <asp:Label ID="lbldocversslc" runat="server" Text="Not Verified"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldocverbysslc" runat="server" Text="NA"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldoccommsslc" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">12th/PU</td>
                            <td>
                                <asp:Label ID="lbldocverpu" runat="server" Text="Not Verified"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldocverbypu" runat="server" Text="NA"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldoccompu" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Diploma</td>
                            <td>
                                <asp:Label ID="lbldocverdiploma" runat="server" Text="Not Verified"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldocverbydiploma" runat="server" Text="NA"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldoccomdiploma" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                        <tr>
                            <td style="font-weight: bold">Graduation</td>
                            <td>
                                <asp:Label ID="lbldocvergrad" runat="server" Text="Not Verified"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldocverbygard" runat="server" Text="NA"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldoccomgrad" runat="server" Text="NA"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="font-weight: bold">Post Graduation</td>
                            <td>
                                <asp:Label ID="lbldocverpg" runat="server" Text="Not Verified"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldocverbypg" runat="server" Text="NA"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbldoccompg" runat="server" Text="NA"></asp:Label></td>
                        </tr>

                    </table>
                    <ol style="border-bottom: 0.2em double grey; margin-bottom: 50px">
                        <li><span class="dipover" style="font-size: 1.3em; color: grey"><a id="A7" class="hvr-underline-from-center diploma" style="color:black;text-decoration:none" onclick="$('#documentveridet').slideToggle(800);; return true;" runat="server">Go Back</a></span></li>
                    </ol>

                </div>
                 <div>
                    <ol style="border-bottom: 0.2em double grey; margin-bottom: 50px">
                        <li style="text-align:center"><span  style="font-size: 1.3em; color: grey">
                           Download candiate Documents</span></li>
                    </ol>
                     <table class="zui-table zui-table-horizontal zui-table-highlight" style="margin:0 auto 0 auto">
                         <tr>
                             <td style="text-align: center; background-color: #e9b5b5; font-weight: bold" colspan="2">Download ID / Address Proof</td>
                         </tr>
                         <tr>
                             <td >Pan Card / ID Proof</td>
                             <td >
                                 <asp:ImageButton ID="downloadid" ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloadid_Click" /></td>
                         </tr>
                         <tr >
                             <td >Passport / Address Proof</td>
                             <td >
                                 <asp:ImageButton ID="downloadadd" ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloadadd_Click" /></td>
                         </tr>
                         <tr >
                           <td style="text-align: center; background-color: #e9b5b5; font-weight: bold" colspan="2">Download Qualification Documents</td> 
                          </tr>
                         <tr>
                             <td >10th / SSLC</td>
                             <td >
                                 <asp:ImageButton ID="downloadsslc"  ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloadsslc_Click" /></td>
                         </tr>
                         <tr>
                             <td>PU / 12th</td>
                             <td>
                                 <asp:ImageButton ID="downloadpu" ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloadpu_Click" /></td>
                         </tr>
                         <tr>
                             <td>Diploma</td>
                             <td>
                                 <asp:ImageButton ID="downloaddiploma" ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloaddiploma_Click" /></td>
                         
                         </tr>
                         <tr>
                             <td>Graduation</td>
                             <td>
                                 <asp:ImageButton ID="downloadgraduation" ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloadgraduation_Click" /></td>
                         </tr>
                         <tr>
                             <td>Post Graduation</td>
                             <td>
                                 <asp:ImageButton ID="downloadpost" ImageUrl="~/fonts/1427980107_download-32.png" Height="32" Width="32" runat="server" OnClick="downloadpost_Click" /></td>
                         </tr>
                     </table>
                </div>
          
 <br />
            <center>
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary2" Width="60px" Text="Clear" OnClick="Button1_Click" />
            </center>
            <br />
                </div>
                            
   </div>
                       <center>         
<table id="viewnot" class="zui-table zui-table-horizontal zui-table-highlight" style="background-color:white" runat="server">
                <tr >
                    <td style="font-weight:bolder">UserID</td>
                    <td >
                        <asp:Label ID="addexperuserid"  runat="server"></asp:Label></td>
                </tr>
                <tr >
                    <td style="font-weight:bolder">Company Worked For</td>
                    <td>
                        <asp:Label ID="addexpcompname"  runat="server" ></asp:Label></td>
                </tr>
                <tr >
                    <td style="font-weight:bolder" >Company Location</td>
                    <td >
                        <asp:Label ID="addexpcomploc"  runat="server"></asp:Label></td>
                </tr>
                 <tr>

                    <td style="font-weight:bolder;border-left:thick" >Employee Designation</td>
                    <td >
                        <asp:Label  ID="empdesg" runat="server" ></asp:Label>
                            </td>
 </tr>

                <tr>

                    <td style="font-weight:bolder">From</td>
                    <td >
                        <asp:Label  ID="addexpfrdate"  runat="server" ></asp:Label>
                    </td>
 </tr>
                <tr>
                    <td style="font-weight:bolder">To</td>
                    <td ><asp:Label  ID="addexpenddate"   runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight:bolder">Skills</td>
                    <td>
                        <asp:TextBox ID="addexpskills1" TextMode="MultiLine" BorderStyle="None" Rows="8" wrap="true" ReadOnly="true" BorderWidth="0" runat="server"></asp:TextBox>
                     </td>
                        </tr>
                <tr>
                    <td style="font-weight:bolder">Candidate Rating</td>
                    <td>
               <asp:Label ID="ratingvalue" Font-Size="XX-Large" runat="server"  ></asp:Label><asp:Label ID="kk" Font-Size="XX-Large" runat="server">/</asp:Label><span style="color:green;font-size:large"> 5</span>
                    </td>
                </tr>
                <tr>
                    <td style="font-weight:bolder">Comments</td>
                    <td>
                        <asp:TextBox ID="addexpcomm1" TextMode="MultiLine" BorderStyle="None" Rows="8" wrap="true" ReadOnly="true" BorderWidth="0" runat="server"></asp:TextBox>
                        </td>
                        </tr>
                <tr>
                    <td style="background-color:white" colspan="2">
                       <center>
              
                        <asp:Button ID="Button3" CssClass="btn btn-primary2" runat="server" Width="70px" Text="Clear" OnClick="Button3_Click"  />
                                </center>      
                    </td>
                </tr>
            </table>
       </center>
        </ContentTemplate>
            </asp:UpdatePanel>
                </form>
</asp:Content>
