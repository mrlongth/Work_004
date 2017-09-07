<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="item_control.aspx.cs" Inherits="myWeb.App_Control.item.item_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlContent" runat="server">
        <table border="0" cellpadding="2" cellspacing="0" style="width: 100%">
            <tr>
                <td align="right" nowrap valign="middle">&nbsp;
                </td>
                <td align="left" nowrap valign="middle" style="text-align: right">
                    <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
                    <asp:Label runat="server" ID="lblLastUpdatedBy">Last Updated By :</asp:Label>
                </td>
                <td align="left" width="1%">
                    <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="148px" ID="txtUpdatedBy"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <t>
                    <td align="right" nowrap valign="middle">&nbsp; </td>
                    <td align="left" nowrap style="text-align: right" valign="middle">&nbsp;<asp:Label ID="lblLastUpdatedDate" runat="server">Last Updated Date :</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUpdatedDate" runat="server" CssClass="textboxdis" ReadOnly="True" Width="148px"></asp:TextBox>
                        &nbsp; </td>
                </t>
            </tr>
        </table>
        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
            <tr align="left">
                <td align="right" nowrap valign="middle" width="25%">
                    <asp:Label runat="server" ID="Label14">ปีงบประมาณ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox" ID="cboYear">
                    </asp:DropDownList>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" CssClass="label_error" ID="Label71">*</asp:Label>
                    <asp:Label runat="server" ID="lblPage3">ประเภทรายการ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox" ID="cboItem_type">
                        <asp:ListItem Value="">---- กรุณาเลือกข้อมูล ----</asp:ListItem>
                        <asp:ListItem Value="D">Debit</asp:ListItem>
                        <asp:ListItem Value="C">Credit</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cboItem_type" ErrorMessage="กรุณาเลือกประเภทรายการ"
                        Display="None" SetFocusOnError="True" ValidationGroup="A" ID="RequiredFieldValidator3"></asp:RequiredFieldValidator>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" ID="lblPage8">รหัสรายได้/จ่าย :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:TextBox runat="server" CssClass="textboxdis" Width="120px"
                        ID="txtitem_code"></asp:TextBox>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" CssClass="label_error" ID="Label72">*</asp:Label>
                    <asp:Label runat="server" ID="lblPage9">รายได้/จ่าย :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:TextBox runat="server" CssClass="textbox" Width="350px" ID="txtitem_name"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtitem_name" ErrorMessage="กรุณาป้อนข้อมูลรายได้/ค่าใช้จ่าย"
                        Display="None" SetFocusOnError="True" ValidationGroup="A" ID="RequiredFieldValidator1"></asp:RequiredFieldValidator>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label ID="Label73" runat="server" CssClass="label_error">*</asp:Label>
                    <asp:Label runat="server" ID="lblPage4">หมวดรายได้/จ่าย :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox"
                        ID="cboItem_group" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="cboItem_group" Display="None" ErrorMessage="กรุณาเลือกหมวดรายได้/จ่าย" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label ID="Label74" runat="server" CssClass="label_error">*</asp:Label>
                    <asp:Label runat="server" ID="lblPage10">รายละเอียดหมวดรายได้/จ่าย :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox" ID="cboItem_group_detail">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="cboItem_group_detail" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดหมวดรายได้/จ่าย" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td align="center" nowrap rowspan="2" style="width: 12%">
                    <asp:ImageButton runat="server" ValidationGroup="A" ImageUrl="~/images/controls/save.jpg" ID="imgSaveOnly"></asp:ImageButton>

                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" ID="Label12">สถานะ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:CheckBox runat="server" Text="ปกติ" ID="chkStatus"></asp:CheckBox>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" />
                </td>
            </tr>

            <tr align="left">
                <td align="right" nowrap valign="middle">&nbsp;
                </td>
                <td align="left" nowrap valign="middle">&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
