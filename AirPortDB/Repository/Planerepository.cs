using AirPortDB.Context;
using ContractsServer;
using ContractsServer.Interface;
using ContractsServer.Models;
using System.Collections.Generic;
using System.Linq;

namespace AirPortDB.Repository
{
    public class Planerepository : IPlaneRepository
    {
        private AirPortContext planeContext;

        public Planerepository()
        {
            planeContext = new AirPortContext();
        }

        public void AddPlaneToHistory(StationModel stationModel)
        {
            using (var db = new AirPortContext())
            {
                db.PlaneHistory.Add(stationModel);
            }
        }

        public IEnumerable<Plane> AddPlaneToLanding(List<Plane> plane)
        {
            IEnumerable<Plane> listOfLandingPlanes = new List<Plane>();
            if (plane != null)
            {
                using (var db = new AirPortContext())
                {
                    listOfLandingPlanes = db.LandingPlanes.AddRange((IEnumerable<PlaneLanding>)plane).Where(x => x.StatusFly == StatusFly.Land);
                }
                return listOfLandingPlanes;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Plane> AddPlaneToTakeOff(List<Plane> plane)
        {
            IEnumerable<Plane> listOfTakeOffPlanes = new List<Plane>();
            if (plane != null)
            {
                using (var db = new AirPortContext())
                {
                    listOfTakeOffPlanes = db.TackOffPlanes.AddRange((IEnumerable<PlaneTakeOff>)plane).Where(x => x.StatusFly == StatusFly.Fly);
                }
                return listOfTakeOffPlanes;
            }
            else
            {
                return null;
            }
        }
    }
}