using ServerRPG.DAL.DBClasses;
using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.BusinessLogic
{
    public class CtrCharacter : IGenericCrud<Character>
    {
        private DbCharacter db = new DbCharacter();

        public void Create(Character entity)
        {
            db.Create(entity);
        }

        public bool Delete(Character entity)
        {
            if (db.Delete(entity))
            {
                return true; // returns true if db.Delete was a succes. Otherwise returns false.
            }
            else
            {
                return false;
            }
        }

        public Character Find(string input)
        {
            Character c = new Character();
            c = db.Find(input);
            return c;
        }

        public IEnumerable<Character> GetAll()
        {
            return db.GetAll();
        }

        public int Update(Character entity)
        {
            return db.Update(entity);
        }
    }
}
