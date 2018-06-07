using ServerRPG.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServerRPG.Server
{
    [ServiceContract(Namespace = "ServerRPG.RumorService")]
    public interface IRumor
    {
        [OperationContract]
        void Create(Rumor entity);
        [OperationContract]
        bool Delete(Rumor entity);
        [OperationContract]
        Rumor Find(string searcher);
        [OperationContract]
        List<Rumor> GetAll();
        [OperationContract]
        int Update(Rumor entity);
    }
}
