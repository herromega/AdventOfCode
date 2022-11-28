using System;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2015 {
	
	class Day8 {
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			int sumLineChars = 0;
			int sumUnescapedChars = 0;

			foreach (string line in instructions) {
	
				sumLineChars += line.Length;
				sumUnescapedChars += Regex.Unescape(line).Length;
                    
				if(line.StartsWith("\"")) {
					sumUnescapedChars--;
				}
    
				if(line.EndsWith("\"")) {
					sumUnescapedChars--;
				}
			}    
			
			Console.WriteLine("Answer Part 1 : " + (sumLineChars - sumUnescapedChars));
		}
		
		public static void Step2(string[] instructions) {

			int sumEscapedChars = 0;
			int sumLineChars = 0;
			
			foreach (string line in instructions) {
				sumLineChars += line.Length;

				sumEscapedChars +=2;
				
				for(int i = 0; i < line.Length; i++) {
					if (line[i] == '\\') {
						sumEscapedChars++;
					}
					
					if (line[i] == '"') {
						sumEscapedChars++;
					}
					
					sumEscapedChars++;
				}
			}    
			
			Console.WriteLine("Answer Part 2 : " + (sumEscapedChars - sumLineChars));
		}
	}
}