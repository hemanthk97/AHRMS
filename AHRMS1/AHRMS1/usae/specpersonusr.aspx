<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="specpersonusr.aspx.cs" MasterPageFile="~/ms/specusrmas.Master" Inherits="AHRMS1.usae.specpersonusr" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <script type ="text/javascript">
        var today = new Date();

        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        today = mm + '/' + dd + '/' + yyyy;

        $(function () {
            $('.datepicker').datepicker(
                {
                    endDate: today,
                    format: "dd-mm-yyyy"
                });
        });
</script>
<style type="text/css">
    input::-webkit-input-placeholder {  color: #b2b2b2; }
input::-moz-placeholder {  color: #b2b2b2; }
input:-ms-input-placeholder {  color: #b2b2b2; }
input:-moz-placeholder {  color: #b2b2b2; }
</style>
    <form id="Form1" runat="server">
         <div class="clearfix">
            <br />
           <div style="margin-top:1% ;margin-left:10%; margin-bottom:1%;padding:0 0 0 0;font-size:1.5em;color:Green" >
            <p runat="server" id="heading">STEP 1:- Fill The Personal Details</p></div> 
        <div class="personcol">
        <ol style="border-bottom:6px double green">
            <li style="font-size:1.8em; text-decoration:underline; color:Green">Personal Details</li>
            <br />
            <li>
                <asp:TextBox ID="firstnamespusr" placeholder="First Name" Font-Bold="true" CssClass="textbox" Width="175px" runat="server"></asp:TextBox>
                <asp:TextBox ID="middlename" placeholder="Middle Name" Font-Bold="true"  CssClass="textbox" Width="100px" runat="server"></asp:TextBox>
                <asp:TextBox ID="lastnamespusr" placeholder="Last Name" Font-Bold="true" CssClass="textbox" Width="100px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1spusr" ValidationGroup="up" ForeColor="Red" Text="Enter first name" Display="Dynamic" ControlToValidate="firstnamespusr"
                    runat="server"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
               
            </li>
            <br />
            <li>
                <asp:TextBox ToolTip="Enter as in your 10th Marks card" ID="fathername"  Font-Bold="true" placeholder="Father Name" runat="server" CssClass="textbox" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="up" runat="server" ErrorMessage="*" Text="Enter your father name" ControlToValidate="fathername" ForeColor="Red"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                
                <asp:TextBox ID="dateofbirth" cssClass="datepicker textbox1" Font-Bold="true"  placeholder="Date Of Birth"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1month" ValidationGroup="up" ForeColor="Red" Text="Select Date of birth" Display="Dynamic" ControlToValidate="dateofbirth"
                    runat="server"
                    ErrorMessage="select month"></asp:RequiredFieldValidator>
            </li>
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

            <li>
                <asp:DropDownList ID="gender" runat="server" Font-Bold="true" Height="30px" CssClass="textbox">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                     </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="up" ErrorMessage="*" Text="Select Gender" ForeColor="Red" ControlToValidate="gender"  InitialValue="-1"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
             <asp:TextBox ID="usrperaddress" Font-Bold="true" CssClass="textbox" placeholder="Permanent Address" Height="70px" runat="server" TextMode="MultiLine"  Wrap="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="up" runat="server" ErrorMessage="*" Text="Enter Address" ForeColor="Red" ControlToValidate="usrperaddress" ></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <asp:DropDownList ID="dropstate" Font-Bold="true" AutoPostBack="true" DataValueField="StateID"  palcehoder="state" ToolTip="Select State" Height="30px" DataTextField="State" 
                     CssClass="textbox" runat="server" OnSelectedIndexChanged="dropstate_SelectedIndexChanged">
                </asp:DropDownList><span style="float:right;margin-right:68%"><asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                    <asp:Image  ImageUrl="~/Images/Skype balls loader.gif" Height="24px" Width="24px" runat="server"></asp:Image>
                   </ProgressTemplate>
                         </asp:UpdateProgress></span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="up" ErrorMessage="*" Text="Select State" ForeColor="Red" ControlToValidate="dropstate" InitialValue="-1"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
               <asp:DropDownList ID="dropcity" DataTextField="CityName"  Font-Bold="true"  DataValueField="CityID" ToolTip="Select City" palceholder="City" Height="30px" CssClass="textbox" runat="server">

               </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="up" ErrorMessage="*" Text="Select State" ForeColor="Red" ControlToValidate="dropcity" InitialValue="-1"></asp:RequiredFieldValidator>
            </li>
               
                    </ContentTemplate>
                     </asp:UpdatePanel>
            <br />
            <li>

                <asp:TextBox ID="pincode" CssClass="textbox" Font-Bold="true"  MaxLength="6"  placeholder="Pincode" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" ValidationGroup="up" runat="server" ErrorMessage="*" Text="Enter Pincode" ControlToValidate="pincode" ForeColor="Red" ></asp:RequiredFieldValidator>  
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="Invalid Pincode" Display="Dynamic" ForeColor="red" Text="Invalid Pincode" ValidationGroup="up" ControlToValidate="pincode" ValidationExpression="^[0-9]{6}" ></asp:RegularExpressionValidator>
                 </li>
            <br />
           
            <li>
                <asp:TextBox ID="usrnumber" MaxLength="10" Font-Bold="true" CssClass="textbox" placeholder="Contact Number" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="up" ErrorMessage="*" Text="Enter Phone Number" ForeColor="Red" ControlToValidate
                    ="usrnumber" Display="Dynamic" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="up" ErrorMessage="*" Display="Dynamic" Text="Invalid Mob Number" ForeColor="Red" ControlToValidate
                    ="usrnumber" ValidationExpression="^[7-9][0-9]{9}$" ></asp:RegularExpressionValidator>
                 </li>
            <br />
            
            </ol>
        <ol>
           
            <br />
            <li style="margin-left:33%" runat="server" id="message1">After filling all the details press submit</li>
            <li style="margin-left:33%" runat="server" id="message2">On Success you will be Redirected to Qualification Section</li>
            <br />
            <li style="margin-left:40%"> <asp:Button ID="btnpersonaldet" ValidationGroup="up" CssClass="btn btn-success" Text="Submit" runat="server" Width="100px" OnClick="btnpersonaldet_Click" /> </li>
            <br />
             <asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server"></asp:ScriptManagerProxy>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
            <li style="margin-left:40%">
                <asp:Button ID="btnupdateperdel" ValidationGroup="up"  CssClass="btn btn-success" runat="server" Width="100px" Text="Update" OnClick="btnupdateperdel_Click" /></li>
            <li><asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel3" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1"  runat="server" ImageUrl="~/Images/ajax_loader_blue_32.gif" Width="100px" />
                    </ProgressTemplate>
                    </asp:UpdateProgress> </li>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>

            
        </ol>
            </div>
             </div>
       
    </form>

</asp:Content>
