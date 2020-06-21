
namespace LandingControlSystem
{
    /// <summary>
    /// Main control of the rocket landing control
    /// </summary>
    public class LandingControl
    {
        #region consts
        private const int DefaultLandingAreaSize = 100;
        private const int DefaultLandingPlatformSize = 10;

        private const int LandingAreaTopLeft = 1;
        private const int LandingPlatformTopLeft = 5;
        #endregion consts

        #region properties
        public SquareArea LandingArea { get; set; }
        public SquareArea LandingPlatform { get; set; }
        private SquareArea PreviousRocketLandingPosition { get; set; }
        #endregion properties

        #region Constructors
        /// <summary>
        /// A landing control consists on a landing area and a landing platform.
        /// Initial positions and sizes are fixed here
        /// </summary>
        public LandingControl()
        {
            LandingArea = new SquareArea(new Coordinate(LandingAreaTopLeft, LandingAreaTopLeft), DefaultLandingAreaSize);
            LandingPlatform = new SquareArea(new Coordinate(LandingPlatformTopLeft, LandingPlatformTopLeft), DefaultLandingPlatformSize);
        }

        /// <summary>
        /// Overload of the constructor to allow modify the landing platform size
        /// Initial positions and landing area size are fixed
        /// </summary>
        /// <param name="sizeForLandingPlatform"></param>
        public LandingControl(int sizeForLandingPlatform)
        {
            if (sizeForLandingPlatform + LandingPlatformTopLeft > DefaultLandingAreaSize)
            {
                throw new System.Exception("[ERROR]: Landing platform must be within landing area");
            }
            else
            {
                LandingArea = new SquareArea(new Coordinate(LandingAreaTopLeft, LandingAreaTopLeft), DefaultLandingAreaSize);
                LandingPlatform = new SquareArea(new Coordinate(LandingPlatformTopLeft, LandingPlatformTopLeft), sizeForLandingPlatform);
            }
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Method to control the requests of landing from the rockets
        /// </summary>
        /// <param name="rocketLandingPosition">x,y pair to check</param>
        /// <returns type=string>ok for landing - when there is no problem to land
        ///                      out of the platform - request is outside of landing platform
        ///                      clash - the previous rocket check for the same position or the
        ///                              checked position is within the safety area of the previous
        ///                              rocket
        ///</returns>
        public string LandingRequest(Coordinate rocketLandingPosition)
        {
            string response = string.Empty;

            if (PreviousRocketLandingPosition != null &&
                AreasService.IsCoordinateInside(PreviousRocketLandingPosition, rocketLandingPosition))
            {
                response = Response.CLASH;
            } else if (AreasService.IsCoordinateInside(LandingPlatform, rocketLandingPosition))
            {
                response = Response.OK_FOR_LANDING;
            }
            else
            {
                response = Response.OUT_OF_PLATFORM;
            }
            // we save the request of landing
            PreviousRocketLandingPosition = AreasService.CreateSafetyArea(rocketLandingPosition);
            return response;
        }

        public string LandingRequest(int x, int y)
        {
            return LandingRequest(new Coordinate(x, y));
        }

        #endregion Methods
    }
}
