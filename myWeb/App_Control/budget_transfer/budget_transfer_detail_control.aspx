<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_transfer_detail_control.aspx.cs" Inherits="myWeb.App_Control.budget_transfer.budget_transfer_detail_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlContent" runat="server">
        <table border="0" cellpadding="2" cellspacing="0" style="width: 100%; display: block;">
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
                    <td align="right" nowrap valign="middle">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" />
                    </td>
                    <td align="left" nowrap style="text-align: right" valign="middle">&nbsp;<asp:Label ID="lblLastUpdatedDate" runat="server">Last Updated Date :</asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUpdatedDate" runat="server" CssClass="textboxdis" ReadOnly="True" Width="148px"></asp:TextBox>
                        &nbsp; </td>
                </t>
            </tr>
        </table>
        <asp:Panel ID="pnlMajor" runat="server">
            <asp:Panel ID="pnlControl" runat="server">
                <table border="0" cellpadding="2" cellspacing="2" class="ui-accordion">

                    <tr align="left">
                        <td align="right" nowrap valign="middle" style="width:15%">&nbsp;</td>
                        <td align="left" nowrap valign="middle" style="width:35%">&nbsp;</td>
                        <td nowrap style="text-align: right" width="15%">&nbsp;</td>
                        <td style="text-align: left; width:35%" colspan="2" >&nbsp;</td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">&nbsp;</td>
                        <td align="left" nowrap valign="middle">
                            <asp:Label ID="Label98" runat="server" CssClass="label_hbk" Font-Bold="True">ต้นทาง</asp:Label>
                        </td>
                        <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                        <td colspan="2" style="text-align: left">
                            <asp:Label ID="Label99" runat="server" CssClass="label_hbk" Font-Bold="True">ปลายทาง</asp:Label>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label90" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label87" runat="server" CssClass="label_hbk">ประเภทงบ :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <asp:DropDownList ID="cboLot_from" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboLot_from_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cboLot_from" Display="None" ErrorMessage="กรุณาเลือกประเภทงบต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td nowrap style="text-align: right" width="10%">
                            <asp:Label ID="Label102" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label103" runat="server" CssClass="label_hbk">ประเภทงบ :</asp:Label>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:DropDownList ID="cboLot_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboLot_to_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="cboItem_group_to" Display="None" ErrorMessage="กรุณาเลือกประเภทงบต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label89" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label4" runat="server" CssClass="label_hbk">หมวดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <asp:DropDownList ID="cboItem_group_from" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_from_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cboItem_group_from" Display="None" ErrorMessage="กรุณาเลือกหมวดค่าใช้จ่ายต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td nowrap style="text-align: right" width="10%">
                            <asp:Label ID="Label107" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label104" runat="server" CssClass="label_hbk">หมวดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:DropDownList ID="cboItem_group_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_group_to_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="cboItem_group_to" Display="None" ErrorMessage="กรุณาเลือกหมวดค่าใช้จ่ายปลายทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label111" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label110" runat="server" CssClass="label_hbk">รายละเอียดหมวดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <asp:DropDownList ID="cboItem_group_detail_from" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_group_detail_from_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="cboItem_group_detail_from" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดหมวดค่าใช้จ่ายต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td nowrap style="text-align: right" width="10%">
                            <asp:Label ID="Label113" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label112" runat="server" CssClass="label_hbk">รายละเอียดหมวดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td colspan="2" style="text-align: left">
                            <asp:DropDownList ID="cboItem_group_detail_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_group_detail_to_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="cboItem_group_detail_to" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดหมวดค่าใช้จ่ายปลายทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle" style="height: 20px">
                            <asp:Label ID="Label6" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label91" runat="server" CssClass="label_hbk">รายการค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle" style="height: 20px">
                            <asp:DropDownList ID="cboItem_from" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_from_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="cboItem_from" Display="None" ErrorMessage="กรุณาเลือกรายการค่าใช้จ่ายต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label108" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label105" runat="server" CssClass="label_hbk">รายการค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" colspan="2" nowrap style="height: 20px" valign="middle">
                            <asp:DropDownList ID="cboItem_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_to_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="cboItem_to" Display="None" ErrorMessage="กรุณาเลือกรายการค่าใช้จ่ายปลายทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle" style="height: 20px">
                            <asp:Label ID="Label101" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label100" runat="server" CssClass="label_hbk">รายละเอียดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle" style="height: 20px">
                            <asp:DropDownList ID="cboItem_detail_from" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_detail_from_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="cboItem_detail_from" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดค่าใช้จ่ายต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hddbudget_money_major_id_from" runat="server" />
                        </td>
                        <td align="right" nowrap style="height: 20px" valign="middle">
                            <asp:Label ID="Label109" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label106" runat="server" CssClass="label_hbk">รายละเอียดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" colspan="2" nowrap style="height: 20px" valign="middle">
                            <asp:DropDownList ID="cboItem_detail_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboItem_detail_to_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="cboItem_detail_to" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดค่าใช้จ่ายปลายทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hddbudget_money_major_id_to" runat="server" />
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label93" runat="server" CssClass="label_hbk">จำนวนเงิน :</asp:Label>
                        </td>
                        <td align="left" colspan="4" nowrap valign="middle">
                            <cc1:AwNumeric ID="txtbudget_transfer_detail_amount" runat="server" CssClass="numberbox" DisplayMode="Control" LeadZero="Show" Width="120px"></cc1:AwNumeric>
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label94" runat="server" CssClass="label_hbk">หมายเหตุ :</asp:Label>
                        </td>
                        <td align="left" colspan="4" nowrap valign="middle">
                            <asp:TextBox ID="txtbudget_transfer_detail_comment" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            &nbsp;</td>
                        <td align="left" nowrap valign="middle">
                            &nbsp;</td>
                        <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                        <td style="text-align: left">&nbsp;</td>
                        <td rowspan="2" style="text-align: right">
                            <asp:ImageButton ID="imgSaveOnly" runat="server" ImageUrl="~/images/controls/save.jpg" ValidationGroup="A" />
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle">&nbsp;</td>
                        <td align="left" nowrap valign="middle">&nbsp;</td>
                        <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                        <td style="text-align: left">&nbsp;</td>
                    </tr>

                </table>

            </asp:Panel>
        </asp:Panel>

    </asp:Panel>

    <script type="text/javascript">


        function RegisterScript()
        {

            $(document).on('keypress', 'form input[type=text]', function (event)
            {
                event.stopImmediatePropagation();
                if (event.which == 13)
                {
                    event.preventDefault();
                    var $input = $('form input[type=text]');
                    if ($(this).is($input.last()))
                    {
                        $input.eq(0).focus();
                    } else
                    {
                        $input.eq($input.index(this) + 1).focus();
                    }
                }
            });

            $(document).ready(function ()
            {
                $("input:text").focus(function () { $(this).select(); });
            });


        };







    </script>


</asp:Content>
