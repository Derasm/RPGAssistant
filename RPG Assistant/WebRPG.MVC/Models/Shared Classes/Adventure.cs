using System;
using System.Collections.Generic;


namespace ServerRPG.Model
{
    public class Adventure
    {
        //Doesn't get send with the rest.
 
        public int ID { get; set; }
        //players in the adventure. Only consists of Users with the Player type.

        public List<User> Players { get; set; }

        public string Name { get; set; }

        public string Logbook { get; set; }
        //date of the created Adventure. Is not the creation of the Adventure object, but the chosen date of the game.

        public DateTime Date { get; set; }

        public Rumor Rumor { get; set; }
   
        public bool Active { get; set; }

        public int MaxPlayers { get; set; }
        
    }
}
