<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="produce_control.aspx.cs" Inherits="myWeb.App_Control.produce.produce_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr align="left">
            <td align="right" nowrap valign="middle" style="width: 15%">
                <asp:Label runat="server" ID="Label14">ปีงบประมาณ :</asp:Label>
            </td>
            <td align="left" nowrap valign="middle">&nbsp;<asp:DropDownList runat="server" CssClass="textbox" ID="cboYear"
                AutoPostBack="True" OnSelectedIndexChanged="cboYear_SelectedIndexChanged">
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
                <asp:Label runat="server" ID="Label13">แผนงบประมาณ  :</asp:Label>
            </td>
            <td align="left" colspan="4" nowrap valign="middle">
                <font face="Tahoma">&nbsp;<asp:DropDownList runat="server" CssClass="textbox" ID="cboBudget">
                </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cboBudget" ErrorMessage="กรุณาเลือกแผนวบประมาณ"
                        Display="None" ValidationGroup="A" ID="RequiredFieldValidator1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" />

                </font>
                <br />
            </td>
        </tr>
        <tr align="left">
            <td align="right" colspan="5" nowrap valign="middle">
                <asp:Panel ID="Panel1" runat="server" CssClass="rcorners2">
                    <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="lblFName" runat="server">รหัสผลผลิต :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:TextBox ID="txtproduce_code" runat="server" CssClass="textbox" MaxLength="5"
                                    ValidationGroup="A" Width="144px"></asp:TextBox>
                            </td>
                            <td align="center" nowrap rowspan="3" style="vertical-align: bottom; width: 1%">
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
                                <asp:Label ID="Label11" runat="server">ผลผลิต :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <font face="Tahoma">
                                    <asp:TextBox ID="txtproduce_name" runat="server" CausesValidation="True" CssClass="textbox"
                                        MaxLength="100" ValidationGroup="A" Width="344px"></asp:TextBox>
                                </font>
                            </td>
                        </tr>
                        <tr align="left">
                            <td align="right" nowrap valign="middle">
                                <asp:Label ID="Label12" runat="server">สถานะ :</asp:Label>
                            </td>
                            <td align="left" nowrap valign="middle">
                                <asp:CheckBox ID="chkStatus" runat="server" Text="ปกติ" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtproduce_name"
                                    Display="None" ErrorMessage="กรุณาป้อนข้อมูล" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </td>
        </tr>
    </table>
    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
        <tr align="left">
            <td>
                <div class="div-lov" style="height: 205px">
                    <asp:GridView runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                        BackColor="White" BorderWidth="1px" CssClass="stGrid" Font-Bold="False" Font-Size="10pt"
                        ID="GridView1" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
                        OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting" OnRowDeleting="GridView1_RowDeleting"
                        OnRowEditing="GridView1_RowEditing">
                        <AlternatingRowStyle BackColor="#EAEAEA"></AlternatingRowStyle>
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server"> </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="5%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รหัสผลผลิต " SortExpression="produce_code">
                                <ItemTemplate>
                                    <asp:Label ID="lblproduce_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.produce_code") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Wrap="True" Width="20%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ชื่อผลผลิต " SortExpression="produce_name">
                                <ItemTemplate>
                                    <asp:Label ID="lblproduce_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.produce_name")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Wrap="True" Width="40%"></ItemStyle>
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
                        <HeaderStyle HorizontalAlign="Center" CssClass="stGridHeader" Font-Bold="True"></HeaderStyle>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
