<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="item_group_detail_control.aspx.cs" Inherits="myWeb.App_Control.item_group.item_group_detail_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register Assembly="Aware.WebControls" Namespace="Aware.WebControls" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlMain" runat="server">
        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
            <tr>
                <td align="left" nowrap style="width: 90%;">&nbsp;
                </td>
                <td align="left" style="width: 0%">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" nowrap style="text-align: right">
                    <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
                    <asp:Label runat="server" ID="lblLastUpdatedBy">Last Updated By :</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="144px" ID="txtUpdatedBy"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" nowrap style="text-align: right">
                    <asp:Label runat="server" CssClass="text" ID="lblLastUpdatedDate">Last Updated Date :</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox runat="server" ReadOnly="True" CssClass="textboxdis" Width="144px" ID="txtUpdatedDate"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="2" cellspacing="0" style="width: 100%">
            <tr align="left">
                <td align="right" nowrap valign="middle" style="width: 15%">
                    <asp:Label runat="server" ID="Label14">ปีงบประมาณ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox" ID="cboYear">
                    </asp:DropDownList>
                </td>
                <td align="center" nowrap style="width: 60px">&nbsp;
                </td>
                <td align="center" nowrap style="width: 80px">&nbsp;
                </td>
                <td align="center">&nbsp;
                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" CssClass="label_error" ID="Label71">*</asp:Label>
                    <asp:Label runat="server" ID="Label13">หมวดค่าใช้จ่าย :</asp:Label>
                </td>
                <td align="left" colspan="4" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox" ID="cboItemGroup" AutoPostBack="True" OnSelectedIndexChanged="cboItemGroup_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cboItemGroup" ErrorMessage="กรุณาเลือกหมวดค่าใช้จ่าย"
                        Display="None" ValidationGroup="A" ID="RequiredFieldValidator1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                </td>
            </tr>
            <tr align="left">
                <td align="right" colspan="5" nowrap valign="middle">
                    <asp:Panel ID="Panel1" runat="server" CssClass="rcorners2">
                        <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr align="left">
                                <td align="right" nowrap valign="middle">
                                    <asp:HiddenField ID="hdditem_group_detail_id" runat="server" />
                                    <asp:Label ID="lblFName" runat="server">รหัส :</asp:Label>
                                </td>
                                <td align="left" nowrap valign="middle">&nbsp;<asp:TextBox ID="txtitem_group_detail_code" runat="server" CssClass="textboxdis" MaxLength="5"
                                    ValidationGroup="A" Width="144px" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td align="center" nowrap rowspan="2" style="width: 1%">
                                    <asp:ImageButton ID="imgSaveOnly" runat="server" ImageUrl="~/images/controls/save.jpg"
                                        ValidationGroup="A" />
                                    &nbsp;
                                        <asp:ImageButton ID="imgClear" runat="server" AlternateText="ยกเลิก" CausesValidation="False"
                                            ImageUrl="~/images/controls/clear.jpg" OnClick="imgClear_Click" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right" nowrap valign="middle">
                                    <asp:Label ID="Label72" runat="server" CssClass="label_error">*</asp:Label>
                                    <asp:Label ID="Label11" runat="server">รายละเอียด :</asp:Label>
                                </td>
                                <td align="left" nowrap valign="middle">
                                    <font face="Tahoma">&nbsp;<asp:TextBox ID="txtitem_group_detail_name" runat="server" CausesValidation="True"
                                        CssClass="textbox" MaxLength="100" ValidationGroup="A" Width="344px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtitem_group_detail_name" Display="None" ErrorMessage="กรุณาป้อนรายละเอียดหมวดค่าใช้จ่าย" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </font>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right" nowrap valign="middle">
                                    <asp:Label ID="Label12" runat="server">สถานะ :</asp:Label>
                                </td>
                                <td align="left" nowrap valign="middle">
                                    <asp:CheckBox ID="chkStatus" runat="server" Text="ปกติ" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle" colspan="5">
                    <div class="div-lov" style="height: 210px">
                        <asp:GridView runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                            EmptyDataText="ยังไม่มีข้อมูล" ShowFooter="True" BackColor="White" BorderWidth="1px"
                            CssClass="stGrid" Font-Bold="False" Font-Size="10pt" ID="GridView1" OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting"
                            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                            <AlternatingRowStyle BackColor="#EAEAEA"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="5%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสรายละเอียด" SortExpression="item_group_detail_code">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdditem_group_detail_id" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.item_group_detail_id") %>' />
                                        <asp:Label ID="lblitem_group_detail_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.item_group_detail_code") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" Width="20%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รายละเอียดหมวดค่าใช้จ่าย " SortExpression="item_group_detail_name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblitem_group_detail_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.item_group_detail_name")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" Width="60%"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="สถานะ" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblc_active" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.c_active") %>'> </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="สถานะ" SortExpression="c_active">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="False" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEdit" runat="server" CausesValidation="False" CommandName="Edit" />
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Delete" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="100px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataRowStyle HorizontalAlign="Center"></EmptyDataRowStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="stGridHeader" Font-Bold="True"></HeaderStyle>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
