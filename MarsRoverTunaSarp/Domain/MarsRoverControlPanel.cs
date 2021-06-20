using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverTunaSarp.Interfaces;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    public class MarsRoverControlPanel
    {

        public MarsRoverControlPanel()
        {
        }

        internal void start()
        {
            Console.WriteLine("Welcome to Mars Rover Panel");

            bool isDone = false;

            while (!isDone)
            {

                Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <positive number> <positive number> like : '5 5' )");
Step1:
                var upperRightCoordinatesInput = Console.ReadLine();
                var plateau = InputService.getInstance.ProcessPlateauInput(upperRightCoordinatesInput);
                if (plateau == null)
                {
                    Console.WriteLine("Invalid argument has been detected, please try again : (ex: <positive number> <positive number> like : '5 5' )");
                    goto Step1;
                }

                Console.WriteLine("Please provide initial coordinates(x,y) for the rover [ 'E': East, 'W': West, 'S': South, 'N': North ]: (ex: <number> <number> <direction> like : '1 2 N') :");
Step2:
                var initialRoverPositionInput = Console.ReadLine();
                var initialRoverPosition = InputService.getInstance.ProcessRoverCoordinatesInput(initialRoverPositionInput);
                if (initialRoverPosition == null)
                {
                    Console.WriteLine("Invalid argument has been detected, please try again : (ex: <number> <nubmer> <direction> like : '1 2 N')");
                    goto Step2;
                }

                Console.WriteLine("Please provide exploration path for the rover [ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]: (ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");
                Step3:
                var explorationRouteInput = Console.ReadLine() ;
                var explorationRoute = InputService.getInstance.IsRoversExplorationPathInputValid(explorationRouteInput);
                if (explorationRoute == null)
                {
                    Console.WriteLine("Invalid argument has been detected, please try again : (ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') ");
                    goto Step3;
                }

                Rover rover = new Rover(initialRoverPosition);
                ExplorationService.getInstance.setRover(rover);
                ExplorationService.getInstance.setPlateau(plateau);
                ExplorationService.getInstance.setRoute(explorationRoute);

                ExplorationService.getInstance.TraceRoute();
                Console.WriteLine(rover.Position.ToString());

                goto Step2;

            }
        }
    }
}
