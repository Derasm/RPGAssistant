using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Model.Enums
{
    [DataContract]
    public enum Dice
    {
    [EnumMember]
        d2,
        [EnumMember]
        d4,
        [EnumMember]
        d6,
        [EnumMember]
        d8,
        [EnumMember]
        d10,
        [EnumMember]
        d12,
        [EnumMember]
        d20,
        [EnumMember]
        d100
    }
}
