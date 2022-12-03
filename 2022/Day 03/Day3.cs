using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2022 {
	class Day3 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 03/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

            List<char> itemTypes = new List<char>();

            foreach (string rucksack in instructions)
            {
                int compartmentDivider = rucksack.Length / 2;

                IEnumerable<char> firstCompartment = rucksack.Take(compartmentDivider);
                IEnumerable<char> secondaryCompartment = rucksack.Skip(compartmentDivider);

                IEnumerable<char> itemInBothCompartments = firstCompartment.Intersect(secondaryCompartment);

                itemTypes.Add(itemInBothCompartments.ElementAt(0));
            }

            char[] priorityChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Dictionary<char, int> priorityDictionary = new Dictionary<char, int>();

            int keyIndex = 1;

            foreach (char value in priorityChars) {
                priorityDictionary.Add(value, keyIndex);
                keyIndex++;
            }

            int sumOfItemPriorities = itemTypes.Select(x => priorityDictionary[x]).Sum();

            Console.WriteLine("Answer Part 1 : " + sumOfItemPriorities);
		}
		
		public static void Step2(string[] instructions) {

            List<char> itemTypes = new List<char>();

            for (int i = 0; i < instructions.Length; i += 3) {

                string firstRucksackInGroup = instructions[i];
                string secondRucksackInGroup = instructions[i+1];
                string thirdRucksackInGroup = instructions[i+2];

                IEnumerable<char> itemInRucksackGroup = firstRucksackInGroup.Intersect(secondRucksackInGroup).Intersect(thirdRucksackInGroup);

                itemTypes.AddRange(itemInRucksackGroup);
            }

            char[] priorityChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            Dictionary<char, int> priorityDictionary = new Dictionary<char, int>();

            int keyIndex = 1;

            foreach (char value in priorityChars) {
                priorityDictionary.Add(value, keyIndex);
                keyIndex++;
            }

            int sumOfItemPriorities = itemTypes.Select(x => priorityDictionary[x]).Sum();

            Console.WriteLine("Answer Part 2 : " + sumOfItemPriorities);
		}
	}
}