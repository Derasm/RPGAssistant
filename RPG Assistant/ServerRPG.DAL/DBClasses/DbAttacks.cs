using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class DbAttacks : IGenericCRUD<Attack>
    {
        public void Create(Attack entity)
        {
            using (DBContext db = new DBContext())
            {
                db.Attacks.Add(entity);
                db.SaveChanges();
            }
        }

        public bool Delete(Attack entity)
        {
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
                Attack current = new Attack();
                current = db.Attacks.FirstOrDefault(x => x.AtkName == entity.AtkName);
                if (current != null)
                {
                    current.Active = !current.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                }
            }
            return actionSuccessful;
        }

        public Attack Find(string searcher)
        {
            Attack current = new Attack();
            using (DBContext db = new DBContext())
            {
                current = db.Attacks.FirstOrDefault(x => x.AtkName == searcher);
                return current;
            }
        }

        public List<Attack> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Attacks.ToList<Attack>();
            }
        }

        public int Update(Attack entity)
        {
            
            TransactionOptions to = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable
            };
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
