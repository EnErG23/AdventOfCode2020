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
        public static DateTime end;

        public static List<string> inputs;
        public static List<long> intInputs;

        static void Main(string[] args)
        {
            start = DateTime.Now;

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

            ////DAY 7
            //Day7Pt1();
            //Day7Pt2();

            ////DAY 8
            //Day8Pt1();
            //Day8Pt2();

            ////DAY 9
            //Day9Pt1();
            //Day9Pt2();

            ////DAY 10
            //Day10Pt1();
            //Day10Pt2();

            ////DAY 11
            //Day11Pt1();
            //Day11Pt2();

            end = DateTime.Now;

            Console.WriteLine("");
            Console.WriteLine($"(Completed in {(end - start).Hours}h{(end - start).Minutes}m{(end - start).Seconds}s{(end - start).Milliseconds}ms)");

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
            var c = 30;

            var trees = 0;

            var i = 3;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    trees++;
                }

                i += 3;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }

            Console.WriteLine($"3 - 1: {trees}");
        }

        static void Day3Pt2()
        {
            GetInputs(3);
            var c = 30;

            var trees = 1;

            //1-1
            var tempTrees = 0;
            var i = 1;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 1;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            trees = trees * tempTrees;

            //3-1
            tempTrees = 0;
            i = 3;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 3;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            trees = trees * tempTrees;

            //5-1
            tempTrees = 0;
            i = 5;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 5;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            trees = trees * tempTrees;

            //7-1
            tempTrees = 0;
            i = 7;
            foreach (var input in inputs.Skip(1))
            {
                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 7;

                if (i > c)
                {
                    i -= (c + 1);
                }
            }
            trees = trees * tempTrees;

            //1-2
            tempTrees = 0;
            i = 1;
            bool skip = false;
            foreach (var input in inputs.Skip(2))
            {
                if (skip)
                {
                    skip = false;
                    continue;
                }

                if (input[i] == '#')
                {
                    tempTrees++;
                }

                i += 1;

                if (i > c)
                {
                    i -= (c + 1);
                }

                skip = true;
            }
            trees = trees * tempTrees;

            Console.WriteLine($"3 - 2: {trees}");
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

                    foreach (var child in bag.ChildBags)
                    {
                        for (int i = 0; i < Convert.ToInt32(child.Substring(0, 1)); i++)
                        {
                            tempCheckBags.Add(bags.Where(b => b.Name == child.Substring(1)).First());
                        }
                    }
                }

                if (tempCheckBags.Count() == 0)
                {
                    hasChildren = false;
                }

                checkBags = tempCheckBags;
            }

            Console.WriteLine($"7 - 2: {result - 1}");
        }

        //DAY 8
        static void Day8Pt1()
        {
            GetInputs(8);

            var ranLines = new List<int>();
            var accumulator = 0;

            var i = 0;

            while (true)
            {
                if (ranLines.Contains(i))
                {
                    break;
                }

                ranLines.Add(i);

                var command = inputs[i].Substring(0, 3);

                switch (command)
                {
                    case "acc":
                        var accValue = Convert.ToInt32(inputs[i].Substring(5));
                        if (inputs[i].Contains("+"))
                        {
                            accumulator += accValue;
                        }
                        else
                        {
                            accumulator -= accValue;
                        }
                        i++;
                        break;
                    case "jmp":
                        var jmpValue = Convert.ToInt32(inputs[i].Substring(5));
                        if (inputs[i].Contains("+"))
                        {
                            i += jmpValue;
                        }
                        else
                        {
                            i -= jmpValue;
                        }
                        break;
                    default:
                        i++;
                        break;
                }
            }

            Console.WriteLine($"8 - 1: {accumulator}");
        }

        static void Day8Pt2()
        {
            var accumulator = 0;

            GetInputs(8);

            for (int j = 0; j < inputs.Count() - 1; j++)
            {
                accumulator = 0;

                GetInputs(8);

                if (inputs[j].Contains("jmp"))
                {
                    inputs[j] = inputs[j].Replace("jmp", "nop");
                }
                else if (inputs[j].Contains("nop"))
                {
                    inputs[j] = inputs[j].Replace("nop", "jmp");
                }
                else
                {
                    continue;
                }

                var ranLines = new List<int>();

                var i = 0;
                var found = false;

                while (true)
                {
                    if (i > inputs.Count() - 1)
                    {
                        found = true;
                        break;
                    }

                    if (ranLines.Contains(i))
                    {
                        break;
                    }

                    ranLines.Add(i);

                    var command = inputs[i].Substring(0, 3);

                    switch (command)
                    {
                        case "acc":
                            var accValue = Convert.ToInt32(inputs[i].Substring(5));
                            if (inputs[i].Contains("+"))
                            {
                                accumulator += accValue;
                            }
                            else
                            {
                                accumulator -= accValue;
                            }
                            i++;
                            break;
                        case "jmp":
                            var jmpValue = Convert.ToInt32(inputs[i].Substring(5));
                            if (inputs[i].Contains("+"))
                            {
                                i += jmpValue;
                            }
                            else
                            {
                                i -= jmpValue;
                            }
                            break;
                        default:
                            i++;
                            break;
                    }
                }

                if (found) break;
            }

            Console.WriteLine($"8 - 2: {accumulator}");
        }

        //DAY 9
        static void Day9Pt1()
        {
            GetInputs(9);
            ConvertInputsToInts();

            long firstError = 0;
            var p = 25;
            var i = p;

            foreach (var input in intInputs.Skip(p))
            {
                var preamble = intInputs.GetRange(i - p, p);
                var found = false;

                foreach (var pre1 in preamble)
                {
                    foreach (var pre2 in preamble.Where(pr => pr != pre1))
                    {
                        if (pre1 + pre2 == input)
                        {
                            found = true;
                        }
                        if (found) break;
                    }
                    if (found) break;
                }
                if (!found)
                {
                    firstError = input;
                    break;
                }
                i++;
            }

            Console.WriteLine($"9 - 1: {firstError}");
        }

        static void Day9Pt2()
        {
            GetInputs(9);
            ConvertInputsToInts();

            long firstError = 0;
            var p = 25;
            var i = p;

            foreach (var input in intInputs.Skip(p))
            {
                var preamble = intInputs.GetRange(i - p, p);
                var found = false;

                foreach (var pre1 in preamble)
                {
                    foreach (var pre2 in preamble.Where(pr => pr != pre1))
                    {
                        if (pre1 + pre2 == input)
                        {
                            found = true;
                        }
                        if (found) break;
                    }
                    if (found) break;
                }
                if (!found)
                {
                    firstError = input;
                    break;
                }
                i++;
            }

            long subTotal = 0;
            var start = 0;
            var length = 1;
            long result = 0;

            foreach (var input1 in intInputs)
            {
                subTotal = 0;
                start = intInputs.IndexOf(input1);
                length = 1;

                foreach (var input2 in intInputs.GetRange(start, intInputs.Count() - start))
                {
                    subTotal += input2;

                    if (subTotal > firstError)
                    {
                        break;
                    }

                    if (subTotal == firstError)
                    {
                        result = intInputs.GetRange(start, length).OrderBy(inp => inp).First() + intInputs.GetRange(start, length).OrderByDescending(inp => inp).First();
                        break;
                    }

                    length++;
                }

                if (result != 0)
                {
                    break;
                }

            }

            Console.WriteLine($"9 - 2: {result}");
        }

        //DAY 10
        static void Day10Pt1()
        {
            GetInputs(10);
            ConvertInputsToInts();

            intInputs.Add(0);
            intInputs = intInputs.OrderBy(i => i).ToList();
            intInputs.Add(intInputs[intInputs.Count() - 1] + 3);

            var a = 0;
            var ones = 0;
            var threes = 0;

            foreach (var intInput in intInputs.Skip(1))
            {
                var difference = intInput - intInputs[a];

                if (difference == 1) ones++;
                else if (difference == 3) threes++;

                a++;
            }

            Console.WriteLine($"10 - 1: {ones * threes}");
        }

        static void Day10Pt2()
        {
            GetInputs(10);
            ConvertInputsToInts();

            intInputs.Add(0);
            intInputs = intInputs.OrderBy(i => i).ToList();
            intInputs.Add(intInputs[intInputs.Count() - 1] + 3);

            long result = 1;

            var count = 0;
            var a = 0;

            foreach (var l in intInputs.Skip(1).Take(intInputs.Count() - 2))
            {
                if ((l - intInputs[a]) + (intInputs[a + 2] - l) < 4)
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

                        if (l - intInputs[a - count] < 4)
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

            Console.WriteLine($"10 - 2: {result}");
        }

        //DAY 11
        static void Day11Pt1()
        {
            GetInputs(11);

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
            GetInputs(11);

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

        //AUX METHODS
        static void GetInputs(int day)
        {
            inputs = new List<string>();
            intInputs = new List<long>();

            StreamReader file = new StreamReader($@"Inputs\{day}.txt");
            string line;

            while ((line = file.ReadLine()) != null)
            {
                inputs.Add(line);
            }
        }

        static void ConvertInputsToInts()
        {
            intInputs = inputs.Select(i => long.Parse(i)).ToList();
        }
    }

    class Bag
    {
        public string Name { get; set; }
        public List<string> ChildBags { get; set; }
    }
}
