using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp
{
    public class Plateau
    {
        private int horizontalUpperRightBoundry;
        private int verticalUpperRightBoundry;
        private int horizontalLoweLeftBoundry;
        private int verticalLowerLeftBoundry;

        
        public Plateau(int horizontalUpperRightBoundry, int verticalUpperRightBoundry, int horizontalLoweLeftBoundry = 0, int verticalLowerLeftBoundry = 0) 
        {
            this.horizontalLoweLeftBoundry = horizontalLoweLeftBoundry;
            this.verticalLowerLeftBoundry = verticalLowerLeftBoundry;
            this.horizontalUpperRightBoundry = horizontalUpperRightBoundry;
            this.verticalUpperRightBoundry = verticalUpperRightBoundry;
        }


        public int HorizontalUpperRightBoundry { get => horizontalUpperRightBoundry; set => horizontalUpperRightBoundry = value; }
        public int VerticalUpperRightBoundry { get => verticalUpperRightBoundry; set => verticalUpperRightBoundry = value; }
        public int HorizontalLoweLeftBoundry { get => horizontalLoweLeftBoundry; set => horizontalLoweLeftBoundry = value; }
        public int VerticalLowerLeftBoundry { get => verticalLowerLeftBoundry; set => verticalLowerLeftBoundry = value; }
    }
}
