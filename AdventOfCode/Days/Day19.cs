using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AdventOfCode
{
    public class Day19
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(19);
        public static List<MessageRule> rules = new List<MessageRule>();

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 19 ({ms}ms)");
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

            inputs = inputs.Where(i => i != "").ToList();

            foreach (var input in inputs.Where(i => i.Contains(":")))
            {
                var id = input.Substring(0, input.IndexOf(":"));
                var subRules = new List<List<string>>();

                if (!input.Contains("\""))
                    foreach (var subRule in input.Substring(input.IndexOf(":") + 1).Split('|'))
                        subRules.Add(subRule.Split(' ').Where(s => s != "").ToList());

                var match = input.Contains("\"") ? input.Substring(input.IndexOf("\"") + 1, input.LastIndexOf("\"") - input.IndexOf("\"") - 1) : "";

                var messageRule = new MessageRule
                {
                    ID = id,
                    SubRules = subRules,
                    Match = match
                };

                rules.Add(messageRule);
            }

            var messages = new List<string>();

            foreach (var input in inputs.Where(i => !i.Contains(":")))
                messages.Add(input);

            var pattern = $@"^{BuildPattern("0")}$";
            
            Regex rgx = new Regex(pattern);

            foreach (var message in messages)
                result += rgx.IsMatch(message) ? 1 : 0;

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;

            inputs = inputs.Where(i => i != "").ToList();

            foreach (var input in inputs.Where(i => i.Contains(":")))
            {
                var id = input.Substring(0, input.IndexOf(":"));
                var subRules = new List<List<string>>();

                if (!input.Contains("\""))
                    foreach (var subRule in input.Substring(input.IndexOf(":") + 1).Split('|'))
                        subRules.Add(subRule.Split(' ').Where(s => s != "").ToList());

                var match = input.Contains("\"") ? input.Substring(input.IndexOf("\"") + 1, input.LastIndexOf("\"") - input.IndexOf("\"") - 1) : "";

                var messageRule = new MessageRule
                {
                    ID = id,
                    SubRules = subRules,
                    Match = match
                };

                rules.Add(messageRule);
            }

            var messages = new List<string>();

            foreach (var input in inputs.Where(i => !i.Contains(":")))
                messages.Add(input);

            var pattern = $@"^{BuildPattern2("0")}$";

            Regex rgx = new Regex(pattern);

            foreach (var message in messages)
                result += rgx.IsMatch(message) ? 1 : 0;

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }

        static string BuildPattern(string ruleID)
        {
            var result = "";

            var rule = rules.Find(r => r.ID == ruleID);

            if (rule.Match != "")
            {
                result += rule.Match;
            }
            else
            {
                result += "(";
                var tempResult = "";
                foreach (var subRule in rule.SubRules)
                {
                    foreach (var subRuleID in subRule)
                    {
                        tempResult += BuildPattern(subRuleID);
                    }
                    tempResult += "|";
                }
                result += $"{tempResult.Substring(0, tempResult.Length - 1)})";
            }

            return result;
        }

        static string BuildPattern2(string ruleID)
        {
            var result = "";

            var rule = rules.Find(r => r.ID == ruleID);

            if (rule.Match != "")
            {
                result += rule.Match;
            }
            else
            {
                if (ruleID == "8")
                    return $"(({BuildPattern2("42")})+)";

                if (ruleID == "11")
                {
                    var elevenResult = "(";

                    for (int i = 1; i < 11; i++)
                    {
                        elevenResult += $"(({BuildPattern2("42")}{{{i}}})({BuildPattern2("31")}{{{i}}}))|";
                    }

                    return $"{elevenResult.Substring(0, elevenResult.Length - 1)})";
                }

                result += "(";

                var tempResult = "";
                foreach (var subRule in rule.SubRules)
                {
                    foreach (var subRuleID in subRule)
                    {
                        tempResult += BuildPattern2(subRuleID);
                    }
                    tempResult += "|";
                }
                result += $"{tempResult.Substring(0, tempResult.Length - 1)})";
            }

            return result;
        }
    }
}