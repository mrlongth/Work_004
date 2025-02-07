﻿using System.Linq;
using System.Web.UI;
using myDLL.Common;
using System.Web.UI.WebControls;

namespace myDLL
{
    public class Utils
    {
        public static void SetControls(Control control, Enumeration.Mode eMode, bool isClear = false)
        {
            switch (eMode)
            {
                case Enumeration.Mode.VIEW:
                    foreach (Control ctrl in control.Controls)
                    {
                        if ((ctrl is TextBox))
                        {
                            // TextBox
                            ((TextBox)(ctrl)).ReadOnly = true;
                            ((TextBox)(ctrl)).CssClass = "textboxdis";
                            ((TextBox)(ctrl)).TabIndex = -1;
                            if (isClear)
                            {
                                ((TextBox)(ctrl)).Text = string.Empty;
                            }
                        }
                        else if ((ctrl is DropDownList))
                        {
                            // DropDownList
                            ((DropDownList)(ctrl)).Enabled = false;
                            ((DropDownList)(ctrl)).CssClass = "textboxdis";
                            ((DropDownList)(ctrl)).TabIndex = -1;
                            if (isClear)
                            {
                                ((DropDownList)(ctrl)).SelectedIndex = 0;
                            }
                        }
                        else if ((ctrl is Button))
                        {
                            ((Button)(ctrl)).Visible = false;
                        }
                        else if ((ctrl is ImageButton))
                        {
                            if (((ImageButton)(ctrl)).ID != "imgStatus" || ((ImageButton)(ctrl)).ID != "imgView")
                            {
                                ((ImageButton)(ctrl)).Visible = false;
                            }
                        }
                        else if ((ctrl is CheckBox))
                        {
                            ((CheckBox)(ctrl)).Enabled = false;
                            ((CheckBox)(ctrl)).TabIndex = -1;
                            if (isClear)
                            {
                                ((CheckBox)(ctrl)).Checked = false;
                            }
                        }
                        else if ((ctrl.Controls.Count > 0))
                        {
                            SetControls(ctrl, eMode);
                        }
                    }
                    break;
            }
        }


       


    }
}
