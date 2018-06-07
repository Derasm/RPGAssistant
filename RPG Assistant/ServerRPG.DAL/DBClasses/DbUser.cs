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
    public class DbUser : IGenericCRUD<User>
    {
        public void Create(User entity)
        {
            using (DBContext db = new DBContext())
            {
                db.Users.Add(entity);
                db.SaveChanges();
            }
        }

        public bool Delete(User entity)
        {
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
                User current = new User();
                current = db.Users.FirstOrDefault(x => x.UserName == entity.UserName);
                if (current != null)
                {
                    current.Active = !current.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                }
            }
            return actionSuccessful;
        }

        public User Find(string searcher)
        {
            using (DBContext db = new DBContext())
            {
                
                User user = db.Users.Include(x => x.Adventures).Include(x=> x.Characters).FirstOrDefault(x => x.UserName.Equals(searcher));
                if (user != null)
                {
                    foreach (var item in user.Characters)
                    {
                        item.User = null;
                    }
                    foreach (var item in user.Adventures)
                    {
                        item.Players = null;
                    }
                }
               
                return user;
            }
        }

        public List<User> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Users.ToList();
            }
        }

        public int Update(User entity)
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
