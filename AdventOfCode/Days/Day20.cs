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
    public class Day20
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(20);
        public static List<Tile> tiles = new List<Tile>();

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 20 ({ms}ms)");
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

            CreateTiles();
            
            FindCornerTiles();

            result = tiles.Where(t => t.IsCorner).Select(t => t.ID).Aggregate(1, (long x, long y) => x * y);

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

        static void CreateTiles()
        {
            Tile tile = new Tile { Edges = new List<Edge>(), IsCorner = false };
            Edge leftEdge = new Edge { Pixels = "", HasMatch = false };
            Edge rightEdge = new Edge { Pixels = "", HasMatch = false };

            var i = 0;

            foreach (var input in inputs)
            {
                if (input.Contains(":"))
                {
                    tile = new Tile { Edges = new List<Edge>(), IsCorner = false };
                    leftEdge = new Edge { Pixels = "", HasMatch = false };
                    rightEdge = new Edge { Pixels = "", HasMatch = false };

                    i = 0;

                    tile.ID = Convert.ToInt32(input.Replace("Tile ", "").Replace(":", ""));
                }
                else if (input == "")
                {
                    tile.Edges.Add(leftEdge);
                    tile.Edges.Add(rightEdge);
                    tiles.Add(tile);
                }
                else
                {
                    if (i == 0 || i == input.Length - 1)
                    {
                        tile.Edges.Add(new Edge { Pixels = input, HasMatch = false });
                    }
                    leftEdge.Pixels += input.Substring(0, 1);
                    rightEdge.Pixels += input.Substring(input.Length - 1);
                    i++;
                }
            }

            tile.Edges.Add(leftEdge);
            tile.Edges.Add(rightEdge);
            tiles.Add(tile);
        }

        static void FindCornerTiles()
        {
            foreach (var tile in tiles)
            {
                int matchingEdges = 0;

                foreach (var edge in tile.Edges)
                {
                    foreach (var checkTile in tiles.Where(t => t.ID != tile.ID))
                    {
                        foreach (var checkEdge in checkTile.Edges)
                        {
                            if (edge.Pixels == checkEdge.Pixels || Reverse(edge.Pixels) == checkEdge.Pixels)
                            {
                                matchingEdges++;
                                break;
                            }
                        }
                        if (matchingEdges > 2) break;
                    }
                    if (matchingEdges > 2) break;
                }
                
                if (matchingEdges < 3)
                {
                    tile.IsCorner = true;
                }

                if (tiles.Count(t => t.IsCorner) > 3) break;
            }
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}