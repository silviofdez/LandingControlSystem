using LandingControlSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LandingControlSystemTests
{
    [TestClass()]
    public class CoordinatesServiceTests
    {
        [TestMethod()]
        public void CreateSafetyAreaTest()
        {
            Coordinate landingRequest = new Coordinate(5, 5);
            SquareArea sa = AreasService.CreateSafetyArea(landingRequest);
            Assert.AreEqual(sa.Size, 3);
            Assert.AreEqual(sa.TopLeftCorner, new Coordinate(4, 4));
        }

        [TestMethod()]
        public void IsCoordinateInsideTest()
        {
            Coordinate landingRequest = new Coordinate(5, 5);
            SquareArea sa = AreasService.CreateSafetyArea(landingRequest);
            Assert.IsTrue(AreasService.IsCoordinateInside(sa, new Coordinate(4, 4)));
            Assert.IsFalse(AreasService.IsCoordinateInside(sa, new Coordinate(11, 11)));
        }
    }
}
