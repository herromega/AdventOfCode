using System;
using System.Text;

namespace AdventOfCode {
	
	class Day11 {
		
		public static char[] disallowedChars = new char[] { 'i', 'o', 'l' };
		public static string possiblePassword;
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions[0]);
			Step2(instructions[0]);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string instruction) {
			
			bool passwordFound = false;
			possiblePassword = instruction; 
			
			while (!passwordFound) {
				possiblePassword = reGeneratePassword(possiblePassword);
                
				if(complyWithPolicy(possiblePassword)) {
					passwordFound = true;
				}
			}

			Console.WriteLine("Answer Part 1 : " + possiblePassword);
		}
		
		public static void Step2(string instruction) {
			
			bool passwordFound = false;
			
			while (!passwordFound) {
				possiblePassword = reGeneratePassword(possiblePassword);
                
				if(complyWithPolicy(possiblePassword)) {
					passwordFound = true;
				}		
			}
			
			Console.WriteLine("Answer Part 2 : " + possiblePassword);
		}
		
		public static string reGeneratePassword(string oldPassword) {
			StringBuilder newPassword = new StringBuilder(oldPassword);
			bool incrementDone = false;
			int i = newPassword.Length-1;
            
			while(!incrementDone) {
				if (newPassword[i] == 'z') {
					newPassword[i] = 'a';
					i--;
				} else {
					newPassword[i]++;
					incrementDone = true;
				}
			} 

			return newPassword.ToString();
        	}
		
		public static bool complyWithPolicy(string checkPassword) {
			
			bool policyDisallowedChars = false;
			bool policyStraights = false;
			bool policyPairs = false;
			
			if (checkPassword.IndexOfAny(disallowedChars) == -1) { 
				
				policyDisallowedChars = true;

				int straightCount = 1;
				for(int i = 0; i < checkPassword.Length - 1; i++) {
					if (checkPassword[i + 1] - checkPassword[i] == 1) {
						straightCount++;
					} else {
						straightCount = 1;
					}
					
					if (straightCount > 2) { 
						policyStraights = true; 
					}
				}
				
				int pairCount = 0;	
				for(int i = 0; i < checkPassword.Length - 1; i++) {
					if(checkPassword[i] == checkPassword[i + 1]) { 
						pairCount++;
						i++;
					}
					
					if (pairCount >= 2) { policyPairs = true; }
				}
			
			}
			
			if(policyDisallowedChars && policyStraights && policyPairs) {
				return true;
			}
			
			return false;
		}
	}
}