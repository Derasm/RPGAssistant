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
    public class Skill
    {
        //Name, description, damage, damagetype, area
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public Dice Damage { get; set; }
        [DataMember]
        public DamageType DamageType { get; set; }
        [DataMember]
        public bool Active { get; set; }

        public Skill(string name, string description, Dice dice, DamageType damageType, bool active)
        {
            this.Name = name;
            this.Description = description;
            this.Damage = dice;
            this.DamageType = damageType;
            this.Active = Active;
        }

        public Skill()
        {

        }
    }
}
