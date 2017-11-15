<%@ Page Language="C#" MasterPageFile="~/Site_list.Master"
    EnableEventValidation="false" ValidateRequest="false" AutoEventWireup="true"
    CodeBehind="budget_transfer_control.aspx.cs" Inherits="myWeb.App_Control.budget_transfer.budget_transfer_control"
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
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Style="display: none;">LinkButton2</asp:LinkButton>
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
                                <asp:TextBox ID="txtbudget_transfer_doc" runat="server" CssClass="textbox" Width="130px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label113" runat="server" CssClass="label_hbk">วันที่ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_transfer_date" runat="server" CssClass="textbox" ReadOnly="True" Width="100px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label130" runat="server" CssClass="label_hbk">เลขที่ใบโอน :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtbudget_doc_no" runat="server" CssClass="textbox" Width="130px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label89" runat="server" CssClass="label_hbk">ประเภทงบประมาณ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboBudget_type" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboBudget_type_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label112" runat="server" CssClass="label_hbk">ปีงบประมาณ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="cboYear" runat="server" CssClass="textbox">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">&nbsp;</td>
                            <td align="left" nowrap valign="middle">
                                <asp:Label ID="Label116" runat="server" CssClass="label_hbk">ข้อมูลต้นทาง</asp:Label>
                            </td>
                            <td nowrap style="text-align: right" width="10%">&nbsp;</td>
                            <td style="text-align: left">
                                <asp:Label ID="Label117" runat="server" CssClass="label_hbk">ข้อมูลปลายทาง</asp:Label>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label84" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label81" runat="server" CssClass="label_hbk">ระดับการศึกษา :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboDegree_from" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboDegree_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboDegree_from" Display="None" ErrorMessage="กรุณาเลือกระดับการศึกษาต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label118" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label119" runat="server" CssClass="label_hbk">ระดับการศึกษา :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="cboDegree_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboDegree_to_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="cboDegree_to" Display="None" ErrorMessage="กรุณาเลือกระดับการศึกษาต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label114" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="lblPage25" runat="server" CssClass="label_hbk">หลักสูตร :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:DropDownList ID="cboMajor_from" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboMajor_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="cboMajor_from" Display="None" ErrorMessage="กรุณาเลือกหลักสูตรต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label120" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="lblPage26" runat="server" CssClass="label_hbk">หลักสูตร :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="cboMajor_to" runat="server" AutoPostBack="True" CssClass="textbox" OnSelectedIndexChanged="cboMajor_to_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="cboMajor_to" Display="None" ErrorMessage="กรุณาเลือกหลักสูตรปลายทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label109" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label110" runat="server" CssClass="label_hbk">ผังงบประมาณ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_plan_code_from" runat="server" CssClass="textbox" MaxLength="10" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="imgList_budget_plan_from" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_budget_plan_from" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" OnClick="imgClear_budget_plan_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtbudget_plan_code_from" Display="None" ErrorMessage="กรุณาเลือกผังงบประมาณต้นทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:LinkButton ID="lbkRefresh_from" runat="server" OnClick="lbkRefresh_from_Click" Style="display: none;">lbkRefresh</asp:LinkButton>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label121" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label122" runat="server" CssClass="label_hbk">ผังงบประมาณ :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtbudget_plan_code_to" runat="server" CssClass="textbox" MaxLength="10" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="imgList_budget_plan_to" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_budget_plan_to" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" OnClick="imgClear_budget_plan_to_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtbudget_plan_code_to" Display="None" ErrorMessage="กรุณาเลือกผังงบประมาณปลายทาง" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:LinkButton ID="lbkRefresh_to" runat="server" OnClick="lbkRefresh_to_Click" Style="display: none;">lbkRefresh_to</asp:LinkButton>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label115" runat="server" CssClass="label_hbk">หน่วยงาน :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtunit_name_from" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label123" runat="server" CssClass="label_hbk">หน่วยงาน :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtunit_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label54" runat="server" CssClass="label_hbk">แผนงบประมาณ  :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_name_from" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label124" runat="server" CssClass="label_hbk">แผนงบประมาณ  :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtbudget_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label55" runat="server" CssClass="label_hbk">ผลผลิต :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtproduce_name_from" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right">
                                <asp:Label ID="Label125" runat="server" CssClass="label_hbk">ผลผลิต :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtproduce_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label53" runat="server" CssClass="label_hbk">กิจกรรม :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtactivity_name_from" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right;">
                                <asp:Label ID="Label126" runat="server" CssClass="label_hbk">กิจกรรม :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtactivity_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label56" runat="server" CssClass="label_hbk">แผนงาน :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtplan_name_from" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right;">
                                <asp:Label ID="Label127" runat="server" CssClass="label_hbk">แผนงาน :</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtplan_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle" style="height: 22px">
                                <asp:Label ID="Label57" runat="server" CssClass="label_hbk">งาน :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" style="height: 22px">
                                <asp:TextBox ID="txtwork_name_from" runat="server" CssClass="textboxdis" Width="400px" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right; height: 22px;">
                                <asp:Label ID="Label128" runat="server" CssClass="label_hbk">งาน :</asp:Label>
                            </td>
                            <td align="left" style="height: 22px">
                                <asp:TextBox ID="txtwork_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="left">
                            <td align="right" nowrap style="height: 22px" valign="middle">
                                <asp:Label ID="Label58" runat="server" CssClass="label_hbk">กองทุน :</asp:Label>
                            </td>
                            <td align="left" nowrap style="height: 22px" valign="middle">
                                <asp:TextBox ID="txtfund_name_from" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right; height: 22px;">
                                <asp:Label ID="Label129" runat="server" CssClass="label_hbk">กองทุน :</asp:Label>
                            </td>
                            <td align="left" style="height: 22px">
                                <asp:TextBox ID="txtfund_name_to" runat="server" CssClass="textboxdis" ReadOnly="True" Width="400px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr align="left">
                            <td align="right" nowrap style="height: 22px" valign="middle">
                                <asp:Label ID="Label86" runat="server" CssClass="label_hbk">หมายเหตุ :</asp:Label>
                            </td>
                            <td align="left" colspan="3" nowrap style="height: 22px" valign="middle">
                                <asp:TextBox ID="txtbudget_transfer_remark" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
                            </td>
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

            <ajaxtoolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="ข้อมูลรายการโอนเงิน">
                <HeaderTemplate>
                    ข้อมูลรายการโอนเงิน
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
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" Width="2%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hddbudget_transfer_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_transfer_detail_id") %>' />
                                        <asp:HiddenField ID="budget_money_major_id_from" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_money_major_id_from") %>' />
                                        <asp:HiddenField ID="budget_money_major_id_to" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_money_major_id_to") %>' />
                                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="งบประมาณต้นทาง" SortExpression="lot_name_from">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbllot_name_from" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lot_name_from") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="หมวดค่าใช้จ่ายต้นทาง" SortExpression="Item_group_name_from">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_group_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_name_from") %>' />
                                        / 
                                        <asp:Label ID="lblItem_group_detail_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_detail_name_from") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="รายการค่าใช้จ่ายต้นทาง" SortExpression="Item_name_from">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_name_from") %>' />
                                        / 
                                        <asp:Label ID="lblitem_detail_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.item_detail_name_from") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="งบประมาณปลายทาง" SortExpression="lot_name_to">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lbllot_name_to" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lot_name_to") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="หมวดค่าใช้จ่ายปลายทาง" SortExpression="Item_group_name_to">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_group_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_name_to") %>' />
                                        / 
                                        <asp:Label ID="lblItem_group_detail_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_detail_name_to") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="รายการค่าใช้จ่ายปลายทาง" SortExpression="Item_name_to">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblItem_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_name_to") %>' />
                                        / 
                                        <asp:Label ID="lblitem_detail_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.item_detail_name_to") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="จำนวนเงิน">
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtbudget_transfer_detail_amount" runat="server" Width="99%" LeadZero="Show"
                                            DisplayMode="Control" Value='<% # DataBinder.Eval(Container, "DataItem.budget_transfer_detail_amount") %>'>
                                        </cc1:AwNumeric>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <cc1:AwNumeric ID="txttransfer_amount" runat="server" Width="99%" LeadZero="Show" DisplayMode="Control" ReadOnly="true">
                                        </cc1:AwNumeric>
                                    </FooterTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="True" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="8%" Wrap="True" />
                                    <FooterStyle HorizontalAlign="Right" Width="8%" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete" />
                                    </ItemTemplate>
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="imgAdd" runat="server" CommandName="Add" />
                                    </HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="False"></HeaderStyle>
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

            $("input[id*=imgList_budget_plan_from]").live("click", function () {
                var txtbudget_plan_code_from = $('#<%=txtbudget_plan_code_from.ClientID%>');
                var cboBudget_type = $('#<%=cboBudget_type.ClientID%>');
                var cboDegree = $('#<%=cboDegree_from.ClientID%>');
                var cboMajor = $('#<%=cboMajor_from.ClientID%>');
                var url = "../lov/budget_plan_lov.aspx?" +
                    "budget_type=" + cboBudget_type.val() +
                    "&budget_plan_code=" + txtbudget_plan_code_from.val() +
                    "&cboDegree=" + cboDegree.val() +
                    "&cboMajor=" + cboMajor.val() +
                    "&ctrl1=" + txtbudget_plan_code_from.attr('id') +
                    "&show=1&from_page=budget_transfer_from";
                OpenPopUp('950px', '500px', '94%', 'ค้นหาข้อมูลผังงบประมาณต้นทาง', url, '1');
                return false;
            });


            $("input[id*=imgList_budget_plan_to]").live("click", function () {
                var txtbudget_plan_code_to = $('#<%=txtbudget_plan_code_to.ClientID%>');
                var cboBudget_type = $('#<%=cboBudget_type.ClientID%>');
                var cboDegree = $('#<%=cboDegree_to.ClientID%>');
                var cboMajor = $('#<%=cboMajor_to.ClientID%>');
                var url = "../lov/budget_plan_lov.aspx?" +
                    "budget_type=" + cboBudget_type.val() +
                    "&budget_plan_code=" + txtbudget_plan_code_to.val() +
                    "&cboDegree=" + cboDegree.val() +
                    "&cboMajor=" + cboMajor.val() +
                    "&ctrl1=" + txtbudget_plan_code_to.attr('id') +
                    "&show=1&from_page=budget_transfer_to";
                OpenPopUp('950px', '500px', '94%', 'ค้นหาข้อมูลผังงบประมาณปลายทาง', url, '1');
                return false;
            });

            //$("input[id*=imgClear_budget_plan]").live("click", function () {
            //    return window.confirm("ยืนยันการเปลี่ยนผังงบประมาณ");
            //});

            $("input[id*=imgAdd]").live("click", function () {
                var cboDegree_from = $('#<%=cboDegree_from.ClientID%>');
                var cboMajor_from = $('#<%=cboMajor_from.ClientID%>');
                var txtbudget_plan_code_from = $('#<%=txtbudget_plan_code_from.ClientID%>');
                var cboDegree_to = $('#<%=cboDegree_to.ClientID%>');
                var cboMajor_to = $('#<%=cboMajor_to.ClientID%>');
                var txtbudget_plan_code_to = $('#<%=txtbudget_plan_code_to.ClientID%>');
                var txtbudget_transfer_doc = $('#<%=txtbudget_transfer_doc.ClientID%>');
                var url = "budget_transfer_detail_control.aspx?" +
                    "major_code_from=" + cboMajor_from.val() +
                    "&degree_code=" + cboDegree_from.val() +
                    "&budget_plan_code_from=" + txtbudget_plan_code_from.val() +
                    "&major_code_to=" + cboMajor_to.val() +
                    "&degree_code_to=" + cboDegree_to.val() +
                    "&budget_plan_code_to=" + txtbudget_plan_code_to.val() +
                    "&budget_transfer_doc=" + txtbudget_transfer_doc.val() +
                    "&show=1&from=budget_transfer_control";

                OpenPopUp('900px', '500px', '96%', 'บันทึกข้อมูลรายการโอนเงิน', url, '1');
                return false;
            });

        };

    </script>

</asp:Content>

