<%@ Page Title="" Language="C#" MasterPageFile="~/ms/hrlogreg.Master" AutoEventWireup="true" CodeBehind="hrlogreg.aspx.cs" Inherits="AHRMS1.ms.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="Form1" runat="server" >
       <div class="container" style="background-color:none; width:100% ; height:100%">
       <div class="col-lg-6" style=" padding-left:8%;">
           <ol style="float:left; text-decoration:none; list-style:none ">
               <br />
               <br />
               <li style="font-size:1.5em; color:gray;">Employer Login</li>
               <li><br /></li>
               <br />
               <li><asp:TextBox ID="txthrid" CssClass="textbox texthrid" placeHolder="HR_ID" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidatorhr" runat="server" 
                       ErrorMessage="Enter User ID" Font-Size="0.8em" ValidationGroup="loghr" ForeColor="Red" Text="*" ControlToValidate="txthrid"></asp:RequiredFieldValidator>
               </li>
               <br />
               <li><asp:TextBox ID="txtpasshr" CssClass="textbox textpass" TextMode="Password" placeholder="Password"  runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1hr" ValidationGroup="loghr" ControlToValidate="txtpasshr" runat="server" Font-Size="0.8em" ForeColor="Red" Text="*" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
               </li>
               <li><br/></li>
               <li style="padding:2px;">
               <asp:Button ID="logbtnhr" runat="server" Text="Login" CssClass="btn btn-primary" ValidationGroup="loghr" Height="40px" Width="80px" OnClick="logbtnhr_Click"/>
                   
               </li>
               <li>
                   <asp:Label ID="lblhrstatus" ForeColor="Red" runat="server" Text=""></asp:Label>
               </li>
               <asp:ValidationSummary ID="ValidationSummary1hr"  ValidationGroup="loghr" runat="server" ForeColor="Red" Font-Size="0.8em" />
               <br /> 
               <li style="border-right:3px dotted #FF9933" ></li>

               <br /> 
              
               </ol>
       </div>
       <div id="reg"  class="col-lg-6 hrreg">
           <ol style="float:right; text-decoration:none; list-style:none">
               <br /> 
               <br />
               <li id="borderleft"  ></li>
               <li style="font-size:1.5em; color:gray;">Employer Registration</li>
               <li><br /></li>
               <br />
               <li><asp:TextBox ID="txtcomname" CssClass="textbox" placeholder="Employer Name" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3hr" runat="server" 
                       ErrorMessage="Enter Company Name" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtcomname"></asp:RequiredFieldValidator>
               </li>
               <br />
               <li><asp:TextBox ID="txtadd" CssClass="textbox" placeholder="Employer Address" runat="server" Wrap="true" Height="80px" TextMode="MultiLine" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2hr" runat="server" 
                       ErrorMessage="Enter Address" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtadd"></asp:RequiredFieldValidator>
               </li>
              <br />
               <li><asp:TextBox ID="txtname" CssClass="textbox textboxname" placeholder="Name(SPOC)" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4hr" runat="server" 
                       ErrorMessage="Enter Name" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtname"></asp:RequiredFieldValidator>
               </li>
               <br />
               <li><asp:TextBox ID="txtcontactno" CssClass="textbox textboxphno" PlaceHolder="Mobile Number" MaxLength="10" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6hr" runat="server" 
                       ErrorMessage="Enter Contact Number" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtcontactno"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1hr" runat="server" 
                       ErrorMessage="Invalid Moblie Number" Text="*" ControlToValidate="txtcontactno" ValidationGroup="reghr" ForeColor="Red" Font-Size="0.8em" ValidationExpression="^[7-9][0-9]{9}$"></asp:RegularExpressionValidator>
               </li>
              <br />
               <li><asp:TextBox ID="txtlandlinenum" CssClass="textbox textboxphnolnd" placeholder="Landline Number" MaxLength="10" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7hr" runat="server" 
                       ErrorMessage="Enter landline Number" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtlandlinenum"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3hr" runat="server" 
                       ErrorMessage="Invalid landline Number"  Text="*" ControlToValidate="txtlandlinenum" 
                       ForeColor="Red" ValidationGroup="reghr" Font-Size="0.8em" ValidationExpression="^[0]{1}[0-9]{2}[0-9]{7}$"></asp:RegularExpressionValidator>
               </li>
               <br />
                   <li><asp:TextBox ID="txtemailreghr" CssClass="textbox textboxemail" Placeholder="Offical Mail_ID" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5hr" runat="server" 
                       ErrorMessage="Enter Email ID" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtemailreghr"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2hr" runat="server"
                    Display="Dynamic"    ErrorMessage="Invalid Email ID" Text="*" ForeColor="Red" Font-Size="0.8em" ValidationGroup="reghr" ControlToValidate="txtemailreghr"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               </li> 
               <br />
                     <li><asp:TextBox ID="txtaltemail" CssClass="textbox textboxemail" Placeholder="Alternate Mail ID" runat="server" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                       ErrorMessage="Enter Email ID" Font-Size="0.8em" ValidationGroup="reghr" ForeColor="Red" Text="*" ControlToValidate="txtaltemail"></asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    Display="Dynamic"    ErrorMessage="Invalid Email ID" Text="*" ForeColor="Red" Font-Size="0.8em" ValidationGroup="reghr" ControlToValidate="txtaltemail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
               </li>  
              
               

             <li>
                 <asp:Button ID="regbtnhr" runat="server" CssClass="btn btn-primary" 
                      ValidationGroup="reghr" Text="Submit" Height="40px" Width="80px" OnClick="regbtnhr_Click" />
                 
             </li>
               
               
               <li>
                   <asp:ValidationSummary ID="ValidationSummary3"  ForeColor="red" Font-Size="0.8em"  ValidationGroup="reghr" runat="server" />
               </li>
               <li>
                   <asp:Label ID="lblreghr" runat="server" Font-Size="0.8em" Text=""></asp:Label>
               </li>
               </ol>
              
       </div>
           </div>
   </form>
</asp:Content>
