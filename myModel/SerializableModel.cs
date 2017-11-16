using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myModel
{
    [Serializable]
    public partial class view_Budget_money_major { }

    [Serializable]
    public partial class view_Budget_receive_detail { }

    [Serializable]
    public partial class view_Budget_transfer_head { }

    [Serializable]
    public partial class view_Budget_open_detail
    {
        public string row_status { get; set; }
    }


}
