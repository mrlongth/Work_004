<%@ Page Language="C#" MasterPageFile="~/Site_main.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="myWeb.Default" Title="ระบบบริหารจัดการงบประมาณ คณะผลิตกรรมการเกษตร มหาวิทยาลัยแม่โจ้ เชียงใหม่" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content_left">
        <div class="head_news">
            <asp:Label ID="Label1" runat="server" CssClass="label_h">ข่าวประชาสัมพันธ์</asp:Label>
        </div>
        <div class="mid_news">
            <asp:Repeater ID="RpPin" runat="server" EnableViewState="False" OnItemDataBound="RpNew_ItemDataBound">
                <ItemTemplate>
                    <div class="news">
                        <asp:HyperLink ID="lblNewTitle" runat="server" Style="text-decoration: none;" NavigateUrl="Menu_control.aspx" />
                        <asp:Image ID="imgNewType" runat="server" ImageUrl="images/new/update2day.gif" />
                        <asp:Image ID="imgNewStatus" runat="server" ImageUrl="images/new/update2day.gif" />
                    </div>
                    <div class="date">
                        <asp:Label ID="lblDate" runat="server" />
                    </div>
                    <div class="read_more">
                        <asp:ImageButton ID="imgRead_more" runat="server" ImageUrl="~/images/readmore_bt.png"
                            TabIndex="-1" />
                    </div>
                    <div class="divider">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="RpNew" runat="server" EnableViewState="False" OnItemDataBound="RpNew_ItemDataBound">
                <ItemTemplate>
                    <div class="news">
                        <asp:HyperLink ID="lblNewTitle" runat="server" Style="text-decoration: none;" NavigateUrl="Menu_control.aspx" />
                        <asp:Image ID="imgNewType" runat="server" ImageUrl="images/new/update2day.gif" />
                        <asp:Image ID="imgNewStatus" runat="server" ImageUrl="images/new/update2day.gif" />
                    </div>
                    <div class="date">
                        <asp:Label ID="lblDate" runat="server" />
                    </div>
                    <div class="read_more">
                        <asp:ImageButton ID="imgRead_more" runat="server" ImageUrl="~/images/readmore_bt.png"
                            TabIndex="-1" />
                    </div>
                    <div class="divider">
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div style="text-align: right; font: 14px Verdana, Geneva, sans-serif; color: #0083c6;">
                <asp:HyperLink ID="lblNewAll" runat="server" Style="text-decoration: none;" NavigateUrl="~/App_Control/news/news_show_list.aspx"
                    Text="อ่านทั้งหมด" />
            </div>
        </div>
        <div class="bt_news">
        </div>
    </div>
    <asp:Panel ID="pnlcontent_right" runat="server" class="content_right" DefaultButton="ImageButton1">
        <div class="login_panel" style="background: url(images/login_panel.png); width: 364px; height: 263px;">
            <table width="100%" border="0" cellspacing="0" cellpadding="8" class="table_login">
                <tr>
                    <td width="31%" align="right">Username :
                    </td>
                    <td width="69%">
                        <asp:TextBox ID="txtUser" runat="server" CssClass="text_f" CausesValidation="True"
                            ValidationGroup="A" Width="193px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="text_f" Width="193px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div class="login_bt" runat="server">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login_bt.png"
                    OnClick="ImageButton1_Click" ValidationGroup="A"></asp:ImageButton>
            </div>
        </div>
    </asp:Panel>
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUser" ErrorMessage="กรุณาป้อน Username"
        Display="None" ValidationGroup="A" ID="RequiredFieldValidator1" SetFocusOnError="True"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPass" ErrorMessage="กรุณาป้อน Password"
        Display="None" ValidationGroup="A" ID="RequiredFieldValidator2" SetFocusOnError="True"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="A" />
    <asp:Label ID="lblError" runat="server" CssClass="label_error"></asp:Label>
    <!-- Hidden Field -->
    <asp:HiddenField ID="hidForModel" runat="server" />

    <cc1:ModalPopupExtender
        ID="WarningModal"
        TargetControlID="hidForModel"
        runat="server"
        BackgroundCssClass="overlay"
        CancelControlID="btnWarning"
        DropShadow="true"
        PopupControlID="pnlIssues">
    </cc1:ModalPopupExtender>

    <!-- Panel -->
    <asp:Panel ID="pnlIssues" runat="server" Style="display: none;"
        BorderColor="Black" BorderStyle="Outset"
        BorderWidth="2" BackColor="#f6b810" Width="500px">
        <center>
            <br />
            <div style="float: left; width: 200px;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/user_accounts_alt.png" />
            </div>
            <div style="float: left; width: 300px;">
                <h2 class="style2">เลือกประเภทกลุ่มผู้ใช้งาน</h2>
                <br />
                <asp:Repeater ID="rptUserGroupSelect" runat="server">
                    <ItemTemplate>
                        <%--<asp:ImageButton ID="btnSelect" runat="server" ImageUrl="~/images/user_group_select.png" />--%>
                        <asp:Button ID="btnSelect" runat="server" Text='<%# Eval("user_group_name") %>' Width="250px" OnClick="btnSelect_Click" />
                        <asp:Label ID="lblUserGroup" runat="server" Text='<%# Eval("user_group_code") %>' Visible="false"></asp:Label>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <br />
            <br />
            <!-- Label in the Panel to turn off the popup -->
            <div>
                <asp:ImageButton ID="btnWarning" runat="server"
                    ImageUrl="~/images/controls/delete.png" />
                <asp:Label ID="Label2" runat="server" Text="ปิดหน้านี้"></asp:Label>
                <br />
                <br />
            </div>
        </center>

    </asp:Panel>

</asp:Content>
