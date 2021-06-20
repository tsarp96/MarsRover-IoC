using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Services
{
    public enum ExplorationResult
    {
        BoundryBreachDetected = 0,
        Success = 1
    }
    public class ExplorationService : IExplorationService
    {
        private Rover rover;
        private string route;
        private Plateau plateau;

        private ExplorationService() { }
        private static ExplorationService instance = null;
        public static ExplorationService getInstance
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


        public ExplorationResult TraceRoute()
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
                    if (!IsGoingToBeInPlateauAfterMovement(rover.Position, plateau))
                    {
                        return ExplorationResult.BoundryBreachDetected;
                    }
                    rover.Move();
                }
            }
            return ExplorationResult.Success;
        }

        private bool IsGoingToBeInPlateauAfterMovement(Position position, Plateau plateau)
        {
            var temp = new Position(position.X, position.Y, position.Direction);
            temp.Move();
            if(temp.X < plateau.HorizontalLoweLeftBoundry || temp.X > plateau.HorizontalUpperRightBoundry
                || temp.Y < plateau.VerticalLowerLeftBoundry || temp.Y > plateau.VerticalUpperRightBoundry)
            {
                return false;
            }
            return true;
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
