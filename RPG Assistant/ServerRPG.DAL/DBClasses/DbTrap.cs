using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class DbTrap : IGenericCRUD<Trap>
    {
        public void Create(Trap entity)
        {
            using (DBContext db = new DBContext())
            {
                db.Traps.Add(entity);
            }
        }

        public bool Delete(Trap entity)
        {
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
                Trap current = new Trap();
                current = db.Traps.FirstOrDefault(x => x.Name == entity.Name);
                if (current != null)
                {
                    current.Active = !current.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                }
            }
            return actionSuccessful;
        }

        public Trap Find(string searcher)
        {
            using (DBContext db = new DBContext())
            {
                return db.Traps.FirstOrDefault(x => x.Name == searcher);
            }
        }

        public List<Trap> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Traps.ToList<Trap>();
            }
        }

        public int Update(Trap entity)
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
