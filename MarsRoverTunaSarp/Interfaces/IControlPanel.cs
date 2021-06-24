using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IControlPanel
    {
        PanelResult Start();

        void UpdateSquadLimit(int limit);

        List<Rover> GetRovers();
    }
}
