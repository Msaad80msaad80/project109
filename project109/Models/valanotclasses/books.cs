namespace project109.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaData))]
    public partial class books
    {
        public class MetaData
        {
            public int Id { get; set; }
            [DisplayName("Book Title")]
            [Required(ErrorMessage = "Book Title Required")]
            public string book_Title { get; set; }
            [DisplayName("Price")]
            [RegularExpression(@"^\d+(\.\d{1,2})?$")]
            [Range(0, 9999999999999999.99)]
            [Required(ErrorMessage = "Enter Valid Price")]
            public Nullable<decimal> price { get; set; }
            [DisplayName("Author")]
            [Range(1, Int32.MaxValue)]
            [Required(ErrorMessage = "Select Author")]
            public Nullable<int> author_id { get; set; }
            [DisplayName("Vendor")]
            public Nullable<int> sold_by { get; set; }
            [DisplayName("Publisher")]
            [Range(1, Int32.MaxValue)]
            [Required(ErrorMessage = "Select Publisher")]
            public Nullable<int> publisher_id { get; set; }
            [DisplayName("Publishing Year")]
            [Range(1, Int32.MaxValue)]
            [Required(ErrorMessage = "Enter Valid  Publishing Year")]
            public Nullable<int> publishing_year { get; set; }
            [DisplayName("Units Count")]
            [Range(1, Int32.MaxValue)]
            [Required(ErrorMessage = "Enter Valid  Count")]
            public string stock { get; set; }
            [DisplayName("Book Cover")]
            public string book_cover { get; set; }
            [DisplayName("Book Softcopy")]
            public string book_softcopy { get; set; }
            [DisplayName("Book Date Insert")]
            public Nullable<System.DateTime> date_insert { get; set; }
            [DisplayName("Book Last Update")]
            public Nullable<System.DateTime> last_update { get; set; }
            [DisplayName("Active")]
            public Nullable<bool> active { get; set; }
            [DisplayName("Book Language")]
            [Required(ErrorMessage = "Enter Language")]
            public string book_language { get; set; }
            [DisplayName("Category")]
            [Range(1, Int32.MaxValue)]
            [Required(ErrorMessage = "Select Category")]
            public Nullable<int> book_cat { get; set; }
        }
    }
}
