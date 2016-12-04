using System;
using System.Linq;

namespace AdventOfCode {
	class Day4 {
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
		
			int realRoomSum = 0;
			
			foreach(string line in instructions) {	
				string checkSum = line.Substring(line.Length - 6).Substring(0,5);
                int sectorId = Convert.ToInt32(line.Substring(line.Length - 10).Substring(0, 3));
                char[] cryptName = line.Substring(0, line.Length - 11).Replace("-",string.Empty).ToCharArray();
				
                string reverseChecksum = new string(
                	cryptName.GroupBy(a => a).Select(
                		b => new { 
                			b.Key, Count = b.Count() 
                		}
                	).OrderByDescending(
                		c => c.Count
                	).ThenBy(
                		c => c.Key
                	).Take(5).Select(
                		c => c.Key
                	).ToArray()
                );
                
                if(checkSum.Equals(reverseChecksum)) {
                	realRoomSum += sectorId;
                }
          
			}
			
			Console.WriteLine("Answer Part 1 : " + realRoomSum);
		}
		
		public static void Step2(string[] instructions) {
			
			int foundSectorId = 0;
			
			foreach(string line in instructions) {	
                int sectorId = Convert.ToInt32(line.Substring(line.Length - 10).Substring(0, 3));
                char[] cryptName = line.Substring(0, line.Length - 11).Replace("-"," ").ToCharArray();
				
				for (int i = 0; i < cryptName.Length; i++) {
					char letter = cryptName[i];

					if(letter.Equals(' ')) {
						continue;
					}
					
					for(int x = 0; x < sectorId % 26; x++) {
						letter = letter == 'z' ? 'a' : (char)(letter + 1);
					} 
					
	    			cryptName[i] = letter;
				}
                
                string decryptedName = new string(cryptName);
                
                if(decryptedName.Contains("northpole")) {
                	foundSectorId = sectorId;
                }
			}
			
			Console.WriteLine("Answer Part 2 : " + foundSectorId);
		}
	}
}