<%@ Page Language="C#" MasterPageFile="~/Site_lov.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="cer_approve_lov.aspx.cs" Inherits="myWeb.App_Control.lov.cer_approve_lov"
    Title="ค้นหาข้อมูลผู้อนุมัติ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="1" cellspacing="0" style="width: 100%" border="0">
        <tr>
            <td style="text-align: right; width: 21%;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage2">ชื่อ - สกุล :
                </asp:Label>
            </td>
            <td>&nbsp;<asp:TextBox runat="server" CssClass="textbox" Width="250px" ID="txtreq_approve"></asp:TextBox>
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
            <td style="text-align: right; vertical-align: bottom;"
                valign="bottom" width="15%">
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="div-lov" style="height: 314px">
        <asp:GridView ID="GridView1" runat="server" CssClass="stGrid" AllowSorting="True"
            AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2"
            Font-Size="10pt" Font-Bold="False" OnRowCreated="GridView1_RowCreated" OnSorting="GridView1_Sorting"
            OnRowDataBound="GridView1_RowDataBound" EmptyDataText="ไม่พบข้อมูลที่ต้องการค้นหา"
            ShowFooter="True" Style="width: 100%">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
                    <ItemTemplate>
                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ผู้อนุมัติ" SortExpression="position_code">
                    <ItemStyle HorizontalAlign="Left" Width="20%" Wrap="True" />
                    <ItemTemplate>
                        <asp:Label ID="lblreq_approve" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.req_approve") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ตำแหน่ง 1" SortExpression="req_approve_position1">
                    <ItemStyle HorizontalAlign="Left" Width="25%" Wrap="True" />
                    <ItemTemplate>
                        <asp:Label ID="lblreq_approve_position1" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.req_approve_position1")%>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ตำแหน่ง 2" SortExpression="req_approve_position2">
                    <ItemStyle HorizontalAlign="Left" Width="25%" Wrap="True" />
                    <ItemTemplate>
                        <asp:Label ID="lblreq_approve_position2" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.req_approve_position2")%>'>
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
