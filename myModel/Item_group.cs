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
    
    public partial class Item_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item_group()
        {
            this.Item_group_detail = new HashSet<Item_group_detail>();
        }
    
        public string item_group_code { get; set; }
        public string item_group_year { get; set; }
        public string item_group_name { get; set; }
        public string item_group_type { get; set; }
        public string lot_code { get; set; }
        public string c_active { get; set; }
        public string c_created_by { get; set; }
        public Nullable<System.DateTime> d_created_date { get; set; }
        public string c_updated_by { get; set; }
        public Nullable<System.DateTime> d_updated_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item_group_detail> Item_group_detail { get; set; }
        public virtual Lot Lot { get; set; }
    }
}
