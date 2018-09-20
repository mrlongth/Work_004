<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="deduct_item_select.aspx.cs"
    Inherits="myWeb.App_Control.deduct.deduct_item_select" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">

        function SelectAll(id)
        {
            var grid = document.getElementById("<%= GridView1.ClientID %>");
            var cell;

            if (grid.rows.length > 0)
            {
                for (i = 1; i < grid.rows.length; i++)
                {
                    cell = grid.rows[i].cells[0];
                    for (j = 0; j < cell.childNodes.length; j++)
                    {
                        if (cell.childNodes[j].type == "checkbox")
                        {
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }

    </script>

    <table cellpadding="1" cellspacing="0" style="width: 100%" border="0">
        <tr>
            <td style="text-align: right;" width="25%">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right;" width="25%">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage4">ประเภทรายการ :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboRecv_item_type" AutoPostBack="True" OnSelectedIndexChanged="cboRecv_item_type_SelectedIndexChanged">
                    <asp:ListItem Value="">---- เลือกข้อมูลทั้งหมด ----</asp:ListItem>
                    <asp:ListItem Value="D">รายการรับ</asp:ListItem>
                    <asp:ListItem Value="C">รายการหัก</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 22px;" width="15%">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage16">รหัสรายการ :</asp:Label>
            </td>
            <td style="height: 22px">
                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtrecv_item_code"
                    MaxLength="10"></asp:TextBox>
            </td>
            <td rowspan="3" style="text-align: right">
                <asp:ImageButton runat="server" ImageUrl="~/images/button/save_add.png"
                    ID="imgSaveOnly" OnClick="imgSaveOnly_Click"></asp:ImageButton>
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage2">รายละเอียด :</asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="textbox" Width="350px"
                    ID="txtrecv_item_name"></asp:TextBox>
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right;" colspan="3">
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
                                   <asp:CheckBox ID="chkRecv_item_is_director" runat="server" Visible="false"  />
                                 </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ประเภทรายการ" SortExpression="recv_item_group_type">
                                <ItemStyle HorizontalAlign="Center" Wrap="True" Width="10%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblrecv_item_type" runat="server" Text='<%# getItemtype(DataBinder.Eval(Container, "DataItem.recv_item_type")) %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รหัสรายการ" SortExpression="recv_item_code">
                                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="20%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblrecv_item_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.recv_item_code") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รายละเอียด" SortExpression="recv_item_name">
                                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="35%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblrecv_item_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.recv_item_name")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="%หัก" SortExpression="recv_item_rate">
                                <ItemStyle HorizontalAlign="Right" Wrap="True" Width="15%"></ItemStyle>
                                <ItemTemplate>
                                    <cc1:AwNumeric ID="txtrecv_item_rate" runat="server"
                                        Value='<% # DataBinder.Eval(Container, "DataItem.recv_item_rate")%>' DisplayMode="View"
                                        CssClass="textbox" LeadZero="Show" MaxValue="99" MinValue="0" Width="100px">
                                    </cc1:AwNumeric>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="หมายเหตุ" SortExpression="recv_item_remark">
                                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="20%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblrecv_item_remark" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.recv_item_remark")%>'>
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

            </td>
        </tr>
    </table>




</asp:Content>
