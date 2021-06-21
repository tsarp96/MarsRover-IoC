using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.ConsoleRetrievers
{
    public class ConsoleRetriever : IRetriever
    {

        private ConsoleRetriever() { }
        private static ConsoleRetriever _instance = null;
        public static ConsoleRetriever Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConsoleRetriever();
                }
                return _instance;
            }
        }

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
