//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project109.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class orders
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<int> buyer_id { get; set; }
        public Nullable<int> vendor_id { get; set; }
        public Nullable<int> book_id { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<bool> done_sel { get; set; }
        public Nullable<System.DateTime> deal_date { get; set; }
        public Nullable<bool> canceled { get; set; }
    }
}
