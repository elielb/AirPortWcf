using ContractsServer.Models;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class StationTestsMovingPlanes
    {
        [TestMethod]
        public void MovmentIfPlaneLand_StationIsFull_PlaneDoesntMoveToStation()
        {
            //arrange
            var plane1 = new Plane(100, StatusFly.Land);
            var station1 = new StationModel { StationId = 1, Plane = plane1 };
            var station2 = new StationModel { StationId = 2, Plane = new Plane(120, StatusFly.Land) };
            var stationManager = new StationManager();
            //act
            stationManager.Movment(station1);
            //assert
            Assert.IsTrue(station2.Plane != plane1);
        }

        [TestMethod]
        public void MovmentIfPlaneIsFly_StationIsFull_PlaneDoesntMoveToStation()
        {
            //arrange
            var plane1 = new Plane(100, StatusFly.Fly);
            var station7 = new StationModel { StationId = 7, Plane = plane1 };
            var station8 = new StationModel { StationId = 8, Plane = new Plane(120, StatusFly.Fly) };
            var stationManager = new StationManager();
            //act
            stationManager.Movment(station7);
            //assert
            Assert.IsTrue(station7.Plane == plane1);
        }

        [TestMethod]
        public void MovmentIfPlaneLand_StationIsEmpty_PlanetMovesToStation()
        {
            //arrange
            var plane1 = new Plane(100, StatusFly.Land);
            var station1 = new StationModel { StationId = 1, Plane = plane1 };
            var station2 = new StationModel { StationId = 2, Plane = null };
            var stationManager = new StationManager();
            //act
            stationManager.Movment(station1);
            //assert
            Assert.IsNull(station2.Plane);
        }

        [TestMethod]
        public void MovmentIfPlaneIsFly_StationIsEmpty_PlanetMovesToStation()
        {
            //arrange
            var plane1 = new Plane(100, StatusFly.Fly);
            var plane2 = new Plane(111, StatusFly.Fly);
            var station7 = new StationModel { StationId = 7, Plane = plane1 };
            var station8 = new StationModel { StationId = 8, Plane = null };
            var station4 = new StationModel { StationId = 4, Plane = plane2 };
            var station6 = new StationModel { StationId = 6, Plane = plane2 };
            var stationManager = new StationManager();
            //act
            stationManager.Movment(station7);
            //assert
            Assert.IsTrue(station8.Plane == plane1);
        }
    }
}