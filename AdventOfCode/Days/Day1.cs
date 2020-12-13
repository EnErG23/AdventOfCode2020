using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day1
    {
        public static List<int> inputs = InputManager.GetInputAsInts(1);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 1 ({ms}ms)");
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

            foreach (int x in inputs)
            {
                foreach (int y in inputs)
                {
                    if (x + y == 2020) result = x * y;

                    if (result != 0) break;
                }
                if (result != 0) break;
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            foreach (int x in inputs)
            {
                foreach (int y in inputs)
                {
                    foreach (int z in inputs)
                    {
                        if (x + y + z == 2020) result = x * y * z;

                        if (result != 0) break;
                    }
                    if (result != 0) break;
                }
                if (result != 0) break;
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
