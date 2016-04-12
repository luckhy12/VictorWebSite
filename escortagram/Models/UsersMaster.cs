using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace escortagram.Models
{
    public class UsersMaster
    {
        [Required]
        [EmailAddress]
       
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
      
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]     
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }
        public int UserID { get; set; }
        public Nullable<int> UserType { get; set; }
         [Required(ErrorMessage="Enter First Name.")]
        public string FirstName { get; set; }
         [Required(ErrorMessage = "Enter Last Name.")]
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Active { get; set; }
        [Required(ErrorMessage = "Enter Age.")]
        [Range(18,65,ErrorMessage="Should be in 18-65 range.")]
        public Nullable<int> Age { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile No.")]
        public Nullable<int> MobileNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
        public DateTime datetime { get; set; }
    }
    public class Users
    {
        [Required]
        public string Emails { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passwords { get; set; }
    }
}