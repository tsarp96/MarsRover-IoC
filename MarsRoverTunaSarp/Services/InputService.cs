using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverTunaSarp.Services
{
    public class InputService
    {
        public int[] ProcessPlateauInput(string input)
        {
            var result = new int[2];
            var items = input.Trim().Split(' ');
            if (items.Length != 2)
            {
                return null;
            }
            for(int i=0; i<2; i++)
            {
                if (!int.TryParse(items[i], out int value))
                {
                    return null;
                }
                result[i] = value;
            }
            return result;
        }

        public Position ProcessRoverCoordinatesInput(string input)
        {
            var result = new int[2];
            var validLetters = new List<string>() { "E", "W", "S", "N" };
            var items = input.Trim().Split(' ');
            if (items.Length != 3)
            {
                return null;
            }
            for (int i = 0; i < 2; i++)
            {
                if (!int.TryParse(items[i], out int value))
                {
                    return null;
                }
                result[i] = value;
            }
            if (!validLetters.Contains(items[2]))
            {
                return null;
            }
            

            return new Position() { X = result[0], Y = result[1], Direction = (int)Enum.Parse(typeof(Compass), items[2]) };
        }

        public string ProcessRoversExplorationPathInput(string explorationMapInput)
        {
            var validLetters = new List<string>() { "L", "R", "M"};
            foreach (var ch in explorationMapInput.ToCharArray())
            {
                if (!validLetters.Contains(ch.ToString()))
                {
                    return null;
                }
            }
            return explorationMapInput;
        }
    }
}
