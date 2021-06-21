using MarsRoverTunaSarp.Domain;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IInputService
    {
        Plateau ProcessPlateauInput(string PlateauInput);

        Position ProcessRoverPositionInput(string roverCoordintesInput);

        string IsRoversExplorationPathInputValid(string explorationMapInput);
    }
}
