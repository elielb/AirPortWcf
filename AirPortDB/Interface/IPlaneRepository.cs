using ContractsServer.Models;
using System.Collections.Generic;

namespace ContractsServer.Interface
{
    public interface IPlaneRepository
    {
        void AddPlaneToHistory(StationModel stationModel);

        IEnumerable<Plane> AddPlaneToLanding(List<Plane> plane);

        IEnumerable<Plane> AddPlaneToTakeOff(List<Plane> plane);
    }
}