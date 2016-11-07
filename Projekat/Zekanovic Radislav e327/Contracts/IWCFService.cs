using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface IWCFService
    {

        [OperationContract]
        void AddEntity(string message);

        //[OperationContract]
        //HashSet<Entity> Read();

        //[OperationContract]
        //void Update(string newMessage);

        
        //[OperationContract]
        //void RemoveEntity(string id);

    }
}
