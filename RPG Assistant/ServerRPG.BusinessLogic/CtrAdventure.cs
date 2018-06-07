using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerRPG.Model;
using ServerRPG.DAL;
using ServerRPG.DAL.DBClasses;

namespace ServerRPG.BusinessLogic
{
    public class CtrAdventure : IGenericCrud<Adventure>
    {
        private DbAdventure db = new DbAdventure();
        public void Create(Adventure entity)
        {
            db.Create(entity);
        }

        public bool Delete(Adventure entity)
        {
            if (db.Delete(entity))
            {
                return true; // returns true if db.Delete was a succes. Otherwise returns false.
            }
            else {
                return false;
            }
        }

        public Adventure Find(string input)
        {
            Adventure adventure = new Adventure();
            adventure = db.Find(input);
            return adventure;
        }

        public IEnumerable<Adventure> GetAll()
        {
            return db.GetAll();
        }

        public int Update(Adventure entity)
        {
            return db.Update(entity);
        }
    }
}
