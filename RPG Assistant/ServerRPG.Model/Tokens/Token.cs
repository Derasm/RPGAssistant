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
    public abstract class Token
    {
        [Key]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Token TokenType { get; set; }

        //value added on Map Generation
        [DataMember]
        public int TokenValue { get; set; }
        [DataMember]
        public bool Active { get; set; }

    }
}
