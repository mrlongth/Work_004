<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="activity_control.aspx.cs" Inherits="myWeb.App_Control.activity.activity_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlMain" runat="server">
        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
            <tr>
                <td align="left" nowrap style="text-align: right">
                    <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
                    <asp:Label runat="server" ID="lblLastUpdatedBy">Last Updated By :</asp:Label>
                </td>
                <td align="left" style="width: 1%">
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
                <td align="right" nowrap valign="middle" style="width: 15%; height: 25px;">
                    <asp:Label runat="server" ID="Label14">ปีงบประมาณ :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle" style="height: 25px">
                    <asp:DropDownList runat="server" CssClass="textbox"
                        ID="cboYear" OnSelectedIndexChanged="cboYear_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;
                &nbsp;
                &nbsp;
                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" CssClass="label_error" ID="Label71">*</asp:Label>
                    <asp:Label runat="server" ID="Label13">แผนงบประมาณ  :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox"
                        ID="cboBudget" AutoPostBack="True"
                        OnSelectedIndexChanged="cboBudget_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="cboBudget" ErrorMessage="กรุณาเลือกแผนงบประมาณ "
                        Display="None" ValidationGroup="A" ID="RequiredFieldValidator1"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="A" />
                    <br />
                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" CssClass="label_error"
                        ID="Label72">*</asp:Label>
                    <asp:Label runat="server" ID="Label15">ผลผลิต :</asp:Label>
                </td>
                <td align="left" nowrap valign="middle">
                    <asp:DropDownList runat="server" CssClass="textbox"
                        ID="cboProduce">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server"
                        ControlToValidate="cboProduce" ErrorMessage="กรุณาเลือกผลผลิต" Display="None"
                        SetFocusOnError="True" ValidationGroup="A" ID="RequiredFieldValidator2"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr align="left">
                <td align="right" colspan="2" nowrap valign="middle">

                    <asp:Panel ID="Panel1" runat="server" CssClass="rcorners2">
                        <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                            <tr align="left">
                                <td align="right" nowrap valign="middle">
                                    <asp:Label ID="lblFName" runat="server">รหัสกิจกรรม :</asp:Label>
                                </td>
                                <td align="left" nowrap valign="middle">&nbsp;<asp:TextBox ID="txtactivity_code" runat="server"
                                    CssClass="textbox" MaxLength="5" ValidationGroup="A" Width="144px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ControlToValidate="txtactivity_name" Display="None"
                                        ErrorMessage="กรุณาป้อนกิจกรรม" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </td>
                                <td align="center" nowrap rowspan="3"
                                    style="vertical-align: bottom; width: 1%;">
                                    <asp:ImageButton ID="imgSaveOnly" runat="server"
                                        ImageUrl="~/images/controls/save.jpg" ValidationGroup="A" />
                                    &nbsp;
                                        <asp:ImageButton ID="imgClear" runat="server" AlternateText="ยกเลิก"
                                            CausesValidation="False" ImageUrl="~/images/controls/clear.jpg"
                                            OnClick="imgClear_Click" />
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right" nowrap valign="middle">
                                    <asp:Label ID="Label73" runat="server" CssClass="label_error">*</asp:Label>
                                    <asp:Label ID="Label11" runat="server">กิจกรรม :</asp:Label>
                                </td>
                                <td align="left" nowrap valign="middle">
                                    <font face="Tahoma">&nbsp;<asp:TextBox ID="txtactivity_name" runat="server" CausesValidation="True"
                                        CssClass="textbox" MaxLength="100" ValidationGroup="A" Width="344px"></asp:TextBox>
                                    </font>
                                </td>
                            </tr>
                            <tr align="left">
                                <td align="right" nowrap valign="middle">
                                    <asp:Label ID="Label12" runat="server">สถานะ :</asp:Label>
                                </td>
                                <td align="left" nowrap valign="middle">
                                    <asp:CheckBox ID="chkStatus" runat="server" Text="ปกติ" />
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
                    <div class="div-lov" style="height: 200px">
                        <asp:GridView runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="2" BackColor="White" BorderWidth="1px"
                            CssClass="stGrid" Font-Bold="False" Font-Size="10pt" ID="GridView1"
                            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCreated="GridView1_RowCreated"
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
                                <asp:TemplateField HeaderText="รหัสกิจกรรม" SortExpression="activity_code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblactivity_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.activity_code") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" Width="20%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ชื่อกิจกรรม" SortExpression="activity_name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblactivity_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.activity_name")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Wrap="True" Width="60%"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="รหัสผลผลิต" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblproduce_code" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.produce_code")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
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
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="5%"></ItemStyle>
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
