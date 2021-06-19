using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp
{
    public class Position
    {
        private int x;
        private int y;
        private int direction;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Direction { get => direction; set => direction = value; }

        public override string ToString()
        {
            return  "X: " + x + " Y:  " + y + " Direction: " + (Compass)Direction;
        }
    }
}
