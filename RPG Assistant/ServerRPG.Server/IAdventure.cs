using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Server
{
    [ServiceContract(Namespace ="ServerRPG.AdventureService")]
    public interface IAdventure
    {
        [OperationContract]
        void Create(Model.Adventure entity);

        [OperationContract]
        bool Delete(Model.Adventure entity);

        [OperationContract]
        Model.Adventure Find(string searcher);

        [OperationContract]
        List<Model.Adventure> GetAll();

        [OperationContract]
        int Update(Model.Adventure entity);
    }
}
