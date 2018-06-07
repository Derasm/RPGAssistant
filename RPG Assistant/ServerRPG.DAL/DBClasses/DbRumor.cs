using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerRPG.Model;
using System.ServiceModel;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class DbRumor : IGenericCRUD<Rumor>
    {
        public void Create(Rumor entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                using (DBContext db = new DBContext())
                {
                    db.Rumors.Add(entity);
                    db.SaveChanges();
                }
                scope.Complete();
            }
        }

        public bool Delete(Rumor entity)
        {
            using (DBContext db = new DBContext())
            {
                entity.Active = !entity.Active;
                db.SaveChanges();
                return !entity.Active;
            }
        }

        public Rumor Find(string searcher)
        {
            Rumor current;
            using (DBContext db = new DBContext())
            {
                current = db.Rumors.FirstOrDefault(x => x.Name == searcher);
                return current;
            }
        }

        public List<Rumor> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Rumors.ToList<Rumor>();
            }
        }

        public int Update(Rumor entity)
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
