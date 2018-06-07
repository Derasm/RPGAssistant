using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerRPG.DAL;
using ServerRPG.DAL.DBClasses;
using ServerRPG.Model;

namespace ServerRPG.BusinessLogic
{
    public class CtrSkill : IGenericCRUD<Skill>
    {
        private DbSkill db = new DbSkill();
        public void Create(Skill entity)
        {
            db.Create(entity);
        }

        public bool Delete(Skill entity)
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

        public Skill Find(string searcher)
        {
            Skill s = new Skill();
            s = db.Find(searcher);
            return s;
        }

        public List<Skill> GetAll()
        {
            return db.GetAll();
        }

        public int Update(Skill entity)
        {
            return db.Update(entity);
        }
    }
}
