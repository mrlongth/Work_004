<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="recv_item_control.aspx.cs" Inherits="myWeb.App_Control.recv_item.recv_item_control" %>

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
                    <asp:DropDownList runat="server" CssClass="textbox" ID="cboRecv_item_type" AutoPostBack="True" OnSelectedIndexChanged="cboRecv_item_type_SelectedIndexChanged">
                        <asp:ListItem Value="">---- กรุณาเลือกข้อมูล ----</asp:ListItem>
                        <asp:ListItem Value="D">รายการรับ</asp:ListItem>
                        <asp:ListItem Value="C">รายการหัก</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cboRecv_item_type" ErrorMessage="กรุณาเลือกประเภทรายการ"
                        Display="None" SetFocusOnError="True" ValidationGroup="A" ID="RequiredFieldValidator3"></asp:RequiredFieldValidator>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label ID="lblPage8" runat="server">รหัสรายการ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:TextBox ID="txtrecv_item_code" runat="server" CssClass="textboxdis" Width="120px"></asp:TextBox>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label ID="Label75" runat="server" CssClass="label_error">*</asp:Label>
                    <asp:Label ID="lblPage11" runat="server">รายละเอียด :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:TextBox ID="txtrecv_item_name" runat="server" CssClass="textbox" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrecv_item_name" Display="None" ErrorMessage="กรุณาป้อนรายละเอียด" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td align="left" nowrap valign="middle">
                    &nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label ID="lblPage13" runat="server">หมายเหตุ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:TextBox ID="txtrecv_item_remark" runat="server" CssClass="textbox" Width="350px"></asp:TextBox>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label ID="lblPage12" runat="server">%หัก :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <cc1:AwNumeric ID="txtrecv_item_rate" runat="server" cssclass="textbox" leadzero="Show" maxvalue="99" minvalue="0" width="100px"></cc1:AwNumeric>
                </td>
                <td align="left" nowrap valign="middle">&nbsp;</td>
            </tr>
            <tr align="left">
                <td align="right" nowrap style="height: 17px" valign="middle">
                    <asp:Label ID="Label76" runat="server">หักให้ส่วนกลาง :</asp:Label>
                </td>
                <td align="left" nowrap style="height: 17px" valign="middle">
                    <asp:CheckBox ID="chkRecv_item_is_director" runat="server" Text="หัก" />
                </td>
                <td align="center" nowrap rowspan="2" style="width: 12%">
                    <asp:ImageButton ID="imgSaveOnly" runat="server" ImageUrl="~/images/controls/save.jpg" ValidationGroup="A" />
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
