using ContractsServer;
using ContractsServer.Models;
using Service.RepositoryModel;
using System.Data.Entity;

namespace Service.Context
{
    public class PlaneContext : DbContext
    {
        public PlaneContext() : base("AirportDB")
        {
            //Station.Add(new Station { StationID = 1, Plane = null });
            //Station.Add(new Station { StationID = 2, Plane = null });
            //Station.Add(new Station { StationID = 3, Plane = null });
            //Station.Add(new Station { StationID = 4, Plane = null });
            //Station.Add(new Station { StationID = 5, Plane = null });
            //Station.Add(new Station { StationID = 6, Plane = null });
            //Station.Add(new Station { StationID = 7, Plane = null });
            //Station.Add(new Station { StationID = 8, Plane = null });
        }

        //public DbSet<PlaneHistoryRepositoryModel> StationHistory { get; set; }
        //public DbSet<PlaneCurrentRepositoryModel> StationCurrentTime { get; set; }
        //public DbSet<PlaneLandingRepository> PlaneLanding { get; set; }
        //public DbSet<PlaneTakeOffRepository> PlaneTakeOff { get; set; }

        public DbSet<Plane> Plane { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<PlaneHistory> History { get; set; }
        public DbSet<PlaneLanding> LandingPlanes { get; set; }
        public DbSet<PlaneTakeOff> TakeOffPlanes { get; set; }
    }
}