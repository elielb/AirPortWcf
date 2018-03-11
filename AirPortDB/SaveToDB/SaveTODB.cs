using AirPortDB.Interface;
using AirPortDB.Repository;
using ContractsServer.Interface;
using ContractsServer.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;

namespace AirPortDB.SaveToDB
{
    //public class SaveTODB : IDALServiceCallback, INotifyPropertyChanged
    //{
    //    private static List<StationModel> list;

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(string name)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //    }

    //    public void GetPlane(StationModel[] ArrStationModel)
    //    {
    //        list = ArrStationModel.ToList();
    //    }
    //}
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class SaveTODB : IDBService
    {
        private IPlaneRepository planeRepository;

        public SaveTODB()
        {
            planeRepository = new Planerepository();
        }

        private static List<StationModel> list;

        public void UpdateListPlane(StationModel[] listPlanes)
        {
            list = listPlanes.ToList();

            //  planeRepository.AddPlaneToCurrent()
        }
    }
}