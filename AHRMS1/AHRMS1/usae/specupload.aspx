<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="specupload.aspx.cs" MasterPageFile="~/ms/specusrmas.Master" Inherits="AHRMS1.usae.specupload" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="Form1" runat="server">
         
         <div class="clearfix">
            <br />
                                

           <div style="margin-top:1% ;margin-left:10%; margin-bottom:1%;padding:0 0 0 0;font-size:1.5em;color:Green" >
            <p style="color:blue">STEP 3:- Upload Your Marks Cards</p></div>
            <div id="imagenote"><p id="note" class="hvr-sweep-to-right" style="border:1px double blue; font-size:0.7em; width:40%" >
         Note:-<br />
                1. Please Upload documents properly as the edition of the documents is again a pain for you<br /> 
                2. Ensure that your image size should be less than 500kb.<br />
                3. Ensure that your image format is either jpg, jpeg, png(other formats are not allowed)<br />
                4. Check the pictures before uploading<br />
                5. The Image should be clear.<br />
              </p></div>
             <div class="personcol">
                 <ol>
                     <li style="font-size:1.8em; text-decoration:underline; color:blue">Please Upload ID/Address Proof</li>
                         <li><span class="red">*</span> PAN CARD/Any other ID Proof
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                             <asp:Label ID="lblfileupload1" runat="server" Text=""></asp:Label>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$" ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>
                     </li>
                     <li><span class="red">*</span> PASSPORT / Any other Address Proof
                         <asp:FileUpload ID="FileUpload2" runat="server" />
                         <asp:Label ID="lblfileupload2" runat="server" Text=""></asp:Label>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="FileUpload2" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"  ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>
                     </li>
                    <li style="font-size:1.8em; text-decoration:underline; color:blue">Please Upload Your Documents</li>
                     <br />
                     <li><span class="red">*</span> 10th / SSLC Marks Card
                         <asp:FileUpload ID="sslcmarkscard" runat="server" />
                         <asp:Label ID="lblsslc" runat="server" Text=""></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="sslcmarkscard" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"  ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>
                     </li>
                     <li><span class="red">*</span> Pu / 12th Marks Card
                         <asp:FileUpload ID="pumarkscard" runat="server" />
                         <asp:Label ID="lblpuc" runat="server" Text=""></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="pumarkscard" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"  ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>
                     </li>
                     <li class="dipover"><span><a class="diploma" onclick="$('#diploma_record').toggle(1000);; return false;" runat="server">Click  Here If you have diploma</a></span></li>
                     </ol>
                     <div id="diploma_record" style="display:none">
                     <ol>
                         <li>
                             Diploma Certificate
                             <asp:FileUpload ID="diplomacertificate" runat="server" />
                            <asp:Label ID="lbldip" runat="server" Text=""></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="diplomacertificate" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"  ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>
                         </li>
                     </ol>    
                     </div>
                 <ol>
                     <li> Degree Convacation / Provisional Degree Certificate
                         <asp:FileUpload ID="degreecertificate" runat="server" />
                         <asp:Label ID="lblgrad" runat="server" Text=""></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="degreecertificate" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"  ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>
                     </li>
                     <li> PG Convacation / Provisional Degree Certificate
                     <asp:FileUpload ID="pgcertificate" runat="server" />
                         <asp:Label ID="lblpg" runat="server" Text=""></asp:Label>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="pgcertificate" ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"  ErrorMessage="Upload Only Images" ForeColor="Red" Text="Upload Only Images"></asp:RegularExpressionValidator>                    
                     </li>
                     <li>
                        
                     </li>
                     <br />
                      
                     
                     <li><asp:Button ID="uploaddoc" CssClass="btn btn-success" Width="150px"  runat="server" OnClick="uploaddoc_Click" Text="Upload" /></li>
                 </ol>
               <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
             

             </div>
             
             
             
         </div>
 
         </form> 
</asp:Content>
