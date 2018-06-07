using System;
using System.Collections.Generic;



namespace ServerRPG.Model
{
    

    public class User
    {
 
        public int ID { get; set; }

        public string UserName { get; set; }

        //hashing of Password to be added!
        public string HashedPassword { get; set; }

        public string Salt { get; set; }

        public List<Adventure> Adventures { get; set; }

        public List<Character> Characters { get; set; }

        public bool Active { get; set; }
        public bool IsGameMaster { get; set; }




    }
}
