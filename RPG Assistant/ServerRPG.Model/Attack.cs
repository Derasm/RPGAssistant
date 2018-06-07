using ServerRPG.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Model
{
    public class Attack
    {
        [Key]
        public int ID { get; set; }
        [DataMember]
        public Dice Damage { get; set; }
        [DataMember]
        public string AtkName { get; set; }
        [DataMember]
        public string AtkDescription { get; set; }
        [DataMember]
        public DamageType AtkType { get; set; }
        [DataMember]
        public int AtkModifier { get; set; }

        [DataMember]
        public bool Active { get; set; }
        //blank constructor used in Db for initializing of object, which then has values set equal to found object.
        public Attack()
        {

        }
    }
}
