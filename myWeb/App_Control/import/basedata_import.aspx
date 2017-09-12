<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" AutoEventWireup="true" CodeBehind="basedata_import.aspx.cs"
    Inherits="myWeb.App_Control.basedata_import.basedata_import_list" Title="แสดงข้อมูลกองทุน " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="1" cellspacing="1" style="width: 100%">
        <tr>
            <td style="text-align: right;" width="20%">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage4">ปีงบประมาณ :</asp:Label>
            </td>
            <td>
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboYear">
                </asp:DropDownList>
                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
            </td>
            <td style="text-align: right" valign="bottom">
                <asp:ImageButton runat="server" AlternateText="ค้นหาข้อมูล" ImageUrl="~/images/button/Search.png"
                    ID="imgFind" OnClick="imgFind_Click"></asp:ImageButton>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">

    <ajaxtoolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="450px" Width="100%"
        BorderWidth="0px" Style="text-align: left">
        <ajaxtoolkit:TabPanel runat="server" HeaderText="ข้อมูลสังกัด" ID="TabPanel1">
            <HeaderTemplate>
                ข้อมูลสังกัด
            </HeaderTemplate>
            <ContentTemplate>
                <asp:GridView ID="gridDirector" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="White" BorderWidth="1px" CellPadding="2" CssClass="stGrid" Font-Bold="False"
                    Font-Size="10pt" OnRowCreated="gridDirector_RowCreated" OnRowDataBound="gridDirector_RowDataBound"
                    OnSorting="gridDirector_Sorting" Style="width: 100%; height:auto; overflow:scroll;" >
                    <AlternatingRowStyle BackColor="#EAEAEA"></AlternatingRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <asp:Label ID="lblNo" runat="server" CssClass="label_hbk"> </asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="2%" Wrap="False" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="รหัสสังกัด " SortExpression="director_code">
                            <ItemStyle HorizontalAlign="Center" Width="20%" Wrap="False" />
                            <ItemTemplate>
                                <asp:Label ID="lbldirector_code" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.director_code") %>'>
                                </asp:Label>
                            </ItemTemplate>
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สังกัด " SortExpression="director_name">
                            <ItemTemplate>
                                <asp:Label ID="lbldirector_name" runat="server" Text='<% # DataBinder.Eval(Container, "DataItem.director_name") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField Visible="False" HeaderText="สถานะ">
                            <HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblc_active" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.c_active") %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="สถานะ" SortExpression="c_active">
                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgStatus" runat="server" CausesValidation="False"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="stGridHeader" HorizontalAlign="Center" />
                    <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/images/next.gif" NextPageText="Next &amp;gt;&amp;gt;"
                        Position="Top" PreviousPageImageUrl="~/images/prev.gif" PreviousPageText="&amp;lt;&amp;lt; Previous"></PagerSettings>
                    <PagerStyle BackColor="Gainsboro" ForeColor="#8C4510" HorizontalAlign="Center" Wrap="True" />
                </asp:GridView>
                </div>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="ข้อมูลหน่วยงาน">
            <HeaderTemplate>
                ข้อมูลหน่วยงาน
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="ข้อมูลแผนงบประมาณ">
            <HeaderTemplate>
                ข้อมูลแผนงบประมาณ
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="ข้อมูลผลผลิต">
            <HeaderTemplate>
                ข้อมูลผลผลิต
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="ข้อมูลกิจกรรม">
            <HeaderTemplate>
                ข้อมูลกิจกรรม
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="ข้อมูลแผนงาน">
            <HeaderTemplate>
                ข้อมูลแผนงาน
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="ข้อมูลงาน">
            <HeaderTemplate>
                ข้อมูลงาน
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel8" runat="server" HeaderText="ข้อมูลกองทุน">
            <HeaderTemplate>
                ข้อมูลกองทุน
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel9" runat="server" HeaderText="ข้อมูลประเภทงบรายจ่าย">
            <HeaderTemplate>
                ข้อมูลประเภทงบรายจ่าย
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>
        <ajaxtoolkit:TabPanel ID="TabPanel10" runat="server" HeaderText="ข้อมูลหมวดค่าใช้จ่าย">
            <HeaderTemplate>
                ข้อมูลหมวดค่าใช้จ่าย
            </HeaderTemplate>
            <ContentTemplate>
            </ContentTemplate>
        </ajaxtoolkit:TabPanel>



    </ajaxtoolkit:TabContainer>

</asp:Content>
