﻿using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverTunaSarp.Enum;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    public class MarsRoverControlPanel
    {
        private List<Rover> Rovers;
        private Plateau Plateau;
        private Position Position;
        private string Route;

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

        internal void start()
        {
            Console.WriteLine("Welcome to Mars Rover Panel");

            bool IsDone = false;

            while (!IsDone)
            {
Step1:
                try
                {
                    Plateau = RetrievePlateauFromConsole();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    goto Step1;
                }
                
Step2: 
                try
                {
                    Position = RetrievePositionFromConsole();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    goto Step2;
                }
Step3: 
                try
                {
                    Route = RetrieveRouteFromConsole();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("------------------------!!!-------------------------------");
                    goto Step3;
                }

                Rover Rover = new Rover(Position);
                Rovers.Add(Rover);
                ExplorationService.Instance.Rover = Rover;
                ExplorationService.Instance.Plateau = Plateau;
                ExplorationService.Instance.Route = Route;

                var result = ExplorationService.Instance.TraceRoute();
                if (result == ExplorationResult.BoundryBreachDetected)
                {
                    Console.WriteLine("Boundry breach detected, rover stays in place.");
                }
                Console.WriteLine("\n \t \t \t \t >> Final position for the {0}. rover : " + Rover.Position.ToString() + " <<" , Rovers.Count);
                Console.WriteLine("---------------------------------------");

                goto Step2;
            }
        }

        private string RetrieveRouteFromConsole()
        {
            string Route;
            Console.WriteLine("Please provide exploration path for the {0}. rover : ", Rovers.Count + 1);
            Console.WriteLine("[ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]");
            Console.WriteLine("(ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");
            var explorationRouteInput = Console.ReadLine();
            Route = InputService.Instance.IsRoversExplorationPathInputValid(explorationRouteInput);
            Console.WriteLine("--------------------------->");
            return Route;
        }

        private Position RetrievePositionFromConsole()
        {
            Position Position;
            Console.WriteLine("Please provide initial position for the {0}. rover ", Rovers.Count + 1);
            Console.WriteLine("['E': East, 'W': West, 'S': South, 'N': North]");
            Console.WriteLine("(ex: <number> <number> <direction> like : '1 2 N') :");

            var initialRoverPositionInput = Console.ReadLine();
            Position = InputService.Instance.ProcessRoverPositionInput(initialRoverPositionInput);
            Console.WriteLine("--------------------------->");
            return Position;
        }

        private Plateau RetrievePlateauFromConsole()
        {
            Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <positive number> <positive number> like : '5 5' )");
            var UpperRightCoordinatesInput = Console.ReadLine();
            Plateau Plateau = InputService.Instance.ProcessPlateauInput(UpperRightCoordinatesInput);
            Console.WriteLine("--------------------------->");
            return Plateau;
        }
    }
}
