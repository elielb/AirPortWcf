using AirPortDB.Repository;
using AirPortDB.SaveToDB;
using ContractsServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace AirPortDB
{
    internal class Program
    {
        private static SaveTODB saveTODB;
        private static List<StationModel> list;
        private static void Main(string[] args)
        {
            saveTODB = new SaveTODB();
            list = new List<StationModel>();
            using (ServiceHost host = new ServiceHost(typeof(SaveTODB)))
            {
                host.Open();
                Console.WriteLine("started DB");
                Console.ReadLine();
            }

            Console.ReadLine();
        }


        public void EnterAPlane(StationModel[] ArrStationModel)
        {
            list = ArrStationModel.ToList();
        }
    }
}