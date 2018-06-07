using ServerRPG.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServerRPG.Server
{
    [ServiceContract(Namespace = "ServerRPG.UserService")]
    public interface IUser
    {
        [OperationContract]
        void Create(User entity);
        //returns all of whatever table desired. No parameter is chosen as this is set in method implementation.
        [OperationContract]
        List<User> GetAll();
        //returns the object found. Input is string, which means int and the like can be used if parsed to string.
        [OperationContract]
        User Find(string searcher);
        [OperationContract]
        User FindUserWithPassword(string searcher, string password);
        //returns an int of the rows updated.
        [OperationContract]
        int Update(User entity);
        // Denne metode er ikke vigtigt i første omgang.
        [OperationContract]
        bool Delete(User entity);

    }
}
