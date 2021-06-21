using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;
using MarsRoverTunaSarp.ConsoleRetrievers;

namespace MarsRoverTunaSarp
{
    public class MarsRoverControlPanel
    {
        public List<Rover> Rovers { get; set; }
        public int SquadLimit { get; set; }
        public IRetriever ConsoleRetriever { get; set; }
        private MarsRoverControlPanel()
        {
            this.Rovers = new List<Rover>();
        }
        private static MarsRoverControlPanel instance = null;
        public static MarsRoverControlPanel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MarsRoverControlPanel();
                }
                return instance;
            }
        }

        public void start()
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
                    Rover Rover = new Rover(RetrieveAndPreparePositionFromConsole());
                    Rovers.Add(Rover);
                    ExplorationService.Instance.Rover = Rover;
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
                if (result == ExplorationResult.BoundryBreachDetected)
                {
                    Console.WriteLine("Boundry breach detected, rover stays in place.");
                }
                Console.WriteLine("\n \t \t \t \t >> Final position for the {0}. rover : " + Rovers[i].Position.ToString() + " <<" , Rovers.Count);
                Console.WriteLine("---------------------------------------");

                if (Rovers.Count == 2) 
                {
                    break;
                }
            }
        }

        public string RetrieveAndPrepareRouteFromConsole()
        {
            string Route;
            Console.WriteLine("Please provide exploration path for the {0}. rover : ", Rovers.Count + 1);
            Console.WriteLine("[ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]");
            Console.WriteLine("(ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");
            var explorationRouteInput = ConsoleRetriever.GetRouteInput();
            Route = InputService.Instance.IsRoversExplorationPathInputValid(explorationRouteInput);
            Console.WriteLine("--------------------------->");
            return Route;
        }

        public Position RetrieveAndPreparePositionFromConsole()
        {
            Position Position;
            Console.WriteLine("Please provide initial position for the {0}. rover ", Rovers.Count + 1);
            Console.WriteLine("['E': East, 'W': West, 'S': South, 'N': North]");
            Console.WriteLine("(ex: <number> <number> <direction> like : '1 2 N') :");

            var initialRoverPositionInput = ConsoleRetriever.GetRoverPositionInput();
            Position = InputService.Instance.ProcessRoverPositionInput(initialRoverPositionInput);
            Console.WriteLine("--------------------------->");
            return Position;
        }

        public Plateau RetrieveAndPreparePlateauFromConsole()
        {
            Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <positive number> <positive number> like : '5 5' )");
            var UpperRightCoordinatesInput = ConsoleRetriever.GetPlateauInput();
            Plateau Plateau = InputService.Instance.ProcessPlateauInput(UpperRightCoordinatesInput);
            Console.WriteLine("--------------------------->");
            return Plateau;
        }
    }
}
