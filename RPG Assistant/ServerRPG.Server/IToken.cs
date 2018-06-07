using ServerRPG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerRPG.Server
{
    [ServiceContract]
    public interface IToken
    {
        [OperationContract]
         void Create(Model.Token entity);

        [OperationContract]
        bool Delete(Model.Token entity);
        [OperationContract]
        Model.Token Find(string searcher);

        [OperationContract]
        List<Model.Token> GetAll();
        [OperationContract]
        int Update(Model.Token entity);
    }
}
