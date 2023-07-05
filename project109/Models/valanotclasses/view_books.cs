namespace project109.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaData))]
    public partial class view_books
    {
        public class MetaData
        {
            public int Id { get; set; }
            [DisplayName("Book Title")]
            public string book_Title { get; set; }
            [DisplayName("Price")]
            public Nullable<decimal> price { get; set; }
            [DisplayName("Author")]
            public Nullable<int> author_id { get; set; }
            [DisplayName("Owner0")]
            public Nullable<int> sold_by { get; set; }
            [DisplayName("Publisher0")]
            public Nullable<int> publisher_id { get; set; }
            [DisplayName("Publishing Year")]
            public Nullable<int> publishing_year { get; set; }
            [DisplayName("Stock")]
            public string stock { get; set; }
            [DisplayName("Book Cover")]
            public string book_cover { get; set; }
            [DisplayName("Book Softcopy")]
            public string book_softcopy { get; set; }
            [DisplayName("Added At")]
            public Nullable<System.DateTime> date_insert { get; set; }
            [DisplayName("Last Update")]
            public Nullable<System.DateTime> last_update { get; set; }
            [DisplayName("Active")]
            public Nullable<bool> active { get; set; }
            [DisplayName("Language")]
            public string book_language { get; set; }
            [DisplayName("Author")]
            public string author_name { get; set; }
            [DisplayName("Owner")]
            public string RealName { get; set; }
            [DisplayName("Publisher")]
            public string publisher_name { get; set; }
            [DisplayName("Category")]
            public Nullable<int> book_cat { get; set; }
            [DisplayName("Category")]
            public string cat_name { get; set; }
        }
    }
}