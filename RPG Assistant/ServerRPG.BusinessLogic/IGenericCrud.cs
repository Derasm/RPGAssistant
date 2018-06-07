using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.BusinessLogic
{
    interface IGenericCrud<T>
    {
        //Generic crud interface, using generic type T as an easy import of the set datatype.
        //our developers said:
        //"super sexy" (Dennis), "ret fed"( Elyas), ubeslutsom(Mikkel).
        void Create(T entity);
        IEnumerable<T> GetAll();
        T Find(String input);
        int Update(T entity);
        //returns a bool telling if the delete was successful.
        bool Delete(T entity);

    }
}
