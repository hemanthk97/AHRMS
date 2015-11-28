<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AHRMS1.otherpages.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
             <p id="headernote" style="text-align:center;color:white">Admin Advance Human Resource Management System </p>
             <div id="sidebar" style="position:absolute; z-index:10; padding:0 0 0 0; outline-offset:0;  margin-top:18%">
       <p class="aa" id="at">A</p>
        <p class="aa" id="ht">H</p>
        <p class="aa" id="rt">R</p>
        <p class="aa" id="mt">M</p>
        <p class="aa" id="st">S</p>
       </div>  
    </div>
    </div>
        <br />
        <br />
        <br />
        <center>
        <div>
        <p style="font-size:x-large;font-weight:800">Verify and Generate HR ID and Password</p>
            <asp:TextBox ID="hridandpass" CssClass="textbox"  Width="500px" Height="40px" Placeholder="Registration ID" runat="server"></asp:TextBox><asp:Label ID="lblhridandpass" runat="server" Text=""></asp:Label>
            <br />
            <br />
    <asp:Button ID="Button1" CssClass="btn btn-success"  Width="150px" runat="server" Text="Verify" OnClick="Button1_Click"></asp:Button>
            </div>
            </center>
        <br />
        <br />
          <center>
        <div>
        <p style="font-size:x-large;font-weight:800">Delete Candidate Data</p>
            <asp:TextBox ID="deleteusr" CssClass="textbox"  Width="500px" Height="40px" Placeholder="User ID" runat="server"></asp:TextBox><asp:Label ID="lbldeleteusr" runat="server" Text=""></asp:Label>
    <br />
            <br />
            <asp:Button ID="Button2" CssClass="btn btn-danger"  Width="150px" runat="server" Text="Delete"></asp:Button>
            </div>
            </center>
        <br />
        <br />
        <center>
        <div>
        <p style="font-size:x-large;font-weight:800">Delete HR Data</p>
            <asp:TextBox ID="TextBox1" CssClass="textbox"  Width="500px" Height="40px" Placeholder="Registration ID" runat="server"></asp:TextBox><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
    <asp:Button ID="Button3" runat="server" CssClass="btn btn-danger"  Width="150px" Text="Delete"></asp:Button>
            </div>
            </center>
        </form>
</body>
</html>
