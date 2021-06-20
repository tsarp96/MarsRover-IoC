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
            Console.WriteLine("Rover with ID : " + id + " has been declared on plateau, initial position : " + position.ToString());
        }

        public void TurnRight()
        {
            position.Rotate90Degree();
        }

        public void TurnLeft()
        {
            position.RotateMinus90Degree();
        }

        public void Move()
        {
            position.Move();
        }

    }
}
