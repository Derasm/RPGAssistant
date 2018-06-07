using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerRPG.Model.Tokens
{
    [DataContract]
    [Table("Loots")]
    public class Loot : Token
    {
        [DataMember]
        public int Value { get; set; }

        //TODO find out if this works without Rarity Enum being added as DataMember as well.
        [DataMember]
        public Rarity LootRarity { get; set; }
        
        public enum Rarity
        {
            [EnumMember]
            Normal,
            [EnumMember]
            Uncommon,
            [EnumMember]
            Common,
            [EnumMember]
            Rare,
            [EnumMember]
            Epic,
            [EnumMember]
            Legendary
        };
        public Loot()
        {

        }
    }
}
