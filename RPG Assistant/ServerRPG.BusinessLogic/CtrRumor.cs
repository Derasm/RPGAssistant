using ServerRPG.DAL.DBClasses;
using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.BusinessLogic
{
    public class CtrRumor : IGenericCrud<Rumor>
    {
        private DbRumor db = new DbRumor();
        public void Create(Rumor entity)
        {
            db.Create(entity);
        }

        public bool Delete(Rumor entity)
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

        public Rumor Find(string input)
        {
            Rumor r = new Rumor();
            r = db.Find(input);
            return r;
        }

        public IEnumerable<Rumor> GetAll()
        {
            return db.GetAll();
        }

        public int Update(Rumor entity)
        {
            return db.Update(entity);
        }
    }
}
