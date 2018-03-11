using System;
using ContractsServer.Models;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Tests
{
    [TestClass]
    public class PlaneExitAirport
    {
        [TestMethod]
        public void ExitAirport_ThereIsNoNextStation_PlaneIsExitingAirport()
        {
            //arrange
            var plane = new Plane(100, StatusFly.Fly);
            var station4 = new StationModel { StationId = 4, Plane = plane };
            var stationManager = new StationManager();
            //act
            stationManager.Movment(station4);
            stationManager.GetArr();
            //assert
        }
    }
}