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
    
    public partial class Major
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Major()
        {
            this.Budget_money_major = new HashSet<Budget_money_major>();
            this.Person_work = new HashSet<Person_work>();
            this.Budget_open_head = new HashSet<Budget_open_head>();
        }
    
        public string major_code { get; set; }
        public string major_year { get; set; }
        public string major_name { get; set; }
        public string c_active { get; set; }
        public string c_created_by { get; set; }
        public Nullable<System.DateTime> d_created_date { get; set; }
        public string c_updated_by { get; set; }
        public Nullable<System.DateTime> d_updated_date { get; set; }
        public string major_abbrev { get; set; }
        public Nullable<int> major_order { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budget_money_major> Budget_money_major { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person_work> Person_work { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Budget_open_head> Budget_open_head { get; set; }
    }
}
