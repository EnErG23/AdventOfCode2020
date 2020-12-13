using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day4
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(4);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 4 ({ms}ms)");
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
                passport += " " + input;
            }

            passports.Add(passport);
            
            foreach (string p in passports)
            {
                if (p.Contains("byr:") && p.Contains("iyr:") && p.Contains("eyr:") && p.Contains("hgt:") && p.Contains("hcl:") && p.Contains("ecl:") && p.Contains("pid:"))
                {
                    result++;
                }
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
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
                passport += " " + input;
            }

            passports.Add(passport);
            
            foreach (string p in passports)
            {
                //Console.WriteLine(p);
                if (p.Contains("byr:") && p.Contains("iyr:") && p.Contains("eyr:") && p.Contains("hgt:") && p.Contains("hcl:") && p.Contains("ecl:") && p.Contains("pid:"))
                {
                    bool valid = true;

                    var fields = p.Replace("  ", " ").Substring(1).Split(' ');

                    foreach (var field in fields)
                    {
                        var key = field.Substring(0, field.IndexOf(':'));
                        var value = field.Substring(field.IndexOf(':') + 1);

                        int i = 0;

                        switch (key)
                        {
                            case "byr":
                                if (int.TryParse(value, out i))
                                {
                                    if (Convert.ToInt32(value) > 1919 && Convert.ToInt32(value) < 2003)
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    valid = false;
                                    //Console.WriteLine($"{key}:{value}");
                                }
                                break;
                            case "iyr":
                                if (int.TryParse(value, out i))
                                {
                                    if (Convert.ToInt32(value) > 2009 && Convert.ToInt32(value) < 2021)
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine($"{key}:{value}");
                                    valid = false;
                                }
                                break;
                            case "eyr":
                                if (int.TryParse(value, out i))
                                {
                                    if (Convert.ToInt32(value) > 2019 && Convert.ToInt32(value) < 2031)
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine($"{key}:{value}");
                                    valid = false;
                                }
                                break;
                            case "hgt":
                                if (value.Contains("cm"))
                                {
                                    if (int.TryParse(value.Replace("cm", ""), out i))
                                    {
                                        if (Convert.ToInt32(value.Replace("cm", "")) > 149 && Convert.ToInt32(value.Replace("cm", "")) < 194)
                                        {
                                            valid = true;
                                        }
                                        else
                                        {
                                            //Console.WriteLine($"{key}:{value}");
                                            valid = false;
                                        }
                                    }
                                }
                                else if (value.Contains("in"))
                                {
                                    if (int.TryParse(value.Replace("in", ""), out i))
                                    {
                                        if (Convert.ToInt32(value.Replace("in", "")) > 58 && Convert.ToInt32(value.Replace("in", "")) < 77)
                                        {
                                            valid = true;
                                        }
                                        else
                                        {
                                            //Console.WriteLine($"{key}:{value}");
                                            valid = false;
                                        }
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine($"{key}:{value}");
                                    valid = false;
                                }
                                break;
                            case "hcl":
                                if (value.Substring(0, 1) == "#")
                                {
                                    if (value.Substring(1).Count() == 6)
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine($"{key}:{value}");
                                    valid = false;
                                }
                                break;
                            case "ecl":
                                List<string> possibleValues = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                                if (possibleValues.Contains(value))
                                {
                                    valid = true;
                                }
                                else
                                {
                                    //Console.WriteLine($"{key}:{value}");
                                    valid = false;
                                }
                                break;
                            case "pid":
                                if (int.TryParse(value, out i))
                                {
                                    if (value.Count() == 9)
                                    {
                                        valid = true;
                                    }
                                    else
                                    {
                                        //Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine($"{key}:{value}");
                                    valid = false;
                                }
                                break;
                            default:
                                break;
                        }

                        if (!valid) break;
                    }

                    if (valid)
                    {
                        result++;
                    }
                }
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
