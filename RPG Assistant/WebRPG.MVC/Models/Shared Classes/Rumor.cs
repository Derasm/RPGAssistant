using System;



namespace ServerRPG.Model
{
 
    public class Rumor
    {
 
        public int ID { get; set; }


        public string Name { get; set; }

 
        public DateTime Date { get; set; }


        public string Description { get; set; }
    
        public bool Active { get; set; }
    }
}
