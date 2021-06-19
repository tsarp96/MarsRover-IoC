using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Services
{
    public class ExplorationService
    {
        private IDrivingOperator rover;
        private string route;
        public ExplorationService(IDrivingOperator rover, string path)
        {
            this.Rover = rover;
            this.Route = path;
        }

        public IDrivingOperator Rover { private get => rover; set => rover = value; }
        public string Route { private get => route; set => route = value; }

        public void TraceRoute()
        {
            foreach (var ch in route.ToCharArray())
            {
                if (ch.Equals('L'))
                {
                    rover.TurnLeft();
                    continue;
                }
                if (ch.Equals('R'))
                {
                    rover.TurnRight();
                    continue;
                }
                if (ch.Equals('M'))
                {
                    rover.Move();
                }
            }
        }
    }
}
