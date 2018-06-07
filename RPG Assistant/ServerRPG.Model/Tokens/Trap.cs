using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ServerRPG.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerRPG.Model
{
    [DataContract]
    [Table("Traps")]
     public class Trap : Token
    {
        [DataMember]
        public Dice Damage{ get; set; }
        [DataMember]
        public DamageType damageType{ get; set; }
       

    }
}
