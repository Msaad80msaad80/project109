namespace project109.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaData))]
    public partial class orders
    {
        public class MetaData
        {
            [DisplayName("Order Date")]
            public Nullable<System.DateTime> order_date { get; set; }
            [DisplayName("Buyer")]
            public Nullable<int> buyer_id { get; set; }
            [DisplayName("Vendor")]
            public Nullable<int> vendor_id { get; set; }
            [DisplayName("Book")]
            public Nullable<int> book_id { get; set; }
            [DisplayName("Units Count")]
            [Range(1, Int32.MaxValue)]
            [Required(ErrorMessage = "Enter Valid  Count")]
            public Nullable<int> qty { get; set; }
            public Nullable<bool> done_sel { get; set; }
            public Nullable<System.DateTime> deal_date { get; set; }
            public Nullable<bool> canceled { get; set; }

        }
    }
}
