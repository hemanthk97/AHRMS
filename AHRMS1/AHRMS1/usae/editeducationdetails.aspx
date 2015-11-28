<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ms/specusrmas.Master" CodeBehind="editeducationdetails.aspx.cs" Inherits="AHRMS1.editeducationdetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            $('#dddd').hide();;
            return false;
        });
    </script>
    <style>
         .completionListElement 
{  
    visibility : hidden; 
    margin : 0px! important; 
    background-color : inherit; 
    color : black; 
    border : solid 1px gray; 
    cursor : pointer; 
    text-align : left; 
    list-style-type : none; 
    font-family: 'Roboto Slab'; 
    font-size: 11px; 
    padding : 0; 
} 
.listItem 
{ 
    background-color: white; 
    padding : 1px; 
}      
.highlightedListItem 
{ 
    background-color: #c3ebf9; 
    padding : 1px; 
}
    </style>
    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="clearfix">
            <br />
            <div style="margin-top: 1%; margin-left: 10%; margin-bottom: 1%; padding: 0 0 0 0; font-size: 1.5em; color: brown">
                <p>Edit Qualification Details</p>
                <p>Fill all mandatory details</p>
                <p>Edit only particluar section which has correction </p>
            </div>
            <div class="personcol" style="float: left; text-align: right; padding-left: 2%; padding-right: 15%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <ol id="sslcdata" runat="server">
                    <p style="border-bottom: 3px double grey; text-align: left; font-size: 1.2em; color: brown">Qualification Details &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "&nbsp;<span style="color: red">*</span>&nbsp;" Indicates Mandatory Field</p>
                    <p style="border-bottom: 2px solid black; text-align: left; color: brown">SSLC / 10th</p>
                    <li><span class="red">*</span>School Name<asp:TextBox ID="schoolname" placeholder="School Name" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ValidationGroup="sslcup" runat="server" ErrorMessage="*" Text="*" ControlToValidate="schoolname" ForeColor="red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span>Location<asp:TextBox ID="locationschool" placeholder="Location" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ValidationGroup="sslcup" runat="server" ErrorMessage="*" Text="*" ControlToValidate="locationschool" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Year Completed
                        <asp:DropDownList ID="yearcompleted" AutoPostBack="true" CssClass="textbox1" DataValueField="yearid" DataTextField="yearname" runat="server">
                            
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ValidationGroup="sslcup" InitialValue="-1" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="yearcompleted"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Board<asp:TextBox ID="boardsslc" Placeholder="Board" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ValidationGroup="sslcup" ErrorMessage="*" Text="*" ControlToValidate="boardsslc" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Percentage<asp:TextBox ID="Persslc" CssClass="textbox1" Placeholder="Percentage" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" ValidationGroup="sslcup" Text="*" ForeColor="red" ControlToValidate="Persslc"></asp:RequiredFieldValidator>
                       <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" Type="Double"  MaximumValue="99.99" MinimumValue="35.00" ValidationGroup="sslcup" ControlToValidate="Persslc" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                    </li>
                </ol>
                <ol  id="sslcdata1" runat="server"  style="border-bottom:1px solid grey">
                    <li>Grade<asp:TextBox ID="gradesslc" CssClass="textbox1" placeholder="Grade" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    </li>
                    <br />
                    <li>
                        <asp:Button ID="updatesslc" runat="server" Text="Update" CssClass="btn btn-primary" Width="100px" ValidationGroup="sslcup" OnClick="updatesslc_Click" /></li>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image1" ImageUrl="~/Images/ajax_loader_blue_32.gif" runat="server" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <li>
                        <asp:Label ID="sucesssslc" runat="server" Text="Label"></asp:Label></li>
              <li><span class="dipover" style="font-size:1.3em;color:Gray"><asp:hyperlink ID="A1" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:hyperlink></span></li>
                     </ol>

                  </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <ol>
                    <p style="border-bottom: 2px solid black; text-align: left; color: brown">PU / 12th</p>
                    <li><span class="red">*</span> School/college Name<asp:TextBox ID="pucollegename" CssClass="textbox1" Placeholder="College Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ValidationGroup="pugroup" runat="server" ErrorMessage="*" Text="*" ForeColor="red" ControlToValidate="pucollegename"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Location<asp:TextBox ID="pulocation" placeholder="Location" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ValidationGroup="pugroup" runat="server" ErrorMessage="*" Text="*" ForeColor="red" ControlToValidate="pulocation"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Year Completed
                        <asp:DropDownList ID="puyearcompleted" AutoPostBack="true" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" runat="server">
                            
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" InitialValue="-1" ErrorMessage="*" ValidationGroup="pugroup" Text="*" ForeColor="Red" ControlToValidate="puyearcompleted"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Board<asp:TextBox ID="puboard" Placeholder="PU Board" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ValidationGroup="pugroup" ControlToValidate="puboard"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Percentage<asp:TextBox ID="perpu" CssClass="textbox1" Placeholder="Percentage" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ValidationGroup="pugroup" ControlToValidate="perpu"></asp:RequiredFieldValidator>
                         <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" MaximumValue="99.99" MinimumValue="35.00" ControlToValidate="perpu" ValidationGroup="pugroup" Type="Double" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                    </li>
                </ol>
                <ol style="border-bottom:1px solid grey">
                    <li>Grade<asp:TextBox ID="gradepu" CssClass="textbox1" placeholder="Grade" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    </li>
                    <br />
                    <li>
                        <asp:Button ID="btnsuccesspu" runat="server" Text="Update" CssClass="btn btn-primary" Width="100px" ValidationGroup="pugroup" OnClick="btnsuccesspu_Click" /></li>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image2" ImageUrl="~/Images/ajax_loader_blue_32.gif" runat="server" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <li>
                        <asp:Label ID="successpu" runat="server" Text="Label"></asp:Label></li>
                    <li><span class="dipover" style="font-size:1.3em;color:Gray"><a class="diploma" onclick="$('#diploma_record').slideToggle(3000);; return false;" runat="server">Click  Here If you have diploma</a></span></li>
                <li><span class="dipover" style="font-size:1.3em;color:Gray"><asp:hyperlink ID="Hyperlink1" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:hyperlink></span></li>
                </ol>
                   </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <div id="diploma_record" style="display: none">
                    <p style="border-bottom: 2px solid black; text-align: left; color: brown; font-weight: normal">Diploma / If have diploma select the below box</p>
                    <ol>
                        <li><span class="red">*</span> Course Type<asp:DropDownList ID="coursetypediploma" CssClass="textbox1" runat="server">
                            <asp:ListItem Text="Full-Time" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Part-Time" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Corrsepondance" Value="3"></asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;</li>
                        <li><span class="red">*</span> University Name<asp:TextBox ID="universitynamediploma" placeholder="University" CssClass="textbox1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ValidationGroup="dipgroup" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="universitynamediploma"></asp:RequiredFieldValidator>
                        </li>
                        <li><span class="red">*</span> College Name<asp:TextBox ID="dipcollegename" placeholder="College Name" CssClass="textbox1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ValidationGroup="dipgroup" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="dipcollegename"></asp:RequiredFieldValidator>
                        </li>
                        <li><span class="red">*</span> Board<asp:TextBox ID="diplomaboard" Placeholder="Board" CssClass="textbox1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ValidationGroup="dipgroup" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="diplomaboard"></asp:RequiredFieldValidator>
                        </li>
                        <li><span class="red">*</span> Specialization<asp:DropDownList DataValueField="specid" DataTextField="Specialization" ID="diplomaspec" CssClass="textbox1" runat="server">
                      
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ErrorMessage="Select Spec" ValidationGroup="dipgroup" Text="*" ControlToValidate="diplomaspec" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>    
                        </li>
                        <li><span class="red">*</span> University Registration Num<asp:TextBox ID="diplomauniregnum" CssClass="textbox1" placeholder="Registration Number" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="dipgroup" ErrorMessage="Enter Registration Number" Text="*" ForeColor="Red" ControlToValidate="diplomauniregnum"></asp:RequiredFieldValidator>
                        </li>
                        <li><span class="red">*</span> Start Date<asp:DropDownList ID="diplomastartmonth" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            <asp:ListItem Text="Month" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                            <asp:DropDownList ID="diplomastartyear" AutoPostBack="true" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                             
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Month" ValidationGroup="dipgroup" Text="*" ControlToValidate="diplomastartmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Year" ValidationGroup="dipgroup" Text="*" ControlToValidate="diplomastartyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                        <li><span class="red">*</span> End Date
                        <asp:DropDownList ID="diplomaendmonth" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            <asp:ListItem Text="Month" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                            <asp:DropDownList ID="diplomaendyear" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                               
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Month" Text="*" ValidationGroup="dipgroup" ControlToValidate="diplomaendmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="dipgroup" ErrorMessage="Select Year" Text="*" ControlToValidate="diplomaendyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        </li>
                        <li><span class="red">*</span> Percentage<asp:TextBox ID="perdiploma" CssClass="textbox1" Placeholder="Percentage" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ValidationGroup="dipgroup" Text="*" ControlToValidate="perdiploma" ForeColor="Red"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" Display="Dynamic" Type="Double" MaximumValue="99.99" MinimumValue="35.00" ValidationGroup="dipgroup" ControlToValidate="perdiploma" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                        </li>
                    </ol>
                    <ol style="border-bottom:1px solid grey">
                        <li>Grade<asp:TextBox ID="gradediploma" CssClass="textbox1" placeholder="Grade" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</li>
                        <br />
                        <li>
                            <asp:Button ID="btnupdatediploma" runat="server" Text="Update" CssClass="btn btn-primary" Width="100px" ValidationGroup="dipgroup" OnClick="btn_dip" /></li>
                        <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel3" runat="server">
                            <ProgressTemplate>
                                 <asp:Image ID="Image3" ImageUrl="~/Images/ajax_loader_blue_32.gif" runat="server" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <li>
                            <asp:Label ID="lblsuccessdiploma" runat="server" Text="Label"></asp:Label></li>
                    <li><span class="dipover" style="font-size:1.3em;color:Gray"><asp:hyperlink ID="Hyperlink2" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:hyperlink></span></li>
                    </ol>
                </div>
               </ContentTemplate>
                </asp:UpdatePanel>



                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <ol>
                    <p style="border-bottom: 2px solid black; text-align: left; color: brown">Graduation</p>
                    <li><span class="red">*</span> Course Type<asp:DropDownList ID="gradcoursetype" CssClass="textbox1" runat="server">
                        <asp:ListItem Text="Full-Time" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Part-Time" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Corrsepondance" Value="3"></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;</li>
                    <li><span class="red">*</span> Degree<asp:DropDownList ID="graddegree1" DataValueField="degreeid" DataTextField="degree"  CssClass="textbox1" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-1" ControlToValidate="graddegree1"></asp:RequiredFieldValidator></li>
                    <li><span class="red">*</span> University Name<asp:TextBox ID="graduniname" placeholder="University" CssClass="textbox1" runat="server"></asp:TextBox>
                        <cc1:AutoCompleteExtender completionlistcssclass="completionListElement" completionlistitemcssclass="listItem" completionlisthighlighteditemcssclass="highlightedListItem" servicemethod="GetCompletionList" targetcontrolid="graduniname" ID="AutoCompleteExtender1" runat="server">
                        </cc1:AutoCompleteExtender>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ValidationGroup="gradeup" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="graduniname"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> College Name<asp:TextBox ID="gradcollegename" placeholder="College Name" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ValidationGroup="gradeup" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="gradcollegename"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Specialization<asp:DropDownList ID="gradspec" DataValueField="specid" DataTextField="Specialization" CssClass="textbox1" runat="server">
                       
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="gradeup" runat="server" ErrorMessage="Select Spec" Text="*" ControlToValidate="gradspec" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> University Registration Num<asp:TextBox ID="graduniregnum" CssClass="textbox1" placeholder="Registration Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="gradeup" ErrorMessage="Enter Registration Number" Text="*" ForeColor="Red" ControlToValidate="graduniregnum"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Start Date<asp:DropDownList ID="gradstartmonth" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                        <asp:ListItem Text="Month" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                        <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                        <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                        <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                        <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                        <asp:DropDownList ID="gradstartyear" DataValueField="yearid" AutoPostBack="true" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Month" ValidationGroup="gradeup" Text="*" ControlToValidate="gradstartmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select Year" ValidationGroup="gradeup" Text="*" ControlToValidate="gradstartyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                </ol>
                <ol>
                    <li>End Date
                        <asp:DropDownList ID="gradendmonth" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            <asp:ListItem Text="Month" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="gradendyear"  DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                           
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select Month" Text="*" ValidationGroup="gradeup" ControlToValidate="gradendmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Select Year" Text="*" ValidationGroup="gradeup" ControlToValidate="gradendyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                </ol>
                <ol>
                    <li><span class="red">*</span> Percentage<asp:TextBox ID="gradperc" CssClass="textbox1" Placeholder="Percentage" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="*" Text="*" ControlToValidate="gradperc" ValidationGroup="gradeup" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RangeValidator ID="RangeValidator4" Display="Dynamic" Type="Double" MaximumValue="99.99" ValidationGroup="gradeup" MinimumValue="35.00" ControlToValidate="gradperc" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                    </li>
                </ol>
                <ol style="border-bottom:1px solid grey">
                    <li>Grade<asp:TextBox ID="gradgrade" CssClass="textbox1" placeholder="Grade" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</li>
                    <br />
                    <li>
                        <asp:Button ID="btngradeupdate" runat="server" Text="Update" CssClass="btn btn-primary" Width="100px" ValidationGroup="gradeup" OnClick="btngradeupdate_Click" /></li>
                    <asp:UpdateProgress ID="UpdateProgress4" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image4" ImageUrl="~/Images/ajax_loader_blue_32.gif" runat="server" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <li>
                        <asp:Label ID="lblsucessgrade" runat="server" Text="Label"></asp:Label></li>
               <li><span class="dipover" style="font-size:1.3em;color:Gray"><asp:hyperlink ID="Hyperlink3" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:hyperlink></span></li>
                     </ol>
                        </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <ol>
                    <p style="border-bottom: 2px solid black; text-align: left; color: brown">Post Graduation</p>
                    <li><span class="red">*</span> Course Type<asp:DropDownList ID="pgcoursetype" CssClass="textbox1" runat="server">
                        <asp:ListItem Text="Full-Time" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Part-Time" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Corrsepondance" Value="3"></asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;</li>
                    <li><span class="red">*</span> Degree<asp:DropDownList ID="pgdegree1" DataValueField="degreeid" DataTextField="degree"  CssClass="textbox1" runat="server"></asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-1" ValidationGroup="pgup" ControlToValidate="pgdegree1"></asp:RequiredFieldValidator></li>
                    <li><span class="red">*</span> University Name<asp:TextBox ID="pguniname" placeholder="University" CssClass="textbox1" runat="server"></asp:TextBox>
                        <cc1:AutoCompleteExtender completionlistcssclass="completionListElement" completionlistitemcssclass="listItem" completionlisthighlighteditemcssclass="highlightedListItem" servicemethod="GetCompletionList" targetcontrolid="pguniname" ID="AutoCompleteExtender3" runat="server">
                        </cc1:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="*" Text="*" ControlToValidate="pguniname" ValidationGroup="pgup" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> College Name<asp:TextBox ID="pgcollegename" placeholder="College Name" CssClass="textbox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="*" Text="*" ControlToValidate="pgcollegename" ValidationGroup="pgup" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Specialization<asp:DropDownList ID="pgspec" DataValueField="specid" DataTextField="Specialization"  CssClass="textbox1" Width="275px" runat="server">
                        
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select Spec" Text="*" ControlToValidate="pgspec" ValidationGroup="pgup" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> University Registration Num<asp:TextBox ID="pgregnum" CssClass="textbox1" placeholder="Registration Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter Registration Number" Text="*" ValidationGroup="pgup" ForeColor="Red" ControlToValidate="pgregnum"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Start Date<asp:DropDownList ID="pgstartmonth" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                        <asp:ListItem Text="Month" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                        <asp:ListItem Text="May" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                        <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                        <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                        <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                        <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                        <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                        <asp:DropDownList ID="pgstartyear" AutoPostBack="true" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Select Month" Text="*" ValidationGroup="pgup" ControlToValidate="pgstartmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Select Year" Text="*" ValidationGroup="pgup" ControlToValidate="pgstartyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                </ol>
                <ol>
                    <li>End Date
                        <asp:DropDownList ID="pgendmonth" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            <asp:ListItem Text="Month" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="pgendyear" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                            
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Select Month" Text="*" ValidationGroup="pgup" ControlToValidate="pgendmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Select Year" ValidationGroup="pgup" Text="*" ControlToValidate="pgendyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                </ol>
                <ol>
                    <li><span class="red">*</span> Percentage<asp:TextBox ID="pgpercentage" CssClass="textbox1" Placeholder="Percentage" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="*" ValidationGroup="pgup" Text="*" ForeColor="Red" ControlToValidate="pgpercentage"></asp:RequiredFieldValidator>
                   <asp:RangeValidator ID="RangeValidator5" Type="Double" Display="Dynamic" MaximumValue="99.99" MinimumValue="35.00" ValidationGroup="pgup" ControlToValidate="pgpercentage" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                         </li>
                </ol>
                <ol style="border-bottom:1px solid grey">
                    <li>Grade<asp:TextBox ID="pggrade1" CssClass="textbox1" placeholder="Grade" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    </li>
                    <br />
                    <li>
                        <asp:Button ID="btnpgupdate" runat="server" Text="Update" CssClass="btn btn-primary" Width="100px" ValidationGroup="pgup" OnClick="btnpgupdate_Click" /></li>
                    <asp:UpdateProgress ID="UpdateProgress5" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image5" ImageUrl="~/Images/ajax_loader_blue_32.gif" runat="server" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <li>
                        <asp:Label ID="lblpgsucess" runat="server" Text="Label"></asp:Label></li>
                <li><span class="dipover" style="font-size:1.3em;color:Gray"><asp:hyperlink ID="Hyperlink4" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:hyperlink></span></li>
                </ol>
                        </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </form>
</asp:Content>
