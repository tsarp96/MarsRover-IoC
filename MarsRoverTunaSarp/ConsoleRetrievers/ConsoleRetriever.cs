using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.ConsoleRetrievers
{
    public class ConsoleRetriever : IRetriever
    {
        public ConsoleRetriever() { }

        public string GetPlateauInput()
        {
            return Console.ReadLine();
        }

        public string GetRoverPositionInput()
        {
            return Console.ReadLine();
        }

        public string GetRouteInput()
        {
            return Console.ReadLine();
        }
    }
}
