using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class DbNPC : IGenericCRUD<NPC>
    {
        public void Create(NPC entity)
        {
            using (DBContext db = new DBContext())
            {
                db.NPC.Add(entity);
            }
        }

        public bool Delete(NPC entity)
        {
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
                NPC current = new NPC();
                current = db.NPC.FirstOrDefault(x => x.Name == entity.Name);
                if (current != null)
                {
                    current.Active = !current.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                }
            }
            return actionSuccessful;
        }

        public NPC Find(string searcher)
        {
            using (DBContext db = new DBContext())
            {
                return db.NPC.FirstOrDefault(x => x.Name == searcher);
            }
        }

        public List<NPC> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.NPC.ToList<NPC>();
            }
        }

        public int Update(NPC entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                using (DBContext db = new DBContext())
                {
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                scope.Complete();
            }
            return entity.ID;
        }
    }
}
