using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebRPG.MVC.UserServiceReference;

namespace WebRPG.MVC.Models.AdventureModel
{
    public class AdventureModel
    {
        //players in the adventure. Only consists of Users with the Player type.
       
        public List<UserServiceReference.User> Players { get; set; }
        
        public string Name { get; set; }
        //date of the created Adventure. Is not the creation of the Adventure object, but the chosen date of the game.
     
        public DateTime Date { get; set; }
    
        public int MaxPlayers { get; set; }

        public Rumor Rumor { get; set; }





    }
}