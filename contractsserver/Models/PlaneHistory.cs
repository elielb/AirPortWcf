using ContractsServer.Models;
using System.Runtime.Serialization;

namespace ContractsServer
{
    [DataContract]
    public class PlaneHistory : Plane
    {
        public PlaneHistory() : base(0, StatusFly.Fly)
        {
        }

        //[DataMember]
        //public DateTime TimeEnterd { get; set; }

        //[DataMember]
        //public DateTime TimeExist { get; set; }
    }
}