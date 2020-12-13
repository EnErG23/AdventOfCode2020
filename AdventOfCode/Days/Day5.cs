﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day5
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(5);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 5 ({ms}ms)");
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
            foreach (var input in inputs)
            {
                var seatID = 0;

                List<int> rows = Enumerable.Range(0, 128).ToList();

                for (int i = 8; i > 1; i--)
                {
                    if (input[8 - i] == 'F')
                    {
                        rows = rows.GetRange(0, rows.Count() / 2);
                    }
                    else
                    {
                        rows = rows.GetRange(rows.Count() / 2, rows.Count() / 2);
                    }
                    //Console.WriteLine(rows[0]);
                }

                List<int> columns = Enumerable.Range(0, 8).ToList();

                for (int i = 4; i > 1; i--)
                {
                    if (input.Substring(7)[4 - i] == 'L')
                    {
                        columns = columns.GetRange(0, columns.Count() / 2);
                    }
                    else
                    {
                        columns = columns.GetRange(columns.Count() / 2, columns.Count() / 2);
                    }
                    //Console.WriteLine(columns[0]);
                }

                seatID = (rows[0] * 8) + columns[0];

                result = Math.Max(result, seatID);
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            List<int> seatIDs = new List<int>();

            foreach (var input in inputs)
            {
                var seatID = 0;

                List<int> rows = Enumerable.Range(0, 128).ToList();

                for (int i = 8; i > 1; i--)
                {
                    if (input[8 - i] == 'F')
                    {
                        rows = rows.GetRange(0, rows.Count() / 2);
                    }
                    else
                    {
                        rows = rows.GetRange(rows.Count() / 2, rows.Count() / 2);
                    }
                }

                List<int> columns = Enumerable.Range(0, 8).ToList();

                for (int i = 4; i > 1; i--)
                {
                    if (input.Substring(7)[4 - i] == 'L')
                    {
                        columns = columns.GetRange(0, columns.Count() / 2);
                    }
                    else
                    {
                        columns = columns.GetRange(columns.Count() / 2, columns.Count() / 2);
                    }
                }

                seatID = (rows[0] * 8) + columns[0];

                seatIDs.Add(seatID);
            }

            List<int> allIDS = Enumerable.Range(9, 1031).ToList();

            result = allIDS.Where(a => a > 79 && a < 927).Where(a => !seatIDs.Contains(a)).First();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
