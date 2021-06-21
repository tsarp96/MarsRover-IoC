using System;

namespace MarsRoverTunaSarp.Domain
{
    public class Rover 
    {
        private string _id;
        public Position Position { get; }
        public Rover(Position initialPosition)
        {
            _id = Guid.NewGuid().ToString();
            this.Position = initialPosition ?? throw new ArgumentNullException("Initial Position");
            Console.WriteLine("Rover with ID : " + _id + " has been declared on plateau, initial position : " + Position.ToString());
        }

        public void TurnRight()
        {
            Position.Rotate90Degree();
        }

        public void TurnLeft()
        {
            Position.RotateMinus90Degree();
        }

        public void Move()
        {
            Position.Move();
        }

    }
}
