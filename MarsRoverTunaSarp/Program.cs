using System;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {
            RoverPanel panel = new RoverPanel(new InputService());

            panel.start();
        }
    }
}
