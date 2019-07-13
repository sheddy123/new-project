using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenieAir.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "User Id")]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "Please enter First Name", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Booking Child")]
        public int? booking_Child
        {
            get; set;
        }
            [Required]
        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "Please enter Last Name", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Age")]
        public int Adult_aAge { get; set; }

        [Display(Name = "Name")]
        public string childName { get; set; }

        [Display(Name = "Age")]
        public string child_age { get; set; }

        [Display(Name = "Sex")]
        public Gender childSex { get; set; }
        public Gender adultSex { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        
    }
}