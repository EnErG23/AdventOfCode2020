using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day6
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(6);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 6 ({ms}ms)");
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

            List<string> passports = new List<string>();
            string passport = "";

            foreach (string input in inputs)
            {
                if (input == "")
                {
                    passports.Add(passport);
                    passport = "";
                }
                passport += input;
            }

            passports.Add(passport);

            result = passports.Select(p => p.Distinct().Count()).Sum();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            List<string> passports = new List<string>();
            string passport = "";

            bool reset = true;

            foreach (string input in inputs)
            {
                if (input == "")
                {
                    passports.Add(passport);
                    passport = "";
                    reset = true;
                }
                else
                {
                    if (reset)
                    {
                        passport = input;
                        reset = false;
                    }
                    else
                    {
                        var ppLetters = passport.Distinct();
                        foreach (var letter in ppLetters)
                        {
                            if (!input.Contains(letter))
                            {
                                passport = passport.Replace(letter.ToString(), "");
                            }
                        }

                        var letters = input.Distinct();
                        foreach (var letter in letters)
                        {
                            if (!passport.Contains(letter))
                            {
                                passport = passport.Replace(letter.ToString(), "");
                            }
                        }
                    }
                }
            }

            passports.Add(passport);

            result = passports.Select(p => p.Distinct().Count()).Sum();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
