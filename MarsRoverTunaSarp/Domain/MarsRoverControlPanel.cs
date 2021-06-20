using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    public class MarsRoverControlPanel
    {

        private List<Rover> rovers;

        private MarsRoverControlPanel()
        {
            this.rovers = new List<Rover>();
        }
        private static MarsRoverControlPanel instance = null;
        public static MarsRoverControlPanel getInstance
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

        internal void start()
        {
            Console.WriteLine("Welcome to Mars Rover Panel");

            bool isDone = false;

            while (!isDone)
            {
Step1:
                Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <positive number> <positive number> like : '5 5' )");

                var upperRightCoordinatesInput = Console.ReadLine();
                Plateau plateau = null;
                try
                {
                    plateau = InputService.getInstance.ProcessPlateauInput(upperRightCoordinatesInput);
                    Console.WriteLine("--------------------------->");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    goto Step1;
                }
                
Step2:
                Console.WriteLine("Please provide initial position for the {0}. rover ", rovers.Count + 1);
                Console.WriteLine("['E': East, 'W': West, 'S': South, 'N': North]");
                Console.WriteLine("(ex: <number> <number> <direction> like : '1 2 N') :");

                var initialRoverPositionInput = Console.ReadLine();
                Position position = null;
                try
                {
                    position = InputService.getInstance.ProcessRoverPositionInput(initialRoverPositionInput);
                    Console.WriteLine("--------------------------->");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    goto Step2;
                }
Step3:
                Console.WriteLine("Please provide exploration path for the {0}. rover : ", rovers.Count + 1);
                Console.WriteLine("[ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]");
                Console.WriteLine("(ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");

                string route = null;
                var explorationRouteInput = Console.ReadLine();
                try
                {
                    route = InputService.getInstance.IsRoversExplorationPathInputValid(explorationRouteInput);
                    Console.WriteLine("--------------------------->");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    goto Step3;
                }

                Rover rover = new Rover(position);
                rovers.Add(rover);
                ExplorationService.getInstance.setRover(rover);
                ExplorationService.getInstance.setPlateau(plateau);
                ExplorationService.getInstance.setRoute(route);

                var result = ExplorationService.getInstance.TraceRoute();
                if (result == ExplorationResult.BoundryBreachDetected)
                {
                    Console.WriteLine("Boundry breach detected, rover stays in place.");
                }
                Console.WriteLine("\n \t \t \t \t >> Final position for the {0}. rover : " + rover.Position.ToString() + " <<" , rovers.Count);
                Console.WriteLine("---------------------------------------");

                goto Step2;

            }
        }
    }
}
