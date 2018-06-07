using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace WebRPG.MVC.Models.User
{
    public class RegistrationViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The two Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "I am creating a User account!")]
        public bool IsPlayer { get; set; }
        [Display(Name = "I am creating a GM account")]
        public bool IsGM { get; set; }

    }
}