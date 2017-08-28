﻿<%@ Page Language="C#" MasterPageFile="~/Site_person.Master" AutoEventWireup="true"
    CodeBehind="MainPerson.aspx.cs" Inherits="myWeb.MainPerson" Title="เมนูการใช้งาน/หลักสูตร" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
            <td>
                <div class="seven">
                </div>
            </td>
            <td align="center">
                <div class="main_menu_bg">
                    <div class="select">
                        เลือกทำรายการที่ท่านต้องการ
                    <asp:Label ID="lblError" runat="server" CssClass="label_error"></asp:Label>
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 40px;">
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/profile.png"
                                    OnClick="imbHistory_Click" Height="155px" Width="143px" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="imbSlip" runat="server" ImageUrl="~/images/slip1.png" OnClick="imbSlip_Click"
                                    Height="155px" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="imbCertificate" runat="server" ImageUrl="~/images/slip2.png"
                                    OnClick="imbCertificate_Click" Height="155px" Visible="false" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="imbLoan" runat="server" ImageUrl="~/images/slip3.png" Height="155px"
                                    OnClick="imbLoan_Click" Visible="false" />
                            </td>
                        </tr>
                    </table>
                    <div class="logout">
                        <asp:LinkButton ID="lnkLogout" runat="server" CssClass="logout_link" OnClick="lnkLogout_Click">ออกจากระบบ</asp:LinkButton>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <asp:LinkButton ID="lbnChangePassAlert" Style="display: none;" runat="server">LinkButton</asp:LinkButton>
      <script type="text/javascript">
          function RegisterScript() {
              $("#<%=lbnChangePassAlert.ClientID%>").on("click", function () {
                alert($(this).text());
            });
        }
    </script>
</asp:Content>
