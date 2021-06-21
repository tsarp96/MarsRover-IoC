using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IRetriever
    {
        string GetPlateauInput();

        string GetRoverPositionInput();

        string GetRouteInput();
    }
}
