using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ContractsServer.Models
{
    [DataContract]
    public class StationModel
    {
        [Key]
        [DataMember]
        public int StationId { get; set; }

        [DataMember]
        public Plane Plane { get; set; }

        public List<StationModel> _landingList { get; set; }
        public List<StationModel> _flightList { get; set; }

        public StationModel(StationModel station)
        {
            StationId = station.StationId;
            Plane = station.Plane;
        }

        public StationModel()
        {
        }
    }
}