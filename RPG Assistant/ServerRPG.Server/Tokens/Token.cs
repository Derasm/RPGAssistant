using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Server.Tokens
{
    public class Token : IGenericCRUD<Token>
    {
        //Is supposed to check the underlying type of the Token object, choosing correct case in Switch statement based on type.
        public void Create(Token entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Token entity)
        {
            throw new NotImplementedException();
        }

        public Token Find(string searcher)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Token> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Update(Token entity)
        {
            throw new NotImplementedException();
        }
    }
}
