using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ServerRPG.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerRPG.Model
{
    [DataContract]
    [Table("Enemies")]
    public class Enemy : Token
    {
        [ForeignKey("Token")]
        public int TokenID { get; set; }
        public Token Token { get; set; }
        [DataMember]
        public int Healthpoint { get; set; }
        //Set as a list of strings, as a creature can have multiple skills.
        [DataMember]
        public List<Skill> AllSkills { get; set; }
    


        public Enemy()
        {

        }



    }
}
