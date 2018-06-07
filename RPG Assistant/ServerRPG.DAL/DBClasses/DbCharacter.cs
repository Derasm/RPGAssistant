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
    public class DbCharacter : IGenericCRUD<Character>
    {
        public void Create(Character entity)
        {
                TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
                {
                    using (DBContext db = new DBContext())
                    {
                        db.Character.Add(entity);
                        db.SaveChanges();
                    }
                    scope.Complete();
                }
        }

        public bool Delete(Character entity)
        {
            using (DBContext db = new DBContext())
            {
                entity.Active = !entity.Active;
                db.SaveChanges();
                return !entity.Active;
            }
        }

        public Character Find(string searcher)
        {
            Character current;
            using (DBContext db = new DBContext())
            {
                current = db.Character.FirstOrDefault(x => x.Name == searcher);
                return current;
            }
        }
        public Character FindWithUserNulled(string searcher)
        {
            Character current;
            using (DBContext db = new DBContext())
            {
                current = db.Character.FirstOrDefault(x => x.Name == searcher);
                //current.User = null;
                return current;
            }
        }

        public List<Character> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Character.ToList<Character>();
            }
        }

        public int Update(Character entity)
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
