<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="menu_list.aspx.cs" Inherits="myWeb.App_Control.menu.menu_list"
    Title="แสดงข้อมูลผู้ใช้งานระบบ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="1" cellspacing="1" style="width: 100%" border="0">
        <tr>
            <td style="text-align: right; width: 20%;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage11">เมนูหลัก :
                </asp:Label>
            </td>
            <td style="width: 1%;">
                            <asp:dropdownlist runat="server" cssclass="textbox" id="cboMenuParent" />
            </td>
            <td style="width: 20%; text-align: right;">
                &nbsp;</td>
            <td style="height: 23px; width: 254px;">
                &nbsp;</td>
            <td rowspan="4">
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
                <asp:ImageButton runat="server" AlternateText="เพิ่มข้อมุล" ImageUrl="~/images/button/Save.png"
                    ID="imgNew"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 20%;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage9">ชื่อเมนู :
                </asp:Label>
            </td>
            <td style="width: 1%;">
                <asp:TextBox runat="server" CssClass="textbox" Width="350px" ID="txtMenuName"></asp:TextBox>
            </td>
            <td style="width: 20%; text-align: right;">
                &nbsp;</td>
            <td style="height: 23px; width: 254px;">
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 20%;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage10">URL :
                </asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox runat="server" CssClass="textbox" Width="350px" ID="txtUrl"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 20%;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage3">สถานะ : </asp:Label>
            </td>
            <td>
                <asp:RadioButton runat="server" GroupName="A" Checked="True" Text="ทั้งหมด" CssClass="label_h"
                    ID="RadioAll"></asp:RadioButton>
                <asp:RadioButton runat="server" GroupName="A" Text="ปกติ" CssClass="label_h" ID="RadioActive">
                </asp:RadioButton>
                <asp:RadioButton runat="server" GroupName="A" Text="ยกเลิก" CssClass="label_h" ID="RadioCancel">
                </asp:RadioButton>
                <asp:Label ID="lblError0" runat="server" CssClass="label_error"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" CssClass="label_h" OnCheckedChanged="CheckBox1_CheckedChanged" Text="ปิดหน้าจอข้อมูลเงินเดือน" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <asp:GridView ID="GridView1" runat="server" CssClass="stGrid" AllowPaging="True"
        AllowSorting="True" AutoGenerateColumns="False" BorderWidth="1px" CellPadding="2"
        Font-Size="10pt" Width="100%" Font-Bold="False" OnRowCreated="GridView1_RowCreated"
        OnRowDeleting="GridView1_RowDeleting" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound"
        EmptyDataText="ไม่พบข้อมูลที่ต้องการค้นหา" ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:TemplateField Visible="false">
                <ItemStyle HorizontalAlign="Center" Width="3%" Wrap="False" />
                <ItemTemplate>
                    <asp:ImageButton ID="imgView" runat="server" CausesValidation="False"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <asp:Label ID="lblNo" runat="server"> </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ชื่อเมนู" SortExpression="MenuName">
                <ItemTemplate>
                    <asp:Label ID="lblMenuName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MenuName") %>'>
                    </asp:Label>
                    <asp:HiddenField ID="hddMenuID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.MenuID") %>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="30%" Wrap="True" />
            </asp:TemplateField>
             <asp:TemplateField HeaderText="ชื่อเมนูหลัก" SortExpression="MenuParentName">
                <ItemTemplate>
                    <asp:Label ID="lblMenuParentName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MenuParentName") %>'>
                    </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="30%" Wrap="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="URL " SortExpression="MenuNavigationUrl">
                <ItemTemplate>
                    <asp:Label ID="lblMenuNavigationUrl" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MenuNavigationUrl") %>'>
                    </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="30%" Wrap="True" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="ลำดับเมนู" SortExpression="MenuOrder">
                <ItemTemplate>
                    <asp:Label ID="lblMenuOrder" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MenuOrder") %>'>
                    </asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" Width="10%" Wrap="True" />
            </asp:TemplateField>
            <asp:TemplateField Visible="False" HeaderText="สถานะ">
                <HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                <ItemTemplate>
                    <asp:Label ID="lblc_active" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="สถานะ" SortExpression="status">
                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                <ItemTemplate>
                    <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="False"></asp:ImageButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" CommandName="Edit" />
                    <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="5%" Wrap="False" />
            </asp:TemplateField>
        </Columns>
        <PagerSettings Mode="NextPrevious" NextPageText="Next &amp;gt;&amp;gt;" PreviousPageText="&amp;lt;&amp;lt; Previous"
            Position="Top" NextPageImageUrl="~/images/next.gif" PreviousPageImageUrl="~/images/prev.gif" />
        <EmptyDataRowStyle HorizontalAlign="Center" />
        <PagerStyle BackColor="Gainsboro" ForeColor="#8C4510" HorizontalAlign="Center" Wrap="True" />
        <HeaderStyle CssClass="stGridHeader" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="#EAEAEA" />
    </asp:GridView>
    <input id="txthpage" type="hidden" name="txthpage" runat="server">
    <input id="txthTotalRecord" type="hidden" name="txthTotalRecord" runat="server">
</asp:Content>
