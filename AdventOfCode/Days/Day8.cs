using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day8
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(8);

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 8 ({ms}ms)");
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

            var ranLines = new List<int>();

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
                            result += accValue;
                        }
                        else
                        {
                            result -= accValue;
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

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            for (int j = 0; j < inputs.Count() - 1; j++)
            {
                result = 0;

                inputs = InputManager.GetInput(8);

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
                                result += accValue;
                            }
                            else
                            {
                                result -= accValue;
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

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }
    }
}
