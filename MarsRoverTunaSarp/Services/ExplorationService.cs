using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Domain;

namespace MarsRoverTunaSarp.Services
{
    public class ExplorationService : IExplorationService
    {
        private Rover _rover;
        private string _route;
        private Plateau _plateau;

        public ExplorationResult TraceRoute()
        {
            foreach (var ch in _route.ToCharArray())
            {
                if (ch.Equals('L'))
                {
                    _rover.TurnLeft();
                    continue;
                }
                if (ch.Equals('R'))
                {
                    _rover.TurnRight();
                    continue;
                }
                if (ch.Equals('M'))
                {
                    if (IsGoingToBeInPlateauAfterMovement(_rover.Position, _plateau))
                    {
                        return ExplorationResult.BoundaryBreachDetected;
                    }
                    _rover.Move();
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

        private bool IsThereAnyCrossoverBetween(Position roverPosition, Plateau plateau)
        {
            return roverPosition.X < plateau.HorizontalLowerLeftBoundary 
                   || roverPosition.X > plateau.HorizontalUpperRightBoundary
                   || roverPosition.Y < plateau.VerticalLowerLeftBoundary 
                   || roverPosition.Y > plateau.VerticalUpperRightBoundary;
        }

        public void UpdateRover(Rover rover)
        {
            _rover = rover;
        }

        public void UpdatePlateau(Plateau plateau)
        {
            _plateau = plateau;
        }

        public void UpdateRoute(string route)
        {
            _route = route;
        }
    }
}
