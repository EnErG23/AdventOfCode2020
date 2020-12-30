using AdventOfCode.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day21
    {
        public static DateTime start;
        public static DateTime end;
        public static List<string> inputs = InputManager.GetInput(21);
        public static List<Food> foods = new List<Food>();
        public static List<Ingredient> ingredients = new List<Ingredient>();

        public static void Run()
        {
            var start = DateTime.Now;

            var part1 = Part1();
            var part2 = Part2();

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            Console.WriteLine($"Day 21 ({ms}ms)");
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

            foreach (var input in inputs)
            {
                var ingredients = input.Substring(0, input.IndexOf("(") - 1).Split(' ').ToList();
                var allergens = input.Substring(input.IndexOf("(") + 1).Replace("contains ", "").Replace(",", "").Replace(")", "").Split(' ').ToList();

                Food food = new Food
                {
                    Ingredients = ingredients,
                    Allergens = allergens
                };

                foods.Add(food);
            }

            foreach (var food in foods)
            {
                foreach (var ingredient in food.Ingredients)
                {
                    if (ingredients.Count(a => a.Name == ingredient) > 0)
                    {
                        var existingIngredient = ingredients.Find(a => a.Name == ingredient);
                        foreach (var allergen in food.Allergens)
                            if (!existingIngredient.Allergens.Contains(allergen))
                                existingIngredient.Allergens.Add(allergen);
                    }
                    else
                        ingredients.Add(new Ingredient { Name = ingredient, Allergens = food.Allergens.ToList() });
                }
            }

            FindAllergens();

            result = foods.Select(f => f.Ingredients.Where(i => ingredients.Where(ig => ig.Allergens.Count() == 0).Select(ig => ig.Name).ToList().Contains(i))).Sum(i => i.Count());

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 1 ({ms}ms): {result}";
        }

        static string Part2()
        {
            var start = DateTime.Now;

            string result = "";

            result = string.Join(",", ingredients.Where(i => i.Allergens.Count() > 0).OrderBy(i => i.Allergens.First()).Select(i => i.Name));

            var ms = Math.Round((DateTime.Now - start).TotalMilliseconds);

            return $"Part 2 ({ms}ms): {result}";
        }

        static void FindAllergens()
        {
            foreach (var ingredient in ingredients)
            {
                var toRemoveAllergens = new List<string>();

                foreach (var allergen in ingredient.Allergens)
                {
                    foreach (var food in foods.Where(f => f.Allergens.Contains(allergen)))
                    {
                        if (!food.Ingredients.Contains(ingredient.Name))
                        {
                            toRemoveAllergens.Add(allergen);
                            break;
                        }
                    }
                }

                foreach (var toRemoveAllergen in toRemoveAllergens)
                {
                    ingredient.Allergens.Remove(toRemoveAllergen);
                }
            }

            while (ingredients.Where(i => i.Allergens.Count() > 1).Count() > 0)
                foreach (var allergen in ingredients.Where(i => i.Allergens.Count() == 1).Select(i => i.Allergens.First()))
                    foreach (var toChangeIngredient in ingredients.Where(i => i.Allergens.Count() > 1))
                        toChangeIngredient.Allergens.Remove(allergen);
        }
    }
}
