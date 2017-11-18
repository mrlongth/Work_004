using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myModel
{
    public  class  Report_param<T>
    {
        public T Report_condition { get; set; }
        public string Report_criteria { get; set; }
        public string Report_criteria_desc { get; set; }
        public string Report_user_print { get; set; }
        public bool Report_is_pdf { get; set; }
        public bool Report_is_excel { get; set; }

    }


}
