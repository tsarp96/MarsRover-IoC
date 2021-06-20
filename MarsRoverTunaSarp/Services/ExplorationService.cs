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

        private ExplorationService() { }
        private static ExplorationService instance = null;
        public static ExplorationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExplorationService();
                }
                return instance;
            }
        }


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

        public Rover getRover()
        {
            return this.rover;
        }

        public void setRover(Rover rover)
        {
            this.rover = rover;
        }

        public Plateau getPlateau()
        {
            return this.plateau;
        }

        public void setPlateau(Plateau plateau)
        {
            this.plateau = plateau;
        }

        public string getRoute()
        {
            return this.route;
        }

        public void setRoute(string route)
        {
            this.route = route;
        }
    }
}
