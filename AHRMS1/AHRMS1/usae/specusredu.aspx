<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="specusredu.aspx.cs" MasterPageFile="~/ms/specusrmas.Master" Inherits="AHRMS1.usae.specusredu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form runat="server">
         <script src="../Scripts/modernizr.custom1.js"></script>
    <style type="text/css">
        checkalign {
        margin-right:20%
        }

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

   
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>
         <div class="clearfix">
             
            <br />       
           <div style="margin-top:1% ;margin-left:10%; margin-bottom:1%;padding:0 0 0 0;font-size:1.5em;color:brown" >
            <p>STEP 2:- Fill Qualification Details</p></div> 
            <div class="personcol" style="float:left;text-align:right;padding-left:2%; padding-right:15%">
            <ol>
                <p style="border-bottom:3px double grey; text-align:left;font-size:1.2em;color:brown">Qualification Details &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; "&nbsp;<span style="color:red">*</span>&nbsp;" Indicates Mandatory Field</p>
                <p style="border-bottom:2px solid black;text-align:left;color:brown">SSLC / 10th(Check If you have 10th/sslc marks card )</p>
                               
                         <asp:CheckBox ID="CheckBox1" CssClass="checkalign" AutoPostBack="true" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
                     <br />    
                <br />           
                <li><span class="red">*</span>School Name<asp:TextBox ID="schoolname"  placeholder="School Name" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="*" Text="*" ControlToValidate="schoolname" ForeColor="red"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span>Location<asp:TextBox ID="locationschool" placeholder="Location" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="*" Text="*" ControlToValidate="locationschool" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Year Completed <asp:DropDownList ID="yearcompleted" AutoPostBack="true" CssClass="textbox1" DataValueField="yearid" DataTextField="yearname"  runat="server" OnSelectedIndexChanged="yearcompleted_SelectedIndexChanged">
                    
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-1" ControlToValidate="yearcompleted"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Board<asp:TextBox ID="boardsslc" Placeholder="Board" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"  ErrorMessage="*" Text="*" ControlToValidate="boardsslc" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Percentage<asp:TextBox ID="Persslc" CssClass="textbox1" MaxLength="5" ToolTip="Percentage Range Should be Between 35.00 to 99.99" Placeholder="35.00 to 99.99" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="*" Text="*" ForeColor="red" ControlToValidate="Persslc"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" Display="Dynamic" Type="Double"  MaximumValue="99.99" MinimumValue="35.00" ControlToValidate="Persslc" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                </li>
                </ol>
                <ol>
                <li >Grade<asp:TextBox ID="gradesslc"  CssClass="textbox1" MaxLength="2" placeholder="Grade" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                </li>
                    <li style="border-bottom:1px solid grey">
                        <asp:Label ID="sslcstatus" runat="server" Text=""></asp:Label></li>
                    </ol>
                <ol>
                <p style="border-bottom:2px solid black;text-align:left;color:brown">PU / 12th(Check you pu marks card)</p>
                    <asp:CheckBox ID="CheckBox2" CssClass="checkalign" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                <br />    
                <br />
                <li><span class="red">*</span> School/college Name<asp:TextBox ID="pucollegename" CssClass="textbox1" Placeholder="College Name" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="*" Text="*" ForeColor="red" ControlToValidate="pucollegename"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Location<asp:TextBox ID="pulocation" placeholder="Location" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="*" Text="*" ForeColor="red" ControlToValidate="pulocation"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Year Completed <asp:DropDownList ID="puyearcompleted" AutoPostBack="true" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1"  runat="server" OnSelectedIndexChanged="puyearcompleted_SelectedIndexChanged">
                    
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="puyearcompleted"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Board<asp:TextBox ID="puboard" Placeholder="PU Board" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="puboard"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Percentage<asp:TextBox ID="perpu" CssClass="textbox1" c Placeholder="35.00 to 99.99" MaxLength="5" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="perpu"></asp:RequiredFieldValidator>
               <asp:RangeValidator ID="RangeValidator2" Display="Dynamic" MaximumValue="99.99" MinimumValue="35.00" ControlToValidate="perpu" ForeColor="Red" Text="*" runat="server" Type="Double" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                     </li>
                </ol>
                <ol>
                <li >Grade<asp:TextBox ID="gradepu"  CssClass="textbox1" MaxLength="2" placeholder="Grade" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;
                </li>
                    <li>
                        <asp:Label ID="pucstatus" runat="server" Text=""></asp:Label></li>
              <li class="dipover" style="border-bottom:1px solid grey"><span><a class="diploma" onclick="$('#diploma_record').slideToggle(3000);; return false;" runat="server">Diploma Holder click here</a></span></li>
            </ol>   
                <div id="diploma_record" style="display:none">                
                <p style="border-bottom:2px solid black;text-align:left;color:brown;font-weight:normal">Diploma / If have diploma select the below box</p>   
                <ol>
                    <li>Diploma(if you have check else dont check)<asp:CheckBox ID="chkdiploma" runat="server" AutoPostBack="true" OnCheckedChanged="chkdiploma_CheckedChanged" /> </li>
                <li><span class="red">*</span> Course Type<asp:DropDownList ID="coursetypediploma" CssClass="textbox1" runat="server">
                    <asp:ListItem Text="Full-Time" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Part-Time" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Corrsepondance" Value="3"></asp:ListItem>
                               </asp:DropDownList>&nbsp;&nbsp;&nbsp;</li>
                <li><span class="red">*</span> University Name<asp:TextBox ID="universitynamediploma" placeholder="University" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="universitynamediploma"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> College Name<asp:TextBox ID="dipcollegename" placeholder="College Name" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="dipcollegename"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Board<asp:TextBox ID="diplomaboard" Placeholder="Board" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="diplomaboard"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Specialization<asp:DropDownList  DataValueField="specid" DataTextField="Specialization" ID="diplomaspec"  CssClass="textbox1" runat="server">
                  
                    </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ErrorMessage="Select Spec" Text="*" ControlToValidate="diplomaspec" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                    <li><span class="red">*</span> University Registration Number<asp:TextBox ID="diplomauniregnum"  CssClass="textbox1" placeholder="Registration Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Registration Number" Text="*" ForeColor="Red" ControlToValidate="diplomauniregnum"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Start Date<asp:DropDownList ID="diplomastartmonth"  CssClass="textbox1" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem></asp:DropDownList>
                        <asp:DropDownList ID="diplomastartyear" AutoPostBack="true" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server" OnSelectedIndexChanged="dip_details">
                   
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Month" Text="*" ControlToValidate="diplomastartmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Year" Text="*" ControlToValidate="diplomastartyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> End Date
                        <asp:DropDownList ID="diplomaendmonth"  CssClass="textbox1" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem></asp:DropDownList>
                        <asp:DropDownList ID="diplomaendyear" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                    
                    </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Month" Text="*" ControlToValidate="diplomaendmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Year" Text="*" ControlToValidate="diplomaendyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                <li><span class="red">*</span> Percentage<asp:TextBox ID="perdiploma" CssClass="textbox1" ToolTip="Percentage Range Should be Between 35.00 to 99.99" Placeholder="35.00 to 99.99" MaxLength="5" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Text="*" ControlToValidate="perdiploma" ForeColor="Red"></asp:RequiredFieldValidator>
               <asp:RangeValidator ID="RangeValidator3" Display="Dynamic" Type="Double" MaximumValue="99.99" MinimumValue="35.00" ControlToValidate="perdiploma" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                     </li>
                </ol>
                    <ol>
                    <li >Grade<asp:TextBox ID="gradediploma"  CssClass="textbox1" MaxLength="2" placeholder="Grade" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</li>
                        <li style="border-bottom:1px solid grey">
                            <asp:Label ID="dipstatus" runat="server" Text="Label"></asp:Label></li>
                </ol>
                    </div>
                <ol>
                    <p style="border-bottom:2px solid black;text-align:left;color:brown">Graduation(Check if you are graduate)</p>
                    <asp:CheckBox ID="CheckBox3" CssClass="checkalign" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox3_CheckedChanged" />
                <br />    
                <br />
                     <li><span class="red">*</span> Course Type<asp:DropDownList ID="gradcoursetype" CssClass="textbox1" runat="server">
                    <asp:ListItem Text="Full-Time" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Part-Time" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Corrsepondance" Value="3"></asp:ListItem>
                               </asp:DropDownList>&nbsp;&nbsp;&nbsp;</li>
                    <li><span class="red">*</span> Degree<asp:DropDownList ID="graddegree1" DataValueField="degreeid" DataTextField="degree"  CssClass="textbox1" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-1" ControlToValidate="graddegree1"></asp:RequiredFieldValidator>
                    </li>
                <li><span class="red">*</span> University Name<asp:TextBox ID="graduniname" placeholder="University" CssClass="textbox1" runat="server"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1"  CompletionListCssClass="completionListElement"  CompletionListItemCssClass="listItem"   CompletionListHighlightedItemCssClass="highlightedListItem"   ServiceMethod="GetCompletionList" TargetControlID="graduniname" runat="server">

                    </cc1:AutoCompleteExtender>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="graduniname"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> College Name<asp:TextBox ID="gradcollegename" placeholder="College Name" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="gradcollegename"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Specialization<asp:DropDownList ID="gradspec" DataValueField="specid" DataTextField="Specialization"  CssClass="textbox1" runat="server">
                   
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Select Spec" Text="*" ControlToValidate="gradspec" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                    <li><span class="red">*</span> University Registration Number<asp:TextBox ID="graduniregnum"  CssClass="textbox1" placeholder="Registration Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Registration Number" Text="*" ForeColor="Red" ControlToValidate="graduniregnum"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Start Date<asp:DropDownList ID="gradstartmonth"  CssClass="textbox1" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem></asp:DropDownList>
                        <asp:DropDownList ID="gradstartyear" DataValueField="yearid" AutoPostBack="true" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server" OnSelectedIndexChanged="gradstartyear_SelectedIndexChanged">
                    
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Month" Text="*" ControlToValidate="gradstartmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select Year" Text="*" ControlToValidate="gradstartyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    </ol>
                <ol>
                    <li>End Date
                        <asp:DropDownList ID="gradendmonth"  CssClass="textbox1" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem></asp:DropDownList>
                        <asp:DropDownList ID="gradendyear" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                                        </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select Month" Text="*" ControlToValidate="gradendmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Select Year" Text="*" ControlToValidate="gradendyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                </ol>
                <ol>
                    <li><span class="red">*</span> Percentage<asp:TextBox ID="gradperc" CssClass="textbox1" ToolTip="Percentage Range Should be Between 35.00 to 99.99" Placeholder="35.00 to 99.99" MaxLength="5" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="*" Text="*" ControlToValidate="gradperc" ForeColor="Red" ></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator4" Display="Dynamic" MaximumValue="99.99" MinimumValue="35.00" ControlToValidate="gradperc" ForeColor="Red" Text="*" runat="server" Type="Double" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                    </li>
                </ol>
                <ol>
                    <li >Grade<asp:TextBox ID="gradgrade"  CssClass="textbox1" MaxLength="2" placeholder="Grade" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</li>
                <li style="border-bottom:1px solid grey">
                    <asp:Label ID="gradstatus" runat="server" Text=""></asp:Label></li> 
                </ol>
                <ol>
                    <p style="border-bottom:2px solid black;text-align:left;color:brown">Post Graduation(check if you are POST GRADUATE)</p>
                    <asp:CheckBox ID="CheckBox4" CssClass="checkalign" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox4_CheckedChanged" />
                <br />    
                <br />
                     <li><span class="red">*</span> Course Type<asp:DropDownList ID="pgcoursetype" CssClass="textbox1" runat="server">
                    <asp:ListItem Text="Full-Time" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Part-Time" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Corrsepondance" Value="3"></asp:ListItem>
                               </asp:DropDownList>&nbsp;&nbsp;&nbsp;</li>
                    <li><span class="red">*</span> Degree<asp:DropDownList ID="pgdegree1" DataValueField="degreeid" DataTextField="degree"  CssClass="textbox1" runat="server"></asp:DropDownList>
<asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" InitialValue="-1" ControlToValidate="pgdegree1"></asp:RequiredFieldValidator>
                    </li>
                <li><span class="red">*</span> University Name<asp:TextBox ID="pguniname" placeholder="University" CssClass="textbox1" runat="server"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2"  CompletionListCssClass="completionListElement"   CompletionListItemCssClass="listItem"  CompletionListHighlightedItemCssClass="highlightedListItem"  ServiceMethod="GetCompletionList" TargetControlID="pguniname" runat="server">

                    </cc1:AutoCompleteExtender>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="*" Text="*" ControlToValidate="pguniname" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span>College Name<asp:TextBox ID="pgcollegename" placeholder="College Name" CssClass="textbox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="*" Text="*" ControlToValidate="pgcollegename" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                <li><span class="red">*</span> Specialization<asp:DropDownList ID="pgspec" DataValueField="specid" DataTextField="Specialization"  CssClass="textbox1" Width="275px" runat="server">
                  
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select Spec" Text="*" ControlToValidate="pgspec" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                </li>
                    <li><span class="red">*</span> University Registration Number<asp:TextBox ID="pgregnum"  CssClass="textbox1" placeholder="Registration Number" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Enter Registration Number" Text="*" ForeColor="Red" ControlToValidate="pgregnum"></asp:RequiredFieldValidator>
                    </li>
                    <li><span class="red">*</span> Start Date<asp:DropDownList ID="pgstartmonth"  CssClass="textbox1" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem></asp:DropDownList>
                        <asp:DropDownList ID="pgstartyear" AutoPostBack="true" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server" OnSelectedIndexChanged="pgstartyear_SelectedIndexChanged">
                    
                    </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="Select Month" Text="*" ControlToValidate="pgstartmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Select Year" Text="*" ControlToValidate="pgstartyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    </ol>
                <ol>
                    <li>End Date
                        <asp:DropDownList ID="pgendmonth"  CssClass="textbox1" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem></asp:DropDownList>
                        <asp:DropDownList ID="pgendyear" DataValueField="yearid" DataTextField="yearname" CssClass="textbox1" Width="100px" Height="30px" runat="server">
                   
                    </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Select Month" Text="*" ControlToValidate="pgendmonth" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Select Year" Text="*" ControlToValidate="pgendyear" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </li>
                    </ol>
                <ol>
                <li><span class="red">*</span> Percentage<asp:TextBox ID="pgpercentage" CssClass="textbox1" ToolTip="Percentage Range Should be Between 35.00 to 99.99" Placeholder="35.00 to 99.99"  MaxLength="5" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="*" Text="*" ForeColor="Red" ControlToValidate="pgpercentage"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator5" Type="Double" Display="Dynamic" MaximumValue="99.99" MinimumValue="35.00" ControlToValidate="pgpercentage" ForeColor="Red" Text="*" runat="server" ErrorMessage="Enter Value Between 35.00 to 99.99"></asp:RangeValidator>
                </li>
                </ol>
                <ol>
                    <li >Grade<asp:TextBox ID="pggrade"  MaxLength="2" CssClass="textbox1" placeholder="Grade" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                    </li>
                    <li style="border-bottom:4px double brown">
                        <asp:Label ID="pgstatus" runat="server" Text=""></asp:Label></li>
               <p style="color:red;text-align:center">Check All the details before submission</p>
                    <p style="color:grey;font-size:1em; text-align:center">After Successful Submission the page will be redirected for uploading the documents</p>
                    <p style="color:grey;font-size:1em;text-align:center">Please be ready with your documents</p>
                   <span style="padding-right:35%">
                       
                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                           <ContentTemplate>
                       <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary"  Width="100px" Text="Submit" OnClick="Button1_Click" />
                    </ContentTemplate>
                               </asp:UpdatePanel>
                                                    
                     <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                         <ProgressTemplate>
                               <span style="font-size:0.8em;color:black;opacity:0.8">Updating Details Please wait...</span> 
                                                                         <div class="facebook">
	<div></div>
	<div></div>
	<div></div>
</div>
                         </ProgressTemplate>
                      </asp:UpdateProgress>
                                   </span></ol>

               
                </div>   
             </div> 

                   </span> 

                </ContentTemplate>
           </asp:UpdatePanel> 
             </form>
     
</asp:Content>