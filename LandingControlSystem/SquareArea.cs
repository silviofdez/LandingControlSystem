namespace LandingControlSystem
{
    /// <summary>
    /// Definition of square area. Width and height are supposed to be the same size
    /// </summary>
    public class SquareArea
    {
        public Coordinate TopLeftCorner { get; set; }

        public int Size { get; set; }

        /// <summary>
        /// To create a square we just need the topLeftCorner and the size
        /// </summary>
        /// <param name="topLeftCorner" type=Coordinate>x,y pair of the top left corner</param>
        /// <param name="size" type=int>vertial and horizontal size, in blank units</param>
        public SquareArea(Coordinate topLeftCorner, int size)
        {
            TopLeftCorner = topLeftCorner;
            Size = size;
        }
    }
}
