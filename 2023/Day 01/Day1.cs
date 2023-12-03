using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Immutable;

namespace AdventOfCode.Y2023 {
	class Day1 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 01/input.txt");
				
			Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int sumCalibrationValues = 0;
            
            foreach (string calibrationInstructionRow in instructions) {

                List<int> extractedCalibrationValues = new List<int>();

                foreach (char calibrationInstructionRowChar in calibrationInstructionRow) {
                    if (char.IsDigit(calibrationInstructionRowChar)) {
                        extractedCalibrationValues.Add(int.Parse(calibrationInstructionRowChar.ToString()));
                    }
                }

                string rowCombination = extractedCalibrationValues.First().ToString() + extractedCalibrationValues.Last().ToString();
                
                sumCalibrationValues += int.Parse(rowCombination);
            }

            Console.WriteLine("Answer Part 1 : " + sumCalibrationValues);
        }

        public static void Step2(string[] instructions) {

            int sumCalibrationValues = 0;

            foreach (string calibrationInstructionRow in instructions)
            {
                string trimmedCalibrationInstructionRow;

                trimmedCalibrationInstructionRow = calibrationInstructionRow
                    .Replace("one", "o1e")
                    .Replace("two", "t2o")
                    .Replace("three", "thr3e")
                    .Replace("four", "fo4r")
                    .Replace("five", "fi5e")
                    .Replace("six", "s6x")
                    .Replace("seven", "se7en")
                    .Replace("eight", "ei8ht")
                    .Replace("nine", "n9ne");

                List<int> extractedCalibrationValues = new List<int>();

                foreach (char calibrationInstructionRowChar in trimmedCalibrationInstructionRow)
                {
                    if (char.IsDigit(calibrationInstructionRowChar))
                    {
                        extractedCalibrationValues.Add(int.Parse(calibrationInstructionRowChar.ToString()));
                    }
                }

                string rowCombination = extractedCalibrationValues.First().ToString() + extractedCalibrationValues.Last().ToString();

                sumCalibrationValues += int.Parse(rowCombination);
            }

            Console.WriteLine("Answer Part 2 : " + sumCalibrationValues);
        }
	}
}