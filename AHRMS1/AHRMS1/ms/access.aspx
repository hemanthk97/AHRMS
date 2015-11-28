<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="access.aspx.cs" Inherits="AHRMS1.access" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
   
<body style="background-image:url(../Images/006.gif);background-repeat:no-repeat;background-size:70%">
   <style type="text/css">
       .fuh {
        font-size:5em;
        font-family:'Franklin Gothic';
       }
   </style>
     <form id="form1" runat="server">
    <div>
        <h1 class="fuh" >404!!!!</h1>
     <p style="color:red;font-size:3em">Page not found!!!!</p>
        <asp:HyperLink ID="HyperLink2"  NavigateUrl="~/usae/userlogreg.aspx"  runat="server">Login</asp:HyperLink>
    </div>
    </form>
</body>
</html>
