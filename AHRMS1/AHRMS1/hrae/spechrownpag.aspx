<%@ Page Title="" Language="C#" MasterPageFile="~/ms/spehrpag.Master" AutoEventWireup="true" CodeBehind="spechrownpag.aspx.cs" Inherits="AHRMS1.ms.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="Form1" runat="server">
   
     <style type="text/css">
         .dddddddd {
             margin-left:46%;
         }
     </style>
    <script>
       
        $(function () {
            
            
            var string = "AHRMS Welcome's you";
            var q = jQuery.map(string.split(''), function (letter) {
                return $('<span>' + letter + '</span>');
            });

            var dest = $('#dynamicletter');

            var c = 0;
            var i = setInterval(function () {
                q[c].appendTo(dest).hide().fadeIn(500);
                c += 1;
                if (c >= q.length) clearInterval(i);
            }, 200);
        });


        $(function () {
            setTimeout(hel, 4150)
            
            function hel()
            {
                
                var string = document.getElementById("<%= lblhrname.ClientID %>").innerText;
                var q = jQuery.map(string.split(''), function (letter) {
                    return $('<span>' + letter + '</span>');
                });

                var dest = $('#Span1');

                var c = 0;
                var i = setInterval(function () {
                    q[c].appendTo(dest).hide().fadeIn(500);
                    c += 1;
                    if (c >= q.length) clearInterval(i);
                }, 200);
            }
            setTimeout(wait, 3000)
            function wait() {
                $('#Span1')
            }

        });
        </script>
    <div style="text-align:center">
    <span id="dynamicletter" style="color:purple;font-size:2.5em"></span>
    <br />
    <span id="Span1" style="color:green;font-size:2.5em"></span>
 </div>
         <asp:Label ID="lblhrname" runat="server" CssClass="dddddddd"  Width="0px"  Height="0px" Text="Company Name" Font-Size="0" ForeColor="Green"></asp:Label></li>  
</form>
    <link href="main.css" rel="stylesheet" />
    <link href="bootstrap.min.css" rel="stylesheet" />
    <section id="pricing-table">
            <div class="container">
                <div class="row">
                    <div class="pricing">
                        <div class="col-md-4 col-sm-12 col-xs-12">
                            <div class="pricing-table">
                                <div class="pricing-header">
                                    <p class="pricing-title">Ease Access</p>
                                    <p class="pricing-rate" style="font-size:1em">Candiate Documents & Experience</p>
                                    <a href="#" class="btn btn-custom">Click Here</a>
                                </div>

                                <div class="pricing-list">
                                    <ul>
                                        <li><i class="fa fa-envelope"></i>Access Documents</li>
                                        <li><i class="fa fa-signal"></i>Download Documents</li>
                                        <li><i class="fa fa-user"></i>View Experience</li>
                                        <li><i class="fa fa-smile-o"></i></li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4 col-sm-12 col-xs-12">
                            <div class="pricing-table">
                                <div class="pricing-header">
                                    <p class="pricing-title">Add Experience</p>
                                    <p class="pricing-rate" style="font-size:1em">To Registered or Unregistered Candidates</p>
                                    <a href="#" class="btn btn-custom">Click Here</a>
                                </div>

                                <div class="pricing-list">
                                    <ul>
                                        <li><i class="fa fa-envelope"></i>Add Experience</li>
                                        <li><i class="fa fa-signal"></i><span>Tag QR Code</span> to experience letter</li>
                                        <li><i class="fa fa-user"></i>Rate Canidate Performance</li>
                                        <li><i class="fa fa-smile-o"></i>Mention Skills Of Candiate</li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4 col-sm-12 col-xs-12">
                            <div class="pricing-table">
                                <div class="pricing-header">
                                    <p class="pricing-title">Verify/Validate</p>
                                    <p class="pricing-rate" style="font-size:1em" >Candidate Profile of Registered Candidate</p>
                                    <a href="#" class="btn btn-custom">Click Here</a>
                                </div>

                                <div class="pricing-list">
                                    <ul>
                                        <li><i class="fa fa-envelope"></i>Verify Candidate Education Details</li>
                                        <li><i class="fa fa-signal"></i>Verify Candiate experience</li>
                                        <li><i class="fa fa-user"></i>Verify candidate documents</li>
                                        <li><i class="fa fa-smile-o"></i>Just Scan to verify details</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

</asp:Content>
