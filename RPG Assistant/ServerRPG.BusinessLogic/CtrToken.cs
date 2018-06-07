using ServerRPG.DAL.DBClasses;
using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.BusinessLogic
{
    class CtrToken : IGenericCrud<Token>
    {
        DbToken db = new DbToken();
        public void Create(Token entity)
        {
            db.Create(entity);
        }

        public bool Delete(Token entity)
        {
            return db.Delete(entity);
        }

        public Token Find(string input)
        {
            return db.Find(input);
        }

        public IEnumerable<Token> GetAll()
        {
            return db.GetAll();
        }

        public int Update(Token entity)
        {
            return db.Update(entity);
        }
    }
}
