using System;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {

            MarsRoverControlPanel panel = new MarsRoverControlPanel();

            panel.start();
        }
    }
}
