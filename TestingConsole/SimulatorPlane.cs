using ContractsServer.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimulatorPlane
{
    public class SimulatorPlane
    {
        public static StationModel station;
        private Plane plane = null;

        private static void Main(string[] args)
        {
            Console.ReadKey();
        }

        public Plane MakeNewPlanes()
        {
            Random random = new Random();
            int ranNumber = 0;
            double ran0To1 = 0;
            ran0To1 = random.NextDouble();
            ranNumber = random.Next(1, 1000);
            if (ran0To1 > 0.5)
            {
                plane = new Plane(ranNumber, StatusFly.Fly);
            }
            else
            {
                plane = new Plane(ranNumber, StatusFly.Land);
            }

            return plane;
        }
    }
}