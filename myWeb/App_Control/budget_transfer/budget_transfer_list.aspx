<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_transfer_list.aspx.cs" Inherits="myWeb.App_Control.budget_transfer.budget_transfer_list"
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
                <asp:Label runat="server" CssClass="label_h" ID="lblPage19">เลขที่เอกสาร : </asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_transfer_doc"></asp:TextBox>
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
            <td colspan="2" style="height: 23px">

                <asp:TextBox ID="txtdate_end" runat="server" CssClass="textbox"
                    Width="100px" />

                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>

            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage18">ระดับการศึกษาต้นทาง :</asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">

                <asp:DropDownList runat="server" CssClass="textbox" ID="cboDegree_from"
                    AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
                </asp:DropDownList>

            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage27">ระดับการศึกษาปลายทาง :</asp:Label>
            </td>
            <td colspan="2" style="height: 23px">

                <asp:DropDownList runat="server" CssClass="textbox" ID="cboDegree_to"
                    AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage2">รหัสผังงบประมาณต้นทาง : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">

                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_plan_code_from"></asp:TextBox>

            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage28">รหัสผังงบประมาณปลายทาง : </asp:Label>
            </td>
            <td colspan="2" style="height: 23px">

                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_plan_code_to"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage8">หน่วยงานต้นทาง :
                </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboUnit_from" AutoPostBack="True"
                    OnSelectedIndexChanged="cboUnit_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage29">หน่วยงานปลายทาง :
                </asp:Label>
            </td>
            <td colspan="2" style="height: 23px">

                <asp:DropDownList runat="server" CssClass="textbox" ID="cboUnit_to" AutoPostBack="True"
                    OnSelectedIndexChanged="cboUnit_to_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" class="label_d">
                <asp:Label ID="lblPage5" runat="server" CssClass="label_h">แผนงบประมาณต้นทาง  :</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboBudget_from" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboBudget_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="lblPage30" runat="server" CssClass="label_h">แผนงบประมาณปลายทาง  :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboBudget_to" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboBudget_to_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="lblPage15" runat="server" CssClass="label_h">ผลผลิตต้นทาง :</asp:Label>
            </td>
            <td style="width: 1%;">
                <asp:DropDownList ID="cboProduce_from" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboProduce_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="lblPage31" runat="server" CssClass="label_h">ผลผลิตปลายทาง :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboProduce_to" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboProduce_to_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage16">กิจกรรมต้นทาง :</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboActivity_from" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboActivity_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage32">กิจกรรมปลายทาง :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboActivity_to" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboActivity_to_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage23">หลักสูตรต้นทาง :</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboMajor_from" runat="server" CssClass="textbox" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage33">หลักสูตรปลายทาง :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboMajor_to" runat="server" CssClass="textbox" AutoPostBack="True"
                    OnSelectedIndexChanged="cboMajor_to_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">&nbsp;</td>
            <td colspan="3">&nbsp;</td>
            <td>&nbsp;
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
                <asp:ImageButton runat="server" AlternateText="เพิ่มข้อมุล" ImageUrl="~/images/button/Save.png"
                    ID="imgNew" OnClick="imgNew_Click"></asp:ImageButton>
            </td>
        </tr>

    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="2" EmptyDataText="ไม่พบข้อมูลที่ต้องการค้นหา" ShowFooter="True"
        BorderWidth="1px" CssClass="stGrid" Font-Bold="False" Font-Size="10pt" Width="100%"
        ID="GridView1" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
        OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
        OnSorting="GridView1_Sorting" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand">
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

            <asp:TemplateField HeaderText="เลขที่เอกสาร" SortExpression="budget_transfer_doc">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_transfer_doc" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_transfer_doc") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="วันที่">
                <ItemTemplate>
                    <cc1:AwLabelDateTime ID="txtbudget_transfer_date" runat="server" Value='<% # DataBinder.Eval(Container, "DataItem.budget_transfer_date")%>'
                        DateFormat="dd/MM/yyyy">
                    </cc1:AwLabelDateTime>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="True" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ระดับการศึกษาต้นทาง" SortExpression="degree_name_from">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lbldegree_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.degree_name_from") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="หลักสูตรต้นทาง" SortExpression="major_name_from">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblmajor_name_from" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.major_name_from") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="รหัสผังงบต้นทาง" SortExpression="budget_plan_code_from">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="30%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_plan_code_from" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_plan_code_from") %>' />
                    : 
                    <asp:Label ID="lblunit_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.unit_name_from") %>' />
                    / 
                    <asp:Label ID="lblbudget_name_from" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.budget_name_from") %>' />
                    / 
                    <asp:Label ID="lblproduce_name_from" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.produce_name_from") %>' />
                    / 
                    <asp:Label ID="lblactivity_name_from" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.activity_name_from") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ระดับการศึกษาปลายทาง" SortExpression="degree_name_to">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lbldegree_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.degree_name_to") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="หลักสูตรปลายทาง" SortExpression="major_name_to">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="10%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblmajor_name_to" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.major_name_to") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="รหัสผังงบปลายทาง" SortExpression="budget_plan_code_to">
                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="30%"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblbudget_plan_code_to" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.budget_plan_code_to") %>' />
                    : 
                    <asp:Label ID="lblunit_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.unit_name_to") %>' />
                    / 
                    <asp:Label ID="lblbudget_name_to" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.budget_name_to") %>' />
                    / 
                    <asp:Label ID="lblproduce_name_to" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.produce_name_to") %>' />
                    / 
                    <asp:Label ID="lblactivity_name_to" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.activity_name_to") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="จำนวนเงิน" SortExpression="budget_transfer_amount" Visible="true">
                <ItemStyle HorizontalAlign="Right" Wrap="True" Width="80px"></ItemStyle>
                <ItemTemplate>
                    <cc1:AwNumeric ID="txtbudget_transfer_amount" runat="server" Width="80px" LeadZero="Show" DisplayMode="View"
                        Value='<% # DataBinder.Eval(Container, "DataItem.budget_transfer_amount")%>' />
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
