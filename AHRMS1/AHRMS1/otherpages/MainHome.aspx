<%@ Page Title="" Language="C#" MasterPageFile="~/ms/HomeMainMaster.Master" AutoEventWireup="true" CodeBehind="MainHome.aspx.cs" Inherits="AHRMS1.otherpages.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="Form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         
          <cc1:ModalPopupExtender ID="ModalPopupExtender1" CancelControlID="hel" PopupControlID="Panel1" BehaviorID="m1"  TargetControlID="HyperLink1" BackgroundCssClass="modalBackground" runat="server"></cc1:ModalPopupExtender>
        
                      <asp:Panel ID="Panel1"  align="center" style = "display:none" runat="server">
                          
             <div class="modal-dialog">
               <div class="modal-content" >
                   <div class="modal-header">
                       <button id="hel" data-dismiss="modal" style="text-align:right" class="close">X</button>
                       <h4 class="modal-title">Contact us</h4>
                  </div>
                   <div class="modal-body" style="text-align:left">
                   <asp:TextBox ID="TextBox1" Placeholder="Name" CssClass="textbox" Height="30%" runat="server"></asp:TextBox>
                       <br />
                       <br />
                   <asp:TextBox ID="TextBox2" Placeholder="Email" CssClass="textbox" Height="30%" runat="server"></asp:TextBox>
                     <br />
                       <br />
                       <asp:TextBox ID="TextBox3" Placeholder="Comments" CssClass="textbox" Height="70%" TextMode="MultiLine" runat="server"></asp:TextBox>  
                           </div>
                       <div class="modal-footer">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>

                           <asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
                                   </ContentTemplate>
             </asp:UpdatePanel> 
                      </div>
                 
                   
                        </div>
                    
                  </div>
               
             </asp:Panel>
             
     </form>
      
    </asp:Content>
