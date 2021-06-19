using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IInputService
    {
        Plateau ProcessPlateauInput(string PlateauInput);

        Position ProcessRoverCoordinatesInput(string roverCoordintesInput);

        string ProcessRoversExplorationPathInput(string explorationMapInput);
    }
}
