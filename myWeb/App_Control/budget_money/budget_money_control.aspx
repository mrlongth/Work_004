<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_money_control.aspx.cs" Inherits="myWeb.App_Control.budget_money.budget_money_control"
    Title="จัดการข้อมูลงบประมาณประจำปี" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%; vertical-align: bottom;" __designer:mapid="475">
        <tr align="left">
            <td align="right" nowrap valign="middle" width="75%">&nbsp;
                <div style="float: left;">
                    <asp:LinkButton ID="btnBack" runat="server" class="button button-pill button-flat-highlight" OnClick="btnBack_Click">ย้อนกลับ</asp:LinkButton>
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="A" />
                <asp:LinkButton ID="lkbRefresh" runat="server" OnClick="lkbRefresh_Click" Style="display: none;">LinkButton</asp:LinkButton>
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
            <td nowrap style="text-align: center; vertical-align: bottom; width: 5%;">
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="display: none;">LinkButton</asp:LinkButton>
                    <asp:LinkButton ID="btnSave" runat="server" class="button button-pill button-flat-highlight" OnClick="btnSave_Click" ValidationGroup="A">บันทึก</asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <asp:Panel ID="pnlMain" runat="server">

        <ajaxtoolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"
            BorderWidth="0px" Style="text-align: left">
            <ajaxtoolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="ข้อมูลการทำงาน">
                <HeaderTemplate>
                    ผังงบประมาณ
                </HeaderTemplate>
                <ContentTemplate>
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="left" nowrap style="text-align: right; width: 90%; height: 17px;">
                                <asp:Label runat="server" CssClass="label_error" ID="Label1"></asp:Label>
                                <asp:Label runat="server" ID="Label2">Last Updated By :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="144px" ID="txtUpdatedBy"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" nowrap style="text-align: right">
                                <asp:Label runat="server" CssClass="text" ID="Label3">Last Updated Date :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="144px" ID="txtUpdatedDate"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="2" cellspacing="2" class="ui-accordion">

                        <tr align="left">
                            <td align="right" nowrap valign="middle">&nbsp;</td>
                            <td align="left" nowrap valign="middle">&nbsp;</td>
                            <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label79" runat="server" CssClass="label_hbk">เลขที่เอกสาร :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_money_doc" runat="server" CssClass="textbox" Width="130px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label80" runat="server" CssClass="label_hbk">ปีงบประมาณ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="cboYear" runat="server" CssClass="textbox">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label84" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label81" runat="server" CssClass="label_hbk">ระดับการศึกษา :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboDegree" runat="server" CssClass="textbox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboDegree" Display="None" ErrorMessage="กรุณาเลือกระดับการศึกษา" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label85" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label82" runat="server" CssClass="label_hbk">ประเภทงบประมาณ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="cboBudget_type" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboBudget_type_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="cboBudget_type" Display="None" ErrorMessage="กรุณาเลือกประเภทงบประมาณ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label70" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label52" runat="server" CssClass="label_hbk">ผังงบประมาณ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_plan_code" runat="server" CssClass="textbox" Width="80px"
                                    MaxLength="10"></asp:TextBox>
                                &nbsp;<asp:ImageButton ID="imgList_budget_plan" runat="server" CausesValidation="False"
                                    ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_budget_plan" runat="server" CausesValidation="False"
                                    ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtbudget_plan_code" Display="None" ErrorMessage="กรุณาเลือกผังงบประมาณ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label60" runat="server" CssClass="label_hbk">สังกัด :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtdirector_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label61" runat="server" CssClass="label_hbk">หน่วยงาน :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtunit_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label54" runat="server" CssClass="label_hbk">แผนงบประมาณ  :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label55" runat="server" CssClass="label_hbk">ผลผลิต :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtproduce_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label53" runat="server" CssClass="label_hbk">กิจกรรม :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtactivity_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right;">
                                <asp:Label ID="Label56" runat="server" CssClass="label_hbk">แผนงาน :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtplan_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle" style="height: 22px">
                                <asp:Label ID="Label57" runat="server" CssClass="label_hbk">งาน :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" style="height: 22px">
                                <asp:TextBox ID="txtwork_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right; height: 22px;">
                                <asp:Label ID="Label58" runat="server" CssClass="label_hbk">กองทุน :</asp:Label>
                            </td>
                            <td align="left" style="height: 22px">
                                <asp:TextBox ID="txtfund_name" runat="server" CssClass="textboxdis" Width="300px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label86" runat="server" CssClass="label_hbk">หมายเหตุ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtcomment" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label12" runat="server" CssClass="label_hbk">สถานะ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:CheckBox ID="chkStatus" runat="server" Text="ปกติ" />
                            </td>
                            <td nowrap style="text-align: right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">&nbsp;&nbsp;
                            </td>
                            <td align="left" nowrap valign="middle">&nbsp;&nbsp;
                            </td>
                            <td nowrap style="text-align: right">&nbsp;&nbsp;
                            </td>
                            <td align="left">&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle"></td>
                            <td align="left" nowrap valign="middle"></td>
                            <td nowrap style=""></td>
                            <td align="left"></td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle"></td>
                            <td align="left" colspan="3" nowrap valign="middle"></td>
                        </tr>
                        <tr align="left">
                            <td align="right" colspan="4" nowrap valign="middle"></td>
                        </tr>
                        <tr align="left">
                            <td align="right" colspan="4" nowrap valign="middle"></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxtoolkit:TabPanel>
            <ajaxtoolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="ข้อมูลประวัติบุคลากร" Visible="false">
                <HeaderTemplate>
                    รายละเอียดงบประมาณ
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Panel ID="pnlDetail" runat="server">
                        <asp:GridView ID="GridViewDetail" runat="server" AllowSorting="True"
                            AutoGenerateColumns="False" BackColor="White" BorderWidth="1px"
                            CellPadding="2" CssClass="stGrid" Font-Bold="False" Font-Size="10pt"
                            OnRowCreated="GridViewDetail_RowCreated" OnRowDataBound="GridViewDetail_RowDataBound"
                            OnSorting="GridViewDetail_Sorting" Width="100%" OnRowCommand="GridViewDetail_RowCommand">
                            <AlternatingRowStyle BackColor="#EAEAEA" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgView" runat="server" CausesValidation="False" CommandName="VIEW" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hddBudget_money_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_money_detail_id") %>' />
                                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%" Wrap="False" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="งบประมาณ" SortExpression="lot_name">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbllot_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lot_name") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                
                                  <asp:TemplateField HeaderText="หมวดค่าใช้จ่าย" SortExpression="Item_group_name">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_group_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_name") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="รายละเอียดหมวดค่าใช้จ่าย" SortExpression="Item_group_name">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_group_detail_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_detail_name") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ค่าใช้จ่าย" SortExpression="Item_name">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_name") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="รายละเอียดค่าใช้จ่าย " SortExpression="item_detail_name">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblitem_detail_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.item_detail_name") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ยอดจัดสรร">
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtbudget_money_detail_plan" runat="server" CssClass="numberbox" LeadZero="Show" DisplayMode="View" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_detail_plan") %>' Width="80px"></cc1:AwNumeric>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ยอดรับจริง">
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtbudget_money_detail_contribute" runat="server" CssClass="numberbox" LeadZero="Show" DisplayMode="View" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_detail_contribute") %>' Width="80px"></cc1:AwNumeric>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ยอดใช้แล้ว">
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtbudget_money_detail_use" runat="server" CssClass="numberbox" LeadZero="Show" DisplayMode="View" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_detail_use") %>' Width="80px"></cc1:AwNumeric>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ยอดคงเหลือ">
                                    <ItemStyle HorizontalAlign="Right" Width="8%" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtbudget_money_detail_remain" runat="server" CssClass="numberdis" LeadZero="Show" TabIndex="-1" DisplayMode="View" Value='<% # DataBinder.Eval(Container, "DataItem.budget_money_detail_remain") %>' Width="80px"></cc1:AwNumeric>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" CommandName="EDITDETAIL" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="DELETEDETAIL" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="imgAdd" runat="server" />
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="stGridHeader" Font-Bold="True" HorizontalAlign="Center" />
                        </asp:GridView>
                    </asp:Panel>


                </ContentTemplate>
            </ajaxtoolkit:TabPanel>
        </ajaxtoolkit:TabContainer>

    </asp:Panel>

    <script type="text/javascript">


        function RegisterScript() {

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

            $("input[id*=imgClear_budget_plan]").live("click", function () {
                $('#<%=txtbudget_plan_code.ClientID%>').val('');
                $('#<%=txtbudget_name.ClientID%>').val('');
                $('#<%=txtproduce_name.ClientID%>').val('');
                $('#<%=txtactivity_name.ClientID%>').val('');
                $('#<%=txtplan_name.ClientID%>').val('');
                $('#<%=txtwork_name.ClientID%>').val('');
                $('#<%=txtfund_name.ClientID%>').val('');
                $('#<%=txtdirector_name.ClientID%>').val('');
                $('#<%=txtunit_name.ClientID%>').val('');
                return false;
            });

            $("input[id*=imgList_budget_plan]").live("click", function () {
                var txtbudget_plan_code = $('#<%=txtbudget_plan_code.ClientID%>');
                var txtbudget_name = $('#<%=txtbudget_name.ClientID%>');
                var txtproduce_name = $('#<%=txtproduce_name.ClientID%>');
                var txtactivity_name = $('#<%=txtactivity_name.ClientID%>');
                var txtplan_name = $('#<%=txtplan_name.ClientID%>');
                var txtwork_name = $('#<%=txtwork_name.ClientID%>');
                var txtfund_name = $('#<%=txtfund_name.ClientID%>');
                var txtdirector_name = $('#<%=txtdirector_name.ClientID%>');
                var txtunit_name = $('#<%=txtunit_name.ClientID%>');
                var cboBudget_type = $('#<%=cboBudget_type.ClientID%>');
                var url = "../lov/budget_plan_lov.aspx?" +
                    "budget_type=" + cboBudget_type.val() +
                    "&budget_plan_code=" + txtbudget_plan_code.val() +
                    "&txtproduce_name=" + txtproduce_name.val() +
                    "&txtactivity_name=" + txtactivity_name.val() +
                    "&txtplan_name=" + txtplan_name.val() +
                    "&txtwork_name=" + txtwork_name.val() +
                    "&txtfund_name=" + txtfund_name.val() +
                    "&txtdirector_name=" + txtdirector_name.val() +
                    "&txtunit_name=" + txtunit_name.val() +
                    "&ctrl1=" + txtbudget_plan_code.attr('id') +
                    "&ctrl2=" + txtbudget_name.attr('id') +
                    "&ctrl3=" + txtproduce_name.attr('id') +
                    "&ctrl4=" + txtactivity_name.attr('id') +
                    "&ctrl5=" + txtplan_name.attr('id') +
                    "&ctrl6=" + txtwork_name.attr('id') +
                    "&ctrl7=" + txtfund_name.attr('id') +
                    "&ctrl9=" + txtdirector_name.attr('id') +
                    "&ctrl10=" + txtunit_name.attr('id') +
                    "&show=1&from=budget_money_control";
                OpenPopUp('950px', '500px', '94%', 'ค้นหาข้อมูลผังงบประมาณประจำปี', url, '1');
                return false;
            });

        };




    </script>

</asp:Content>

