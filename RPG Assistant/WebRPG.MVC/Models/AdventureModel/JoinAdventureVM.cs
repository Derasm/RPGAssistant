using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRPG.MVC.UserServiceReference;

namespace WebRPG.MVC.Models.AdventureModel
{
    public class JoinAdventureVM
    {
        public UserServiceReference.User User{ get; set; }
        public Adventure Adventure { get; set; }
    }
}