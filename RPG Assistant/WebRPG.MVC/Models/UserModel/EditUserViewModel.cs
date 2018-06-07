using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebRPG.MVC.Models.UserModel
{
    public class EditUserViewModel
    {
        public EditUserModel EditUser { get; set; }
        public UserServiceReference.User User { get; set; }


    }
}