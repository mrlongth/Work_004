<%@ Page Language="C#" MasterPageFile="~/Site_list.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="main_transfer_report.aspx.cs" Inherits="myWeb.App_Control.report.main_transfer_report"
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
            <asp:Label runat="server" CssClass="label_h" ID="Label2">ประเภทงบประมาณ :
            </asp:Label>
            </td>
            <td colspan="2">
            <asp:DropDownList runat="server" CssClass="textbox" ID="cboBudgetType" AutoPostBack="True">
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage19">เลขที่เอกสาร : </asp:Label>
            </td>
            <td style="width: 1%; height: 23px;">

                <asp:TextBox runat="server" CssClass="textbox" Width="100px" ID="txtbudget_transfer_doc"></asp:TextBox>

            </td>
            <td style="text-align: right; height: 23px;">
                &nbsp;</td>
            <td colspan="2" style="height: 23px">

                &nbsp;</td>
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
                <asp:DropDownList runat="server" CssClass="textbox" ID="cboUnit_from">
                </asp:DropDownList>
            </td>
            <td style="text-align: right; height: 23px;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage29">หน่วยงานปลายทาง :
                </asp:Label>
            </td>
            <td colspan="2" style="height: 23px">

                <asp:DropDownList runat="server" CssClass="textbox" ID="cboUnit_to">
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
                <asp:DropDownList ID="cboActivity_from" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage32">กิจกรรมปลายทาง :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboActivity_to" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage23">หลักสูตรต้นทาง :</asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboMajor_from" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
            <td style="text-align: right">
                <asp:Label runat="server" CssClass="label_h" ID="lblPage33">หลักสูตรปลายทาง :</asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cboMajor_to" runat="server" CssClass="textbox">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;"><asp:Label runat="server" CssClass="label_h" ID="Label1">รูปแบบรายงาน :</asp:Label></td>
            <td colspan="3"> <asp:CheckBox ID="chkPdf" runat="server" Checked="true" Text="Pdf" />
            <asp:CheckBox ID="chkExcel" runat="server" Checked="false" Text="Excel" /></td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td style="text-align: right;">&nbsp;</td>
            <td colspan="3">
            <asp:HyperLink ID="lnkPdfFile" runat="server" CssClass="pdf" Target="_blank">
                <img id="imgPdf" runat="server" alt="ดาวน์โหลดไฟล์" src="~/images/icon_pdfdisable.gif" border="0" />
            </asp:HyperLink>
            <asp:HyperLink ID="lnkExcelFile" runat="server" CssClass="pdf" Target="_blank">
                <img id="imgExcel" runat="server" alt="ดาวน์โหลดไฟล์" src="~/images/icon_exceldisable.gif" border="0" />
            </asp:HyperLink>
            <asp:ImageButton runat="server" AlternateText="พิมพ์ข้อมูล" ImageUrl="~/images/button/print.png"
                ID="imgPrint" OnClick="imgPrint_Click"></asp:ImageButton>
            </td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td colspan="5">

                <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>

            </td>
        </tr>

    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <input id="txthpage" type="hidden" name="txthpage" runat="server" />
    <input id="txthTotalRecord" type="hidden" name="txthTotalRecord" runat="server" />
</asp:Content>
