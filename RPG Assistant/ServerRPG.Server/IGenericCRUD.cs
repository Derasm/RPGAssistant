using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServerRPG.Model;


namespace ServerRPG.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGenericCRUD<User>
    {
        [OperationContract]
        void Create(User entity);
        //returns all of whatever table desired. No parameter is chosen as this is set in method implementation.
        [OperationContract]
        IEnumerable<User> GetAll();
        //returns the object found. Input is string, which means int and the like can be used if parsed to string.
        [OperationContract]
        User Find(string searcher);
        //returns an int of the rows updated.
        [OperationContract]
        int Update(User entity);
        // Denne metode er ikke vigtigt i første omgang.
        [OperationContract]
        bool Delete(User entity);

    }
}
