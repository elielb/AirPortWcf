using ContractsServer;
using ContractsServer.Models;
using System.Data.Entity;

namespace AirPortDB.Context
{
    public class AirPortContext : DbContext
    {
        public DbSet<StationModel> PlaneHistory { get; set; }
        public DbSet<PlaneLanding> LandingPlanes { get; set; }
        public DbSet<PlaneTakeOff> TackOffPlanes { get; set; }
    }
}