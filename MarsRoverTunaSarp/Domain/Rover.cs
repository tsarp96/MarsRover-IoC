using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp
{
    public class Rover 
    {

        private readonly string id;
        private Position position;

        public string Id { get => id; }
        public Position Position { get => position; set => position = value; }

        public Rover(Position initialPosition)
        {
            if (initialPosition == null) throw new ArgumentNullException("Initial Position");
            id = Guid.NewGuid().ToString();
            Position = initialPosition;
            Console.WriteLine("Rover with ID : " + id + " has been declared on plateau with coordinates : " + position.ToString());
        }

        public void TurnRight()
        {
            var index = position.Direction;
            index++;
            index %= 4;

            position.Direction = index;

            Console.WriteLine(position.ToString());
        }

        public void TurnLeft()
        {
            var index = position.Direction;
            index--;
            if (index < 0)
            {
                index = 3;
            }
            position.Direction = index;

            Console.WriteLine(position.ToString());
        }

        public void Move()
        {
            switch (position.Direction)
            {
                case (int)Compass.N:
                    position.Y++;
                    break;
                case (int)Compass.E:
                    position.X++;
                    break;
                case (int)Compass.W:
                    position.X--;
                    break;
                case (int)Compass.S:
                    position.Y--;
                    break;
            }
            Console.WriteLine(position.ToString());
        }

    }
}
