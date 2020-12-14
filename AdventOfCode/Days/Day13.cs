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
    public class Day13
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(13);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 13 ({ms}ms)");
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

            var timeStamp = Convert.ToInt32(inputs[0]);
            var buses = inputs[1].Replace("x,", "").Split(',').Select(i => Convert.ToInt32(i));

            var iterateTimeStamp = timeStamp;

            while (true)
            {
                foreach (var bus in buses)
                {
                    if (iterateTimeStamp % bus == 0)
                    {
                        result = (iterateTimeStamp - timeStamp) * bus;
                        break;
                    }
                }
                if (result > 0) break;
                iterateTimeStamp++;
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            var oldBuses = inputs[1].Split(',').Select(i => Convert.ToInt32(i.Replace("x", "0"))).ToList();

            var buses = new List<Bus>();

            foreach (var b in oldBuses)
            {
                if (b > 0)
                {
                    Bus bus = new Bus
                    {
                        ID = b,
                        Pos = oldBuses.IndexOf(b)
                    };
                    buses.Add(bus);
                }
            }

            buses = buses.OrderByDescending(b => b.ID).ToList();

            var highestID = buses.First().ID;
            var highestPos = buses.First().Pos;


            buses = buses.Skip(1).ToList();

            long result = highestID;

            while (true)
            {
                Console.WriteLine($"{result}");

                if (buses.Where(b => (result - (highestPos - b.Pos)) % b.ID == 0).Count() == buses.Count()) break;

                result += highestID;
            }

            //// Start poging 2
            //long result = LCM(buses.ToArray()).ID;

            result -= highestPos;

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }

        //static Bus LCM(Bus[] buses)
        //{
        //    return buses.Aggregate(lcm);
        //}

        //static Bus lcm(Bus a, Bus b)
        //{
        //    return new Bus { ID = Math.Abs(a.ID * b.ID) / GCD(a.ID, b.ID, (b.Pos - a.Pos)) };
        //}

        //static long GCD(long a, long b, long offset)
        //{
        //    return b == 0 ? a : GCD(b, a % b, offset);
        //}
    }
}
