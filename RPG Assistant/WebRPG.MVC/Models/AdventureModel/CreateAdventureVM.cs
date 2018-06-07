using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebRPG.MVC.UserServiceReference;

namespace WebRPG.MVC.Models.AdventureModel
{
    public class CreateAdventureVM
    {
        public List<UserServiceReference.User> Players { get; set; }
        [Required]
        public string Name { get; set; }
        //date of the created Adventure. Is not the creation of the Adventure object, but the chosen date of the game.
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public int MaxPlayers { get; set; }

        public string UserName { get; set; }


    }
}