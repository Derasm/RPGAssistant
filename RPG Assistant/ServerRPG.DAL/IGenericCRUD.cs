using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.DAL
{
    public interface IGenericCRUD<T>
    {
        void Create(T entity);
        //returns all of whatever table desired. No parameter is chosen as this is set in method implementation.
        List<T> GetAll();
        //returns the object found. Input is string, which means int and the like can be used if parsed to string.
        T Find(string searcher);
        //returns an int of the rows updated.
        int Update(T entity);

        // Denne metode er ikke vigtigt i første omgang.
        bool Delete(T entity);

    }
}
