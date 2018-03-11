using ContractsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AirPortDB.Interface
{
    [ServiceContract]
    public interface IDBService
    {
        [OperationContract]
        void UpdateListPlane(StationModel[] listPlanes);
    }

}
