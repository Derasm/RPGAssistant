using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ServerRPG.DAL.DBClasses
{
    public class DbToken : IGenericCRUD<Token>
    {
        public void Create(Token entity)
        {
            using (DBContext db = new DBContext())
            {
                db.Tokens.Add(entity);
            }
        }

        public bool Delete(Token entity)
        {
            //bool actionSuccessful = false;
            //using (DBContext db = new DBContext())
            //{
            //    Token current = new Token();
            //    current = db.Tokens.FirstOrDefault(x => x.Name == entity.Name);
            //    if (current != null)
            //    {
            //        current.Active = current.Active;
            //        db.SaveChanges();
            //        actionSuccessful = true;
            //    }
            //}
            //return actionSuccessful;
            throw new NotImplementedException();
        }

        public Token Find(string searcher)
        {
            using (DBContext db = new DBContext())
            {
                return db.Tokens.FirstOrDefault(x => x.Name == searcher);
            }
        }

        public List<Token> GetAll()
        {
            using (DBContext db = new DBContext())
            {
                //for some dumb reason, this works despite Token being abstract xD
                return db.Tokens.ToList<Token>();
            }
        }

        public int Update(Token entity)
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

