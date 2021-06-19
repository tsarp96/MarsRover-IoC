using System;
using MarsRoverTunaSarp.Services;

namespace MarsRoverTunaSarp
{
    class Program
    {
        static void Main(string[] args)
        {
            RoverPanel panel = new RoverPanel();
            panel.InputService = new InputService();
            

            Console.WriteLine("Welcome to Mars Rover Panel");
            
            bool isDone = false;
            
            while (!isDone)
            {

                Console.WriteLine("Please provide upper-right coordinates(x,y) of the plateau : (ex: <number> <number> like : '5 5' )");
Step1:
                var upperRightCoordinatesInput = Console.ReadLine();
                var plateauCoordinates = panel.InputService.ProcessPlateauInput(upperRightCoordinatesInput);
                if (plateauCoordinates == null)
                {
                    Console.WriteLine("Invalid argument has been detected, please try again : (ex: <number> <number> like : '5 5' )");
                    goto Step1;
                }

                Console.WriteLine("Please provide initial coordinates(x,y) for the rover [ 'E': East, 'W': West, 'S': South, 'N': North ]: (ex: <number> <nubmer> <direction> like : '1 2 N') :");
Step2:
                var initialRoverPositionInput = Console.ReadLine();
                var initialRoverPosition = panel.InputService.ProcessRoverCoordinatesInput(initialRoverPositionInput);
                if (initialRoverPosition == null)
                {
                    Console.WriteLine("Invalid argument has been detected, please try again : (ex: <number> <nubmer> <direction> like : '1 2 N')");
                    goto Step2;
                }

                Console.WriteLine("Please provide exploration path for the rover [ 'L': Rotate -90 Degree, 'R: Rotate +90 Degree', 'M': Move one unit ]: (ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') :");
Step3:
                var explorationMapInput = Console.ReadLine();
                var explorationMap = panel.InputService.ProcessRoversExplorationPathInput(explorationMapInput);
                if (explorationMap == null)
                {
                    Console.WriteLine("Invalid argument has been detected, please try again : (ex: '<series of capital letters>' like : 'LLMMMRMMLMLLMRRMMM') ");
                    goto Step3;
                }

                IDrivingOperator rover = new Rover(initialRoverPosition);
                panel.ExplorationService = new ExplorationService(rover, explorationMap);
                panel.ExplorationService.TraceRoute();
               

                goto Step2;
                
            }


           
            


            


            
        }
    }
}
