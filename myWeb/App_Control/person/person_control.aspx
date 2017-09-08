<%@ Page Language="C#" MasterPageFile="~/Site_popup.Master" EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="person_control.aspx.cs" Inherits="myWeb.App_Control.person.person_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">
        function RunValidationsAndSetActiveTab() {
            if (typeof (Page_Validators) == "undefined") return;
            try {
                var noOfValidators = Page_Validators.length;
                for (var validatorIndex = 0; validatorIndex < noOfValidators; validatorIndex++) {
                    var validator = Page_Validators[validatorIndex];
                    ValidatorValidate(validator);
                    if (!validator.isvalid) {
                        var tabPanel = validator.parentElement.parentElement.parentElement.parentElement.parentElement.control;
                        var tabContainer = tabPanel.get_owner();
                        tabContainer.set_activeTabIndex(tabPanel.get_tabIndex());
                        break;
                    }
                }
            }
            catch (Error) {
                alert("Failed");
            }
        }

        function RetrieveMembertype(res) {
            var retVal = res.value;
            var cbomember_type = document.getElementById("ctl00_ContentPlaceHolder1_TabContainer1_TabPanel2_cboMember_type");
            if (retVal != null && retVal.Rows.length > 0) {
                var Len = retVal.Rows.length;
                // Reset 
                for (i = cbomember_type.options.length - 1; i >= 0; i--) {
                    cbomember_type.remove(i);
                }
                // Add  Data
                var optn = document.createElement("OPTION");
                optn.text = "N";
                optn.value = '';
                cbomember_type.options.add(optn);
                for (i = 0; i < Len; i++) {
                    var opt = document.createElement("OPTION");
                    opt.text = retVal.Rows[i].member_type_name;
                    opt.value = retVal.Rows[i].member_type_code;
                    opt.setAttribute("wv", retVal.Rows[i].member_type_code);
                    cbomember_type.add(opt);
                }
            }
            else {
                // Reset 
                for (i = cbomember_type.options.length - 1; i >= 0; i--) {
                    cbomember_type.remove(i);
                }
                var optn = document.createElement("OPTION");
                optn.text = "N";
                optn.value = '';
                cbomember_type.options.add(optn);
            }
        }

        function changeMembertype(e, gbk, gsj, sos) {
            myWeb.App_Control.person.person_control.GetDataMemberType(e.options[e.selectedIndex].value, gbk, gsj, sos, RetrieveMembertype);
        }
    </script>
    <asp:Panel ID="pnlMain" runat="server">
        <table border="0" cellpadding="1" cellspacing="2" style="width: 100%">
            <tr align="center">
                <td>
                    <ajaxtoolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Height="450px"
                        BorderWidth="0px" Style="text-align: left">
                        <ajaxtoolkit:TabPanel runat="server" HeaderText="�����Ż���ѵԺؤ�ҡ�" ID="TabPanel1">
                            <HeaderTemplate>
                                ����ѵԺؤ�ҡ�
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="left" nowrap style="text-align: right" valign="middle">&nbsp;&nbsp;
                                        </td>
                                        <td align="left" style="width: 0%">&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" nowrap style="text-align: right" valign="middle">
                                            <asp:Label ID="lblLastUpdatedBy" runat="server" CssClass="label_hbk">Last Updated By :</asp:Label>
                                        </td>
                                        <td align="left" width="15%">
                                            <asp:TextBox ID="txtUpdatedBy" runat="server" CssClass="textboxdis" ReadOnly="True"
                                                Width="148px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" nowrap style="text-align: right" valign="middle">
                                            <asp:Label ID="lblLastUpdatedDate" runat="server" CssClass="label_hbk">Last Updated Date :</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUpdatedDate" runat="server" CssClass="textboxdis" ReadOnly="True"
                                                Width="148px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
                                    <tr align="left">
                                        <td align="right" nowrap style="" valign="middle" width="10%">
                                            <asp:Label ID="Label21" runat="server" CssClass="label_hbk">���ʺؤ�ҡ� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle" width="40%">
                                            <asp:TextBox ID="txtperson_code" runat="server" CssClass="textboxdis" Width="120px"></asp:TextBox>
                                        </td>
                                        <td align="left" nowrap valign="middle" width="20%"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap style="" valign="middle">
                                            <asp:Label ID="Label71" runat="server" CssClass="label_error">*</asp:Label><asp:Label
                                                ID="Label16" runat="server" CssClass="label_hbk">�ӹ�˹�Ҫ��� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:DropDownList ID="cboTitle" runat="server" CssClass="textbox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="cboTitle"
                                                Display="None" ErrorMessage="��س����͡�ӹ�˹�Ҫ���" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtperson_thai_name"
                                                    Display="None" ErrorMessage="��سһ�͹����������" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="left" nowrap rowspan="9" style="text-align: center" valign="middle">
                                            <asp:Image ID="imgPerson" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="200px"
                                                ImageUrl="~/person_pic/image_n_a.jpg" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle" style="">
                                            <asp:Label ID="Label73" runat="server" CssClass="label_error">*</asp:Label><asp:Label
                                                ID="Label14" runat="server" CssClass="label_hbk">���������� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle" style="">
                                            <asp:TextBox ID="txtperson_thai_name" runat="server" CssClass="textbox" Width="400px"
                                                MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label15" runat="server" CssClass="label_hbk">���ʡ�������� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtperson_thai_surname" runat="server" CssClass="textbox" MaxLength="50"
                                                Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label17" runat="server" CssClass="label_hbk">���������ѧ��� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtperson_eng_name" runat="server" CssClass="textbox" MaxLength="50"
                                                Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label18" runat="server" CssClass="label_hbk">���ʡ�������ѧ��� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtperson_eng_surname" runat="server" CssClass="textbox" Width="400px"
                                                MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle" style="">
                                            <asp:Label ID="Label72" runat="server" CssClass="label_error">*</asp:Label><asp:Label
                                                ID="Label20" runat="server" CssClass="label_hbk">�Ţ���ѵû�ЪҪ� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle" style="">
                                            <asp:TextBox ID="txtperson_id" runat="server" CssClass="textbox" Width="200px" MaxLength="13"></asp:TextBox>

                                            <%-- <ajaxtoolkit:FilteredTextBoxExtender
                                            ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtperson_id" FilterType="Numbers"
                                            Enabled="True" />--%>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtperson_id"
                                                Display="None" ErrorMessage="��سһ�͹�Ţ���ѵû�ЪҪ�" ValidationGroup="A"
                                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label19" runat="server" CssClass="label_hbk">������� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtperson_nickname" runat="server" CssClass="textbox" MaxLength="50"
                                                Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label63" runat="server" CssClass="label_hbk">�ٻ�ؤ�ҡ� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap>
                                            <asp:TextBox ID="txtperson_pic" runat="server" CssClass="textbox" Width="400px"></asp:TextBox><asp:ImageButton
                                                ID="imgperson_pic" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/images/picture.png" /><asp:ImageButton
                                                    ID="imgClear_person_pic" runat="server" CausesValidation="False" ImageAlign="AbsBottom"
                                                    ImageUrl="../../images/controls/erase.gif" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label76" runat="server" CssClass="label_hbk">ʶҹ� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <font face="Tahoma">
                                                <asp:CheckBox ID="chkStatus" runat="server" Text="����" Checked="True" />
                                            </font>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" nowrap valign="middle">&nbsp;&nbsp;
                                        </td>
                                        <td align="left"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" nowrap valign="middle">&nbsp;&nbsp;
                                        </td>
                                        <td align="left"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle" style="height: 15px"></td>
                                        <td align="left" nowrap valign="middle" style="height: 15px"></td>
                                        <td style="height: 15px"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" nowrap valign="middle"></td>
                                        <td align="left"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" nowrap valign="middle"></td>
                                        <td align="left"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" colspan="2" nowrap valign="middle"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle" colspan="3"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" colspan="3" nowrap valign="middle"></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxtoolkit:TabPanel>
                        <ajaxtoolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="�����š�÷ӧҹ">
                            <HeaderTemplate>
                                ��÷ӧҹ
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%;">
                                    <tr align="left">
                                        <td nowrap valign="middle" align="right">
                                            <asp:Label ID="Label65" runat="server" CssClass="label_error">*</asp:Label>
                                            <asp:Label ID="Label49" runat="server" CssClass="label_hbk">���˹觻Ѩ�غѹ :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtposition_code" runat="server" CssClass="textbox" MaxLength="5"
                                                Width="80px"></asp:TextBox>
                                            &nbsp;<asp:ImageButton ID="imgList_position" runat="server" CausesValidation="False"
                                                ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                            <asp:ImageButton ID="imgClear_position" runat="server" CausesValidation="False" ImageAlign="AbsBottom"
                                                ImageUrl="../../images/controls/erase.gif" />
                                            &nbsp;<asp:TextBox ID="txtposition_name" runat="server" CssClass="textboxdis" MaxLength="100"
                                                Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtposition_code"
                                                Display="None" ErrorMessage="��سһ�͹���˹觻Ѩ�غѹ" SetFocusOnError="True"
                                                ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                        <td nowrap style="text-align: right" width="10%">
                                            <asp:Label ID="Label77" runat="server" CssClass="label_hbk">���������˹� :</asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txttype_position_code" runat="server" CssClass="textbox" MaxLength="5"
                                                Width="80px"></asp:TextBox>
                                            &nbsp;<asp:ImageButton ID="imgList_type" runat="server" CausesValidation="False"
                                                ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                            <asp:ImageButton ID="imgClear_type" runat="server" CausesValidation="False" ImageAlign="AbsBottom"
                                                ImageUrl="../../images/controls/erase.gif" />
                                            &nbsp;<asp:TextBox ID="txttype_position_name" runat="server" CssClass="textboxdis"
                                                MaxLength="100" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label3" runat="server" CssClass="label_hbk">�дѺ���˹� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtperson_level" runat="server" CssClass="textbox" MaxLength="5"
                                                Width="80px"></asp:TextBox>
                                            &nbsp;<asp:ImageButton ID="imgList_level" runat="server" CausesValidation="False"
                                                ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                            <asp:ImageButton ID="imgClear_level" runat="server" CausesValidation="False" ImageAlign="AbsBottom"
                                                ImageUrl="../../images/controls/erase.gif" />
                                            &nbsp;<asp:TextBox ID="txtlevel_position_name" runat="server" CssClass="textboxdis"
                                                MaxLength="100" Width="200px"></asp:TextBox>
                                        </td>
                                        <td nowrap style="text-align: right" width="10%">
                                            <asp:Label ID="Label6" runat="server" CssClass="label_hbk">�Ţ�����˹� :</asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="txtperson_postionno" runat="server" CssClass="textbox" Width="130px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle" style="">
                                            <asp:Label ID="Label69" runat="server" CssClass="label_error">*</asp:Label>
                                            <asp:Label ID="Label50" runat="server" CssClass="label_hbk">������ؤ�ҡ� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle" style="">
                                            <asp:DropDownList ID="cboPerson_group" runat="server" CssClass="textbox">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="cboPerson_group" Display="None" ErrorMessage="��س����͡������ؤ�ҡ�" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </td>
                                        <td nowrap style="text-align: right;">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label43" runat="server" CssClass="label_hbk">�ѹ����è� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap style="vertical-align: middle">
                                            <asp:TextBox ID="txtperson_start" runat="server" CssClass="textbox" ReadOnly="True"
                                                Width="130px"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="txtperson_start_CalendarExtender" runat="server"
                                                Enabled="True" PopupButtonID="imgperson_start" TargetControlID="txtperson_start">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:ImageButton ID="imgperson_start" runat="server" AlternateText="Click to show calendar"
                                                ImageAlign="AbsMiddle" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                        </td>
                                        <td nowrap style="text-align: right">
                                            <asp:Label ID="Label44" runat="server" CssClass="label_hbk">�ѹ������³ :</asp:Label>
                                        </td>
                                        <td align="left" style="vertical-align: middle">
                                            <asp:TextBox ID="txtperson_end" runat="server" CssClass="textbox" Width="130px" ReadOnly="True"></asp:TextBox>
                                            <ajaxtoolkit:CalendarExtender ID="txtperson_end_CalendarExtender" runat="server"
                                                Enabled="True" PopupButtonID="imgperson_end" TargetControlID="txtperson_end">
                                            </ajaxtoolkit:CalendarExtender>
                                            <asp:ImageButton ID="imgperson_end" runat="server" AlternateText="Click to show calendar"
                                                ImageAlign="AbsMiddle" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label46" runat="server" CssClass="label_hbk">���˹觺����� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle" style="text-align: left">
                                            <asp:TextBox ID="txtperson_manage_code" runat="server" CssClass="textbox" MaxLength="5"
                                                Width="80px"></asp:TextBox>&nbsp;<asp:ImageButton ID="imgList_person_manage" runat="server"
                                                    ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" CausesValidation="False"></asp:ImageButton>
                                            <asp:ImageButton ID="imgClear_person_manage" runat="server" CausesValidation="False"
                                                ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif"></asp:ImageButton>
                                            &nbsp;<asp:TextBox ID="txtperson_manage_name" runat="server" CssClass="textboxdis"
                                                MaxLength="100" Width="200px"></asp:TextBox>
                                        </td>
                                        <td nowrap align="right" valign="middle">
                                            <asp:Label ID="Label1" runat="server">������������ҳ :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">&nbsp;<asp:DropDownList ID="cboBudget_type" runat="server" AutoPostBack="True" CssClass="textbox"
                                            OnSelectedIndexChanged="cboBudget_type_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label70" runat="server" CssClass="label_error">*</asp:Label>
                                            <asp:Label ID="Label52" runat="server" CssClass="label_hbk">�ѧ������ҳ :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtbudget_plan_code" runat="server" CssClass="textbox" Width="80px"
                                                MaxLength="10"></asp:TextBox>
                                            &nbsp;<asp:ImageButton ID="imgList_budget_plan" runat="server" CausesValidation="False"
                                                ImageAlign="AbsBottom" ImageUrl="../../images/controls/view2.gif" />
                                            <asp:ImageButton ID="imgClear_budget_plan" runat="server" CausesValidation="False"
                                                ImageAlign="AbsBottom" ImageUrl="../../images/controls/erase.gif" />
                                        </td>
                                        <td nowrap style="text-align: right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label60" runat="server" CssClass="label_hbk">�ѧ�Ѵ :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtdirector_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                        <td nowrap style="text-align: right">
                                            <asp:Label ID="Label61" runat="server" CssClass="label_hbk">˹��§ҹ :</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtunit_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label54" runat="server" CssClass="label_hbk">Ἱ������ҳ  :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtbudget_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                        <td nowrap style="text-align: right">
                                            <asp:Label ID="Label55" runat="server" CssClass="label_hbk">�ż�Ե :</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtproduce_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label53" runat="server" CssClass="label_hbk">�Ԩ���� :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtactivity_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                        <td nowrap style="text-align: right;">
                                            <asp:Label ID="Label56" runat="server" CssClass="label_hbk">Ἱ�ҹ :</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtplan_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle" style="height: 22px">
                                            <asp:Label ID="Label57" runat="server" CssClass="label_hbk">�ҹ :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle" style="height: 22px">
                                            <asp:TextBox ID="txtwork_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                        <td nowrap style="text-align: right; height: 22px;">
                                            <asp:Label ID="Label58" runat="server" CssClass="label_hbk">�ͧ�ع :</asp:Label>
                                            </td>
                                        <td align="left" style="height: 22px">
                                            <asp:TextBox ID="txtfund_name" runat="server" CssClass="textboxdis" Width="300px"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label64" runat="server" CssClass="label_hbk">�է�����ҳ :</asp:Label>
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:TextBox ID="txtbudget_plan_year" runat="server" CssClass="textboxdis" Width="130px"></asp:TextBox>
                                        </td>
                                        <td nowrap style="text-align: right">
                                            <asp:Label ID="Label78" runat="server" CssClass="label_hbk">�Ң� :</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboMajor" runat="server" CssClass="textbox">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">
                                            <asp:Label ID="Label62" runat="server" CssClass="label_hbk">ʶҹС�÷ӧҹ :</asp:Label>
                                            &nbsp;
                                        </td>
                                        <td align="left" nowrap valign="middle">
                                            <asp:DropDownList ID="cboPerson_work_status" runat="server" CssClass="textbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td nowrap style="text-align: right">&nbsp;&nbsp;
                                        </td>
                                        <td align="left">&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle">&nbsp;&nbsp;
                                        </td>
                                        <td align="left" nowrap valign="middle">&nbsp;&nbsp;
                                        </td>
                                        <td nowrap style="text-align: right">&nbsp;&nbsp;
                                        </td>
                                        <td align="left">&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" nowrap valign="middle"></td>
                                        <td nowrap style=""></td>
                                        <td align="left"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" nowrap valign="middle"></td>
                                        <td align="left" colspan="3" nowrap valign="middle"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" colspan="4" nowrap valign="middle"></td>
                                    </tr>
                                    <tr align="left">
                                        <td align="right" colspan="4" nowrap valign="middle"></td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxtoolkit:TabPanel>
                    </ajaxtoolkit:TabContainer>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%; vertical-align: bottom;">
            <tr align="left">
                <td align="right" nowrap valign="middle" width="75%">&nbsp;
                </td>
                <td nowrap rowspan="3" style="text-align: center; vertical-align: bottom; width: 10%;">
                    <asp:ImageButton runat="server" ValidationGroup="A" AlternateText="�ѹ�֡" ImageUrl="~/images/controls/save.jpg"
                        ID="imgSaveOnly"></asp:ImageButton>
                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle" width="75%">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="A" />
                    <%-- <ajaxtoolkit:FilteredTextBoxExtender
                                            ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtperson_id" FilterType="Numbers"
                                            Enabled="True" />--%>&nbsp;
                </td>
            </tr>
            <tr align="left">
                <td align="right" nowrap valign="middle">
                    <asp:Label runat="server" CssClass="label_error" ID="lblError"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
