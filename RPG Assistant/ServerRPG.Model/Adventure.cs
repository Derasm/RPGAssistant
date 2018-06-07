using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerRPG.Model
{
    
    [DataContract]
    public class Adventure
    {
        //Doesn't get send with the rest.
        [Key]
        [DataMember]
        public int ID { get; set; }
        //players in the adventure. Only consists of Users with the Player type.
        [DataMember]
        public List<User> Players { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Logbook { get; set; }
        //date of the created Adventure. Is not the creation of the Adventure object, but the chosen date of the game.
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Rumor Rumor { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int MaxPlayers { get; set; }
        public Adventure()
        {
            Players = new List<User>();
        }
    }
}
