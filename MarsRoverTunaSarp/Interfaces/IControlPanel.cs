using MarsRoverTunaSarp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Interfaces
{
    public interface IControlPanel
    {
        void Start();

        void UpdateSquadLimit(int limit);

        List<Rover> GetRovers();
    }
}
