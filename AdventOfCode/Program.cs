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
        public static DateTime start;

        public static List<string> inputs = InputManager.GetInput(11);

        static void Main(string[] args)
        {
            start = DateTime.Now;

            //Day1.Run(); // To Optimise
            //Day2.Run(); // To Clean
            //Day3.Run(); // To Clean
            //Day4.Run(); // To Clean
            //Day5.Run(); // To Clean
            //Day6.Run(); // To Clean
            //Day7.Run(); // To Clean
            //Day8.Run(); // To Clean
            //Day9.Run(); // To Clean
            //Day10.Run(); // To Clean
            ////Day11.Run(); // To Move
            //Day12.Run(); // To Clean
            //Day13.Run(); // To Clean
            Day14.Run(); // To Clean // PART 2 => ÜBERSLOW
            //Day15.Run(); // To Clean
            //Day16.Run(); // To Clean
            Day17.Run(); // To Clean // PART 2 => ÜBERSLOW
            //Day18.Run(); // To Clean
            //Day19.Run(); // To Clean
            //Day20.Run();

            ////DAY 11
            //Day11Pt1();
            //Day11Pt2();

            var time = DateTime.Now - start;

            Console.WriteLine($"(All days completed in {time.Minutes}m {time.Seconds}s {time.Milliseconds}ms)");

            Console.Read();
        }
        
        //DAY 11
        static void Day11Pt1()
        {
            var seats = inputs.Select(i => i.ToList()).ToList();

            var change = true;
            var rule1 = false;

            while (change)
            {
                Console.Clear();

                foreach (var s in seats)
                {
                    Console.WriteLine(string.Join("", s));
                }

                Console.WriteLine("");

                var newSeats = new List<List<char>>();

                change = false;
                rule1 = !rule1;

                for (int i = 0; i < seats.Count(); i++)
                {
                    var newRow = new List<char>();

                    for (int j = 0; j < seats[0].Count(); j++)
                    {
                        var seat = seats[i][j];

                        if (seat == '.')
                        {
                            newRow.Add('.');
                            continue;
                        }

                        var adjacentSeats = "";

                        try { adjacentSeats += seats[i - 1][j]; } catch { }         //U
                        try { adjacentSeats += seats[i - 1][j + 1]; } catch { }     //RU
                        try { adjacentSeats += seats[i][j + 1]; } catch { }         //R
                        try { adjacentSeats += seats[i + 1][j + 1]; } catch { }     //RD
                        try { adjacentSeats += seats[i + 1][j]; } catch { }         //D
                        try { adjacentSeats += seats[i + 1][j - 1]; } catch { }     //LD
                        try { adjacentSeats += seats[i][j - 1]; } catch { }         //L
                        try { adjacentSeats += seats[i - 1][j - 1]; } catch { }     //LU

                        if (rule1)
                        {
                            if (seat == 'L')
                            {
                                if (!adjacentSeats.Contains('#'))
                                {
                                    change = true;
                                    newRow.Add('#');
                                }
                                else
                                {
                                    newRow.Add('L');
                                }
                            }
                            else
                            {
                                newRow.Add('#');
                            }
                        }
                        else
                        {
                            if (seat == '#')
                            {
                                if (adjacentSeats.Count(a => a == '#') > 3)
                                {
                                    change = true;
                                    newRow.Add('L');
                                }
                                else
                                {
                                    newRow.Add('#');
                                }
                            }
                            else
                            {
                                newRow.Add('L');
                            }
                        }

                        //Console.WriteLine($"{seat} => {adjacentSeats}");

                        //foreach (var s in newSeats)
                        //{
                        //    Console.WriteLine(string.Join("", s));
                        //}

                        //Console.WriteLine("");
                    }
                    newSeats.Add(newRow);
                }
                seats = newSeats;
            }

            var totalOccupied = seats.Sum(r => r.Count(s => s == '#'));

            Console.WriteLine($"11 - 1: {totalOccupied}");
        }

        static void Day11Pt2()
        {
            var seats = inputs.Select(i => i.ToList()).ToList();

            var change = true;
            var rule1 = false;

            while (change)
            {
                Console.Clear();

                foreach (var s in seats)
                {
                    Console.WriteLine(string.Join("", s));
                }

                Console.WriteLine("");

                var newSeats = new List<List<char>>();

                change = false;
                rule1 = !rule1;

                for (int i = 0; i < seats.Count(); i++)
                {
                    var newRow = new List<char>();

                    for (int j = 0; j < seats[0].Count(); j++)
                    {
                        var seat = seats[i][j];

                        if (seat == '.')
                        {
                            newRow.Add('.');
                            continue;
                        }

                        var adjacentSeats = "";

                        //U
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i - offset][j];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //RU
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i - offset][j + offset];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //R
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i][j + offset];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //RD
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i + offset][j + offset];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //D
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i + offset][j];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //LD
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i + offset][j - offset];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //L
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i][j - offset];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        //LU
                        try
                        {
                            var noSeat = true;
                            var offset = 0;

                            while (noSeat)
                            {
                                offset++;
                                var checkSeat = seats[i - offset][j - offset];
                                if (checkSeat == 'L' || checkSeat == '#')
                                {
                                    if (checkSeat == '#') adjacentSeats += checkSeat;
                                    noSeat = false;
                                }
                            }
                        }
                        catch { }

                        if (rule1)
                        {
                            if (seat == 'L')
                            {
                                if (!adjacentSeats.Contains('#'))
                                {
                                    change = true;
                                    newRow.Add('#');
                                }
                                else
                                {
                                    newRow.Add('L');
                                }
                            }
                            else
                            {
                                newRow.Add('#');
                            }
                        }
                        else
                        {
                            if (seat == '#')
                            {
                                if (adjacentSeats.Count() > 4)
                                {
                                    change = true;
                                    newRow.Add('L');
                                }
                                else
                                {
                                    newRow.Add('#');
                                }
                            }
                            else
                            {
                                newRow.Add('L');
                            }
                        }
                    }
                    newSeats.Add(newRow);
                }
                seats = newSeats;
            }

            var totalOccupied = seats.Sum(r => r.Count(s => s == '#'));

            Console.WriteLine($"11 - 2: {totalOccupied}");
        }        
    }
}
