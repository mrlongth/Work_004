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
    
    public partial class Person_his
    {
        public string person_code { get; set; }
        public string title_code { get; set; }
        public string person_thai_name { get; set; }
        public string person_thai_surname { get; set; }
        public string person_eng_name { get; set; }
        public string person_eng_surname { get; set; }
        public string person_nickname { get; set; }
        public string person_id { get; set; }
        public string person_pic { get; set; }
        public string c_active { get; set; }
        public string c_created_by { get; set; }
        public Nullable<System.DateTime> d_created_date { get; set; }
        public string c_updated_by { get; set; }
        public Nullable<System.DateTime> d_updated_date { get; set; }
        public string person_password { get; set; }
        public string person_email { get; set; }
    
        public virtual Title Title { get; set; }
    }
}
