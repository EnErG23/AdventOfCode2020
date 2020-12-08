using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        public static List<string> inputs;
        public static List<int> intInputs;

        static void Main(string[] args)
        {
            Day1Pt1();
            Day1Pt2();

            Day2Pt1();
            Day2Pt2();

            Day3Pt1();
            Day3Pt2();

            Console.Read();
        }

        static void GetInputs(int day)
        {
            inputs = new List<string>();
            intInputs = new List<int>();

            StreamReader file = new StreamReader($@"Inputs\{day}.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                inputs.Add(line);
            }
        }

        static void ConvertInputsToInts()
        {
            intInputs = inputs.Select(i => Convert.ToInt32(i)).ToList();
        }

        static void Day1Pt1()
        {
            GetInputs(1);
            ConvertInputsToInts();

            foreach (int x in intInputs)
            {
                foreach (int y in intInputs)
                {
                    if (x + y == 2020)
                    {
                        Console.WriteLine($"1 - 1: {x * y}");
                        return;
                    }
                }
            }
        }

        static void Day1Pt2()
        {
            GetInputs(1);
            ConvertInputsToInts();

            foreach (int x in intInputs)
            {
                foreach (int y in intInputs)
                {
                    foreach (int z in intInputs)
                    {
                        if (x + y + z == 2020)
                        {
                            Console.WriteLine($"1 - 2: {x * y * z}");
                            return;
                        }
                    }
                }
            }
        }

        static void Day2Pt1()
        {
            GetInputs(2);
            int correctPasswords = 0;

            foreach (string input in inputs)
            {
                var i = input;
                int min = Convert.ToInt32(i.Substring(0, i.IndexOf('-')));

                i = i.Substring(i.IndexOf('-') + 1);
                int max = Convert.ToInt32(i.Substring(0, i.IndexOf(' ')));

                i = i.Substring(i.IndexOf(' ') + 1);
                char letter = Convert.ToChar(i.Substring(0, 1));

                i = i.Substring(i.IndexOf(' ') + 1);
                string password = i;

                var count = password.Count(s => s == letter);

                if (count >= min && count <= max)
                {
                    correctPasswords++;
                }
            }

            Console.WriteLine($"2 - 1: {correctPasswords}");
        }

        static void Day2Pt2()
        {
            GetInputs(2);
            int correctPasswords = 0;

            foreach (string input in inputs)
            {
                var i = input;
                int pos1 = Convert.ToInt32(i.Substring(0, i.IndexOf('-')));

                i = i.Substring(i.IndexOf('-') + 1);
                int pos2 = Convert.ToInt32(i.Substring(0, i.IndexOf(' ')));

                i = i.Substring(i.IndexOf(' ') + 1);
                string letter = i.Substring(0, 1);

                i = i.Substring(i.IndexOf(' ') + 1);
                string password = i;

                var pos1HasChar = password.Substring(pos1 - 1, 1) == letter;
                var pos2HasChar = password.Substring(pos2 - 1, 1) == letter;

                if (pos1HasChar)
                {
                    if (!pos2HasChar)
                    {
                        correctPasswords++;
                    }
                }
                else
                {
                    if (pos2HasChar)
                    {
                        correctPasswords++;
                    }
                }
            }

            Console.WriteLine($"2 - 2: {correctPasswords}");
        }

        static void Day3Pt1()
        {
            GetInputs(3);

            Console.WriteLine($"3 - 1: ");
        }

        static void Day3Pt2()
        {
            GetInputs(3);

            Console.WriteLine($"3 - 2: ");
        }
    }
}
