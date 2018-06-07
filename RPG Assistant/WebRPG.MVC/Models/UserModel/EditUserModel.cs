using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRPG.MVC.Models.UserModel
{
    public class EditUserModel
    {
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The passwords do not match. Please write it again.")]
        public string ConfirmPassword { get; set; }
        public bool IsGamemaster { get; set; }
    }
}