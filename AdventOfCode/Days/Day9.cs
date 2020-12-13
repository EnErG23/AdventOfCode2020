using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day9
    {
        public static DateTime start;
        public static DateTime end;
        public static List<long> inputs = InputManager.GetInputAsLongs(9);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 9 ({ms}ms)");
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

            var p = 25;
            var i = p;

            foreach (var input in inputs.Skip(p))
            {
                var preamble = inputs.GetRange(i - p, p);
                var found = false;

                foreach (var pre1 in preamble)
                {
                    foreach (var pre2 in preamble.Where(pr => pr != pre1))
                    {
                        if (pre1 + pre2 == input)
                        {
                            found = true;
                        }
                        if (found) break;
                    }
                    if (found) break;
                }
                if (!found)
                {
                    result = input;
                    break;
                }
                i++;
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            long firstError = 0;
            var p = 25;
            var i = p;

            foreach (var input in inputs.Skip(p))
            {
                var preamble = inputs.GetRange(i - p, p);
                var found = false;

                foreach (var pre1 in preamble)
                {
                    foreach (var pre2 in preamble.Where(pr => pr != pre1))
                    {
                        if (pre1 + pre2 == input)
                        {
                            found = true;
                        }
                        if (found) break;
                    }
                    if (found) break;
                }
                if (!found)
                {
                    firstError = input;
                    break;
                }
                i++;
            }

            long subTotal = 0;
            var a = 0;
            var length = 1;

            foreach (var input1 in inputs)
            {
                subTotal = 0;
                a = inputs.IndexOf(input1);
                length = 1;

                foreach (var input2 in inputs.GetRange(a, inputs.Count() - a))
                {
                    subTotal += input2;

                    if (subTotal > firstError)
                    {
                        break;
                    }

                    if (subTotal == firstError)
                    {
                        result = inputs.GetRange(a, length).OrderBy(inp => inp).First() + inputs.GetRange(a, length).OrderByDescending(inp => inp).First();
                        break;
                    }

                    length++;
                }

                if (result != 0)
                {
                    break;
                }

            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
