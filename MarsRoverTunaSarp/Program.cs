using System;
using System.Collections.Generic;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rover> rovers = new List<Rover>();
            MarsRoverControlPanel panel = new MarsRoverControlPanel(rovers);
            panel.start();
        }
    }
}
