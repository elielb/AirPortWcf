using ContractsServer.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace Logic
{
    [ServiceContract(CallbackContract = typeof(IWatingListCallBack))]
    public interface IWaitingListService
    {
        [OperationContract]
        void GetWatingList();
    }

    public interface IWatingListCallBack
    {
        [OperationContract]
        void GetWatingListCallBack(Plane[] listPlanes);
    }
}
