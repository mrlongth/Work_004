<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="deduct_control.aspx.cs" Inherits="myWeb.App_Control.deduct.deduct_control"
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
                                <asp:TextBox ID="txtdeduct_doc" runat="server" CssClass="textbox" Width="130px"></asp:TextBox>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label91" runat="server" CssClass="label_hbk">วันที่ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtdeduct_date" runat="server" CssClass="textbox" ReadOnly="True" Width="100px" />
                            </td>
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
                                <asp:Label ID="Label90" runat="server" CssClass="label_hbk">ปีงบประมาณ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="cboYear" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label87" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="Label113" runat="server" CssClass="label_hbk">เลขที่งบประมาณ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtbudget_money_doc" runat="server" CssClass="textbox" MaxLength="10" Width="80px"></asp:TextBox>
                                <asp:ImageButton ID="imgList_budget_money_doc" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_budget_money_doc" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" OnClick="imgClear_budget_plan_Click" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtbudget_money_doc" Display="None" ErrorMessage="กรุณาเลือกเลขที่งบประมาณ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:LinkButton ID="lbkRefresh" runat="server" OnClick="lbkRefresh_Click" Style="display: none;">lbkRefresh</asp:LinkButton>
                            </td>
                            <td nowrap style="text-align: right" width="10%">
                                <asp:Label ID="Label116" runat="server" CssClass="label_hbk">ผังงบประมาณ :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txtbudget_plan_code" runat="server" CssClass="textbox" MaxLength="10" Width="80px"></asp:TextBox>
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
                                <asp:Label ID="Label115" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="lblPage28" runat="server" CssClass="label_hbk">หลักสูตร :</asp:Label>
                            </td>
                            <td align="left" nowrap style="height: 22px" valign="middle">
                                <asp:DropDownList ID="cboMajor" runat="server" CssClass="textbox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="cboMajor" Display="None" ErrorMessage="กรุณาเลือกหลักสูตร" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                            <td nowrap style="text-align: right; height: 22px;">
                                <asp:Label ID="Label114" runat="server" CssClass="label_error">*</asp:Label>
                                <asp:Label ID="lblPage27" runat="server" CssClass="label_hbk">รายละเอียดหมวดรายรับ :</asp:Label>
                            </td>
                            <td align="left" style="height: 22px">
                                <asp:DropDownList ID="cboItem_group_detail" runat="server" CssClass="textbox">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="cboItem_group_detail" Display="None" ErrorMessage="กรุณาเลือกรายละเอียดหมวดรายรับ" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap style="height: 22px" valign="middle">
                                <asp:Label ID="Label86" runat="server" CssClass="label_hbk">หมายเหตุ :</asp:Label>
                            </td>
                            <td align="left" colspan="3" nowrap style="height: 22px" valign="middle">
                                <asp:TextBox ID="txtcomment" runat="server" CssClass="textbox" Width="600px"></asp:TextBox>
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
                    </table>
                </ContentTemplate>
            </ajaxtoolkit:TabPanel>
            <ajaxtoolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="รายละเอียดรายการหัก" Visible="false">
                <HeaderTemplate>
                    รายละเอียดรายการหัก
                </HeaderTemplate>
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" class="ui-accordion">
                        <tr align="left" style="display:none;">
                            <td align="right" nowrap valign="middle" style="width: 20%">
                                <asp:Label ID="Label6" runat="server" CssClass="label_hbk">เลขที่ใบรับเงิน :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtrecv_doc_no" runat="server" CssClass="textbox" MaxLength="10" Width="150px"
                                    Text='<%# DataBinder.Eval(Container, "DataItem.recv_doc_no") %>'></asp:TextBox>
                                <asp:ImageButton ID="imgList_recv" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                <asp:ImageButton ID="imgClear_recv" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" />

                            </td>
                            <td nowrap style="text-align: right" width="20%"></td>
                            <td style="text-align: left"></td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle" style="width: 20%">
                                <asp:Label ID="Label4" runat="server" CssClass="label_hbk">จำนวนเงินที่รับ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <cc1:AwNumeric ID="txtrecv_total_amount" runat="server" CssClass="textbox"
                                    Value='<%# DataBinder.Eval(Container, "DataItem.recv_total_amount") %>' Width="150px"></cc1:AwNumeric>
                            </td>
                            <td nowrap style="text-align: right" width="20%">
                                <asp:Label ID="Label5" runat="server" CssClass="label_hbk">จำนวนเงินที่หัก :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <cc1:AwNumeric ID="txtdeduct_total_reduce" runat="server" CssClass="textbox" 
                                    Value='<%# DataBinder.Eval(Container, "DataItem.deduct_total_reduce") %>' Width="150px"></cc1:AwNumeric>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap style="width: 20%" valign="middle">
                                <asp:Label ID="Label111" runat="server" CssClass="label_hbk">จำนวนเงินที่หักสำหรับส่วนกลาง :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <cc1:AwNumeric ID="txtdeduct_total_reduce_director" runat="server" CssClass="textbox" 
                                    Value='<%# DataBinder.Eval(Container, "DataItem.deduct_total_reduce_director") %>' Width="150px"></cc1:AwNumeric>
                            </td>
                            <td nowrap style="text-align: right" width="20%">
                                <asp:Label ID="Label112" runat="server" CssClass="label_hbk">จำนวนคงเหลือของหลักสูตร :</asp:Label>
                            </td>
                            <td style="text-align: left">
                                <cc1:AwNumeric ID="txtdeduct_total_remain" runat="server" CssClass="textbox"  
                                    Value='<%# DataBinder.Eval(Container, "DataItem.deduct_total_reduce") %>' Width="150px"></cc1:AwNumeric>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlDetail" runat="server">
                        <asp:GridView ID="GridView1" runat="server"
                            AutoGenerateColumns="False" BackColor="White" BorderWidth="1px"
                            CellPadding="2" CssClass="stGrid" Font-Bold="False" Font-Size="10pt"
                            OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound"
                            OnSorting="GridView1_Sorting" Width="100%" OnRowCommand="GridView1_RowCommand"
                            OnRowDeleting="GridView1_RowDeleting">
                            <AlternatingRowStyle BackColor="#EAEAEA" />
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                        <asp:HiddenField ID="hdddeduct_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.deduct_detail_id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="รายการหัก" SortExpression="recv_item_code">
                                    <ItemStyle HorizontalAlign="Left" Width="40%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtrecv_item_code" runat="server" CssClass="textbox" MaxLength="10" Width="20%"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.recv_item_code") %>'></asp:TextBox>
                                        <%--<asp:ImageButton ID="imgList_recv_item" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />--%>
                                        <%--<asp:ImageButton ID="imgClear_recv_item" runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" />--%>
                                        <asp:TextBox ID="txtrecv_item_name" runat="server" CssClass="textboxdis" MaxLength="255" Width="78%"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.recv_item_name") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="%หัก" SortExpression="recv_item_rate">
                                    <ItemStyle HorizontalAlign="Right" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtrecv_item_rate" runat="server" CssClass="textbox"
                                            Value='<%# DataBinder.Eval(Container, "DataItem.recv_item_rate") %>'
                                            LeadZero="Show" Width="98%"></cc1:AwNumeric>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="จำนวนหัก" SortExpression="deduct_item_amount">
                                    <ItemStyle HorizontalAlign="Right" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtdeduct_item_amount" runat="server" CssClass="textbox"
                                            Value='<%# DataBinder.Eval(Container, "DataItem.deduct_item_amount") %>'
                                            LeadZero="Show" Width="98%"></cc1:AwNumeric>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="หักส่วนกลาง" SortExpression="deduct_item_is_director">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDeduct_item_is_director" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="หมายเหตุ" SortExpression="deduct_item_remark">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" Wrap="True" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtdeduct_item_remark" runat="server" CssClass="textbox" MaxLength="255" Width="98%"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.deduct_item_remark") %>'></asp:TextBox>
                                    </ItemTemplate>
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
                            <HeaderStyle CssClass="stGridHeader" Font-Bold="True" HorizontalAlign="Center" />
                        </asp:GridView>
                    </asp:Panel>


                </ContentTemplate>
            </ajaxtoolkit:TabPanel>
            <ajaxtoolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="รายละเอียดการนำเข้าเงินงบประมาณ" Visible="false">
                <HeaderTemplate>
                    รายละเอียดการนำเข้าเงินงบประมาณ
                </HeaderTemplate>
                <ContentTemplate>
                    <table border="0" cellpadding="2" cellspacing="2" class="ui-accordion">
                        <tr align="left" style="display:block;">
                            <td align="right" nowrap valign="middle" style="width: 20%; height: 26px;">
                                <asp:Label ID="Label7" runat="server" CssClass="label_hbk">เลขที่การนำเข้าเงินงบประมาณ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle" style="height: 26px">
                                <asp:TextBox ID="txtbudget_receive_doc" runat="server" CssClass="textboxdis" ReadOnly="True" MaxLength="10" Width="150px"
                                    Text='<%# DataBinder.Eval(Container, "DataItem.recv_doc_no") %>'></asp:TextBox>

                            </td>
                            <td nowrap style="text-align: right; height: 26px;" width="20%"></td>
                            <td style="text-align: left; height: 26px;"></td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:GridView ID="GridView2" runat="server"
                            AutoGenerateColumns="False" BackColor="White" BorderWidth="1px"
                            CellPadding="2" CssClass="stGrid" Font-Bold="False" Font-Size="10pt"
                            OnRowCreated="GridView2_RowCreated"
                            OnRowDataBound="GridView2_RowDataBound"
                            OnSorting="GridView2_Sorting" Width="100%">
                            <AlternatingRowStyle BackColor="#EAEAEA" />
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                        <asp:HiddenField ID="hddbudget_receive_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_receive_detail_id") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="1%" Wrap="False" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="หลักสูตร" SortExpression="major_name">
                                    <ItemStyle HorizontalAlign="Left" Width="40%" Wrap="True" />
                                    <ItemTemplate>
                                         <asp:Label ID="lblmajor_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.major_name") %>'> </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="จำนวนเงินรับ" SortExpression="budget_receive_detail_contribute">
                                    <ItemStyle HorizontalAlign="Right" Width="10%" Wrap="True" />
                                    <ItemTemplate>
                                        <cc1:AwNumeric ID="txtbudget_receive_detail_contribute" runat="server" CssClass="textbox"
                                            Value='<%# DataBinder.Eval(Container, "DataItem.budget_receive_detail_contribute") %>'
                                            LeadZero="Show" DisplayMode="View" Width="98%"></cc1:AwNumeric>
                                    </ItemTemplate>
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


            $("input[id*=imgList_budget_money_doc]").live("click", function ()
            {
                var txtbudget_money_doc = $('#<%=txtbudget_money_doc.ClientID%>');
                var txtbudget_plan_code = $('#<%=txtbudget_plan_code.ClientID%>');
                var txtbudget_name = $('#<%=txtbudget_name.ClientID%>');
                var txtproduce_name = $('#<%=txtproduce_name.ClientID%>');
                var txtactivity_name = $('#<%=txtactivity_name.ClientID%>');
                var txtplan_name = $('#<%=txtplan_name.ClientID%>');
                var txtwork_name = $('#<%=txtwork_name.ClientID%>');
                var txtfund_name = $('#<%=txtfund_name.ClientID%>');
                var txtdirector_name = $('#<%=txtdirector_name.ClientID%>');
                var txtunit_name = $('#<%=txtunit_name.ClientID%>');
                var cboDegree = $('#<%=cboDegree.ClientID%>');
                var cboYear = $('#<%=cboYear.ClientID%>');                
                var url = "../lov/budget_money_lov.aspx?" +
                    "budget_type=R" +
                    "&budget_money_doc=" + txtbudget_money_doc.val() +
                    "&budget_money_year=" + cboYear.val() +
                    "&budget_plan_code=" + txtbudget_plan_code.val() +
                    "&txtproduce_name=" + txtproduce_name.val() +
                    "&txtactivity_name=" + txtactivity_name.val() +
                    "&txtplan_name=" + txtplan_name.val() +
                    "&txtwork_name=" + txtwork_name.val() +
                    "&txtfund_name=" + txtfund_name.val() +
                    "&txtdirector_name=" + txtdirector_name.val() +
                    "&txtunit_name=" + txtunit_name.val() +
                    "&cboDegree=" + cboDegree.val() +
                    "&ctrl0=" + txtbudget_money_doc.attr('id') +
                    "&ctrl1=" + txtbudget_plan_code.attr('id') +
                    "&ctrl2=" + txtbudget_name.attr('id') +
                    "&ctrl3=" + txtproduce_name.attr('id') +
                    "&ctrl4=" + txtactivity_name.attr('id') +
                    "&ctrl5=" + txtplan_name.attr('id') +
                    "&ctrl6=" + txtwork_name.attr('id') +
                    "&ctrl7=" + txtfund_name.attr('id') +
                    "&ctrl9=" + txtdirector_name.attr('id') +
                    "&ctrl10=" + txtunit_name.attr('id') +
                    "&show=1&from_page=deduct_control";
                OpenPopUp('950px', '500px', '94%', 'ค้นหาข้อมูลงบประมาณประจำปี', url, '1');
                return false;
            });


            $("input[id*=imgAdd]").live("click", function ()
            {
                var txtdeduct_doc = $('#<%=txtdeduct_doc.ClientID%>');
                var txtrecv_total_amount = $('#<%=txtrecv_total_amount.ClientID%>');
                var cboYear = $('#<%=cboYear.ClientID%>');
                var url = "deduct_item_select.aspx?" +
                    "recv_item_type=C" +
                    "&recv_item_year=" + cboYear.val() +
                    "&deduct_doc=" + txtdeduct_doc.val() +
                    "&recv_total_amount=" + txtrecv_total_amount.val() +
                    "&lbkRefresh=" + $('#<%=lkbRefresh.UniqueID%>') +
                    "&show=1&from_page=deduct_control";

                OpenPopUp('1000px', '500px', '96%', 'ค้นหาข้อมูลรายการหัก', url, '1');
                return false;
            });

            var GridView1 = '<%=GridView1.ClientID%>';

            $("#" + GridView1 + " input[id*=txtrecv_item_rate]").live("keyup", function ()
            {
                CalItemAmount(this);
            });
            $("#" + GridView1 + " input[id*=txtrecv_item_rate]").live("blur", function ()
            {
                CalItemAmount(this);
            });

            $("#" + GridView1 + " input[id*=txtrecv_item_rate]").live("change", function ()
            {
                CalItemAmount(this);
            });

            $("#" + GridView1 + " input[id*=txtdeduct_item_amount]").live("keyup", function ()
            {
                CalAmount();
            });
            $("#" + GridView1 + " input[id*=txtdeduct_item_amount]").live("blur", function ()
            {
                CalAmount();
            });

            $("#" + GridView1 + " input[id*=txtdeduct_item_amount]").live("change", function ()
            {
                CalAmount();
            });


            $("#" + GridView1 + " input[id*=chkDeduct_item_is_director]").live("change", function ()
            {
                CalAmount();
            });


            $("#<%=txtrecv_total_amount.ClientID%>").live("change", function ()
            {
                $("#" + GridView1 + " input[id*=txtrecv_item_rate]").each(function ()
                {
                    CalItemAmount(this);
                });
            });
            $("#<%=txtrecv_total_amount.ClientID%>").live("keyup", function ()
            {
                $("#" + GridView1 + " input[id*=txtrecv_item_rate]").each(function ()
                {
                    CalItemAmount(this);
                });
            });
            $("#<%=txtrecv_total_amount.ClientID%>").live("blur", function ()
            {
                $("#" + GridView1 + " input[id*=txtrecv_item_rate]").each(function ()
                {
                    CalItemAmount(this);
                });
            });


            $("#<%=txtrecv_total_amount.ClientID%>").live("keyup", function ()
            {
                CalAmount();
            });
            $("#<%=txtrecv_total_amount.ClientID%>").live("blur", function ()
            {
                CalAmount();
            });

            function CalAmount()
            {
                var GridView1 = '<%=GridView1.ClientID%>';
                var rowCount = document.getElementById(GridView1).rows.length;

                var txtdeduct_item_amount = 0;
                var txtdeduct_item_amount_all = 0;
                var txtdeduct_total_reduce_director = 0;

                var strdeduct_item_amount = "";

                var strdeduct_item_is_director = "";

                for (var i = 2; i <= rowCount; i++)
                {

                    var numdeduct_item_amount = 0;

                    if (i < 10)
                    {
                        strdeduct_item_amount = GridView1 + '_ctl0' + i + '_txtdeduct_item_amount';
                        strdeduct_item_is_director = GridView1 + '_ctl0' + i + '_chkDeduct_item_is_director';
                    }
                    else
                    {
                        strdeduct_item_amount = GridView1 + '_ctl' + i + '_txtdeduct_item_amount';
                        strdeduct_item_is_director = GridView1 + '_ctl' + i + '_chkDeduct_item_is_director';
                    }

                    txtdeduct_item_amount = document.getElementById(strdeduct_item_amount).value.replace(/,/g, "");
                    numdeduct_item_amount = parseFloat(txtdeduct_item_amount);
                    if (checkNaN(numdeduct_item_amount)) numdeduct_item_amount = 0;
                    txtdeduct_item_amount_all = txtdeduct_item_amount_all + numdeduct_item_amount;

                    var chk = $('#' + strdeduct_item_is_director);
                    if (chk.is(":checked"))
                    {
                        txtdeduct_total_reduce_director = txtdeduct_total_reduce_director + numdeduct_item_amount;
                    }

                }

                var txtdeduct_total_reduce = $("#<%=txtdeduct_total_reduce.ClientID%>");
                txtdeduct_total_reduce.val(txtdeduct_item_amount_all.toFixed('2'));
                CommaFormatted(document.getElementById(txtdeduct_total_reduce.attr('id')));
                
                var txtdeduct_total_reduce_director_ctr = $("#<%=txtdeduct_total_reduce_director.ClientID%>");
                txtdeduct_total_reduce_director_ctr.val(txtdeduct_total_reduce_director.toFixed('2'));
                CommaFormatted(document.getElementById(txtdeduct_total_reduce_director_ctr.attr('id')));


                var txtrecv_total_amount_ctr = $("#<%=txtrecv_total_amount.ClientID%>");
                var numrecv_total_amount = parseFloat(document.getElementById(txtrecv_total_amount_ctr.attr('id')).value.replace(/,/g, ""));

                var total_remain = numrecv_total_amount - txtdeduct_item_amount_all;
                var txtdeduct_total_remain_ctr = $("#<%=txtdeduct_total_remain.ClientID%>");
                txtdeduct_total_remain_ctr.val(total_remain.toFixed('2'));
                CommaFormatted(document.getElementById(txtdeduct_total_remain_ctr.attr('id')));

            
            }

            function CalItemAmount(my)
            {

                var txtrecv_item_rate = 0;
                var txtdeduct_item_amount = 0;
                var strdeduct_item_amount = "";
                var strrecv_item_rate = "";

                var numdeduct_item_amount = 0;
                var numrecv_item_rate = 0;
                var txtrecv_total_amount = $("#<%=txtrecv_total_amount.ClientID%>");
                var numrecv_total_amount = parseFloat(document.getElementById(txtrecv_total_amount.attr('id')).value.replace(/,/g, ""));

                strrecv_item_rate = my.id;
                strdeduct_item_amount = strrecv_item_rate.replace("recv_item_rate", "deduct_item_amount");
                var txtdeduct_item_amount = $("#" + strdeduct_item_amount);
                
                txtrecv_item_rate = document.getElementById(strrecv_item_rate).value.replace(/,/g, "");
                numrecv_item_rate = parseFloat(txtrecv_item_rate);
                if (checkNaN(numrecv_item_rate)) numrecv_item_rate = 0;

                numdeduct_item_amount = numrecv_total_amount * numrecv_item_rate / 100;
                txtdeduct_item_amount.val(numdeduct_item_amount.toFixed('2'));
                CommaFormatted(document.getElementById(txtdeduct_item_amount.attr('id')));

                CalAmount();

            }


        };






    </script>

</asp:Content>

