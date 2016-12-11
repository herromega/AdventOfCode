using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode {
	class Day7 {
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			int tlsSupportedIPv7 = 0;
			
			foreach (string ipv7 in instructions) {
				bool foundAbbaControlOutsideBrackets = false;
				bool foundAbbaControlInsideBrackets = false;
				bool iterateInsideBrackets = false;
				
				for (int i = 0; i < ipv7.Length-3; i++) {
					if (ipv7[i] == '[') {
						iterateInsideBrackets = true;
					}
					
					if(ipv7[i] == ']') {
						iterateInsideBrackets = false;
					}
					
					if (ipv7[i] == ipv7[i + 3] && ipv7[i + 1] == ipv7[i + 2] && ipv7[i] != ipv7[i + 1]) {
						if (iterateInsideBrackets) { 
							foundAbbaControlInsideBrackets = true; 
						} else if(!iterateInsideBrackets) {
							foundAbbaControlOutsideBrackets = true;
						}
					}
				}
				
				if(!foundAbbaControlInsideBrackets && foundAbbaControlOutsideBrackets) {
					tlsSupportedIPv7++;
				}
			}
				
			Console.WriteLine("Answer Part 1 : " + tlsSupportedIPv7);
		}
		
		public static void Step2(string[] instructions) {
			
			int sslSupportedIPv7 = 0;
			
			foreach (string ipv7 in instructions) {

				string foundABA = null;
				string foundBAB = null;
				
				List<string> ABAs = new List<string>();
				List<string> BABs = new List<string>();
				
				bool iterateInsideBrackets = false;
				
				for (int i = 0; i < ipv7.Length-2; i++) {
					if (ipv7[i] == '[') {
						iterateInsideBrackets = true;
					}
					
					if(ipv7[i] == ']') {
						iterateInsideBrackets = false;
					}
					
					if (ipv7[i] == ipv7[i + 2] && ipv7[i] != ipv7[i + 1]) {
						
						if(!iterateInsideBrackets) {
							foundABA = "" + ipv7[i + 1] + ipv7[i] + ipv7[i + 1];
                        	
							if(BABs.Contains(foundABA)) {
								sslSupportedIPv7++;
								break;
							} else {                        	
								ABAs.Add(foundABA);
							}
						}
						
						if(iterateInsideBrackets) {
							foundBAB = "" + ipv7[i] + ipv7[i + 1] + ipv7[i + 2];
							
							if(ABAs.Contains(foundBAB)) {
								sslSupportedIPv7++;	
								break;
							} else {
								BABs.Add(foundBAB);
							}
						}
					
					}
				}
			}
			
			Console.WriteLine("Answer Part 2 : " + sslSupportedIPv7 );
		}
		
	}
}