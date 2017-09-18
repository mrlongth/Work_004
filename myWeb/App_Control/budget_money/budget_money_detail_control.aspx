<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_money_detail_control.aspx.cs" Inherits="myWeb.App_Control.item.budget_money_detail_control" %>

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
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label90" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label87" runat="server" CssClass="label_hbk">ประเภทงบ :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <asp:DropDownList ID="cboLot" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboLot_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="cboLot" Display="None" ErrorMessage="กรุณาเลือกประเภทงบ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hddbudget_money_detail_id" runat="server" />
                        </td>
                        <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                        <td style="text-align: left" colspan="2">
                            <asp:HiddenField ID="hddbudget_type" runat="server" />
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label89" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label4" runat="server" CssClass="label_hbk">หมวดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <asp:DropDownList ID="cboItem_group" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_SelectedIndexChanged1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cboItem_group" Display="None" ErrorMessage="กรุณาเลือกหมวดค่าใช้จ่าย" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                        <td nowrap style="text-align: right" width="10%">
                            <asp:Label ID="Label88" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label5" runat="server" CssClass="label_hbk">รายละเอียดหมวดค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td style="text-align: left" colspan="2">
                            <asp:DropDownList ID="cboItem_group_detail" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_detail_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="cboItem_group_detail" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดหมดค่าใช้จ่าย" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label6" runat="server" CssClass="label_error">*</asp:Label>
                            <asp:Label ID="Label91" runat="server" CssClass="label_hbk">รายละเอียดค่าใช้จ่าย :</asp:Label>

                        </td>
                        <td align="left" nowrap valign="middle" colspan="4">
                            <asp:TextBox ID="txtitem_detail_code" runat="server" CssClass="textbox" MaxLength="10" Width="100px"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="imgList_item_detail" runat="server" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                            <asp:ImageButton ID="imgClear_item_detail" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" />
                            &nbsp;<asp:TextBox ID="txtitem_detail_name" runat="server" CssClass="textbox" MaxLength="100" Width="330px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtitem_detail_code" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดค่าใช้จ่าย" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hdditem_detail_id" runat="server" />
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label7" runat="server" CssClass="label_hbk">ค่าใช้จ่าย :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle" colspan="4">
                            <asp:TextBox ID="txtitem_name" runat="server" CssClass="textbox" MaxLength="100" Width="330px"></asp:TextBox>
                            <asp:LinkButton ID="lbkRefresh" runat="server" OnClick="lbkRefresh_Click" Style="display: none;">lbkRefresh</asp:LinkButton>
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label94" runat="server" CssClass="label_hbk">หมายเหตุ :</asp:Label>
                        </td>
                        <td align="left" colspan="4" nowrap valign="middle">
                            <asp:TextBox ID="txtbudget_money_detail_comment" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label93" runat="server" CssClass="label_hbk">รวมยอดจัดสรร :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <cc1:AwNumeric ID="txtbudget_money_detail_plan" runat="server" CssClass="numberdis" LeadZero="Show" TabIndex="-1" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_remain") %>' Width="150px"></cc1:AwNumeric>
                        </td>
                        <td nowrap style="text-align: right" width="10%">
                            <asp:Label ID="Label95" runat="server" CssClass="label_hbk">รวมยอดรับจริง :</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <cc1:AwNumeric ID="txtbudget_money_detail_contribute" runat="server" CssClassDefault="numberdis" ReadOnly="true" LeadZero="Show" TabIndex="-1" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_remain") %>' Width="150px"></cc1:AwNumeric>
                        </td>
                        <td rowspan="2" style="text-align: right">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="display: none;">LinkButton</asp:LinkButton>
                            <asp:ImageButton ID="imgSaveOnly" runat="server" ImageUrl="~/images/controls/save.jpg" ValidationGroup="A" />
                        </td>
                    </tr>

                    <tr align="left">
                        <td align="right" nowrap valign="middle">
                            <asp:Label ID="Label97" runat="server" CssClass="label_hbk">รวมยอดใช้แล้ว :</asp:Label>
                        </td>
                        <td align="left" nowrap valign="middle">
                            <cc1:AwNumeric ID="txtbudget_money_detail_use" runat="server" CssClassDefault="numberdis" LeadZero="Show" ReadOnly="true" TabIndex="-1" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_remain") %>' Width="150px"></cc1:AwNumeric>
                        </td>
                        <td nowrap style="text-align: right" width="10%">
                            <asp:Label ID="Label96" runat="server" CssClass="label_hbk">รวมยอดคงเหลือ :</asp:Label>
                        </td>
                        <td style="text-align: left">
                            <cc1:AwNumeric ID="txtbudget_money_detail_remain" runat="server" CssClassDefault="numberdis" LeadZero="Show" ReadOnly="true" TabIndex="-1" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_remain") %>' Width="150px"></cc1:AwNumeric>
                        </td>
                    </tr>

                </table>

            </asp:Panel>
            <div class="div-lov" style="height: 400px">
                <asp:GridView ID="GridViewMajor" runat="server"
                    AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="White" BorderWidth="1px"
                    CellPadding="2" CssClass="stGrid"
                    Font-Bold="False" Font-Size="10pt"
                    OnRowCreated="GridViewMajor_RowCreated"
                    OnRowDataBound="GridViewMajor_RowDataBound"
                    OnSorting="GridViewMajor_Sorting" Width="100%" OnRowDeleting="GridViewMajor_RowDeleting">
                    <AlternatingRowStyle BackColor="#EAEAEA" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblNo" runat="server"> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หลักสูตร" SortExpression="major_name">
                            <ItemStyle HorizontalAlign="Left" Width="30%" Wrap="True" />
                            <ItemTemplate>
                                <asp:HiddenField ID="hddbudget_money_major_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_money_major_id") %>' />
                                <asp:Label ID="lblmajor_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.major_name") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ยอดจัดสรร">
                            <ItemStyle HorizontalAlign="Center" Width="15%" Wrap="False" />
                            <ItemTemplate>
                                <cc1:AwNumeric ID="txtbudget_money_major_plan" runat="server" CssClass="numberbox" LeadZero="Show" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_plan") %>' Width="100px">
                                </cc1:AwNumeric>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ยอดรับจริง">
                            <ItemStyle HorizontalAlign="Center" Width="15%" Wrap="False" />
                            <ItemTemplate>
                                <cc1:AwNumeric ID="txtbudget_money_major_contribute" runat="server" CssClass="numberbox" LeadZero="Show" DisplayMode="View" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_contribute") %>' Width="100px"></cc1:AwNumeric>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ยอดใช้แล้ว">
                            <ItemStyle HorizontalAlign="Center" Width="15%" Wrap="False" />
                            <ItemTemplate>
                                <cc1:AwNumeric ID="txtbudget_money_major_use" runat="server" CssClass="numberbox" LeadZero="Show" DisplayMode="View" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_use") %>' Width="100px"></cc1:AwNumeric>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ยอดคงเหลือ">
                            <ItemStyle HorizontalAlign="Center" Width="15%" Wrap="False" />
                            <ItemTemplate>
                                <cc1:AwNumeric ID="txtbudget_money_major_remain" runat="server" CssClass="numberdis" LeadZero="Show" DisplayMode="View" TabIndex="-1" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_major_remain") %>' Width="100px"></cc1:AwNumeric>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="DELETE" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:ImageButton ID="imgAdd" runat="server" CommandName="ADD" />
                            </HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="stGridHeader" Font-Bold="True" HorizontalAlign="Center" />
                </asp:GridView>
            </div>
        </asp:Panel>

    </asp:Panel>

    <script type="text/javascript">


        function RegisterScript()
        {

            $(document).on('keypress', 'form input[type=text]', function (event) {
                event.stopImmediatePropagation();
                if (event.which == 13) {
                    event.preventDefault();
                    var $input = $('form input[type=text]');
                    if ($(this).is($input.last())) {
                        $input.eq(0).focus();
                    } else {
                        $input.eq($input.index(this) + 1).focus();
                    }
                }
            });

            $("input[id*=imgClear_item_detail]").live("click", function () {
                $('#<%=txtitem_detail_code.ClientID%>').val('');
                $('#<%=txtitem_detail_name.ClientID%>').val('');
                $('#<%=txtitem_name.ClientID%>').val('');
                return false;
            });

            $("input[id*=imgList_item_detail]").live("click", function () {
                var hdditem_detail_id = $('#<%=hdditem_detail_id.ClientID%>');
                var cboLot = $('#<%=cboLot.ClientID%>');
                var cboItem_group = $('#<%=cboItem_group.ClientID%>');
                var cboItem_group_detail = $('#<%=cboItem_group_detail.ClientID%>');
                var txtitem_detail_code = $('#<%=txtitem_detail_code.ClientID%>');
                var txtitem_detail_name = $('#<%=txtitem_detail_name.ClientID%>');
                var hdditem_detail_id = $('#<%=hdditem_detail_id.ClientID%>');
                var hddbudget_type = $('#<%=hddbudget_type.ClientID%>');
                var lbkRefresh = $('#<%=lbkRefresh.ClientID%>');
                var url = "../lov/item_detail_lov.aspx?" +
                    "lot_code=" + cboLot.val() +
                    "&item_detail_code=" + txtitem_detail_code.val() +
                    "&item_detail_name=" + txtitem_detail_name.val() +
                    "&item_type=C" +
                    "&budget_type=<%=BudgetType%>" +
                    "&item_group_code=" + cboItem_group.val() +
                    "&item_group_detail_id=" + cboItem_group_detail.val() +
                    "&hdditem_detail_id=" + hdditem_detail_id.attr('id') +
                    "&lbkRefresh=ctl00$ContentPlaceHolder1$lbkRefresh" +
                    "&show=2&from_page=budget_money_detail_control";
                OpenPopUp('1000px', '500px', '94%', 'ค้นหาข้อมูลรายละเอียดรายได้/ค่าใช้จ่าย', url, '2');
                return false;
            });

            var GridView1 = '<%=GridViewMajor.ClientID%>';

            $("#" + GridView1 + " input[id*=txtbudget_money_major_plan]").live("keyup", function () {
                CalAmount();
            });
            $("#" + GridView1 + " input[id*=txtbudget_money_major_plan]").live("blur", function () {
                CalAmount();
            });

            $("#" + GridView1 + " input[id*=txtbudget_money_major_plan]").live("change", function () {
                CalAmount();
            });

        

            function CalAmount() {
                var GridView1 = '<%=GridViewMajor.ClientID%>';
                var rowCount = document.getElementById(GridView1).rows.length;
                var txtbudget_money_major_plan = 0;
                var txtbudget_money_major_plan_all = 0;
                var strbudget_money_major_plan = "";

                for (var i = 2; i < rowCount + 1; i++) {

                    var numbudget_money_major_plan = 0;

                    if (i < 10) {
                        strbudget_money_major_plan = GridView1 + '_ctl0' + i + '_txtbudget_money_major_plan';
                    }
                    else {
                        strbudget_money_major_plan = GridView1 + '_ctl' + i + '_txtbudget_money_major_plan';
                    }
                    txtbudget_money_major_plan = document.getElementById(strbudget_money_major_plan).value.replace(/,/g, "");
                    numbudget_money_major_plan = parseFloat(txtbudget_money_major_plan);
                    if (checkNaN(numbudget_money_major_plan)) numbudget_money_major_plan = 0;
                    txtbudget_money_major_plan_all = txtbudget_money_major_plan_all + numbudget_money_major_plan;

                }

           
                document.getElementById('<%=txtbudget_money_detail_plan.ClientID%>').value = txtbudget_money_major_plan_all.toFixed('2');
                   CommaFormatted(document.getElementById('<%=txtbudget_money_detail_plan.ClientID%>'));

            }


        };







    </script>


</asp:Content>
