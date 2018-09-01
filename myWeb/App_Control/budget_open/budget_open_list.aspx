<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_open_list.aspx.cs" Inherits="myWeb.App_Control.budget_open.budget_open_list"
    Title="แสดงข้อมูลผังงบประมาณ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="1" cellspacing="1" style="width: 100%">
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage4">ปีงบประมาณ :</asp:Label>
            </td>
            <td style="width: 1%;">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboYear"
                    AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage18">ระดับการศึกษา :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboDegree"
                    AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage22">ตั้งแต่วันที่ : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">

                <asp:TextBox ID="txtdate_begin" runat="server" CssClass="textbox"
                    Width="100px" />

            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage24">ถึงวันที่ :</asp:Label>
            </td>
            <td colspan="2">

                <asp:TextBox ID="txtdate_end" runat="server" CssClass="textbox"
                    Width="100px" />

            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage31">ตั้งแต่วันที่เบิก : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">

                <asp:TextBox ID="txtdate_actual_begin" runat="server" CssClass="textbox"
                    Width="100px" />

            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage32">ถึงวันที่ :</asp:Label>
            </td>
            <td colspan="2">

                <asp:TextBox ID="txtdate_actual_end" runat="server" CssClass="textbox"
                    Width="100px" />

            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage19">เลขที่เอกสาร : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_open_doc"></asp:TextBox>
            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage25">รายการขออนุมัติ :</asp:Label>
            </td>
            <td colspan="2">

                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtopen_code" MaxLength="20"></asp:TextBox>
                &nbsp;<asp:ImageButton runat="server" ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif"
                    ID="imgList_open"></asp:ImageButton>
                <asp:ImageButton runat="server" CausesValidation="False" ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif"
                    ID="imgClear_open"></asp:ImageButton>
                &nbsp;<asp:TextBox runat="server" CssClass="textbox" Width="230px" ID="txtopen_title"
                    MaxLength="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage28">เลขที่ใบขออนุมัติ : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_open_no"></asp:TextBox>
            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage27">เลขที่งบ : </asp:Label>
            </td>
            <td colspan="2">

                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_open_budget_no"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage29">เลขที่ AP : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_open_ap"></asp:TextBox>
            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage30">เลขที่ PR : </asp:Label>
            </td>
            <td colspan="2">

                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_open_pr"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" class="label_d">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage2">รหัสผังงบประมาณ : </asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_plan_code"></asp:TextBox>
            </td>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage8">หน่วยงาน :
                </asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboUnit" AutoPostBack="True"
                    OnSelectedIndexChanged="cboUnit_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="lblPage5" runat="server" CssClass="label_h">แผนงบประมาณ  :</asp:Label>
            </td>
            <td style="width: 1%;">
                <asp:DropDownList ID="cboBudget" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboBudget_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="lblPage15" runat="server" CssClass="label_h">ผลผลิต :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboProduce" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboProduce_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage16">กิจกรรม :</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboActivity" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboActivity_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage23">หลักสูตร :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboMajor" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboActivity_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage26">สถานะการอนุมัติ :</asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboApproveStatus">
                    <asp:ListItem Value="">---- เลือกทั้งหมด ----</asp:ListItem>
                    <asp:ListItem Value="P">รออนุมัติ</asp:ListItem>
                    <asp:ListItem Value="A">อนุมัติ</asp:ListItem>
                    <asp:ListItem Value="C">ยกเลิกรายการ</asp:ListItem>
                </asp:DropDownList></td>
            <td rowspan="3">&nbsp;
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
                <asp:ImageButton runat="server" AlternateText="เพิ่มข้อมุล" ImageUrl="~/images/button/Save.png"
                    ID="imgNew" OnClick="imgNew_Click"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">&nbsp;</td>
            <td colspan="3">
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
        </tr>

    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
   <asp:GridView ID="GridView1" runat="server" CssClass="stGrid" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" BorderWidth="1px"
        CellPadding="2" Font-Size="10pt" Width="100%" Font-Bold="False" OnRowCreated="GridView1_RowCreated"
        OnRowDeleting="GridView1_RowDeleting" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound"
        OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand"
        EmptyDataText="ไม่พบข้อมูลที่ต้องการค้นหา" ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="#EAEAEA"></AlternatingRowStyle>
        <Columns>
            <asp:TemplateField Visible="true">
                <ItemTemplate>
                    <asp:ImageButton ID="imgView" runat="server" CausesValidation="False" CommandName="VIEW" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <asp:Label ID="lblNo" runat="server"> </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="True" Width="2%"></ItemStyle>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="เลขที่เอกสาร" SortExpression="budget_open_doc">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_open_doc" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_open_doc") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="เลขที่ใบขออนุมัติ" SortExpression="budget_open_no">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_open_no" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_open_no") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="เลขที่งบ" SortExpression="budget_open_budget_no">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_open_budget_no" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_open_budget_no") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="เลขที่ AP" SortExpression="budget_open_ap">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_open_ap" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_open_ap") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="เลขที่ PR" SortExpression="budget_open_pr">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_open_pr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_open_pr") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="วันที่" SortExpression="budget_open_date">
                <ItemTemplate>
                    <cc1:AwLabelDateTime ID="txtbudget_open_date" runat="server" Value='<% # DataBinder.Eval(Container, "DataItem.budget_open_date")%>'
                        DateFormat="dd/MM/yyyy">
                    </cc1:AwLabelDateTime>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="True" />
            </asp:TemplateField>

             <asp:TemplateField HeaderText="วันที่เบิกจริง" SortExpression="budget_open_date_actual">
                <ItemTemplate>
                    <cc1:AwLabelDateTime ID="txtbudget_open_date_actual" runat="server" Value='<% # DataBinder.Eval(Container, "DataItem.budget_open_date_actual")%>'
                        DateFormat="dd/MM/yyyy">
                    </cc1:AwLabelDateTime>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="True" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="รหัสผังงบ" SortExpression="budget_plan_code">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_plan_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_plan_code") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ระดับการศึกษา" SortExpression="degree_name">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lbldegree_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.degree_name") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="หน่วยงาน" SortExpression="unit_name" Visible="false">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblunit_code" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.unit_code") %>'
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblunit_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.unit_name") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="แผนงบประมาณ " SortExpression="budget_name" Visible="true">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_code" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.budget_code") %>'
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblbudget_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.budget_name") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ผลผลิต" SortExpression="produce_name" Visible="true">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblproduce_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.produce_code") %>'
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblproduce_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.produce_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="กิจกรรม" SortExpression="activity_name">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblactivity_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.activity_code") %>'
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblactivity_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.activity_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="หลักสูตร" SortExpression="major_name">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblmajor_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.major_code") %>'
                        Visible="false"></asp:Label>
                    <asp:Label ID="lblmajor_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.major_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="รายการขออนุมัติเบิกจ่าย" SortExpression="open_title" Visible="false">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="15%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblopen_title" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.open_title")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="จำนวนเงินขอเบิก" SortExpression="open_amount" Visible="true">
                <ItemStyle HorizontalAlign="Right" Wrap="True" Width="80px"></ItemStyle>
                <ItemTemplate>
                    <cc1:AwNumeric ID="txtopen_amount" runat="server" Width="80px" LeadZero="Show" DisplayMode="View"
                        Value='<% # DataBinder.Eval(Container, "DataItem.open_amount")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="สถานะ" SortExpression="approve_head_status"
                Visible="true">
                <ItemStyle HorizontalAlign="Center" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblapprove_head_status" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" CommandName="EDIT" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                    <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="DELETE" CommandArgument="<%# Container.DisplayIndex + 1 %>" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="5%"></ItemStyle>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
        <HeaderStyle HorizontalAlign="Center" CssClass="stGridHeader" Font-Bold="True"></HeaderStyle>
        <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/images/next.gif" NextPageText="Next &amp;gt;&amp;gt;"
            Position="Top" PreviousPageImageUrl="~/images/prev.gif" PreviousPageText="&amp;lt;&amp;lt; Previous"></PagerSettings>
        <PagerStyle HorizontalAlign="Center" Wrap="True" BackColor="Gainsboro" ForeColor="#8C4510"></PagerStyle>
    </asp:GridView>
    <input id="txthpage" type="hidden" name="txthpage" runat="server" />
    <input id="txthTotalRecord" type="hidden" name="txthTotalRecord" runat="server" />
</asp:Content>
