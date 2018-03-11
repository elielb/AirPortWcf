using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ContractsServer.Models
{
    [DataContract]
    public class PlaneTakeOff : Plane
    {
        public PlaneTakeOff() : base(0, StatusFly.Fly)
        {
        }

        [DataMember]
        public IEnumerable<Plane> TakeOffPlanes { get; set; }
    }
}