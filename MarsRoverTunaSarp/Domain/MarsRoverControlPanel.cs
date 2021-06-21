using System;
using System.Collections.Generic;
using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp.Domain
{
    public class MarsRoverControlPanel
    {
        public List<Rover> Rovers { get; }
        public int SquadLimit { get; set; }
        public IRetriever ConsoleRetriever { get; set; }
        private MarsRoverControlPanel()
        {
            this.Rovers = new List<Rover>();
        }
        private static MarsRoverControlPanel _instance = null;
        public static MarsRoverControlPanel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MarsRoverControlPanel();
                }
                return _instance;
            }
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Mars Rover Panel");

            try
            {
                ExplorationService.Instance.Plateau = RetrieveAndPreparePlateauFromConsole();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("------------------------!!!-------------------------------");
                Console.WriteLine("Please restart the program");
                return;
            }

            for (int i = 0; i<SquadLimit; i++)
            {
               
                try
                {
                    var rover = new Rover(RetrieveAndPreparePositionFromConsole());
                    Rovers.Add(rover);
                    ExplorationService.Instance.Rover = rover;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    Console.WriteLine("Please restart the program");
                    return;
                }

                try
                {

                    ExplorationService.Instance.Route = RetrieveAndPrepareRouteFromConsole();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    Console.WriteLine("Please restart the program");
                    return;
                }

                var result = ExplorationService.Instance.TraceRoute();
                if (result == ExplorationResult.BoundaryBreachDetected)
                {
                    Console.WriteLine("Boundary breach detected, rover stays in place.");
                }
                Console.WriteLine("\n \t \t \t \t >> Final position for the {0}. rover : " + Rovers[i].Position + " <<" , Rovers.Count);
                Console.WriteLine("---------------------------------------");

                if (Rovers.Count == 2) 
                {
                    break;
                }
            }
        }

        private string RetrieveAndPrepareRouteFromConsole()
        {
            Console.WriteLine("Please provide exploration path for the {0}. rover : ", Rovers.Count + 1);
            Console.WriteLine("[ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]");
            Console.WriteLine("(ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");
            var explorationRouteInput = ConsoleRetriever.GetRouteInput();
            var route = InputService.Instance.IsRoversExplorationPathInputValid(explorationRouteInput);
            Console.WriteLine("--------------------------->");
            return route;
        }

        private Position RetrieveAndPreparePositionFromConsole()
        {
            Console.WriteLine("Please provide initial position for the {0}. rover ", Rovers.Count + 1);
            Console.WriteLine("['E': East, 'W': West, 'S': South, 'N': North]");
            Console.WriteLine("(ex: <number> <number> <direction> like : '1 2 N') :");

            var initialRoverPositionInput = ConsoleRetriever.GetRoverPositionInput();
            var position = InputService.Instance.ProcessRoverPositionInput(initialRoverPositionInput);
            Console.WriteLine("--------------------------->");
            return position;
        }

        private Plateau RetrieveAndPreparePlateauFromConsole()
        {
            Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <positive number> <positive number> like : '5 5' )");
            var upperRightCoordinatesInput = ConsoleRetriever.GetPlateauInput();
            var plateau = InputService.Instance.ProcessPlateauInput(upperRightCoordinatesInput);
            Console.WriteLine("--------------------------->");
            return plateau;
        }
    }
}
