using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Enum;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IExplorationService
    {
        ExplorationResult TraceRoute();

        void UpdateRover(Rover rover);

        void UpdatePlateau(Plateau plateau);

        void UpdateRoute(string route);
    }
}
