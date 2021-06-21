using MarsRoverTunaSarp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverTunaSarp.Domain;
using MarsRoverTunaSarp.Enum;

namespace MarsRoverTunaSarp.Services
{
    public class InputService : IInputService
    {
        private InputService() { }
        private static InputService _instance = null;
        public static InputService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputService();
                }
                return _instance;
            }
        }
        public Plateau ProcessPlateauInput(string input)
        {
            var result = new int[2];
            var items = input.Trim().Split(' ');
            if (items.Length != 2)
            {
                throw new ArgumentException("This process requires 2 arguments");
            }
            for(int i=0; i<2; i++)
            {
                if (!int.TryParse(items[i], out int value))
                {
                    throw new ArgumentException("Non numeric argument is detected");
                }
                if(value == 0)
                {
                    throw new ArgumentException("Plateau can not be one dimensional");
                }
                if(value < 0)
                {
                    throw new ArgumentException("Negative argument is detected");
                }
                result[i] = value;
            }
            return new Plateau(result[0], result[1]);
        }

        public Position ProcessRoverPositionInput(string input)
        {
            var result = new int[2];
            var validLetters = new List<string>() { "E", "W", "S", "N" };
            var items = input.Trim().ToUpper().Split(' ');
            if (items.Length != 3)
            {
                throw new ArgumentException("This process requires 3 arguments");
            }
            for (int i = 0; i < 2; i++)
            {
                if (!int.TryParse(items[i], out int value))
                {
                    throw new ArgumentException("Non numeric argument is detected");
                }
                if(value < 0)
                {
                    throw new ArgumentException("Negative argument is detected");
                }
                result[i] = value;
            }
            if (!validLetters.Contains(items[2]))
            {
                throw new ArgumentException("Invalid letter is detected for direction");
            }
            return new Position( result[0], result[1], (int)System.Enum.Parse(typeof(Compass), items[2]) );
        }

        public string IsRoversExplorationPathInputValid(string explorationMapInput)
        {
            if (string.IsNullOrWhiteSpace(explorationMapInput) || string.IsNullOrEmpty(explorationMapInput))
            {
                throw new ArgumentException();
            }
            var preparedInput = explorationMapInput.Trim().ToUpper();
            var validLetters = new List<string>() { "L", "R", "M" };
            if (preparedInput.ToCharArray().Any(ch => !validLetters.Contains(ch.ToString())))
            {
                throw new ArgumentException("Invalid letter is detected for cardinal compass");
            }
            return preparedInput;
        }
    }
}
