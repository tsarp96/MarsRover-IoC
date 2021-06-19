using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    public class RoverPanel
    {
        private InputService inputService;
        private ExplorationService explorationService;
        public RoverPanel()
        {
            
        }

        public InputService InputService { get => inputService; set => inputService = value; }
        public ExplorationService ExplorationService { get => explorationService; set => explorationService = value; }
    }
}
