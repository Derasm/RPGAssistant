using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class DbEnemy : IGenericCRUD<Enemy>
    {
        public void Create(Enemy entity)
        {
            using (DBContext db = new DBContext())
            {
                db.Enemies.Add(entity);
            }
        }

        public bool Delete(Enemy entity)
        {
            bool actionSuccessful = false;
            using (DBContext db = new DBContext())
            {
                Enemy enemy = new Enemy();
                enemy = db.Enemies.FirstOrDefault(x => x.Name == entity.Name);
                //checks to see if an enemy with the name actually exists.
                if (enemy != null)
                {
                    //sets the active state to the opposite of what it currently is.
                    enemy.Active = !enemy.Active;
                    db.SaveChanges();
                    actionSuccessful = true;
                }
            }
            return actionSuccessful;
        }

        public Enemy Find(string searcher)
        {
            using (DBContext db = new DBContext())
            {
                return db.Enemies.FirstOrDefault(x => x.Name == searcher);
            }
        }

        public List<Enemy> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                return db.Enemies.ToList<Enemy>();
            }
        }

        public int Update(Enemy entity)
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
