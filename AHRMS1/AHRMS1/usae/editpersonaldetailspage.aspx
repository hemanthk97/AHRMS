<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ms/specusrmas.Master" CodeBehind="editpersonaldetailspage.aspx.cs" Inherits="AHRMS1.editpersonaldetailspage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).ready(function () {
            $('#dddd').hide();;
            return false;
        });
    </script>
    <form id="Form1" runat="server">
         <div class="clearfix">
            <br />
           <div style="margin-top:1% ;margin-left:10%; margin-bottom:1%;padding:0 0 0 0;font-size:1.5em;color:Green" >
            <p>Edit Personal Details</p>
               <p>Fill All mandtory fields once again</p>
           </div> 
        <div class="personcol">
        <ol style="border-bottom:1px solid Grey">
            <li style="font-size:1.8em; text-decoration:underline; color:Green">Personal Details</li>
            <br />
            <li>
                <label style="padding-right:15%" >Name ::</label><asp:TextBox ID="firstnamespusr" placeholder="First Name" CssClass="textbox" Width="175px" runat="server"></asp:TextBox>
                <asp:TextBox ID="lastnamespusr" placeholder="Last Name" CssClass="textbox" Width="100px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1spusr" ForeColor="Red" Text="Enter first name" Display="Dynamic" ControlToValidate="firstnamespusr"
                    runat="server"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
               
            </li>
            <br />
            <li>
                <label style="padding-right:9.8%" >Father Name ::</label><asp:TextBox ID="fathername" placeholder="Father Name" runat="server" CssClass="textbox" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Text="Enter your father name" ControlToValidate="fathername" ForeColor="Red"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <label style="padding-right:16.2%" >DOB ::</label><asp:DropDownList ID="month"  CssClass="textbox" Width="100px" Height="30px" runat="server">
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
                    <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                    </asp:DropDownList>
                <asp:DropDownList ID="day" CssClass="textbox" Width="100px"  Height="30px" runat="server">
                    <asp:ListItem Text="Day" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                    <asp:ListItem Text="20" Value="21"></asp:ListItem>
                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="year" CssClass="textbox" Width="100px" Height="30px" runat="server">
                    <asp:ListItem Text="Year" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="1970" Value="1970"></asp:ListItem>
                    <asp:ListItem Text="1971" Value="1971"></asp:ListItem>
                    <asp:ListItem Text="1972" Value="1972"></asp:ListItem>
                    <asp:ListItem Text="1973" Value="1973"></asp:ListItem>
                    <asp:ListItem Text="1974" Value="1974"></asp:ListItem>
                    <asp:ListItem Text="1975" Value="1975"></asp:ListItem>
                    <asp:ListItem Text="1976" Value="1976"></asp:ListItem>
                    <asp:ListItem Text="1977" Value="1977"></asp:ListItem>
                    <asp:ListItem Text="1978" Value="1978"></asp:ListItem>
                    <asp:ListItem Text="1979" Value="1979"></asp:ListItem>
                    <asp:ListItem Text="1980" Value="1980"></asp:ListItem>
                    <asp:ListItem Text="1981" Value="1981"></asp:ListItem>
                    <asp:ListItem Text="1982" Value="1982"></asp:ListItem>
                    <asp:ListItem Text="1983" Value="1983"></asp:ListItem>
                    <asp:ListItem Text="1984" Value="1984"></asp:ListItem>
                    <asp:ListItem Text="1985" Value="1985"></asp:ListItem>
                    <asp:ListItem Text="1986" Value="1986"></asp:ListItem>
                    <asp:ListItem Text="1987" Value="1987"></asp:ListItem>
                    <asp:ListItem Text="1988" Value="1988"></asp:ListItem>
                    <asp:ListItem Text="1989" Value="1989"></asp:ListItem>
                    <asp:ListItem Text="1990" Value="1990"></asp:ListItem>
                    <asp:ListItem Text="1991" Value="1991"></asp:ListItem>
                    <asp:ListItem Text="1992" Value="1992"></asp:ListItem>
                    <asp:ListItem Text="1993" Value="1993"></asp:ListItem>
                    <asp:ListItem Text="1994" Value="1994"></asp:ListItem>
                    <asp:ListItem Text="1995" Value="1995"></asp:ListItem>
                    <asp:ListItem Text="1996" Value="1996"></asp:ListItem>
                    <asp:ListItem Text="1997" Value="1997"></asp:ListItem>
                    <asp:ListItem Text="1998" Value="1998"></asp:ListItem>
                    <asp:ListItem Text="1999" Value="1999"></asp:ListItem>
                    <asp:ListItem Text="2000" Value="2000"></asp:ListItem>
                    <asp:ListItem Text="2001" Value="2001"></asp:ListItem>
                    <asp:ListItem Text="2002" Value="2002"></asp:ListItem>
                    <asp:ListItem Text="2003" Value="2003"></asp:ListItem>
                    <asp:ListItem Text="2004" Value="2004"></asp:ListItem>
                    <asp:ListItem Text="2005" Value="2005"></asp:ListItem>
                    <asp:ListItem Text="2006" Value="2006"></asp:ListItem>
                    <asp:ListItem Text="2007" Value="2007"></asp:ListItem>
                    <asp:ListItem Text="2008" Value="2008"></asp:ListItem>
                    <asp:ListItem Text="2009" Value="2009"></asp:ListItem>
                    <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                    </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1month" ForeColor="Red" Text="*" Display="Dynamic" ControlToValidate="month"
                    runat="server" InitialValue="-1"
                    ErrorMessage="select month"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2day" ForeColor="Red" Text="*" Display="Dynamic" ControlToValidate="day"
                    runat="server" InitialValue="-1"
                    ErrorMessage="Select Day"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" Text="*"  Display="Dynamic" ControlToValidate="year"
                    runat="server" InitialValue="-1"
                    ErrorMessage="Select Year"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <label style="padding-right:14%" >Gender ::</label><asp:DropDownList ID="gender" runat="server" Height="30px" CssClass="textbox">
                    <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                   </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" Text="Select Gender" ForeColor="Red" ControlToValidate="gender"  InitialValue="-1"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <label style="padding-right:15.4%" >State ::</label><asp:DropDownList ID="dropstate" DataValueField="stateid" Height="30px" DataTextField="State" 
                    AutoPostBack="true"  CssClass="textbox" runat="server">
      </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" Text="Select State" ForeColor="Red" ControlToValidate="dropstate" InitialValue="-1"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <label style="padding-right:16.2%" >City ::</label><asp:DropDownList ID="dropcity" DataTextField="city" DataValueField="cityid" Height="30px" CssClass="textbox" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" Text="Select State" ForeColor="Red" ControlToValidate="dropcity" InitialValue="-1"></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <label style="padding-right:13.4%" >Pincode ::</label><asp:TextBox ID="pincode" CssClass="textbox"  MaxLength="6" TextMode="Number" placeholder="Pincode" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" Text="Enter Pincode" ControlToValidate="pincode" ForeColor="Red" ></asp:RequiredFieldValidator>  
            </li>
            <br />
            <li>
             <label style="padding-right:13.4%" >Address ::</label><asp:TextBox ID="usrperaddress" CssClass="textbox" placeholder="Address" runat="server" TextMode="MultiLine"  Wrap="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" Text="Enter Address" ForeColor="Red" ControlToValidate="usrperaddress" ></asp:RequiredFieldValidator>
            </li>
            <br />
            <li>
                <label style="padding-right:11.3%" >Contact No ::</label><asp:TextBox ID="usrnumber" MaxLength="10" CssClass="textbox" placeholder="Contact Number" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" Text="Enter Phone Number" ForeColor="Red" ControlToValidate
                    ="usrnumber" Display="Dynamic" ></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="*" Display="Dynamic" Text="Invalid Mob Number" ForeColor="Red" ControlToValidate
                    ="usrnumber" ValidationExpression="^[7-9][0-9]{9}$" ></asp:RegularExpressionValidator>
                 </li>
            <br />
            <li style="margin-left:40%"> <asp:Button ID="btnpersonaldetupdate" CssClass="btn btn-success" Text="Update" runat="server" Width="100px" /></li>
            <li>
                <asp:Label ID="lblupdationsuccess" runat="server" Text="Label"></asp:Label></li>
            <span class="dipover" style="font-size:1.3em;color:Gray"><asp:hyperlink ID="A1" class="diploma" NavigateUrl="~/marcbuils-jquery.webcamqrcode-3fd7723/WebForm2.aspx" runat="server">Go Back</asp:hyperlink></span>
                </ol>
 </div>
             </div>
       
    </form>

</asp:Content>