﻿<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" AutoEventWireup="true"
    CodeBehind="produce_view.aspx.cs" Inherits="myWeb.App_Control.produce.produce_view" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr>
            <td align="left" nowrap style="width: 90%;">
                &nbsp;
            </td>
            <td align="left" style="width: 0%">
                &nbsp;
            </td>
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
            <td align="right" nowrap valign="middle">
                &nbsp;</td>
            <td align="left" nowrap valign="middle">
                &nbsp;</td>
            <td align="left" class="style2" nowrap valign="middle">
                &nbsp;</td>
            <td align="left" colspan="2" nowrap valign="middle">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle" style="height: 25px">
                <asp:Label runat="server" ID="lblFName">รหัสผลผลิต :</asp:Label>
            </td>
            <td align="left" nowrap valign="middle" style="height: 25px">
                <asp:TextBox ID="txtproduce_code" runat="server" CssClass="textboxdis" MaxLength="30"
                    ReadOnly="True" Width="144px"></asp:TextBox>
            </td>
            <td align="left" class="style2" nowrap valign="middle" 
                style="height: 25px; text-align: right">
                <asp:Label ID="Label11" runat="server">ผลผลิต :</asp:Label>
            </td>
            <td align="left" colspan="2" nowrap valign="middle" style="height: 25px">
                <font face="Tahoma">&nbsp;<asp:TextBox ID="txtproduce_name" runat="server" CssClass="textboxdis"
                    MaxLength="100" ReadOnly="True"   Width="300px"></asp:TextBox>
                </font>
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle">
                <asp:Label ID="lblFName0" runat="server">รหัสแผนงบประมาณ  :</asp:Label>
            </td>
            <td align="left" nowrap valign="middle">
                <asp:TextBox ID="txtbudget_code" runat="server" CssClass="textboxdis" MaxLength="30"
                    ReadOnly="True"   Width="144px"></asp:TextBox>
            </td>
            <td align="left" class="style2" nowrap valign="middle" 
                style="text-align: right">
                <asp:Label ID="Label14" runat="server">แผนงบประมาณ  :</asp:Label>
            </td>
            <td align="left" colspan="2" nowrap valign="middle">
                <font face="Tahoma">&nbsp;<asp:TextBox ID="txtbudget_name" runat="server" CssClass="textboxdis"
                    MaxLength="100" ReadOnly="True"   Width="300px"></asp:TextBox>
                </font>
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle">
                <asp:Label ID="Label13" runat="server">ปีงบประมาณ :</asp:Label>
            </td>
            <td align="left" nowrap valign="middle">
                <asp:TextBox ID="txtyear" runat="server" CssClass="textboxdis"
                    ReadOnly="True"   Width="144px"></asp:TextBox>
            </td>
            <td align="left" class="style2" nowrap valign="middle">
                &nbsp;</td>
            <td align="left" colspan="2" nowrap valign="middle">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle">
                <asp:Label ID="Label12" runat="server">สถานะ :</asp:Label>
            </td>
            <td align="left" nowrap valign="middle" colspan="2">
                <asp:CheckBox ID="chkStatus" runat="server" Enabled="False" Text="ปกติ" />
            </td>
            <td align="right" nowrap valign="middle">
            </td>
            <td rowspan="2" align="center" style="width: 15%">
                <br />
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle">
            </td>
            <td align="left" nowrap valign="middle" colspan="2">
            </td>
            <td align="right">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
