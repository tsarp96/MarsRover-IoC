namespace MarsRoverTunaSarp.Domain
{
    public class Plateau
    {
        public int HorizontalUpperRightBoundary { get; }
        public int VerticalUpperRightBoundary { get; }
        public int HorizontalLowerLeftBoundary { get; }
        public int VerticalLowerLeftBoundary { get; }


        public Plateau(int horizontalUpperRightBoundary, int verticalUpperRightBoundary, int horizontalLoweLeftBoundary = 0, int verticalLowerLeftBoundary = 0) 
        {
            HorizontalLowerLeftBoundary = horizontalLoweLeftBoundary;
            VerticalLowerLeftBoundary = verticalLowerLeftBoundary;
            HorizontalUpperRightBoundary = horizontalUpperRightBoundary;
            VerticalUpperRightBoundary = verticalUpperRightBoundary;
        }
    }
}
