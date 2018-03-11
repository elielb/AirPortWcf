using ContractsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LogicService : IWaitingListService, IDALService
    {
        private static StationManager station;
        //private static List<StationModel> listStationModel;
        public LogicService()
        {
           
        }
        static public void SetStation(StationManager s)
        {
            station = s;
            
        }

        public void GetWatingList()
        {
            IWatingListCallBack callBack = OperationContext.Current.GetCallbackChannel<IWatingListCallBack>();
            callBack.GetWatingListCallBack(station.GetWaitingList().ToArray());
        }

        public void GetListPlanes()
        {
            IDALServiceCallBack callBack = OperationContext.Current.GetCallbackChannel<IDALServiceCallBack>();
            callBack.GetPlane(station.GetArr());
        }
    }

}
