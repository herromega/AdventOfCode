using System;
using System.Text.RegularExpressions;

namespace AdventOfCode {
	
	class Day10 {
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions[0]);
			Step2(instructions[0]);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string input) {
			
			int answer = multipleLookAndSay(input, 40);
			
			Console.WriteLine("Answer Part 1 : " + answer);
		}
		
		public static void Step2(string input) {
			
			int answer = multipleLookAndSay(input, 50);
			
			Console.WriteLine("Answer Part 2 : " + answer);
		}
		
		public static string lookAndSay(string a) {
			string regexPattern = "(.)\\1*";
			string returnValue = "";
			
			foreach (Match mc in Regex.Matches(a, regexPattern, RegexOptions.IgnoreCase)) {
				returnValue = returnValue + mc.Length + mc.Value[0];
			}

			return returnValue;
		}

		public static int multipleLookAndSay (string a, int n) {
			
			for (int i = 0; i < n; i++) {
				a = lookAndSay(a);
			}

			return a.Length;
		}
	}
}