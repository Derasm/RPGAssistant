using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Model
{
    [DataContract]
    public enum UserType
    {
        Player,
        GameMaster
    };
}
