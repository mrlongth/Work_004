//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace myModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Budget_open_detail
    {
        public long budget_open_detail_id { get; set; }
        public string budget_open_doc { get; set; }
        public Nullable<long> budget_money_major_id { get; set; }
        public string budget_open_detail_remark { get; set; }
        public Nullable<decimal> budget_open_detail_amount { get; set; }
        public Nullable<int> material_id { get; set; }
        public string material_name { get; set; }
        public string material_detail { get; set; }
        public string c_created_by { get; set; }
        public Nullable<System.DateTime> d_created_date { get; set; }
        public string c_updated_by { get; set; }
        public Nullable<System.DateTime> d_updated_date { get; set; }
    
        public virtual Budget_money_major Budget_money_major { get; set; }
        public virtual Budget_open_head Budget_open_head { get; set; }
    }
}
