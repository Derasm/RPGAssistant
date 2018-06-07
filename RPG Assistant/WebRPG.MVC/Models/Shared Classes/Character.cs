using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServerRPG.Model
{
    public class Character
    {
 
        public int ID { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public string Class { get; set; }

        public string BackGroundStory { get; set; }

        public bool Active { get; set; }
    }
}
