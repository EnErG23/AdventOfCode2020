using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day11
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(11);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 11 ({ms}ms)");
            Console.WriteLine("");
            Console.WriteLine($"    {part1}");
            Console.WriteLine($"    {part2}");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
        }
        
        static string Part1()
        {
            var start = DateTime.Now;

            long result = 0;

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
                    result++;
                }
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;
            
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
                        result++;
                    }
                }
                else
                {
                    if (pos2HasChar)
                    {
                        result++;
                    }
                }
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
