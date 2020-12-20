using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day15
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(15);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 15 ({ms}ms)");
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

            List<long> spokenNumbers = new List<long>();

            spokenNumbers.AddRange(inputs[0].Split(',').Select(i => Convert.ToInt64(i)).ToList());

            for (int i = spokenNumbers.Count(); i < 2020; i++)
            {
                var number = 0;

                if (spokenNumbers.Count(s => s == spokenNumbers[i - 1]) > 1)
                {
                    number = i - 1 - spokenNumbers.Take(spokenNumbers.Count() - 1).ToList().LastIndexOf(spokenNumbers[i - 1]);
                }

                if (i % 10000 == 0) Console.WriteLine($"{i})    Prev: {spokenNumbers[i - 1]}, Pos: {spokenNumbers.Take(spokenNumbers.Count() - 1).ToList().LastIndexOf(spokenNumbers[i - 1])} => {number}");
                spokenNumbers.Add(number);
            }

            result = spokenNumbers.Last();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            var spokenNumbers = inputs[0].Split(',').Select(i => Convert.ToInt64(i)).ToArray();

            //init array length 30m
            var rounds = 30000000;
            var numbers = new long[rounds];

            //enter initial values
            for (int i = 0; i < spokenNumbers.Count()-1; i++)
            {
                numbers[spokenNumbers[i]] = i+1;
                Console.WriteLine($"{spokenNumbers[i]} => numbers[{spokenNumbers[i]}] = {i+1}");
            }

            //start with last value
            var pos = 6;
            var init = spokenNumbers.Last();

            //update array
            while (pos <= rounds)
            {
                long initNew = 0;

                if (numbers[init] != 0)
                    initNew = pos - numbers[init];

                numbers[init] = pos;
                init = initNew;
                pos++;
            }

            result = numbers.ToList().IndexOf(rounds);

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
