using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerRPG.Model
{
    [DataContract]
    [Table("NPCs")]
    public class NPC : Token
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string  Note { get; set; }
       

        public NPC(string description, string note, int tokenValue)
        {
            TokenType = this; // check if this actually works.
            TokenValue = tokenValue;
            this.Description = description;
            this.Note = note;
        }
        public NPC()
        {

        }
    }
}
