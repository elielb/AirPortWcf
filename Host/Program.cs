using ContractsServer.Models;
using Logic;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using SimulatorPlane;

namespace Host
{
    internal class Program
    {
        private static SimulatorPlane.SimulatorPlane _simulator;
        private static StationManager _station;
        
        private static void Main(string[] args)
        {
            _simulator = new SimulatorPlane.SimulatorPlane();
            _station = new StationManager();
            StationManager.LoadingLists();
            StationManager.UpdateStations();
           
            MakePlanes();

            using (ServiceHost hosting = new ServiceHost(typeof(LogicService)))
            {
                hosting.Open();
                LogicService.SetStation(_station);
                Console.WriteLine($"Host started  {DateTime.Now}");
                Console.ReadLine();
            }
        }

        private static async void MakePlanes()
        {
            for (int i = 0; i < 100000; i++)
            {
                await Task.Delay(2000);
                Plane a = _simulator.MakeNewPlanes();
               LogicService.SetStation(_station);
                 _station.AddingNewPlane(a);
            }
        }
    }
}