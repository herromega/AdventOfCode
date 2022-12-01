using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2021 {
	class Day1 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 01/input.txt");
				
			Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

            List<int> sonarMeasurement = instructions.Select(x => Int32.Parse(x)).ToList();

            int previousSonarMeasurement = 0;
			int numLargerSonarValues = 0;

            foreach (int currentMeasurement in sonarMeasurement) {

                if (currentMeasurement > previousSonarMeasurement) {
                    numLargerSonarValues++;
                }

                previousSonarMeasurement = currentMeasurement;
            }

            Console.WriteLine("Answer Part 1 : " + (numLargerSonarValues - 1));
		}
		
		public static void Step2(string[] instructions) {

            List<int> sonarMeasurement = instructions.Select(x => Int32.Parse(x)).ToList();

            int numLargerSonarValues = 0;

            int currentSonarMeasurement = 0;
            int previousSonarMeasurement = sonarMeasurement[0] + sonarMeasurement[1] + sonarMeasurement[2];

            for (int i = 1; i < (sonarMeasurement.Count - 2); i++) {

                currentSonarMeasurement = sonarMeasurement[i] + sonarMeasurement[i + 1] + sonarMeasurement[i + 2];

                if (currentSonarMeasurement > previousSonarMeasurement) {
                    numLargerSonarValues++;
                }

                previousSonarMeasurement = currentSonarMeasurement;
            }

            Console.WriteLine("Answer Part 2 : " + numLargerSonarValues);
		}
	}
}