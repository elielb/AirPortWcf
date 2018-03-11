using ContractsServer.Models;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class AddingPlane
    {
        [TestMethod]
        public void AddPlaneIfLand_PlaneIsLanding_AddingPlaneToStation()
        {
            //arrange
            var plane = new Plane(100, StatusFly.Land);
            var station1 = new StationModel { StationId = 1 };
            var stationmanager = new StationManager();
            //act
            stationmanager.AddingNewPlane(plane);
            //assert
            Assert.IsTrue(station1.Plane == plane);
        }

        [TestMethod]
        public void AddPlaneIfFly_PlaneIsFlying_AddingPlaneToStation()
        {
            //arrange
            var plane = new Plane(100, StatusFly.Fly);
            var plane2 = new Plane(122, StatusFly.Fly);
            var station8 = new StationModel { StationId = 8, Plane = plane2 };
            var station7 = new StationModel { StationId = 7 };
            var station6 = new StationModel { StationId = 6 };
            var stationmanager = new StationManager();
            //act
            stationmanager.AddingNewPlane(plane);
            //assert
            Assert.IsTrue(station6.Plane == plane || station7.Plane == plane);
        }

        [TestMethod]
        public void AddPlaneIfLand_PlaneIsLanding_PlaneDosentAddToTheFirstStation()
        {
            //arrange
            var plane = new Plane(100, StatusFly.Land);
            var plane2 = new Plane(101, StatusFly.Land);
            var station1 = new StationModel { StationId = 1, Plane = plane };
            var stationmanager = new StationManager();
            //act
            stationmanager.AddingNewPlane(plane2);
            //assert
            Assert.IsNotNull(station1.Plane);
        }

        [TestMethod]
        public void AddPlaneIfFly_PlaneIsFlying_PlaneDosentAddToTheFirstStationn()
        {
            //arrange
            var plane = new Plane(100, StatusFly.Fly);
            var plane2 = new Plane(101, StatusFly.Fly);
            var station8 = new StationModel { StationId = 8, Plane = plane };
            var station7 = new StationModel { StationId = 7, Plane = plane };
            var stationmanager = new StationManager();
            //act
            stationmanager.AddingNewPlane(plane2);
            //assert
            Assert.IsNotNull(station8.Plane);
        }
    }
}