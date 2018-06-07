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
    
    public class Character
    {
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string BackGroundStory { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
