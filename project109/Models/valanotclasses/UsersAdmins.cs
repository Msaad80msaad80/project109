namespace project109.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MetaData))]
    public partial class UsersAdmins
    {
        public class MetaData
        {


            [DisplayName("Full Name")]
            [Required(ErrorMessage = "Enter Your Real Name")]
            public string RealName { get; set; }
            [DisplayName("Title")]
            public string Title { get; set; }
            [DisplayName("Email")]
            [Required(ErrorMessage = "Enter Valid Email")]
            [EmailAddress]
            public string Email { get; set; }
            [DisplayName("Username")]
            [Required(ErrorMessage = "Enter Username")]
            public string Username { get; set; }
            [DisplayName("Password")]
            [Required(ErrorMessage = "Enter Password")]
            public string Password { get; set; }
            public Nullable<bool> IsAdmin { get; set; }
            public Nullable<bool> Active { get; set; }
            [DisplayName("Phone")]
            [Required(ErrorMessage = "Enter your Phone")]
            public string Phone { get; set; }
            public string Address { get; set; }
            public Nullable<int> UserType { get; set; }
            [DisplayName("Join At")]
            public Nullable<System.DateTime> date_insert { get; set; }
            [DisplayName("Last Update")]
            public Nullable<System.DateTime> last_update { get; set; }


        }
        }
}