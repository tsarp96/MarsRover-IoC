using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Domain;

namespace MarsRoverTunaSarp.Services
{
    public class ExplorationService : IExplorationService
    {
        public Rover Rover { get; set; }
        public string Route { get; set; }
        public Plateau Plateau { get; set; }

        private ExplorationService() { }
        private static ExplorationService _instance = null;
        public static ExplorationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExplorationService();
                }
                return _instance;
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
                        return ExplorationResult.BoundaryBreachDetected;
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

        private bool IsThereAnyCrossoverBetween(Position roverPosition, Plateau plateau)
        {
            return roverPosition.X < plateau.HorizontalLowerLeftBoundary 
                   || roverPosition.X > plateau.HorizontalUpperRightBoundary
                   || roverPosition.Y < plateau.VerticalLowerLeftBoundary 
                   || roverPosition.Y > plateau.VerticalUpperRightBoundary;
        }
    }
}
