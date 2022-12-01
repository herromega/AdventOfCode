using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Immutable;

namespace AdventOfCode.Y2022 {
	class Day1 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 01/input.txt");
				
			Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int elfNumber = 1;
            List<int> elfCarrying = new List<int>();

			int elfCalories = 0;

            foreach (string logRow in instructions) {
				if(!int.TryParse(logRow, out int logRowValue)) {

					elfCarrying.Add(elfCalories);
					elfCalories = 0;
                    elfNumber++;
				}

				elfCalories += logRowValue;
            }

            Console.WriteLine("Answer Part 1 : " + elfCarrying.Max().ToString());
		}
		
		public static void Step2(string[] instructions) {

            int elfNumber = 1;
            List<int> elfCarrying = new List<int>();

            int elfCalories = 0;

            foreach (string logRow in instructions)
            {
                if (!int.TryParse(logRow, out int logRowValue))
                {

                    elfCarrying.Add(elfCalories);
                    elfCalories = 0;
                    elfNumber++;
                }

                elfCalories += logRowValue;
            }

            elfCarrying.Sort();
            elfCarrying.Reverse();

            Console.WriteLine("Answer Part 2 : " + elfCarrying.Take(3).Sum().ToString());
		}
	}
}