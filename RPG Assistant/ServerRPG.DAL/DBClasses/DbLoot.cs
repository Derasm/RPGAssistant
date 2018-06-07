using ServerRPG.Model.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class Dbloot : IGenericCRUD<Loot>
    {
        public void Create(Loot entity)
        {
            using (DBContext db = new DBContext())
            {
                db.Loots.Add(entity);
            }
        }

        public bool Delete(Loot entity)
        {
           
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
                Loot current = new Loot();
                current = db.Loots.FirstOrDefault(x => x.Name == entity.Name);
                if (current != null)
                {
                    current.Active = !current.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                }
            }
            return actionSuccessful;
            
        }

        public Loot Find(string searcher)
        {
            using (DBContext db = new DBContext())
            {
                return db.Loots.FirstOrDefault(x => x.Name == searcher);
            }
        }

        public List<Loot> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Loots.ToList<Loot>();
            }
        }

        public int Update(Loot entity)
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
