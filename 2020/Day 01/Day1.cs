using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2020 {
	class Day1 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 01/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int valueFound = 0;

			for (int i = 0; i < instructions.Length; i++) {

                for (int j = 0; j < instructions.Length; j++) {
					if ((int.Parse(instructions[i]) + int.Parse(instructions[j])) == 2020) {
                        valueFound = int.Parse(instructions[i]) * int.Parse(instructions[j]); 
					}
				}
			}
			
			Console.WriteLine("Answer Part 1 : " + valueFound);
		}
		
		public static void Step2(string[] instructions) {

            int valueFound = 0;

            for (int i = 0; i < instructions.Length; i++){
                for (int j = 0; j < instructions.Length; j++) {
                    for (int k = 0; k < instructions.Length; k++) {
                        if ((int.Parse(instructions[i]) + int.Parse(instructions[j]) + int.Parse(instructions[k])) == 2020) {
                            valueFound = int.Parse(instructions[i]) * int.Parse(instructions[j]) * int.Parse(instructions[k]);
                        }
                    }
                }
            }

            Console.WriteLine("Answer Part 2 : " + valueFound);
		}
	}
}