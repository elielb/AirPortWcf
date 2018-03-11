using ContractsServer.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace Logic
{
    [ServiceContract(CallbackContract = typeof(IDALServiceCallBack))]
    public interface IDALService
    {
        [OperationContract]
        void GetListPlanes();
    }

    public interface IDALServiceCallBack
    {
        [OperationContract]
        void GetPlane(StationModel[] ArrStationModel);
    }
}