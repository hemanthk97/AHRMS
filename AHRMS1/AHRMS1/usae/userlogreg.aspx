<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogreg.aspx.cs" MasterPageFile="~/ms/userlogreg.master" Inherits="AHRMS1.otherpages.userlogreg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form name="userlog" runat="server" >
        <style type="text/css">
            
            .validator
{
    color: #d16262  !important;
}
            
        </style>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <div class="container" style="width:100% ; height:100%">
       <div  class="col-lg-6" style="margin-top:50px; border-right:3px  dotted #FF9933; padding-left:8%; z-index:10 ;">
           <ol style="float:left; text-decoration:none; list-style:none ">
               <li style="font-size:1.5em; color:gray;">User Login</li>
               <li><br /></li>
              <br />
               <li><asp:TextBox ID="txtuserid"  CssClass="textbox textuserid" placeholder="User ID" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" 
                       ErrorMessage="Enter User ID" Font-Size="0.8em" ValidationGroup="log" ForeColor="#d16262" Text="*" ControlToValidate="txtuserid"></asp:RequiredFieldValidator>
               </li>
               <br />
               <li><asp:TextBox ID="txtpass" TextMode="Password" CssClass="textbox textpass" placeholder="Password"  runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="log" ControlToValidate="txtpass" runat="server" Font-Size="0.8em" ForeColor="#d16262" Text="*" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
               </li>
              <li><br/></li>
               <li style="padding:2px;">
               <asp:Button ID="logbtn" runat="server" Text="Login" CssClass="btn btn-primary" ValidationGroup="log" Height="40px" Width="80px" OnClick="logbtn_Click" />
                   
               </li>
               <li>
                   <asp:Label ID="lblloginstatus" runat="server" ForeColor="#d16262" Text=""></asp:Label>
               </li>
               <asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup="log" runat="server" ForeColor="#d16262" Font-Size="0.8em" />
               <br /> 
               <li style="border-bottom:3px dotted #FF9933" ></li>

               <br /> 
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                       <ContentTemplate>
               <li style="font-size:1.5em; color:gray">Forgot Password</li>
               <li style="font-size:0.7em; color:gray">Enter your Email_id for password</li>
               <br />
               <li style="font-size:0.8em; color:gray; margin-left:20px">Enter Your Mail ID</li>
               <li><asp:TextBox ID="fpemailid" CssClass="textbox textboxemail"  placeholder="Email_ID"  runat="server" Wrap="False"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                   Display="Dynamic" ErrorMessage="Enter Mail ID" Text="*" ValidationGroup="fp" ForeColor="#d16262" Font-Size="0.8em" ControlToValidate="fpemailid"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    Display="Dynamic"    ErrorMessage="Invalid Email ID" Text="*" ForeColor="#d16262" Font-Size="0.8em" ValidationGroup="fp" ControlToValidate="fpemailid"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

               </li>
               <br />

               <li>
                   
               <asp:Button ID="fpbtn" runat="server" Text="Submit" ValidationGroup="fp" CssClass="btn btn-primary" Height="40px" Width="80px" OnClick="fpbtn_Click"  />
                           <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel3" runat="server">
                               <ProgressTemplate>
                                 <span style="font-size:0.8em;color:black;opacity:0.8">Wait.....</span> 
                                                                         <div class="facebook">
	<div></div>
	<div></div>
	<div></div>
</div>
                               </ProgressTemplate>
                           </asp:UpdateProgress>
               
                       </li>
               <li>
                   <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="fp"  ForeColor="#d16262" Font-Size="0.8em" />
               </li>
               <li>
                   <asp:Label ID="fplbl" runat="server" Text="" ForeColor="Green" Font-Size="0.8em"></asp:Label>
               
                 </ContentTemplate>
                           </asp:UpdatePanel>
                    </li>
              
               </ol>
       </div>
            
       <div id="reg" class="col-lg-6" style="">
           <ol style="float:right; text-decoration:none; list-style:none">
               <br />
               <br />

               <li style="font-size:1.5em; color:gray;">User Registration</li>
               <li><br /></li>
               <li style="box-sizing:border-box; color:grey; border:2px solid;">
                   <p style="font-size:0.7em; color:#ba0202;">Note:-User ID should be a aplhanumeric characters(no special characters)</p>
                   <p style="font-size:0.7em; color:#ba0202;">Password must be Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character</p>
                       <p style="font-size:0.7em; color:#ba0202;">Please Enter Correct Email ID, To which QR Code to be sent</p>
               </li>
               <br />
               <li style="display:inline"><asp:TextBox ID="txtfirstname"  CssClass="textbox" Width="175px" Placeholder="First Name" runat="server"  ></asp:TextBox>
                   <asp:TextBox ID="txtlastname"  CssClass="textbox" Width="100px" Placeholder="Last Name" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                       ErrorMessage="Enter First Name" Font-Size="0.8em" ValidationGroup="reg" ForeColor="#d16262" Text="*" ControlToValidate="txtfirstname"></asp:RequiredFieldValidator>
                   </li>
               <br />
              
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                   <ContentTemplate>
               <br />
               <li><asp:TextBox ID="txtuseridreg" AutoPostBack="true"  onchange="if (this.value.length == 0) return;"  CssClass="textbox" Placeholder="Enter User ID" runat="server" OnTextChanged="txtuseridreg_TextChanged"></asp:TextBox>
                   <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                       <ProgressTemplate>
<div class="spinner-wave"><span style="font-size:0.8em;color:black;opacity:0.8">Checking for Availability.....</span> 
    <div></div>
    <div></div>
    <div></div>
    <div></div>
    <div></div>
</div>
                       </ProgressTemplate>
                   </asp:UpdateProgress>
                   <asp:Image ID="available" Visible="false" ToolTip="User ID avaiable"  ImageUrl="~/Images/1429032217_circle-check-24.png" Height="24px"  Width="24px" runat="server" />
                   <asp:Image ID="notavail" Visible="false"  ToolTip="ID Already used" ImageUrl="~/Images/1429032260_circle-close-24.png" Height="24px"  Width="24px" runat="server" />
                   
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                       ErrorMessage="Enter User ID" Font-Size="0.8em" EnableClientScript="true" ValidationGroup="reg" ForeColor="#d16262" Text="*" ControlToValidate="txtuseridreg"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator4usr" EnableClientScript="true" runat="server"
                    Display="Dynamic"    ErrorMessage="NO Special Character And Always start with Letter" Text="*" ForeColor="#d16262" Font-Size="0.8em" ValidationGroup="reg" ControlToValidate="txtuseridreg"
                        ValidationExpression="[a-zA-z0-9]+"></asp:RegularExpressionValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" EnableClientScript="true" runat="server"
                    Display="Dynamic"    ErrorMessage="No Space Allowed in UserID" Text="*" ForeColor="#d16262" Font-Size="0.8em" ValidationGroup="reg" ControlToValidate="txtuseridreg"
                        ValidationExpression="[^\s]+"></asp:RegularExpressionValidator>
                    </li>
                        </ContentTemplate>
                   </asp:UpdatePanel>
               <br />
                   <li><asp:TextBox ID="txtpassreg" TextMode="Password" ToolTip="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character" placeholder="Password" CssClass="textbox" runat="server" ></asp:TextBox><span id="time" ></span>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                       ErrorMessage="Enter Password" Font-Size="0.8em" ValidationGroup="reg"   Text="*" ControlToValidate="txtpassreg"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator30" Font-Size="0.8em" ValidationGroup="reg" ControlToValidate="txtpassreg" runat="server" ForeColor="#d16262" ErrorMessage="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character" Text="Kindly Check Note" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$"></asp:RegularExpressionValidator>
                   </li>
              
               <br />
                   <li><asp:TextBox ID="txtconpass" TextMode="Password" placeholder="Confirm Password" CssClass="textbox" runat="server" ></asp:TextBox>
                   <asp:CompareValidator ID="CompareValidator5" runat="server" 
                       ErrorMessage="Password Mismatch" Font-Size="0.8em" ValidationGroup="reg" ForeColor="#d16262" Text="*" ControlToCompare="txtpassreg" ControlToValidate="txtconpass"></asp:CompareValidator>
               </li>
               <br />
                   <li><asp:TextBox ID="txtemailreg" CssClass="textbox textboxemail" placeholder="Email ID"  runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                       ErrorMessage="Enter Email ID" Font-Size="0.8em" ValidationGroup="reg" ForeColor="#d16262" Text="*" ControlToValidate="txtemailreg"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                    Display="Dynamic"    ErrorMessage="Invalid Email ID" Text="*" ForeColor="#d16262" Font-Size="0.8em" ValidationGroup="reg" ControlToValidate="txtemailreg"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               </li>
               <br />  
               <li>
                  <asp:TextBox ID="txtcontactnousr"  TextMode="Phone"  CssClass="textbox textboxphno" PlaceHolder="Mobile Number" MaxLength="10" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6hr" runat="server" 
                       ErrorMessage="Enter Contact Number" Font-Size="0.8em" ValidationGroup="reg" ForeColor="#d16262" Text="*" ControlToValidate="txtcontactnousr"></asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                    Display="Dynamic"    ErrorMessage="Invalid Mobile Number" Text="*" ForeColor="#d16262" Font-Size="0.8em" ValidationGroup="reg" ControlToValidate="txtcontactnousr"
                        ValidationExpression="^[7-9][0-9]{9}$"></asp:RegularExpressionValidator>




                   
               </li>  
               <br />
               
               
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                   <ContentTemplate>
                       

             <li>
                 <asp:Button ID="regbtn" runat="server" CssClass="btn btn-primary" ValidationGroup="reg" Text="Submit" Height="40px" Width="80px" OnClick="regbtn_Click" />

                  <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                               <ProgressTemplate>
                                 <span style="font-size:0.8em;color:black;opacity:0.8">Wait.....</span> 
                                      <div class="facebook">
	<div></div>
	<div></div>
	<div></div>
</div>
                               </ProgressTemplate>
                           </asp:UpdateProgress>
             </li>
                  
               <li>
                   <asp:ValidationSummary ID="ValidationSummary3"  ForeColor="#d16262" Font-Size="0.8em" ValidationGroup="reg" runat="server" />
               </li>
                    

               <li>
                   <asp:Label ID="lblmailwel" runat="server" Font-Size="0.8em" Text=""></asp:Label>
                   <br />
                   <asp:Label ID="lblreg" runat="server" Font-Size="0.8em" Text=""></asp:Label>
               </li>
               </ol>
                 </ContentTemplate>
               </asp:UpdatePanel>
       </div>
         
           </div>
           </form> 
</asp:Content>
