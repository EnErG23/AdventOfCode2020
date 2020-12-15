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
    // PRECAUTION: YOUR SANITY WILL BE AFFECTED BY READING THIS
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

            List<Bus> buses = inputs[1].Split(',')
                              .Select(i => new Bus { ID = Convert.ToInt32(i.Replace("x", "0")), Pos = inputs[1].Split(',').ToList().IndexOf(i) })
                              .Where(b => b.ID > 0)
                              .ToList();

            long[] n = buses.Select(b => b.ID).ToArray();
            long[] a = buses.Select(b => b.ID - b.Pos < 0 ? b.ID - (b.Pos % b.ID) : b.ID - b.Pos).ToArray();

            long result = Solve(n, a);

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }

        public static long Solve(long[] n, long[] a)
        {
            long prod = n.Aggregate(1, (long i, long j) => i * j);
            long p;
            long sm = 0;

            for (long i = 0; i < n.Length; i++)
            {
                p = prod / n[i];
                sm += a[i] * ModularMultiplicativeInverse(p, n[i]) * p;
            }

            return sm % prod;
        }

        private static long ModularMultiplicativeInverse(long a, long mod)
        {
            long b = a % mod;

            for (long x = 1; x < mod; x++)
            {
                if ((b * x) % mod == 1)
                {
                    return x;
                }
            }
            return 1;
        }
    }
}
