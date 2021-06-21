using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp
{
    public class Plateau
    {
        public int HorizontalUpperRightBoundry { get; set; }
        public int VerticalUpperRightBoundry { get; set; }
        public int HorizontalLowerLeftBoundry { get; set; }
        public int VerticalLowerLeftBoundry { get; set; }


        public Plateau(int horizontalUpperRightBoundry, int verticalUpperRightBoundry, int horizontalLoweLeftBoundry = 0, int verticalLowerLeftBoundry = 0) 
        {
            this.HorizontalLowerLeftBoundry = horizontalLoweLeftBoundry;
            this.VerticalLowerLeftBoundry = verticalLowerLeftBoundry;
            this.HorizontalUpperRightBoundry = horizontalUpperRightBoundry;
            this.VerticalUpperRightBoundry = verticalUpperRightBoundry;
        }
    }
}
