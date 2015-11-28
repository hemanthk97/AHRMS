<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="AHRMS1.error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:#eae4e4">
    <style type="text/css">
        .giff
{
            margin-left:35%;
            margin-top:1%;
            padding-top:0;
}
        .hel {
            text-align:center;
            margin-left:48%;
        }
    </style>
    <form id="form1" runat="server">
        <p style="text-align:center;font-family:'Bell MT';font-size:1.5em;font-weight:bold">Oops!!! Some thing went wrong</p>
        <asp:Image ID="Image1" CssClass="giff"  ImageUrl="~/Images/014.gif" runat="server" />
        
            <p style="color: red; font-size: 2.3em; text-align:center; background-color: #eae4e4; top: 0">Application Error!!</p>
            <p style="color: gray;text-align:center;">
                An error occured in the application and your page could not be served.<br />
                Please try again in few moments
            </p>
            <p style="color: gray;text-align:center;">If you are application owner,check your logs for details</p>
        <asp:HyperLink ID="HyperLink1" CssClass="hel" Text="Home Page" NavigateUrl="~/otherpages/MainHome.aspx" runat="server"></asp:HyperLink>
    </form>
</body>
</html>
