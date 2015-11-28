<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AHRMS1.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>AHRMS</title>
    <link href="/Content/bootstrap-theme.css" rel="stylesheet" />
    <link href="/Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/bootstrap.min.css" rel="stylesheet" />

    <script src="/Scripts/_references.js"></script>
  
    
   
    <script src="/Scripts/jquery-1.9.1.js"></script>
    <script src="/Scripts/jquery-1.9.1.min.js"></script>
    <script src="/Scripts/jquery-ui-1.8.20.js"></script>
    <script src="/Scripts/jquery-ui-1.8.20.min.js"></script>
    <script src="/Scripts/modernizr-2.5.3.js"></script>
    <script src="/Scripts/npm.js"></script>
   <script src="/Scripts/bootstrap.js"></script>
    <script src="/Scripts/bootstrap.min.js"></script>
   <script src="/Scripts/advancetitleusr.js"></script>

<link href="../Content/userlogreg.css" rel="stylesheet" />
    <link href="../Content/footerstick.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
          <div id="header">
         <span style="position:fixed" class="hvr-buzz-out">
            <input class="logosize" type="image" alt="AHRMS" src="../Images/logo.png"/></span>
             <p id="headernote" style="text-align:center;color:white"> Advance Human Resource Management System </p>
             
    </div>
        <div id="sidebar" style="position:absolute; z-index:10; padding:0 0 0 0; outline-offset:0;  margin-top:18%">
       <p class="aa" id="at">A</p>
        <p class="aa" id="ht">H</p>
        <p class="aa" id="rt">R</p>
        <p class="aa" id="mt">M</p>
        <p class="aa" id="st">S</p>
       </div>
        <div style="margin-left:20%;margin-right:20%;padding-top:10%;">
        <p style="font-size:x-large;font-weight:800">Change your new password</p>
            <br />
            <p >Strengthen the security of your account with a new password</p>
        <asp:Label ID="userid" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="uniqueid" runat="server" Visible="false" Text="Label"></asp:Label>
            <br />
        <asp:TextBox ID="txtcnpass" TextMode="Password" CssClass="textbox"  Width="500px" Height="40px" placeholder="New Password" ToolTip="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character"  runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcnpass" Text="*" ForeColor="Red" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="*" ForeColor="Red" ControlToValidate="txtcnpass" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$" ErrorMessage="Minimum 8 characters atleast 1 Alphabet, 1 Number and 1 Special Character"></asp:RegularExpressionValidator>
       <div style="padding-top:1em">  </div>
             <asp:TextBox ID="txtcnpassconf" TextMode="Password"  Width="500px" Height="40px" CssClass="textbox" placeholder="Confirm new Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcnpassconf" Text="*" ForeColor="Red" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtcnpassconf" ControlToCompare="txtcnpass" Text="*" ForeColor="Red"  ErrorMessage="Password Mismatch"></asp:CompareValidator><br /><br />
        <asp:Button ID="cnpass" runat="server" Width="150px" Text="Change Password" CssClass="btn btn-primary"   OnClick="cnpass_Click" /><br /><br />
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="red" runat="server" />

        <asp:Label ID="lblcnpas" runat="server"  Text=""></asp:Label><br />
                   <br />
            <br /><asp:HyperLink ID="HyperLink1" Visible="false" NavigateUrl="~/usae/userlogreg.aspx" ForeColor="Black" runat="server">Click here to login</asp:HyperLink>
    </div>
        </div>
    </form>
</body>
</html>
