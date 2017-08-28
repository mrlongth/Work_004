<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="user_control.aspx.cs" Inherits="myWeb.App_Control.user.user_menu_control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr align="left">
            <td align="right" nowrap valign="middle" style="width: 24%">
                &nbsp;</td>
            <td align="left" nowrap valign="middle">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle" style="width: 24%">
                <asp:HiddenField ID="hddperson_code" runat="server" />
                <asp:HiddenField ID="hdduser_group_list" runat="server" />
                <asp:Label ID="Label3" runat="server" Font-Bold="True">���� - ʡ�� : </asp:Label>
            </td>
            <td align="left" nowrap valign="middle">
                <asp:Label ID="lblperson_name" runat="server" Font-Bold="True">XXXXXXXXXX</asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td align="center" nowrap valign="middle" colspan="2">
                <asp:GridView runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                    BackColor="White" BorderWidth="1px" CssClass="stGrid" Font-Bold="False" Font-Size="10pt"
                    Width="90%" ID="GridView1" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
                    <AlternatingRowStyle BackColor="#EAEAEA"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="���͡">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="2%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����������ҹ" SortExpression="g_name">
                            <ItemTemplate>
                                <asp:HiddenField ID="hddg_code" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.user_group_code") %>' />
                                <asp:Label ID="lblg_name" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.user_group_name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="80%" Wrap="True" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" CssClass="stGridHeader" Font-Bold="True"></HeaderStyle>
                </asp:GridView>
            </td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle" style="width: 24%">
                &nbsp;
            </td>
            <td align="left" nowrap valign="middle">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle" style="width: 24%">
                &nbsp;</td>
            <td colspan="2" style="white-space: nowrap;">
                                &nbsp;</td>
        </tr>
        <tr align="left">
            <td align="right" nowrap valign="middle" style="width: 24%">
                &nbsp;
            </td>
            <td align="left" nowrap valign="middle">
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
        </tr>
    </table>
    <div style="float: right; padding-right: 20px;">
        <asp:ImageButton runat="server" ValidationGroup="A" ImageUrl="~/images/button/save_add.png"
            ID="imgSaveOnly" OnClick="imgSaveOnly_Click"></asp:ImageButton>
    </div>
    <br />
    <br />
    <br />

    <%--<script>
        $(function() {
            $('input[type="checkbox"]').bind('click', function() {
                $('input[type="checkbox"]').not(this).prop("checked", false);
            });
        });
        
    </script>--%>

</asp:Content>
