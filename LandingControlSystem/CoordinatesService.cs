namespace LandingControlSystem
{
    /// <summary>
    /// Repository of methods for working with coordinates & areas relationships
    /// </summary>
    public static class AreasService
    { 
        /// <summary>
        /// It creates an adjacent safety area to a given position, including all the nearest
        /// coordinates.
        /// </summary>
        /// <param name="coordinate"> x,y pair to get the safety area</param>
        /// <returns> a square area defining the safety zone</returns>
        public static SquareArea CreateSafetyArea(Coordinate coordinate)
        {
            Coordinate topLeftCorner = new Coordinate(coordinate.X - 1, coordinate.Y - 1) ;
            return new SquareArea(topLeftCorner, 3);
        }

        /// <summary>
        /// Check if a given coordinate belong to the square are
        /// </summary>
        /// <param name="coordinate">Pair of x,y to check</param>
        /// <returns>true if the coordinate belongs and false otherwise</returns>
        public static bool IsCoordinateInside(SquareArea area, Coordinate coordinate)
        {
            Coordinate topLeftCorner = area.TopLeftCorner;
            int size = area.Size;
            return coordinate.X >= topLeftCorner.X &&
                    coordinate.X <= topLeftCorner.X + size - 1 &&
                    coordinate.Y >= topLeftCorner.Y &&
                    coordinate.Y <= topLeftCorner.Y + size - 1;
        }
    }
}
