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
    
    public partial class Budget_open_head
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Budget_open_head()
        {
            this.Budget_open_detail = new HashSet<Budget_open_detail>();
        }
    
        public string budget_open_doc { get; set; }
        public string budget_open_year { get; set; }
        public Nullable<System.DateTime> budget_open_date { get; set; }
        public Nullable<int> open_code { get; set; }
        public string open_title { get; set; }
        public string open_command_desc { get; set; }
        public string open_desc { get; set; }
        public string budget_type { get; set; }
        public string budget_plan_code { get; set; }
        public string degree_code { get; set; }
        public string major_code { get; set; }
        public string open_remark { get; set; }
        public Nullable<decimal> open_amount { get; set; }
        public string person_open { get; set; }
        public string approve_head_status { get; set; }
        public string c_created_by { get; set; }
        public Nullable<System.DateTime> d_created_date { get; set; }
        public string c_updated_by { get; set; }
        public Nullable<System.DateTime> d_updated_date { get; set; }
        public string ef_open_doc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budget_open_detail> Budget_open_detail { get; set; }
        public virtual Budget_plan Budget_plan { get; set; }
        public virtual Degree Degree { get; set; }
        public virtual Major Major { get; set; }
    }
}
