using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode.Y2015 {
	class Day5 {
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			int niceWords = 0;
			
			string[] crit1 = {"a","e","i","o","u"};
			string[] crit3 = {"ab", "cd", "pq", "xy"};
			
			foreach (string line in instructions) {			
				int foundvowels = 0;
				for (int i = 0; i < line.Length; i++) {
					if(crit1.Contains(line[i].ToString())) {
						foundvowels++;
					}
				}

				int foundDualLetters = 0;
				for (int i = 1; i < line.Length; i++) { 
					if(line[i-1] == line[i]) {
						foundDualLetters++;
					}
				}

				int foundBannedComb = 0;
				foreach (string comb in crit3) {
					if(line.Contains(comb)) {
						foundBannedComb++;
					}
				}

				if((foundvowels >= 3) && (foundDualLetters >= 1) && (foundBannedComb == 0)) {
					niceWords++;
				} 
			}
			
			Console.WriteLine("Answer Part 1 : " + niceWords);
		}
		
		public static void Step2(string[] instructions) {
			
			int niceWords = 0;
			
			foreach (string line in instructions) {
				bool pairCondition = false;
				bool repeatingCondition = false;
	
				for (int i = 0; i < line.Length - 2; i++) {
					if (line.IndexOf(line.Substring(i, 2), i + 2) > 0) {
						pairCondition = true;
					}
                    
					if(line[i] == line[i+2]) {
						repeatingCondition = true;
					}
				}
				
				if (pairCondition && repeatingCondition) {
					niceWords++;
				} 
			}
			
			Console.WriteLine("Answer Part 2 : " + niceWords);
		}
	}
}