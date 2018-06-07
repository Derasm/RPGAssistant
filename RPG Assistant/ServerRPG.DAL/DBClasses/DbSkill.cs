using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ServerRPG.Model;

namespace ServerRPG.DAL.DBClasses
{
    public class DbSkill : IGenericCRUD<Skill>
    {
        public void Create(Skill entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                using (DBContext db = new DBContext())
                {
                    db.Skills.Add(entity);
                    db.SaveChanges();
                }
                scope.Complete();
            }
        }

        public bool Delete(Skill entity)
        {
            using (DBContext db = new DBContext())
            {
                entity.Active = !entity.Active;
                db.SaveChanges();
                return !entity.Active;
            }
        }

        public Skill Find(string searcher)
        {
            Skill current;
            using (DBContext db = new DBContext())
            {
                current = db.Skills.FirstOrDefault(x => x.Name == searcher);
                return current;
            }
        }

        public List<Skill> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Skills.ToList<Skill>();
            }
        }

        public int Update(Skill entity)
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
