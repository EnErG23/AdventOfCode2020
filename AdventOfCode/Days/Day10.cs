using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day10
    {
        public static DateTime start;
        public static DateTime end;
        public static List<int> inputs = InputManager.GetInputAsInts(10);

        public static void Run()
        {
            var start = DateTime.Now;

            inputs.Add(0);
            inputs = inputs.OrderBy(i => i).ToList();
            inputs.Add(inputs[inputs.Count() - 1] + 3);

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 10 ({ms}ms)");
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
            
            var a = 0;
            var ones = 0;
            var threes = 0;

            foreach (var intInput in inputs.Skip(1))
            {
                var difference = intInput - inputs[a];

                if (difference == 1) ones++;
                else if (difference == 3) threes++;

                a++;
            }

            result = ones * threes;

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;            

            long result = 1;

            var count = 0;
            var a = 0;

            foreach (var l in inputs.Skip(1).Take(inputs.Count() - 2))
            {
                if (inputs[a + 2] - inputs[a] < 4)
                {
                    count++;
                }
                else
                {
                    if (count > 0)
                    {
                        var fact = count;

                        for (var i = count - 1; i >= 1; i--)
                        {
                            fact = fact * i;
                        }

                        if (l - inputs[a - count] < 4)
                        {
                            fact++;
                        }

                        if (count > 1)
                        {
                            fact++;
                        }

                        result *= fact;

                        count = 0;
                    }
                }

                a++;
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
