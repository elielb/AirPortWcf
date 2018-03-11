using ContractsServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.RepositoryModel
{
    public class StationRepositoryModel
    {
        [Key]
        public int StationID { get; set; }

        public Plane PlaneInStation { get; set; }

        public DateTime PlaneTimeEnteredStation { get; set; }

        public DateTime PlaneTimerExitStation { get; set; }
    }
}