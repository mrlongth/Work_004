﻿<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="work_control.aspx.cs" Inherits="myWeb.App_Control.work.work_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr>
            <td align="left" nowrap style="width: 90%;">&nbsp;</td>
            <td align="left" style="width: 0%">&nbsp;</td>
        </tr>
        <tr>
            <td align="left" nowrap style="text-align: right">
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
                <asp:Label runat="server" ID="lblLastUpdatedBy">Last Updated By :</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="144px" ID="txtUpdatedBy"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" nowrap style="text-align: right">
                <asp:Label runat="server" CssClass="text" ID="lblLastUpdatedDate">Last Updated Date :</asp:Label>
            </td>
            <td align="left">
                <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="144px" ID="txtUpdatedDate"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr align="left">
            <td align="right" nowrap valign="top">
                <asp:Label runat="server" ID="lblFName">รหัสงาน :</asp:Label>
            </td>
            <td align="left" colspan="2" nowrap valign="top">
                <asp:TextBox ID="txtwork_code" runat="server" CssClass="textbox" MaxLength="5"
                    Width="144px" ValidationGroup="A"></asp:TextBox>
            </td>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="top">
                <asp:Label runat="server" CssClass="label_error" ID="Label71">*</asp:Label>
                <asp:Label ID="Label11" runat="server">งาน :</asp:Label>
            </td>
            <td align="left" colspan="2" nowrap valign="top">
                <font face="Tahoma">
                    <asp:TextBox ID="txtwork_name" runat="server" CssClass="textbox"
                        MaxLength="100" Width="344px" CausesValidation="True" ValidationGroup="A"></asp:TextBox>
                </font>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="top" style="height: 23px">
                <asp:Label ID="Label13" runat="server">ปีงบประมาณ :</asp:Label>
            </td>
            <td align="left" colspan="2" nowrap valign="top" style="height: 23px">
                <asp:DropDownList ID="cboYear" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
            <td style="height: 23px"></td>
            <td style="height: 23px"></td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="top">
                <asp:Label ID="Label12" runat="server">สถานะ :</asp:Label>
            </td>
            <td align="left" colspan="2" nowrap valign="top">
                <font face="Tahoma">
                    <asp:CheckBox ID="chkStatus" runat="server" Text="ปกติ" />
                </font>
            </td>
            <td nowrap rowspan="4" align="center" colspan="2">
                <asp:ImageButton ID="imgSaveOnly" runat="server" ImageUrl="~/images/controls/save.jpg"
                    ValidationGroup="A" />
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="top">&nbsp;</td>
            <td align="left" nowrap valign="top" colspan="2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtwork_name"
                    Display="None" ErrorMessage="กรุณาป้อนงาน" ValidationGroup="A"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" />
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="top" style="height: 20px">&nbsp;</td>
            <td align="left" nowrap valign="top" style="height: 20px">&nbsp;</td>
            <td align="right" nowrap valign="top" style="height: 20px">&nbsp;
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="top">&nbsp;
            </td>
            <td align="left" nowrap valign="top">&nbsp;
            </td>
            <td align="right" nowrap style="text-align: left" valign="top">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
