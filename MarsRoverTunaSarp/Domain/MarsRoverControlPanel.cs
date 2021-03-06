using System;
using System.Collections.Generic;
using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using Unity;

namespace MarsRoverTunaSarp.Domain
{
    public class MarsRoverControlPanel : IControlPanel
    {
        private List<Rover> _rovers { get; }

        private int _squadLimit;

        private IRetriever _consoleRetriever;

        private IExplorationService _explorationService;

        private IInputService _inputService;

        [InjectionConstructor]
        public MarsRoverControlPanel(IRetriever retriever, IExplorationService explorationService, IInputService inputService, int squadlimit)
        {
            _consoleRetriever = retriever;
            _explorationService = explorationService;
            _squadLimit = squadlimit;
            _inputService = inputService;
            _rovers = new List<Rover>();
        }

        public PanelResult Start()
        {
            Console.WriteLine("Welcome to Mars Rover Panel");

            try
            {
                _explorationService.UpdatePlateau(RetrieveAndPreparePlateauFromConsole());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("------------------------!!!-------------------------------");
                Console.WriteLine("Please restart the program");
                return PanelResult.Fail;
            }

            for (int i = 0; i<_squadLimit; i++)
            {
               
                try
                {
                    var rover = new Rover(RetrieveAndPreparePositionFromConsole());
                    _rovers.Add(rover);
                    _explorationService.UpdateRover(rover);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    Console.WriteLine("Please restart the program");
                    return PanelResult.Fail;
                }

                try
                {

                    _explorationService.UpdateRoute(RetrieveAndPrepareRouteFromConsole());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    Console.WriteLine("Please restart the program");
                    return PanelResult.Fail;
                }

                var result = _explorationService.TraceRoute();
                if (result == ExplorationResult.BoundaryBreachDetected)
                {
                    Console.WriteLine("Boundary breach detected, rover stays in place.");
                }
                Console.WriteLine("\n \t \t \t \t >> Final position for the {0}. rover : " + _rovers[i].Position + " <<" , _rovers.Count);
                Console.WriteLine("---------------------------------------");

            }
            return PanelResult.Success;
        }

        private string RetrieveAndPrepareRouteFromConsole()
        {
            Console.WriteLine("Please provide exploration path for the {0}. rover : ", _rovers.Count + 1);
            Console.WriteLine("[ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]");
            Console.WriteLine("(ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");
            var explorationRouteInput = _consoleRetriever.GetRouteInput();
            var route = _inputService.IsRoversExplorationPathInputValid(explorationRouteInput);
            Console.WriteLine("--------------------------->");
            return route;
        }

        private Position RetrieveAndPreparePositionFromConsole()
        {
            Console.WriteLine("Please provide initial position for the {0}. rover ", _rovers.Count + 1);
            Console.WriteLine("['E': East, 'W': West, 'S': South, 'N': North]");
            Console.WriteLine("(ex: <number> <number> <direction> like : '1 2 N') :");

            var initialRoverPositionInput = _consoleRetriever.GetRoverPositionInput();
            var position = _inputService.ProcessRoverPositionInput(initialRoverPositionInput);
            Console.WriteLine("--------------------------->");
            return position;
        }

        private Plateau RetrieveAndPreparePlateauFromConsole()
        {
            Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <positive number> <positive number> like : '5 5' )");
            var upperRightCoordinatesInput = _consoleRetriever.GetPlateauInput();
            var plateau = _inputService.ProcessPlateauInput(upperRightCoordinatesInput);
            Console.WriteLine("--------------------------->");
            return plateau;
        }

        public void UpdateSquadLimit(int limit)
        {
            _squadLimit = limit;
        }

        public List<Rover> GetRovers()
        {
            return _rovers;
        }
    }
}
