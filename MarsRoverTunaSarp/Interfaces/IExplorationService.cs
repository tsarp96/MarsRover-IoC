using MarsRoverTunaSarp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IExplorationService
    {
        ExplorationResult TraceRoute();

        Rover getRover();

        void setRover(Rover rover);

        Plateau getPlateau();

        void setPlateau(Plateau plateau);

        string getRoute();

        void setRoute(string route);
    }
}
