using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;

namespace ServerRPG.DAL.DBClasses
{
    public class DbAdventure : IGenericCRUD<Adventure>
    {
        public void Create(Adventure entity)
        {
            //DBContext implements IDisposable, which means it gets disposed after method is run, freeing memory.
            using (DBContext db = new DBContext())
            {
                db.Adventures.Add(entity);
                db.SaveChanges();
            }
                
        }

        public bool Delete(Adventure entity)
        {
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
               
                Adventure current = new Adventure();
                current = db.Adventures.FirstOrDefault(x => x.Name == entity.Name);
                if (current != null)
                {
                    current.Active = !current.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                    
                }
            }
            return actionSuccessful;
        }

        public Adventure Find(string searcher)
        {

            using (DBContext db = new DBContext())
            {
                Adventure current = new Adventure();
                current = db.Adventures.Include(x => x.Players).FirstOrDefault(x => x.Name == searcher);
                if (current != null && current.Players != null)
                {
                    foreach (var item in current.Players)
                    {
                        item.Adventures = null;
                        item.Characters = null;
                    }
                }
                return current;
            }
                
        }

        public List<Adventure> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Adventures.ToList<Adventure>();
            }
        }

        public int Update(Adventure entity)
        {
            //most likely error due to entitystate.modified. Updated is not happening for some reason, conflict.
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
