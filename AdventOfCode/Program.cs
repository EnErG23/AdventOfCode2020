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
        public static List<string> inputs;
        public static List<int> intInputs;

        static void Main(string[] args)
        {
            ////DAY 1
            //Day1Pt1();
            //Day1Pt2();

            ////DAY 2
            //Day2Pt1();
            //Day2Pt2();

            ////DAY 3
            //Day3Pt1();
            //Day3Pt2();

            ////DAY 4
            //Day4Pt1();
            //Day4Pt2();

            //DAY 5
            Day5Pt1();
            Day5Pt2();

            Console.Read();
        }

        //DAY 1
        static void Day1Pt1()
        {
            GetInputs(1);
            ConvertInputsToInts();

            foreach (int x in intInputs)
            {
                foreach (int y in intInputs)
                {
                    if (x + y == 2020)
                    {
                        Console.WriteLine($"1 - 1: {x * y}");
                        return;
                    }
                }
            }
        }

        static void Day1Pt2()
        {
            GetInputs(1);
            ConvertInputsToInts();

            foreach (int x in intInputs)
            {
                foreach (int y in intInputs)
                {
                    foreach (int z in intInputs)
                    {
                        if (x + y + z == 2020)
                        {
                            Console.WriteLine($"1 - 2: {x * y * z}");
                            return;
                        }
                    }
                }
            }
        }

        //DAY 2
        static void Day2Pt1()
        {
            GetInputs(2);
            int correctPasswords = 0;

            foreach (string input in inputs)
            {
                var i = input;
                int min = Convert.ToInt32(i.Substring(0, i.IndexOf('-')));

                i = i.Substring(i.IndexOf('-') + 1);
                int max = Convert.ToInt32(i.Substring(0, i.IndexOf(' ')));

                i = i.Substring(i.IndexOf(' ') + 1);
                char letter = Convert.ToChar(i.Substring(0, 1));

                i = i.Substring(i.IndexOf(' ') + 1);
                string password = i;

                var count = password.Count(s => s == letter);

                if (count >= min && count <= max)
                {
                    correctPasswords++;
                }
            }

            Console.WriteLine($"2 - 1: {correctPasswords}");
        }

        static void Day2Pt2()
        {
            GetInputs(2);
            int correctPasswords = 0;

            foreach (string input in inputs)
            {
                var i = input;
                int pos1 = Convert.ToInt32(i.Substring(0, i.IndexOf('-')));

                i = i.Substring(i.IndexOf('-') + 1);
                int pos2 = Convert.ToInt32(i.Substring(0, i.IndexOf(' ')));

                i = i.Substring(i.IndexOf(' ') + 1);
                string letter = i.Substring(0, 1);

                i = i.Substring(i.IndexOf(' ') + 1);
                string password = i;

                var pos1HasChar = password.Substring(pos1 - 1, 1) == letter;
                var pos2HasChar = password.Substring(pos2 - 1, 1) == letter;

                if (pos1HasChar)
                {
                    if (!pos2HasChar)
                    {
                        correctPasswords++;
                    }
                }
                else
                {
                    if (pos2HasChar)
                    {
                        correctPasswords++;
                    }
                }
            }

            Console.WriteLine($"2 - 2: {correctPasswords}");
        }

        //DAY 3
        static void Day3Pt1()
        {
            GetInputs(3);

            Console.WriteLine($"3 - 1: ");
        }

        static void Day3Pt2()
        {
            GetInputs(3);

            Console.WriteLine($"3 - 2: ");
        }

        //DAY 4
        static void Day4Pt1()
        {
            GetInputs(4);

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

            int validPassports = 0;

            foreach (string p in passports)
            {
                Console.WriteLine(p);
                if (p.Contains("byr:") && p.Contains("iyr:") && p.Contains("eyr:") && p.Contains("hgt:") && p.Contains("hcl:") && p.Contains("ecl:") && p.Contains("pid:"))
                {
                    validPassports++;
                    Console.WriteLine("Valid");
                    Console.WriteLine("");
                }
            }

            Console.WriteLine($"4 - 1: {validPassports}");
        }

        static void Day4Pt2()
        {
            GetInputs(4);

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

            int validPassports = 0;

            foreach (string p in passports)
            {
                Console.WriteLine(p);
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
                                        Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    valid = false;
                                    Console.WriteLine($"{key}:{value}");
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
                                        Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{key}:{value}");
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
                                        Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{key}:{value}");
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
                                            Console.WriteLine($"{key}:{value}");
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
                                            Console.WriteLine($"{key}:{value}");
                                            valid = false;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{key}:{value}");
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
                                        Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{key}:{value}");
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
                                    Console.WriteLine($"{key}:{value}");
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
                                        Console.WriteLine($"{key}:{value}");
                                        valid = false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"{key}:{value}");
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
                        validPassports++;
                        Console.WriteLine("Valid");
                    }
                    Console.WriteLine("");
                }
            }

            Console.WriteLine($"4 - 2: {validPassports}");
        }

        //DAY 4
        static void Day5Pt1()
        {
            GetInputs(5);

            Console.WriteLine($"5 - 1: ");
        }

        static void Day5Pt2()
        {
            GetInputs(5);

            Console.WriteLine($"5 - 2: ");
        }

        //AUX METHODS
        static void GetInputs(int day)
        {
            inputs = new List<string>();
            intInputs = new List<int>();

            StreamReader file = new StreamReader($@"Inputs\{day}.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                inputs.Add(line);
            }
        }

        static void ConvertInputsToInts()
        {
            intInputs = inputs.Select(i => Convert.ToInt32(i)).ToList();
        }
    }
}
