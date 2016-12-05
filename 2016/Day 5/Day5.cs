using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode {
	class Day5 {
		
		static MD5 hasher = MD5.Create();
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			//Step1(instructions[0]);
			Step2(instructions[0]);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string instructions) {
		
			string doorId = instructions;

			byte[] stringToHashAsBytes;
			byte[] computedHashAsBytes;
            
			string stringToHash;
			string computedHash;
            
			int foundPasswordFragments = 0;
            
			StringBuilder passwordString = new StringBuilder();
            
			for (int i = 0; i < int.MaxValue; i++) {
            	
				stringToHash = doorId + i.ToString();
                
				stringToHashAsBytes = System.Text.Encoding.UTF8.GetBytes(stringToHash);	
				computedHashAsBytes = hasher.ComputeHash(stringToHashAsBytes);
                
				computedHash = getStringFromByteArray(computedHashAsBytes);
                
				if (computedHash.StartsWith("00000")) {
					passwordString.Append(computedHash[5]);
					foundPasswordFragments++;
                	
					if(foundPasswordFragments == 8) {
						break;
					}	                           
				}
			}
			
			Console.WriteLine("Answer Part 1 : " + passwordString.ToString());
		}
		
		public static void Step2(string instructions) {
			
			string doorId = instructions;

			byte[] stringToHashAsBytes;
			byte[] computedHashAsBytes;
            
			string stringToHash;
			string computedHash;
            
			int foundPasswordFragments = 0;
            
			string passwordString;
			char[] passwordArray = { '_', '_', '_', '_', '_', '_', '_', '_' };
            
            
			for (int i = 0; i < int.MaxValue; i++) {
            	
				stringToHash = doorId + i.ToString();
                
				stringToHashAsBytes = System.Text.Encoding.UTF8.GetBytes(stringToHash);
				computedHashAsBytes = hasher.ComputeHash(stringToHashAsBytes);
                
				computedHash = getStringFromByteArray(computedHashAsBytes);
                
				if (computedHash.StartsWith("00000")) {
					if (Char.IsDigit(computedHash[5])) {
						
						int num = (int)Char.GetNumericValue(computedHash[5]);
                		
						if (num >= 0 && num < 8) {
							if(passwordArray[num] == '_') {	
								Console.Clear();
                				
								passwordArray[num] = computedHash[6];
								foundPasswordFragments++;
                				
								passwordString = String.Concat(passwordArray);
								Console.WriteLine("Answer Part 2 : " + passwordString);
							} 
							
							if(foundPasswordFragments == 8) {
								break;
							}
						}
					}                             
				}
			}
            
			Console.Clear();
			Console.WriteLine("Answer Part 2 : " + passwordString);
		}
		
		public static string getStringFromByteArray(byte[] input) {
			StringBuilder returnString = new StringBuilder();
            
			for (int x = 0; x < input.Length; x++) {
				returnString.Append(input[x].ToString("x2"));
			}
			
			return returnString.ToString();
		}
	}
}