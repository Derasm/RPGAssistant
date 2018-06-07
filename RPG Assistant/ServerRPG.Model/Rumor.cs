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
    public class Rumor
    {
        [Key]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool Active { get; set; }
        public Rumor()
        {

        }
    }
}
