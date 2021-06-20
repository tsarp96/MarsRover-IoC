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

        public Position(int x, int y, int direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }


        public void Rotate90Degree()
        {
            var index = direction;
            index++;
            index %= 4;

            direction = index;
        }

        public void RotateMinus90Degree()
        {
            var index = direction;
            index--;
            if (index < 0)
            {
                index = 3;
            }
            direction = index;
        }

        public void Move()
        {
            switch (direction)
            {
                case (int)Compass.N:
                    Y++;
                    break;
                case (int)Compass.E:
                    X++;
                    break;
                case (int)Compass.W:
                    X--;
                    break;
                case (int)Compass.S:
                    Y--;
                    break;
            }
        }

        public override string ToString()
        {
            return  X + " " + Y + " " + (Compass)Direction;
        }
    }
}
