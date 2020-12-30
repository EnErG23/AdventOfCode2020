using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day22
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(22);
        public static List<List<int>> decks = new List<List<int>>();

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 22 ({ms}ms)");
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

            List<int> deck = new List<int>();

            foreach (var input in inputs)
            {
                if (input.Contains(":"))
                    continue;
                else if (input == "")
                {
                    decks.Add(deck);
                    deck = new List<int>();
                }
                else
                    deck.Add(Convert.ToInt32(input));
            }
            decks.Add(deck);

            WriteDecks();

            PlayGame();

            WriteDecks();

            var winnersDeck = decks.Find(d => d.Count > 0);

            int i = winnersDeck.Count();

            foreach (var card in winnersDeck)
            {
                result += card * i;
                i--;
            }

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            long result = 0;



            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }

        static void WriteDecks()
        {
            var i = 0;
            foreach (var d in decks)
            {
                i++;
                Console.WriteLine($"Player {i}: {string.Join(", ", d)}");
            }
            Console.WriteLine();
        }

        static void PlayGame()
        {
            while (decks.Where(d => d.Count() == 0).Count() == 0)
            {
                int card1 = decks[0][0];
                int card2 = decks[1][0];

                if (card1 > card2)
                {
                    decks[0].Remove(card1);
                    decks[1].Remove(card2);

                    decks[0].Add(card1);
                    decks[0].Add(card2);
                }
                else
                {
                    decks[0].Remove(card1);
                    decks[1].Remove(card2);

                    decks[1].Add(card2);
                    decks[1].Add(card1);
                }
            }
        }
    }
}
