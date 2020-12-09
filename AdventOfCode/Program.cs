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

            ////DAY 5
            //Day5Pt1();
            //Day5Pt2();

            ////DAY 6
            //Day6Pt1();
            //Day6Pt2();

            //DAY 7
            //Day7Pt1();
            Day7Pt2();

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
                //Console.WriteLine(p);
                if (p.Contains("byr:") && p.Contains("iyr:") && p.Contains("eyr:") && p.Contains("hgt:") && p.Contains("hcl:") && p.Contains("ecl:") && p.Contains("pid:"))
                {
                    validPassports++;
                    //Console.WriteLine("Valid");
                    //Console.WriteLine("");
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
                        validPassports++;
                        //Console.WriteLine("Valid");
                    }
                    //Console.WriteLine("");
                }
            }

            Console.WriteLine($"4 - 2: {validPassports}");
        }

        //DAY 5
        static void Day5Pt1()
        {
            GetInputs(5);

            var highestSeatID = 0;

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

                highestSeatID = Math.Max(highestSeatID, seatID);
            }

            Console.WriteLine($"5 - 1: {highestSeatID}");
        }

        static void Day5Pt2()
        {
            GetInputs(5);

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

                seatIDs.Add(seatID);
            }

            List<int> allIDS = Enumerable.Range(9, 1031).ToList();

            //foreach(var id in allIDS.Where(a => !seatIDs.Contains(a)))
            //{
            //    Console.WriteLine($"Possible: {id}");
            //}

            var mySeatID = allIDS.Where(a => a > 79 && a < 927).Where(a => !seatIDs.Contains(a)).First();

            Console.WriteLine($"5 - 2: {mySeatID}");
        }

        //DAY 6
        static void Day6Pt1()
        {
            GetInputs(6);

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

            var counts = passports.Select(p => p.Distinct().Count());

            Console.WriteLine($"6 - 1: {counts.Sum(c => c)}");
        }

        static void Day6Pt2()
        {
            GetInputs(6);

            List<string> passports = new List<string>();
            string passport = "";

            bool reset = true;

            foreach (string input in inputs)
            {
                if (input == "")
                {
                    Console.WriteLine(passport);
                    Console.WriteLine(passport.Distinct().Count());
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

            Console.WriteLine(passport);
            Console.WriteLine(passport.Distinct().Count());
            passports.Add(passport);

            var counts = passports.Select(p => p.Distinct().Count());

            Console.WriteLine($"6 - 2: {counts.Sum(c => c)}");
        }

        //DAY 7
        static void Day7Pt1()
        {
            GetInputs(7);

            List<string> newInputs = new List<string>();

            foreach (var input in inputs)
            {
                var tempInput = input.Replace("bags ", "").Replace("bags, ", "").Replace("bags.", "").Replace("contain ", "").Replace("bag", "").Replace(", ", "").Replace(".", "").Replace(" no other", "");

                for (int i = 0; i < 10; i++)
                {
                    tempInput = tempInput.Replace($"{i}", "");
                }

                tempInput = tempInput.Replace($"  ", ";");
                newInputs.Add(tempInput.Replace(" ", ""));
            }

            List<Bag> bags = new List<Bag>();

            foreach (var newInput in newInputs)
            {
                var newBags = newInput.Split(';').ToList();

                if (bags.Where(b => b.Name == newBags[0]).Count() > 0)
                {
                    var bag = bags.Where(b => b.Name == newBags[0]).First();

                    foreach (var childBag in newBags.GetRange(1, newBags.Count() - 1))
                    {
                        if (!bag.ChildBags.Contains(childBag))
                        {
                            bag.ChildBags.Add(childBag);
                        }
                    }
                }
                else
                {
                    var childBags = newBags.GetRange(1, newBags.Count() - 1);

                    Bag bag = new Bag
                    {
                        Name = newBags[0],
                        ChildBags = childBags
                    };

                    if (bag.Name == "vibrant white" || bag.Name == "vibrant fuchsia")
                    {
                        Console.WriteLine($"{bag.Name}: {string.Join(";", bag.ChildBags)}");
                        Console.WriteLine("");
                    }

                    bags.Add(bag);
                }
            }

            bags = bags.OrderBy(b => b.Name).ToList();

            var result = 0;

            var hasParent = true;
            var bagNames = new List<string>() { "shinygold" };
            var possibleBags = new List<Bag>();

            while (hasParent)
            {
                if (bags.Where(b => b.ChildBags.Any(item => bagNames.Contains(item))).Count() > 0)
                {
                    possibleBags.AddRange(bags.Where(b => b.ChildBags.Any(item => bagNames.Contains(item))));

                    Console.WriteLine("BAG NAMES");
                    Console.WriteLine("---------");
                    Console.WriteLine(string.Join(";", bagNames));
                    Console.WriteLine("---------");

                    foreach (var bag in possibleBags)
                    {
                        Console.WriteLine($"{bag.Name}: {string.Join(";", bag.ChildBags)}");
                    }

                    Console.WriteLine(" ");

                    bagNames = bags.Where(b => b.ChildBags.Any(item => bagNames.Contains(item))).Select(b => b.Name).ToList();
                }
                else
                {
                    hasParent = false;
                }
            }

            result = possibleBags.Distinct().Count();

            Console.WriteLine($"7 - 1: {result}");
        }

        static void Day7Pt2()
        {
            GetInputs(7);

            List<string> newInputs = new List<string>();

            foreach (var input in inputs)
            {
                var tempInput = input.Replace("bags ", "").Replace("bags, ", "").Replace("bags.", "").Replace("contain ", "").Replace("bag", "").Replace(", ", "").Replace(".", "").Replace(" no other", "");

                for (int i = 0; i < 10; i++)
                {
                    tempInput = tempInput.Replace($"{i}", $";{i}");
                }

                tempInput = tempInput.Replace($"  ", ";");
                newInputs.Add(tempInput.Replace(" ", ""));
            }

            List<Bag> bags = new List<Bag>();

            foreach (var newInput in newInputs)
            {
                var newBags = newInput.Split(';').ToList();

                if (bags.Where(b => b.Name == newBags[0]).Count() > 0)
                {
                    var bag = bags.Where(b => b.Name == newBags[0]).First();

                    foreach (var childBag in newBags.GetRange(1, newBags.Count() - 1))
                    {
                        if (!bag.ChildBags.Contains(childBag))
                        {
                            bag.ChildBags.Add(childBag);
                        }
                    }
                }
                else
                {
                    var childBags = newBags.GetRange(1, newBags.Count() - 1);

                    Bag bag = new Bag
                    {
                        Name = newBags[0],
                        ChildBags = childBags
                    };

                    bags.Add(bag);
                }
            }

            bags = bags.OrderBy(b => b.Name).ToList();

            var result = 0;

            var checkBags = bags.Where(b => b.Name == "shinygold");
            
            var hasChildren = true;

            while (hasChildren)
            {
                var tempCheckBags = new List<Bag>();

                foreach (var bag in checkBags)
                {
                    result++;

                    Console.WriteLine($"--------------------------------------");
                    Console.WriteLine($"CHECKING {bag.Name}");
                    Console.WriteLine($"--------------------------------------");

                    foreach (var child in bag.ChildBags)
                    {
                        Console.WriteLine($"{child}");
                        Console.WriteLine($"--------------------------------------");
                        for (int i = 0; i < Convert.ToInt32(child.Substring(0, 1)); i++)
                        {
                            Console.WriteLine($"Added {child.Substring(1)} bags");
                            tempCheckBags.Add(bags.Where(b => b.Name == child.Substring(1)).First());
                        }
                    }
                    Console.WriteLine($"--------------------------------------");
                    Console.WriteLine($" ");
                }

                if (tempCheckBags.Count() == 0)
                {
                    hasChildren = false;
                }

                checkBags = tempCheckBags;
            }

            //var hasChildren = true;
            //var bagNames = new List<string>() { "shinygold" };
            //var childBags = new List<Bag>();

            //while (bagNames)
            //{
            //    if (bags.Where(b => b.ChildBags.Any(item => bagNames.Contains(item))).Count() > 0)
            //    {
            //        possibleBags.AddRange(bags.Where(b => b.ChildBags.Any(item => bagNames.Contains(item))));

            //        Console.WriteLine("BAG NAMES");
            //        Console.WriteLine("---------");
            //        Console.WriteLine(string.Join(";", bagNames));
            //        Console.WriteLine("---------");

            //        foreach (var bag in possibleBags)
            //        {
            //            Console.WriteLine($"{bag.Name}: {string.Join(";", bag.ChildBags)}");
            //        }

            //        Console.WriteLine(" ");

            //        bagNames = bags.Where(b => b.ChildBags.Any(item => bagNames.Contains(item))).Select(b => b.Name).ToList();
            //    }
            //    else
            //    {
            //        hasParent = false;
            //    }
            //}

            //result = possibleBags.Distinct().Count();

            Console.WriteLine($"7 - 2: {result-1}");
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

    class Bag
    {
        public string Name { get; set; }
        public List<string> ChildBags { get; set; }
    }
}
