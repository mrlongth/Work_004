<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="menu_control.aspx.cs" Inherits="myWeb.App_Control.menu.menu_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register assembly="Aware.WebControls" namespace="Aware.WebControls" tagprefix="cc1" %>
<asp:content id="Content1" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="1" cellspacing="2" style="width: 100%">
        <tr align="center">
            <td>
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="left" nowrap style="text-align: right" valign="middle">
                            <asp:label runat="server" cssclass="label_error" id="lblError"></asp:label>
                        </td>
                        <td align="left" style="width: 0%">
                            &#160;&#160;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap style="text-align: right" valign="middle">
                            <asp:label id="lblLastUpdatedBy" runat="server" cssclass="label_hbk">Last Updated By :</asp:label>
                        </td>
                        <td align="left" width="15%">
                            <asp:textbox id="txtUpdatedBy" runat="server" cssclass="textboxdis" readonly="True"
                                width="148px">
                            </asp:textbox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" nowrap style="text-align: right" valign="middle">
                            <asp:label id="lblLastUpdatedDate" runat="server" cssclass="label_hbk">Last Updated Date :</asp:label>
                        </td>
                        <td align="left">
                            <asp:textbox id="txtUpdatedDate" runat="server" cssclass="textboxdis" readonly="True"
                                width="148px">
                            </asp:textbox>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="2" cellspacing="0" style="width: 100%;">
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label80" runat="server" cssclass="label_error">*</asp:label>
                            <asp:label id="Label81" runat="server" cssclass="label_hbk">ชื่อเมนู :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="4">
                            <asp:textbox runat="server" cssclass="textbox" width="400px" id="txtMenuName"
                                maxlength="255"></asp:textbox>
                            <asp:hiddenfield id="hddMenuID" runat="server" />
                            <asp:hiddenfield id="hddMenuName" runat="server" />
                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" controltovalidate="txtMenuName"
                                display="None" errormessage="กรุณาป้อนชื่อเมนู" validationgroup="A" setfocusonerror="True"></asp:requiredfieldvalidator>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label82" runat="server" cssclass="label_hbk">Url :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="4">
                            <asp:textbox runat="server" cssclass="textbox" width="400px" id="txtMenuNavigationUrl"
                                maxlength="255"></asp:textbox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label83" runat="server" cssclass="label_hbk">ImageUrl :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="4">
                            <asp:textbox runat="server" cssclass="textbox" width="400px" id="txtMenuImageUrl"
                                maxlength="255"></asp:textbox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label84" runat="server" cssclass="label_hbk">Target :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="4">
                            <asp:dropdownlist runat="server" cssclass="textbox" id="cboMenuTarget" >
                                <asp:ListItem Selected="True">_self</asp:ListItem>
                                <asp:ListItem>_blank</asp:ListItem>
                                <asp:ListItem>_parent</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label21" runat="server" cssclass="label_hbk">เมนูหลัก :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="4">
                            <asp:dropdownlist runat="server" cssclass="textbox" id="cboMenuParent" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label79" runat="server" cssclass="label_hbk">ลำดับเมนู :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="4">
                            <cc1:AwNumeric runat="server" MaxValue="99999999" MinValue="-99999999" CssClass="textbox" Width="100px" ID="txtMenuOrder" DecimalPlaces="0"></cc1:AwNumeric>

                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label85" runat="server" cssclass="label_hbk">สามารถกำหนดสิทธิ์ :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" style="width: -40%">
                            <font face="Tahoma">
                                <asp:checkbox id="chkCanView" runat="server" text="การดู" checked="True" />
                            </font>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="2" style="width: 0%">
                            <font face="Tahoma">
                                <asp:checkbox id="chkCanInsert" runat="server" text="การเพิ่ม" checked="True" />
                            </font>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" style="width: 13%">
                            <font face="Tahoma">
                                <asp:checkbox id="chkCanEdit" runat="server" text="การแก้ไข" checked="True" />
                            </font>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            &nbsp;</td>
                        <td align="left" nowrap valign="middle" width="40%" style="width: -40%">
                            <font face="Tahoma">
                                <asp:checkbox id="chkCanDelete" runat="server" text="การลบ" checked="True" />
                            </font>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" colspan="2" style="width: 0%">
                            <font face="Tahoma">
                                <asp:checkbox id="chkCanApprove" runat="server" text="การอนุมัติ" checked="True" />
                            </font>
                        </td>
                        <td align="left" nowrap valign="middle" width="40%" style="width: 13%">
                            <font face="Tahoma">
                                <asp:checkbox id="chkCanExtra" runat="server" text="เงื่อนไขพิเศษ" checked="True" />
                            </font>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap style="" valign="middle" width="10%">
                            <asp:label id="Label86" runat="server" cssclass="label_hbk">หมายเหตุ :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" colspan="4">
                            <asp:textbox runat="server" cssclass="textbox" width="400px" id="txtRemark"
                                maxlength="255"></asp:textbox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:label id="Label76" runat="server" cssclass="label_hbk">สถานะ :</asp:label>
                        </td>
                        <td align="left" nowrap valign="middle" colspan="2">
                            <font face="Tahoma">
                                <asp:checkbox id="chkStatus" runat="server" text="ปกติ" checked="True" />
                            </font>
                        </td>
                        <td align="left" nowrap valign="middle" rowspan="2" style="text-align: right" colspan="2">
                            <asp:imagebutton runat="server" validationgroup="A" alternatetext="บันทึก" imageurl="~/images/controls/save.jpg"
                                id="imgSaveOnly">
                            </asp:imagebutton>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                        </td>
                        <td align="left" nowrap valign="middle" style="text-align: right" colspan="2">
                            <asp:validationsummary id="ValidationSummary1" runat="server" showmessagebox="True"
                                showsummary="False" validationgroup="A" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:content>
