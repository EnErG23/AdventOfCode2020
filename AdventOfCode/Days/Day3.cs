using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day3
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(3);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 3 ({ms}ms)");
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
            
            var c = 30;

            var i = 3;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    result++;
                }

                i += 3;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 1;
            var c = 30;

            //1-1
            var tempTrees = 0;
            var i = 1;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 1;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            result = result * tempTrees;

            //3-1
            tempTrees = 0;
            i = 3;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 3;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            result = result * tempTrees;

            //5-1
            tempTrees = 0;
            i = 5;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 5;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            result = result * tempTrees;

            //7-1
            tempTrees = 0;
            i = 7;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 7;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            result = result * tempTrees;

            //1-2
            tempTrees = 0;
            i = 1;
            bool skip = false;
            foreach (var input in inputs.Skip(2))
            {
                if (skip)
                {
                    skip = false;
                    continue;
                }

                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 1;

                if (i > c)
                {
                    i -= (c + 1);
                }

                skip = true;
            }
            result = result * tempTrees;

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
