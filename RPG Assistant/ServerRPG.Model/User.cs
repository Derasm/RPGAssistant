using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ServerRPG.Model
{
    
    [DataContract]
    public class User
    {
        [DataMember]
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string HashedPassword { get; set; }
        [DataMember]
        public string Salt { get; set; }
        [DataMember]
        public List<Adventure> Adventures { get; set; }
        [DataMember]
        public List<Character> Characters { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public bool IsGameMaster { get; set; }
        public User()
        {
            Adventures = new List<Adventure>();
            Characters = new List<Character>();
        }
    }
}
