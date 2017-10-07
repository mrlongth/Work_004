﻿<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_open_control.aspx.cs" Inherits="myWeb.App_Control.budget_open.budget_open_control"
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
            <td nowrap style="text-align: center; vertical-align: bottom; width: 10%;">
                <div>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="display: none;">LinkButton</asp:LinkButton>
                    <asp:LinkButton ID="btnSave" runat="server" class="button button-pill button-flat-highlight" OnClick="btnSave_Click" ValidationGroup="A">บันทึก</asp:LinkButton>
                    <asp:LinkButton ID="btnCancel" runat="server" class="button button-pill button-flat-highlight" OnClick="btnCancel_Click">ยกเลิก</asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <asp:Panel ID="pnlMain" runat="server">

        <ajaxtoolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1"
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
                                <asp:TextBox ID="txtbudget_open_doc" runat="server" CssClass="textbox" Width="130px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label84" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label81" runat="server" CssClass="label_hbk">ระดับการศึกษา :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboDegree" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboDegree_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboDegree" Display="None" ErrorMessage="กรุณาเลือกระดับการศึกษา" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label113" runat="server" CssClass="label_hbk">วันที่ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtbudget_open_date" runat="server" CssClass="textbox" ReadOnly="True" Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label85" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label89" runat="server" CssClass="label_hbk">ประเภทงบประมาณ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboBudget_type" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboBudget_type_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="cboBudget_type" Display="None" ErrorMessage="กรุณาเลือกประเภทงบประมาณ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label112" runat="server" CssClass="label_hbk">ปีงบประมาณ :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cboYear" runat="server" CssClass="textbox">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label108" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="lblPage24" runat="server" CssClass="label_hbk">หลักสูตร :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboMajor" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboMajor_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="cboMajor" Display="None" ErrorMessage="กรุณาเลือกหลักสูตร" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label109" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label110" runat="server" CssClass="label_hbk">ผังงบประมาณ :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtbudget_plan_code" runat="server" CssClass="textbox" MaxLength="10" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="imgList_budget_plan" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_budget_plan" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" OnClick="imgClear_budget_plan_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtbudget_plan_code" Display="None" ErrorMessage="กรุณาเลือกผังงบประมาณ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:LinkButton ID="lbkRefresh" runat="server" OnClick="lbkRefresh_Click" Style="display: none;">lbkRefresh</asp:LinkButton>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label60" runat="server" CssClass="label_hbk">สังกัด :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtdirector_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label61" runat="server" CssClass="label_hbk">หน่วยงาน :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtunit_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label54" runat="server" CssClass="label_hbk">แผนงบประมาณ  :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label55" runat="server" CssClass="label_hbk">ผลผลิต :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtproduce_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label53" runat="server" CssClass="label_hbk">กิจกรรม :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtactivity_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right;">
                                <asp:Label ID="Label56" runat="server" CssClass="label_hbk">แผนงาน :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtplan_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle" style="height: 22px">
                                <asp:Label ID="Label57" runat="server" CssClass="label_hbk">งาน :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" style="height: 22px">
                                <asp:TextBox ID="txtwork_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right; height: 22px;">
                                <asp:Label ID="Label58" runat="server" CssClass="label_hbk">กองทุน :</asp:Label>
                            </td>
                            <td align="left" style="height: 22px">
                                <asp:TextBox ID="txtfund_name" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="left">
                            <td align="right" nowrap style="height: 22px" valign="middle">
                                <asp:Label ID="Label86" runat="server" CssClass="label_hbk">หมายเหตุ :</asp:Label>
                            </td>
                            <td align="left" colspan="3" nowrap style="height: 22px" valign="middle">
                                <asp:TextBox ID="txtopen_remark" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="left">
                            <td align="right" nowrap valign="middle">&nbsp;</td>
                            <td align="left" nowrap valign="middle">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">&nbsp;</td>
                            <td align="left" nowrap valign="middle">&nbsp;</td>
                            <td nowrap style="text-align: right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle"></td>
                            <td align="left" nowrap valign="middle"></td>
                            <td nowrap style=""></td>
                            <td align="left"></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxtoolkit:TabPanel>


            <ajaxtoolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="ข้อมูลรายละเอียดการขออนุมัติเบิก">
                <HeaderTemplate>
                    ข้อมูลรายละเอียดการขออนุมัติเบิก
                </HeaderTemplate>
                <ContentTemplate>
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr align="left">
                            <td align="right" nowrap style="width: 15%" valign="middle">&nbsp;</td>
                            <td align="left" nowrap style="width: 38%" valign="middle">&nbsp;</td>
                            <td align="left" nowrap style="text-align: right;" valign="middle">&nbsp;</td>
                            <td align="left" nowrap valign="middle">&nbsp;</td>
                            <td align="left" nowrap style="vertical-align: bottom; width: 1%;" valign="middle">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label103" runat="server" CssClass="label_hbk">เลขที่เอกสารอ้างอิง :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtef_open_doc" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                &nbsp;<asp:ImageButton ID="imgList_ef_open_doc" runat="server" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_ef_open_doc" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" OnClick="imgClear_item_Click" Style="width: 18px" />
                                &nbsp; </td>
                            <td align="left" nowrap valign="middle">
                                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">LinkButton</asp:LinkButton>
                            </td>
                            <td align="left" nowrap valign="middle">&nbsp;</td>
                            <td align="left" nowrap style="vertical-align: bottom; width: 1%;" valign="middle">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label21" runat="server" CssClass="label_hbk">รหัสขอเบิก :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtopen_code" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                                &nbsp;<asp:ImageButton ID="imgList_open" runat="server" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_open" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" OnClick="imgClear_item_Click" Style="width: 18px" />
                                &nbsp; </td>
                            <td align="left" nowrap style="text-align: right;" valign="middle">&nbsp; </td>
                            <td align="left" nowrap valign="middle">&nbsp; </td>
                            <td align="left" nowrap style="vertical-align: bottom; width: 1%;" valign="middle">&nbsp;&nbsp; </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label100" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label49" runat="server" CssClass="label_hbk">เรื่อง :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" colspan="2">
                                <asp:TextBox ID="txtopen_title" runat="server" CssClass="textbox" MaxLength="255"
                                    Width="700px" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtopen_title"
                                    Display="None" ErrorMessage="กรุณาระบุเรื่อง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td align="left" nowrap valign="middle" style="vertical-align: bottom; width: 1%;"
                                rowspan="8">&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label5" runat="server" CssClass="label_hbk">รายละเอียด :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" colspan="2">
                                <asp:TextBox ID="txtopen_desc" runat="server" CssClass="textbox" MaxLength="4000"
                                    Rows="8" TextMode="MultiLine" Width="700px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label102" runat="server" CssClass="label_hbk">รายละเอียดการขออนุมัติ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" colspan="2" style="height: 1px;">
                                <asp:TextBox ID="txtopen_command_desc" runat="server" CssClass="textbox" MaxLength="4000"
                                    Rows="8" TextMode="MultiLine" Width="700px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">&nbsp;</td>
                            <td align="left" colspan="2" nowrap style="height: 1px;" valign="middle">&nbsp;</td>
                        </tr>
                    </table>
                </ContentTemplate>
            </ajaxtoolkit:TabPanel>
            <ajaxtoolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="ข้อมูลรายการเบิกจ่าย">
                <HeaderTemplate>
                    ข้อมูลรายการขอเบิก
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="div-lov" style="height: 380px">
                        <asp:GridView runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                            BackColor="White" BorderWidth="1px" CssClass="stGrid" Font-Bold="False" Font-Size="10pt"
                            Width="100%" ID="GridView1" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound"
                            OnSorting="GridView1_Sorting" OnRowDeleting="GridView1_RowDeleting" OnRowCommand="GridView1_RowCommand"
                            ShowFooter="True">
                            <AlternatingRowStyle BackColor="#EAEAEA"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hddopen_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.open_detail_id") %>' />
                                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายการขอเบิก">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hddmaterial_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.material_id") %>' />
                                        <asp:TextBox runat="server" CssClass="textbox" Width="240" ID="txtmaterial_name"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.material_name") %>' />
                                        <asp:ImageButton ID="imgList_material" runat="server" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                        <asp:ImageButton ID="imgClear_material" runat="server" CausesValidation="False" ImageAlign="AbsBottom"
                                            ImageUrl="../../images/controls/erase.gif" Style="width: 18px" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="30%" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายละเอียดรายการ">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="textbox" Width="99%" ID="txtmaterial_detail"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.material_detail") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="30%" Wrap="True" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        รวมทั้งสิ้น
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="จำนวนเงิน">
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtopen_detail_amount" runat="server" Width="80px" LeadZero="Show"
                                            DisplayMode="Control" Value='<% # DataBinder.Eval(Container, "DataItem.open_detail_amount") %>'>
                                        </cc1:AwNumeric>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <cc1:AwNumeric ID="txtopen_amount" runat="server" Width="80px" LeadZero="Show" DisplayMode="Control">
                                        </cc1:AwNumeric>
                                    </FooterTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="หมายเหตุ">
                                    <ItemTemplate>
                                        <asp:TextBox runat="server" CssClass="textbox" Width="99%" ID="txtopen_detail_remark"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.open_detail_remark") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="True" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete" />
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="imgAdd" runat="server" CommandName="Add" />
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" CssClass="stGridHeader" Font-Bold="True"></HeaderStyle>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </ajaxtoolkit:TabPanel>

        </ajaxtoolkit:TabContainer>

    </asp:Panel>

    <script type="text/javascript">


        function RegisterScript() {


            $(function () {
                LoadTinyMCE();
            });


            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler_Page);
            function BeforePostback() { tinyMCE.triggerSave(); }

            function EndRequestHandler_Page(sender, args) {
                LoadTinyMCE();
            }

            function LoadTinyMCE() {

                tinyMCE.remove('#<%=txtopen_command_desc.ClientID%>');
                tinyMCE.remove('#<%=txtopen_desc.ClientID%>');

                tinyMCE.init({ selector: "#<%=txtopen_command_desc.ClientID%>", height: 140, statusbar: false, toolbar: false, menubar: false, plugins: ['preview', 'code', 'paste'], paste_auto_cleanup_on_paste: true });
                tinyMCE.init({ selector: "#<%=txtopen_desc.ClientID%>", height: 140, statusbar: false, toolbar: false, menubar: false, plugins: ['preview', 'code', 'paste'], paste_auto_cleanup_on_paste: true });

            }


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

            $(document).ready(function () {
                $("input:text").focus(function () { $(this).select(); });
            });

            $("input[id*=imgList_budget_plan]").live("click", function () {
                var txtbudget_plan_code = $('#<%=txtbudget_plan_code.ClientID%>');
                var cboBudget_type = $('#<%=cboBudget_type.ClientID%>');
                var cboDegree = $('#<%=cboDegree.ClientID%>');
                var cboMajor = $('#<%=cboMajor.ClientID%>');
                var url = "../lov/budget_plan_lov.aspx?" +
                    "budget_type=" + cboBudget_type.val() +
                    "&budget_plan_code=" + txtbudget_plan_code.val() +
                    "&cboDegree=" + cboDegree.val() +
                    "&cboMajor=" + cboMajor.val() +
                    "&ctrl1=" + txtbudget_plan_code.attr('id') +
                    "&show=1&from=budget_open_control";
                OpenPopUp('950px', '500px', '94%', 'ค้นหาข้อมูลผังงบประมาณประจำปี', url, '1');
                return false;
            });


            $("input[id*=imgClear_ef_open_doc]").live("click", function () {
                $('#' + this.id.replace('imgClear_ef_open_doc', 'txtef_open_doc')).val('');
                return false;
            });

            $("input[id*=imgList_ef_open_doc]").live("click", function () {
                var txtbudget_plan_code = $('#<%=txtbudget_plan_code.ClientID%>');
                var txtef_open_doc = $('#' + this.id.replace('imgList_ef_open_doc', 'txtef_open_doc'));
                var url = "../lov/open_head_lov.aspx?" +
                    "open_doc=" + txtef_open_doc.val() +
                    "&budget_plan_code=" + txtbudget_plan_code.val() +
                    "&ctrl1=" + $(txtef_open_doc).attr('id') +
                    "&show=1&from=budget_open_control";
                OpenPopUp('800px', '400px', '93%', 'ค้นหาข้อมูลรายการเบิกจ่าย', url, '1');
                return false;
            });

        };




    </script>

</asp:Content>

