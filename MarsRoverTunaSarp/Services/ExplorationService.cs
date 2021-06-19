using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Services
{
    public class ExplorationService : IExplorationService
    {
        private Rover rover;
        private string route;
        private Plateau plateau;

        public ExplorationService(Rover rover, Plateau plateau, string route)
        {
            if (rover == null) throw new ArgumentNullException("Rover not found !");
            if (plateau == null) throw new ArgumentNullException("Plateau not found !");
            if (route == null) throw new ArgumentNullException("Path not found !");

            this.rover = rover;
            this.plateau = plateau;
            this.route = route;
        }

        public Rover Rover { private get => rover; set => rover = value; }
        public string Route { private get => route; set => route = value; }
        internal Plateau Plateau { get => plateau; set => plateau = value; }

        public void TraceRoute()
        {
            foreach (var ch in route.ToCharArray())
            {
                if (ch.Equals('L'))
                {
                    rover.TurnLeft();
                    continue;
                }
                if (ch.Equals('R'))
                {
                    rover.TurnRight();
                    continue;
                }
                if (ch.Equals('M'))
                {
                    rover.Move();
                    checkBoundries(rover.Position, plateau);
                }
            }
        }

        private void checkBoundries(Position position, Plateau plateau)
        {
            if(position.X < plateau.HorizontalLoweLeftBoundry || position.X > plateau.HorizontalUpperRightBoundry
                || position.Y < plateau.VerticalLowerLeftBoundry || position.Y > plateau.VerticalUpperRightBoundry)
            {
                throw new Exception("Boundry breach detected !");
            }
        }
    }
}
