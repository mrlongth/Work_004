<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="budget_money_item_lov.aspx.cs" Inherits="myWeb.App_Control.lov.budget_money_item_lov"
    Title="ค้นหาข้อมูลรายได้/ค่าใช้จ่าย" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">

        function SelectAll(id) {
            var grid = document.getElementById("<%= GridView1.ClientID %>");
            var cell;

            if (grid.rows.length > 0) {
                for (i = 1; i < grid.rows.length; i++) {
                    cell = grid.rows[i].cells[0];
                    for (j = 0; j < cell.childNodes.length; j++) {
                        if (cell.childNodes[j].type == "checkbox") {
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

    </script>

    <table cellpadding="1" cellspacing="0" style="width: 100%" border="0">
        <tr>
            <td style="text-align: right;" width="25%">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage4">หมวดรายได้/ค่าใช้จ่าย :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboItem_group" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 16px;" width="15%">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage14">รายละเอียดหมวดรายได้/ค่าใช้จ่าย :</asp:Label>
            </td>
            <td colspan="2" style="height: 16px">
                <asp:DropDownList ID="cboItem_group_detail" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_detail_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 22px;" width="15%">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage16">รายได้/ค่าใช้จ่าย :</asp:Label>
            </td>
            <td style="height: 22px">
                <asp:DropDownList ID="cboItem" runat="server" CssClass="textbox" AutoPostBack="True" OnSelectedIndexChanged="cboItem_group_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td rowspan="2" style="text-align: right">
                <asp:ImageButton runat="server" ImageUrl="~/images/button/save_add.png"
                    ID="imgSaveOnly" OnClick="imgSaveOnly_Click"></asp:ImageButton>
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage2">รายละเอียดรายได้/ค่าใช้จ่าย :</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtitem_detail_code"
                    MaxLength="10"></asp:TextBox>
                &nbsp;<asp:TextBox runat="server" CssClass="textbox" Width="350px"
                    ID="txtitem_detail_name"></asp:TextBox>
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
        </tr>
    </table>
    <div class="div-lov" style="height: 318px">
        <asp:GridView ID="GridView1" runat="server" CssClass="stGrid" AllowSorting="True"
            AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2"
            Font-Size="10pt" Width="100%" Font-Bold="False" OnRowCreated="GridView1_RowCreated"
            OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" EmptyDataText="ไม่พบข้อมูลที่ต้องการค้นหา"
            ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="เลือก">
                    <HeaderTemplate>
                        <asp:CheckBox ID="cbSelectAll" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <asp:HiddenField ID="hddbudget_money_major_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.budget_money_major_id") %>'></asp:HiddenField>
                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Wrap="True" Width="5%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รหัส" SortExpression="item_detail_code">
                    <ItemStyle HorizontalAlign="Center" Wrap="True" Width="10%"></ItemStyle>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdditem_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.item_detail_id") %>' />
                        <asp:Label ID="lblitem_detail_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.item_detail_code") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รายละเอียดรายได้/ค่าใช้จ่าย " SortExpression="item_detail_name">
                    <ItemStyle HorizontalAlign="Left" Wrap="True" Width="20%"></ItemStyle>
                    <ItemTemplate>
                        <asp:Label ID="lblitem_detail_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.item_detail_name") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รายได้/ค่าใช้จ่าย" SortExpression="Item_name">
                    <ItemStyle HorizontalAlign="Left" Width="20%" Wrap="True" />
                    <ItemTemplate>
                        <asp:Label ID="lblItem_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_name") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="รายละเอียดหมวดรายได้/ค่าใช้จ่าย" SortExpression="Item_group_detail_name" Visible="false">
                    <ItemStyle HorizontalAlign="Left" Width="20%" Wrap="True" />
                    <ItemTemplate>
                        <asp:Label ID="lblItem_group_detail_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.Item_group_detail_name") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="หมวดรายได้/ค่าใช้จ่าย" SortExpression="item_group_name">
                    <ItemStyle HorizontalAlign="Left" Width="20%" Wrap="False" />
                    <ItemTemplate>
                        <asp:Label ID="lblitem_group_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.item_group_name") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <HeaderStyle CssClass="stGridHeader"
                HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="#EAEAEA" />
        </asp:GridView>
    </div>
</asp:Content>

