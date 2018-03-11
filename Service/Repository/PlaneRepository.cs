using ContractsServer.Interface;
using ContractsServer.Models;
using Service.Context;
using Service.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Repository
{
    public class PlaneRepository : IPlaneRepository
    {
        private PlaneContext planeContext;

        public PlaneRepository()
        {
            planeContext = new PlaneContext();
        }



        public IEnumerable<Plane> AddPlaneToHistory(List<Plane> plane)
        {
            IEnumerable<Plane> historyListOfPlanes = new List<Plane>();
            using (var db = new PlaneContext())
            {
                historyListOfPlanes = db.Plane.AddRange(plane);
            }
            return historyListOfPlanes;

        }



        //Done
        public IEnumerable<Plane> AddPlaneToLanding(List<Plane> plane)
        {
            IEnumerable<Plane> listOfLandingPlanes = new List<Plane>();
            if (plane != null)
            {
                using (var db = new PlaneContext())
                {
                    listOfLandingPlanes = db.Plane.AddRange(plane).Where(x => x.StatusFly == StatusFly.Land);
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
                using (var db = new PlaneContext())
                {
                    listOfTakeOffPlanes = db.Plane.AddRange(plane).Where(x => x.StatusFly == StatusFly.Fly);
                }
                return listOfTakeOffPlanes;
            }
            else
            {
                return null;
            }
        }
        public IEnumerable<Plane> AddPlaneToCurrent(List<Plane> plane)
        {
            IEnumerable<Plane> currentListOfPlanes = new List<Plane>();

            using (var db = new PlaneContext())
            {
                currentListOfPlanes = db.Plane.AddRange(plane);
            }
            return currentListOfPlanes;
        }
    }
}
