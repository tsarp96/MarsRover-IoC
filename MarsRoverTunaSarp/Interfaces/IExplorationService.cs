using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IExplorationService
    {
        ExplorationResult TraceRoute();
    }
}
