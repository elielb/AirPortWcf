using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ContractsServer.Models;

namespace Logic
{
    public class StationManager
    {
        #region Properties

        [DataMember]
        private static List<Plane> waitingListStations;

        private string outputText;
        private Object abc;
        private StationModel s = null;

        [DataMember]
        public static StationModel[] arrStations;

        public StationManager() : base()
        {
            waitingListStations = new List<Plane>();
            arrStations = new StationModel[8];
            abc = new Object();
        }

        #endregion Properties

        #region Stations

        public static StationModel station1 = new StationModel()
        {
            StationId = 1,
        };

        public static StationModel station2 = new StationModel()
        {
            StationId = 2,
        };

        public static StationModel station3 = new StationModel()
        {
            StationId = 3,
        };

        public static StationModel station4 = new StationModel()
        {
            StationId = 4,
        };

        public static StationModel station5 = new StationModel()
        {
            StationId = 5,
        };

        public static StationModel station6 = new StationModel()
        {
            StationId = 6,
        };

        public static StationModel station7 = new StationModel()
        {
            StationId = 7,
        };

        public static StationModel station8 = new StationModel()
        {
            StationId = 8,
        };

        #endregion Stations

        public event Action<StationModel[]> changeUI;

        //DBService.IPlaneRepository client = ServiceManager.CreateServiceClient<DBService.IPlaneRepositoryChannel>("NetTcpBinding_IPlaneRepository");
        public List<Plane> GetWaitingList()
        {
            return waitingListStations;
        }

        public StationModel[] GetArr()
        {
            return arrStations;
        }

        public static void UpdateStations()
        {
            arrStations[0] = (new StationModel(station1));
            arrStations[1] = (new StationModel(station2));
            arrStations[2] = (new StationModel(station3));
            arrStations[3] = (new StationModel(station4));
            arrStations[4] = (new StationModel(station5));
            arrStations[5] = (new StationModel(station6));
            arrStations[6] = (new StationModel(station7));
            arrStations[7] = (new StationModel(station8));
        }

        public static void LoadingLists()
        {
            station1._landingList = new List<StationModel>() { station2 };
            station2._landingList = new List<StationModel>() { station3 };
            station3._landingList = new List<StationModel>() { station4 };
            station4._landingList = new List<StationModel>() { station5 };
            station5._landingList = new List<StationModel>() { station6, station7 };
            station6._flightList = new List<StationModel>() { station8 };
            station7._flightList = new List<StationModel>() { station8 };
            station8._flightList = new List<StationModel>() { station4 };
        }

        #region Update lists and array

        private void DeleteFromWaitingStations(Plane plane)
        {
            var itemToRemove = waitingListStations.FirstOrDefault(x => x.PlaneID == plane.PlaneID);
            waitingListStations.Remove(itemToRemove);
        }

        private void UpdateWaitingStations(Plane plane)
        {
            if (!waitingListStations.Any(x => x.PlaneID == plane.PlaneID))
            {
                waitingListStations.Add(plane);
            }
        }

        private void UpdateListStations(StationModel stationModel)
        {
            changeUI.Invoke(arrStations);
            var planeObj = arrStations.FirstOrDefault(x => x.Plane == stationModel.Plane);
            var stationObj = arrStations.FirstOrDefault(x => x.StationId == stationModel.StationId);
            int planeIndex = Array.IndexOf(arrStations, planeObj);
            int staionIndex = Array.IndexOf(arrStations, stationObj);

            if (planeIndex > -1)
                arrStations[planeIndex].Plane = null;

            if (staionIndex > -1)
                arrStations[staionIndex] = new StationModel(stationModel);
        }

        #endregion Update lists and array

        #region Adding Planes

        public void AddingNewPlane(Plane TPlane)
        {
            UpdateWaitingStations(TPlane);
            if (TPlane.StatusFly == StatusFly.Fly)
            {
                Task.Run(() =>
                {
                    AddPlaneIfFly(TPlane);
                });
            }
            else if (TPlane.StatusFly == StatusFly.Land)
            {
                Task.Run(() =>
                {
                    AddPlaneIfLand(TPlane);
                });
            }
        }

        private void AddPlaneIfLand(Plane TPlane)
        {
            if (station1.Plane == null)
            {
                station1.Plane = TPlane;
                UpdateListStations(station1);
                Console.WriteLine(ConsoleChecker(station1));
                DeleteFromWaitingStations(TPlane);
                Movment(station1);
            }
            else
            {
                while (station1.Plane != null)
                {
                    AddingNewPlane(TPlane);
                }
            }
        }

        private void AddPlaneIfFly(Plane TPlane)
        {
            if (station6.Plane == null)
            {
                station6.Plane = TPlane;
                Console.WriteLine(ConsoleChecker(station6));
                UpdateListStations(station6);
                DeleteFromWaitingStations(TPlane);
                Movment(station6);
            }
            else if (station7.Plane == null)
            {
                station7.Plane = TPlane;
                Console.WriteLine(ConsoleChecker(station7));
                UpdateListStations(station7);
                DeleteFromWaitingStations(TPlane);
                Movment(station7);
            }
        }

        #endregion Adding Planes

        #region Movement

        public void Movment(StationModel stationModel)
        {
            Thread.Sleep(500);
            if (stationModel.Plane != null)
            {
                if (stationModel.Plane.StatusFly == StatusFly.Fly)
                {
                    Task.Run(() =>
                    {
                        MovmentIfPlaneIsFly(stationModel);
                    });
                }
                else if (stationModel.Plane.StatusFly == StatusFly.Land)
                {
                    MovmentIfPlaneLand(stationModel);
                }
            }
        }

        private StationModel nextStation;

        private void MovmentIfPlaneLand(StationModel stationModel)
        {
            if (stationModel._landingList != null)
            {
                lock (abc)
                {
                    nextStation = stationModel._landingList.FirstOrDefault(x => x.Plane == null);
                    while (nextStation == null)
                    {
                        nextStation = stationModel._landingList.FirstOrDefault(x => x.Plane == null);
                    }

                    nextStation.Plane = stationModel.Plane;
                    stationModel.Plane = null;
                    UpdateListStations(nextStation);
                    Console.WriteLine(ConsoleChecker(nextStation));
                }
                Movment(nextStation);
            }
            else
            {
                Console.WriteLine("land is out " + stationModel.Plane.PlaneID.ToString() + "\n");
                stationModel.Plane = null;
            }
        }

        private void MovmentIfPlaneIsFly(StationModel stationModel)
        {
            if (stationModel._flightList != null)
            {
                lock (abc)
                {
                    nextStation = stationModel._flightList.FirstOrDefault(x => x.Plane == null);
                    while (nextStation == null)
                    {
                        nextStation = stationModel._flightList.FirstOrDefault(x => x.Plane == null);
                    }

                    nextStation.Plane = stationModel.Plane;
                    stationModel.Plane = null;
                    UpdateListStations(nextStation);
                    Console.WriteLine(ConsoleChecker(nextStation));
                }
                Movment(nextStation);
            }
            else
            {
                Console.WriteLine("fly is out " + stationModel.Plane.PlaneID.ToString() + "\n");
                stationModel.Plane = null;
            }
        }

        #endregion Movement

        private string ConsoleChecker(StationModel stationModel)
        {
            outputText = " station number : " + stationModel.StationId.ToString() + " Plane number : " + stationModel.Plane.PlaneID.ToString();
            return outputText;
        }
    }
}