using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Services
{
    public class ExplorationService : IExplorationService
    {
        public Rover Rover { get; set; }
        public string Route { get; set; }
        public Plateau Plateau { get; set; }

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


        public ExplorationResult TraceRoute()
        {
            foreach (var ch in Route.ToCharArray())
            {
                if (ch.Equals('L'))
                {
                    Rover.TurnLeft();
                    continue;
                }
                if (ch.Equals('R'))
                {
                    Rover.TurnRight();
                    continue;
                }
                if (ch.Equals('M'))
                {
                    if (IsGoingToBeInPlateauAfterMovement(Rover.Position, Plateau))
                    {
                        return ExplorationResult.BoundryBreachDetected;
                    }
                    Rover.Move();
                }
            }
            return ExplorationResult.Success;
        }

        private bool IsGoingToBeInPlateauAfterMovement(Position position, Plateau plateau)
        {
            var temp = new Position(position.X, position.Y, position.Direction);
            temp.Move();
            return IsThereAnyCrossoverBetween(temp, plateau);
        }

        private bool IsThereAnyCrossoverBetween(Position RoverPosition, Plateau plateau)
        {
            return RoverPosition.X < plateau.HorizontalLowerLeftBoundry || RoverPosition.X > plateau.HorizontalUpperRightBoundry
                 || RoverPosition.Y < plateau.VerticalLowerLeftBoundry || RoverPosition.Y > plateau.VerticalUpperRightBoundry;
        }
    }
}
