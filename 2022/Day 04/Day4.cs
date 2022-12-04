using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2022 {
	class Day4 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 04/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int numSectionsFullyContains = 0;

			foreach (string sectionAssignments in instructions) {

                string[] elfsSections = sectionAssignments.Split(',');

                int[] elfOneRanges = elfsSections[0].Split('-').Select(int.Parse).ToArray();
                int[] elfTwoRanges = elfsSections[1].Split('-').Select(int.Parse).ToArray();

                if(elfOneRanges[0] <= elfTwoRanges[0] && elfOneRanges[1] >= elfTwoRanges[1]  || elfTwoRanges[0] <= elfOneRanges[0] && elfTwoRanges[1] >= elfOneRanges[1] ) {
                    numSectionsFullyContains++;
                }
            }

            Console.WriteLine("Answer Part 1 : " + numSectionsFullyContains);
		}
		
		public static void Step2(string[] instructions) {

            int numOfPartialContains = 0;

            foreach (string sectionAssignments in instructions)
            {

                string[] elfsSections = sectionAssignments.Split(',');

                int[] elfOneRanges = elfsSections[0].Split('-').Select(int.Parse).ToArray();
                int[] elfTwoRanges = elfsSections[1].Split('-').Select(int.Parse).ToArray();

                if (elfOneRanges[1] >= elfTwoRanges[0] && elfOneRanges[0] <= elfTwoRanges[1]) {
                    numOfPartialContains++;
                }
            }

            Console.WriteLine("Answer Part 2 : " + numOfPartialContains);
		}
	}
}