using ContractsServer.Models;
using System.Collections.Concurrent;

namespace Service.Mock
{
    public class Mock
    {
        private static ConcurrentDictionary<Plane, int> _Db = new ConcurrentDictionary<Plane, int>();

        public Mock()
        {
        }

        public void AddPlaneToDB(Plane plane)
        {
            _Db.TryAdd(plane, plane.PlaneID);
        }

        //public void AddingPlan(Plane TPlan, int TStation)
        //{
        //    //chack if station is empty
        //    if (!_Db.Any(TStation,))
        //    {
        //        //Try to add to the station
        //        if (_Db.TryAdd(TStation, TPlan.PlaneID))
        //        {
        //            //try to move to the next session
        //            var nextStation = listStations.FirstOrDefault(x => x.StationID == TStation);
        //            if ( TPlan.StatusFly == StatusFly.Fly)
        //            {
        //                //output the next station and make the plane to go there
        //                nextStation.LandingList.FirstOrDefault();
        //            }
        //        }
        //        else
        //        {
        //            //try adding again after a whill
        //        }
        //    }
        //}

        //public void AddingPlan(Plane TPlan, Station TStation)
        //{
        //    int planeId = TPlan.PlaneID;
        //    //if its one of end point 6,7 and 4
        //    if (TStation.StationID == 4 ||
        //        TStation.StationID == 6 ||
        //        TStation.StationID == 7)
        //    {
        //        if (_Db.Any(x => x.Key == TStation.StationID && x.Value == TPlan.PlaneID))
        //        {
        //            if (_Db.TryRemove(TStation.StationID, out planeId)) { }
        //            else
        //                AddingPlan(TPlan, TStation);
        //        }
        //        else
        //            throw new NotImplementedException();
        //    }
        //    else
        //    {
        //        //maybe try again after 1 second
        //        AddingPlan(TPlan, TStation);
        //    }
        //    try
        //    {
        //        if (!_Db.Any(x => x.Key == TStation.StationID))
        //        {
        //            if (_Db.TryAdd(TStation.StationID, TPlan.PlaneID))
        //            {
        //            }
        //        }
        //        else
        //        {
        //            //maybe try again after 1 second
        //            AddingPlan(TPlan, TStation);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //Middel or strt
        //        throw new NotImplementedException();
        //    }
        //}

        //public Plane LastStation(Plane TPlan, int TStation)
        //{
        //    throw new NotImplementedException();
        //}
    }
}