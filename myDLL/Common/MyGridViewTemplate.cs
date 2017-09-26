using Aware.WebControls;
using myModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace myDLL.Common
{
    public class MyGridViewTemplate : ITemplate
    {
        private DataControlRowType templateType;
        private string columnName;
        public MyGridViewTemplate(DataControlRowType type, string colname)
        {
            templateType = type;
            columnName = colname;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            // Create the content for the different row types.
            switch (templateType)
            {
                case DataControlRowType.Header:
                    // Create the controls to put in the header
                    // section and set their properties.
                    Literal lc = new Literal();
                    lc.Text = "<b>" + columnName + "</b>";

                    // Add the controls to the Controls collection
                    // of the container.
                    container.Controls.Add(lc);
                    break;
                case DataControlRowType.DataRow:
                    // Create the controls to put in a data row
                    // section and set their properties.
                    AwNumeric textbox = new AwNumeric
                    {
                        Width = System.Web.UI.WebControls.Unit.Percentage(90),
                        ID = columnName,
                        Visible = false
                    };
                    container.Controls.Add(textbox);
                    HiddenField hidden = new HiddenField
                    {
                        ID = columnName.Replace("txt","hdd")
                    };
                    container.Controls.Add(hidden);
                    break;

                // Insert cases to create the content for the other 
                // row types, if desired.

                default:
                    // Insert code to handle unexpected values.
                    break;
            }
        }

    }
}
