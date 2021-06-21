using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.ConsoleRetrievers
{
    public class ConsoleRetriever : IRetriever
    {

        private ConsoleRetriever() { }
        private static ConsoleRetriever instance = null;
        public static ConsoleRetriever Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleRetriever();
                }
                return instance;
            }
        }

        public virtual string GetPlateauInput()
        {
            return Console.ReadLine();
        }

        public virtual string GetRoverPositionInput()
        {
            return Console.ReadLine();
        }

        public virtual string GetRouteInput()
        {
            return Console.ReadLine();
        }
    }
}
