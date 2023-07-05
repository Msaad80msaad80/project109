namespace project109.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaData))]
    public partial class view_orders
    {
        public class MetaData
        {
            [DisplayName("Request Date")]
            public Nullable<System.DateTime> order_date { get; set; }
            [DisplayName("buyer_id")]
            public Nullable<int> buyer_id { get; set; }
            [DisplayName("vendor_id")]
            public Nullable<int> vendor_id { get; set; }
            [DisplayName("book_id")]
            public Nullable<int> book_id { get; set; }
            [DisplayName("Units Count")]
            public Nullable<int> qty { get; set; }
            [DisplayName("Is Done")]
            public Nullable<bool> done_sel { get; set; }
            [DisplayName("Deal Date")]
            public Nullable<System.DateTime> deal_date { get; set; }
            [DisplayName("Is Rejected")]
            public Nullable<bool> canceled { get; set; }
            [DisplayName("Buyer")]
            public string buyername { get; set; }
            [DisplayName("Book")]
            public string book_Title { get; set; }
            [DisplayName("Price")]
            public Nullable<decimal> price { get; set; }
            [DisplayName("Vendor")]
            public string vendorname { get; set; }
        }
    }
}