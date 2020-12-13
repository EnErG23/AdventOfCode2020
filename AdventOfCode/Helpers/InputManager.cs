using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class InputManager
    {
        public static List<string> GetInput(int day)
        {
            var inputs = new List<string>();

            StreamReader file = new StreamReader($@"Inputs\{day}.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                inputs.Add(line);
            }

            return inputs;
        }

        public static List<int> GetInputAsInts(int day)
        {
            return GetInput(day).Select(i => int.Parse(i)).ToList();
        }

        public static List<long> GetInputAsLongs(int day)
        {
            return GetInput(day).Select(i => long.Parse(i)).ToList();
        }
    }
}
