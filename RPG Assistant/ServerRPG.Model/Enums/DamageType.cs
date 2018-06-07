using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Model.Enums
{
    [DataContract]
    public enum DamageType
    {
        [EnumMember]
        Slashing,
        [EnumMember]
        Piercing,
        [EnumMember]
        Blunt,
        [EnumMember]
        Frost,
        [EnumMember]
        Fire,
        [EnumMember]
        Lightning,
        [EnumMember]
        Poison,
        [EnumMember]
        Necrotic,
        [EnumMember]
        Acid,
        [EnumMember]
        Magic
    }
}
