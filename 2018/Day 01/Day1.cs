using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml.Linq;

namespace AdventOfCode.Y2018 {
    class Day1 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 01/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int currentFrequency = 0;

			foreach (string frequencyChange in instructions) {
                currentFrequency += int.Parse(frequencyChange);
            }

            Console.WriteLine("Answer Part 1 : " + currentFrequency);
		}
		
		public static void Step2(string[] instructions) {

            int currentFrequency = 0;
            bool foundFrequencyTwice = false;

            List<int> frequencyList = new List<int>();

            string frequencyChange = "";

            for (int i = 0; i < instructions.Length; i++) {

                frequencyChange = instructions[i];
                currentFrequency += int.Parse(frequencyChange);

                if (frequencyList.Contains(currentFrequency)) {
                    foundFrequencyTwice = true;
                    break;
                } else {
                    frequencyList.Add(currentFrequency);
                }

                if (i == (instructions.Length - 1) && !foundFrequencyTwice) { i = -1; }
            }


            Console.WriteLine("Answer Part 2 : " + currentFrequency);
		}
	}
}