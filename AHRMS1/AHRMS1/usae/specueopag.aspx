<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="specueopag.aspx.cs" MasterPageFile="~/ms/specusrmas.Master" Inherits="AHRMS1.specueopag" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" style="background:none">
         <ol class="mainuser" style="background:white;opacity:0.9">
     <li style="padding-left:5%"><h1 style="color:purple;">Welcome</h1></li>
     <li style="float:right;margin-right:4%">Your QR Code</li>
             <br />
             <br />
             <div style="float:right; margin-right:2%;border:2px solid green;padding:4px">
                 <asp:Image ID="QRImag" Width="150px" Height="150px" runat="server" />
             </div>
             <li style="padding-left:15%">
         <asp:Label ID="lblusername" runat="server" Text="hemanth !!!!" Font-Size="XX-Large" ForeColor="Green"></asp:Label></li>
     <li style="padding-left:20%"><p id="note" class="hvr-sweep-to-right"  style="border:1px double blue; font-size:0.7em; width:50%;" >
         Note:-<br /> 1. Please Read all the Instructions Before filling the details.<br />
                2. Ensure all the Mandatray fields are filled.<br />
                3. Save your QR code<br />
                 4.If QR code is lost contact ahrmsadmin@outlook.com with your userid).<br />
                5. Enter Accurate data.<br />
         6.Upload your documents within the specified size.<br />
         7.Only .jpeg, .png, .jpg format are allowed.<br />
         </p></li>
             
     <li style="font-size:x-large;color:purple; text-decoration:underline;padding-left:5%">Step By Step Procedure to fill details</li>
     <br /><li style="font-size:large;color:Green; padding-left:8%  "><asp:Image ImageUrl="~/fonts/1427987301_icon-ios7-arrow-right-32.png" runat="server" />Step1:-Fill all personal details</li>
     <br />
     <li style="font-size:large;color:brown;padding-left:8%"><asp:Image ID="Image1" ImageUrl="~/fonts/1427987301_icon-ios7-arrow-right-32.png" runat="server" />Step2:- Fill all your qualification deatils/If all already filled edit it</li>
     
     <br /><li style="font-size:large;color:blue;padding-left:8%"><asp:Image ID="Image2" ImageUrl="~/fonts/1427987301_icon-ios7-arrow-right-32.png" runat="server" />Step3:-Upload Your Douments</li>
            <br /> <li style="font-size:large;color:red;padding-left:8%"><asp:Image ID="Image3" ImageUrl="~/fonts/1427987301_icon-ios7-arrow-right-32.png" runat="server" />Step4:- View/Verify Your profile for correction</li> 
     <br />
     <br />    
             <li ></li>
         </ol>
        <span style="padding-left:45%"><asp:Image ID="Image4" ImageUrl="~/Images/1428055610_icon-arrow-down-b-64.png" ImageAlign="Middle" runat="server" /></span>
<div class="mainuser111" style="background:none">
    <br />
      <p style="font-size:x-large;color:#980000;padding-bottom:1%;margin-top:-1%; text-align:center;border-bottom:3px double grey;">Please read the below instructions</p>
     <br />
        
               <div style="margin-bottom:3%;background:none" >
                 <textarea id="TextArea1" style="width:95%;font-size:0.9em; height:150px; background-color:#c4bdbd; color:black " readonly="readonly" wrap="hard">
1. Visit AHRMS web page to access the home page of the “User Segment”.
2. For Candidate Registration process you have to click on “user” option it will fetch out Candidate Basic Registration page in which the candidates have to fill fundamental information, particulars and details asked for. Fields marked with * are mandatory and essential to be filled in by the candidate. Every field has clear instructions for filling up are written which should be carefully read and strictly followed by the candidates while filling up the form.
3. After Registration Candidate can login and fill all his personal and qualification details. 
4. Here the system asks for Candidate’s Personal Information including  ‘Name’, ‘Father’s/husband's name’, ’DOB’, Gender, ‘Marital status’, ‘Contact no’, Email-Id, and other relevant information.
5. After entering personal details the page will be redirected to qualification page. Where user has update his qualification details with required documents which has to be uploaded.
6. After which candidate can view his profile which is saved in the system. And later can edit the changes required.
7. All The documents (identity proof, address proof) should be less than 100kb in .jpeg, .png or jpg format.
8. All The documents (Marks card) should be less than 150kb in .jpeg, .png or jpg format.
9. Photo should be uploaded should be less than 75kb.</textarea>
                   
               </div>
            </div>
               <br />
               <div style="margin-left:45%;background:none">
               <asp:Button ID="startfill" runat="server" CssClass="btn btn-success"  Text="Start" Width="76px" Height="40px" OnClick="startfill_Click" />
</div>
    </form>
</asp:Content>