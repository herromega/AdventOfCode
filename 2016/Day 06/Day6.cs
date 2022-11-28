using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Y2016 {
	class Day6 {
		
		public static Dictionary<char, int>[] codeFragments;
		public static StringBuilder errorCorrectedCode;
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {

			setupJammer();
			
			foreach(string recievedCodeStrings in instructions) {
				for(int i = 0; i < recievedCodeStrings.Length; i++) {
					
					if (codeFragments[i].ContainsKey(recievedCodeStrings[i])) {
						codeFragments[i][recievedCodeStrings[i]]++;
					} else {
						codeFragments[i].Add(recievedCodeStrings[i], 1);
					}
				}
			}
			
			for (int i = 0; i < 8; i++) {
				errorCorrectedCode.Append(codeFragments[i].OrderBy(f => f.Value).Last().Key);
			}
			
			Console.WriteLine("Answer Part 1 : " + errorCorrectedCode);
		}
		
		public static void Step2(string[] instructions) {
			setupJammer();
			
			foreach(string recievedCodeStrings in instructions) {
				for(int i = 0; i < recievedCodeStrings.Length; i++) {
					
					if (codeFragments[i].ContainsKey(recievedCodeStrings[i])) {
						codeFragments[i][recievedCodeStrings[i]]++;
					} else {
						codeFragments[i].Add(recievedCodeStrings[i], 1);
					}
				}
			}
			
			for (int i = 0; i < 8; i++) {
				errorCorrectedCode.Append(codeFragments[i].OrderBy(f => f.Value).First().Key);
			}
			
			Console.WriteLine("Answer Part 2 : " + errorCorrectedCode);
		}
		
		public static void setupJammer() {
			codeFragments = new Dictionary<char, int>[8];
			errorCorrectedCode = new StringBuilder();
			
			for (int i = 0; i < 8; i++) {
				codeFragments[i] = new Dictionary<char, int>();
			}
		}
	}
}