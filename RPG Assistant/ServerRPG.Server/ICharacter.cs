using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Server
{
    [ServiceContract(Namespace = "ServerRPG.CharacterService")]
    public interface ICharacter
    {
        [OperationContract]
        void Create(Model.Character entity);
        //returns all of whatever table desired. No parameter is chosen as this is set in method implementation.
        [OperationContract]
        List<Model.Character> GetAll();
        //returns the object found. Input is string, which means int and the like can be used if parsed to string.
        [OperationContract]
        Model.Character Find(string searcher);
        //returns an int of the rows updated.
        [OperationContract]
        int Update(Model.Character entity);
        // Denne metode er ikke vigtigt i første omgang.
        [OperationContract]
        bool Delete(Model.Character entity);
    }
}
