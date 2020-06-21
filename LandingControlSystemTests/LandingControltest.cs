using LandingControlSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LandingControlSystemTests
{
    [TestClass]
    public class LandingControltest
    {
        [TestMethod]
        public void RequestTopCornerPlatform()
        {
            LandingControl control = new LandingControl();

            Coordinate rocket01 = new Coordinate(5, 5);
            Assert.AreEqual(Response.OK_FOR_LANDING, control.LandingRequest(rocket01));
        }

        [TestMethod]
        public void RequestDownCornerPlatform()
        {
            LandingControl control = new LandingControl();

            Coordinate rocket01 = new Coordinate(7, 7);
            Assert.AreEqual(Response.OK_FOR_LANDING, control.LandingRequest(rocket01));
        }

        [TestMethod]
        public void RequestOutButNearPlatform()
        {
            LandingControl control = new LandingControl();

            Coordinate rocket01 = new Coordinate(4, 5);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket01));

            Coordinate rocket02 = new Coordinate(5, 4);
            Assert.AreEqual(Response.CLASH, control.LandingRequest(rocket02));
        }

        [TestMethod]
        public void RequestSomewhereInArea()
        {
            LandingControl control = new LandingControl();

            Coordinate rocket02 = new Coordinate(4, 5);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket02));

            Coordinate rocket03 = new Coordinate(16, 5);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket03));
        }

        [TestMethod]
        public void RequestPreviouslyChecked()
        {
            LandingControl control = new LandingControl();

            Coordinate rocket01 = new Coordinate(16, 5);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket01));

            Coordinate rocket02 = new Coordinate(16, 5);
            Assert.AreEqual(Response.CLASH, control.LandingRequest(rocket02));
        }

        [TestMethod]
        public void RequestPreviouslyCheckedCornerCases()
        {
            LandingControl control = new LandingControl();

            Coordinate rocket01 = new Coordinate(1, 1);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket01));

            Coordinate rocket02 = new Coordinate(1, 1);
            Assert.AreEqual(Response.CLASH, control.LandingRequest(rocket02));

            Coordinate rocket03 = new Coordinate(2, 2);
            Assert.AreEqual(Response.CLASH, control.LandingRequest(rocket03));

            Coordinate rocket04 = new Coordinate(100, 100);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket04));

            Coordinate rocket05 = new Coordinate(100, 100);
            Assert.AreEqual(Response.CLASH, control.LandingRequest(rocket05));

            Coordinate rocket06 = new Coordinate(100, 99);
            Assert.AreEqual(Response.CLASH, control.LandingRequest(rocket06));
        }

        [TestMethod]
        public void RequestByXAndY()
        {
            LandingControl control = new LandingControl();

            Assert.AreEqual(Response.OK_FOR_LANDING, control.LandingRequest(5, 5));

            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(1, 1));

            Assert.AreEqual(Response.CLASH, control.LandingRequest(1, 1));
        }

        [TestMethod]
        public void RequestOutsideArea()
        {
            LandingControl control = new LandingControl();

            // not defined, this could makes sense, also throw a controlled exception
            Coordinate rocket05 = new Coordinate(0, 0);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket05));

            Coordinate rocket06 = new Coordinate(200, 2000);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket06));
        }

        [TestMethod]
        public void BiggerPlatform()
        {
            LandingControl control = new LandingControl(25);

            Coordinate rocket01 = new Coordinate(16, 5);
            Assert.AreEqual(Response.OK_FOR_LANDING, control.LandingRequest(rocket01));

            Coordinate rocket02 = new Coordinate(30, 5);
            Assert.AreEqual(Response.OUT_OF_PLATFORM, control.LandingRequest(rocket02));
        }

        [TestMethod]
        public void TooMuchBiggerPlatform()
        {
            var ex = Assert.ThrowsException<System.Exception>(() => new LandingControl(100));

            Assert.AreEqual("[ERROR]: Landing platform must be within landing area", ex.Message);
        }
    }
}
