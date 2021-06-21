using MarsRoverTunaSarp.Enum;

namespace MarsRoverTunaSarp.Domain
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Direction { get; private set; }

        public Position(int x, int y, int direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }


        public void Rotate90Degree()
        {
            var index = Direction;
            index++;
            index %= 4;

            Direction = index;
        }

        public void RotateMinus90Degree()
        {
            var index = Direction;
            index--;
            if (index < 0)
            {
                index = 3;
            }
            Direction = index;
        }

        public void Move()
        {
            switch (Direction)
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
