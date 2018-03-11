using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ContractsServer.Models
{
    [DataContract]
    public class PlaneLanding : Plane
    {
        public PlaneLanding() : base(0, StatusFly.Land)
        {
        }

        [DataMember]
        public IEnumerable<Plane> LandingPlanes { get; set; }
    }
}