using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutionWeb1.Models.ViewModels.TutorVM
{
    public class TutorCreateViewModel
    {

        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Adderess Line 1")]
        [Required(ErrorMessage = "Please enter address line 1.")]
        public string Address1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address Line 2")]
        [Required(ErrorMessage = "Please enter address line.")]
        public string Address2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address Line 3")]
        public string Address3 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Telephone Number 1")]
        [Required(ErrorMessage = "Please enter telephone number.")]
        public string Tel1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Telephone No 2")]
        public string Tel2 { get; set; }


        [DataType(DataType.EmailAddress)]
        [Display(Name = "E Mail")]
        [Required(ErrorMessage = "Please enter E Mail address.")]
        [EmailAddress(ErrorMessage = "Invalid E Mail address.")]
        public string EMail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}