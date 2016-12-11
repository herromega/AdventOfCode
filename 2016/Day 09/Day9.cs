using System;
using System.Linq;
using System.Text;

namespace AdventOfCode {
	class Day9 {
		
		public static long total;
		
		public static void Main(string[] args) {
			
			string instructions = System.IO.File.ReadAllText(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string input) {
			
			total = 0;
			
			decompressData(input, false);
			
			Console.WriteLine("Answer Part 1 : " + total);
		}
		
		public static void Step2(string input) {
			
			total = 0;
			
			decompressData(input, true);			
		
			Console.WriteLine("Answer Part 2 : " + total );
		}

		public static long decompressData(string encpytedText, bool recursive) {
			
			int startMarkerPos = 0;
			int endMarkerPos = 0;
			string possiblyDecompressedChunk;
			
			for(int i = 0; i < encpytedText.Length; i++) {

				if(encpytedText[i] == '(') {
					startMarkerPos = i;	
					endMarkerPos = encpytedText.IndexOf(')', startMarkerPos);

					string[] multiplyer = encpytedText.Substring(startMarkerPos+1, (endMarkerPos-startMarkerPos) - 1).Split('x');
					
					int numChars = Convert.ToInt16(multiplyer[0]);
					int numTimes = Convert.ToInt16(multiplyer[1]);
					
					string chunk = encpytedText.Substring(endMarkerPos+1, numChars);
					
					if(recursive) {
						possiblyDecompressedChunk = decompressChunk(chunk, numChars, numTimes);
						
						if(possiblyDecompressedChunk.IndexOf('(') != -1) {
							decompressData(possiblyDecompressedChunk, recursive);
						} else {
							total += possiblyDecompressedChunk.Length;
						}
					} else {
						total += decompressChunk(chunk, numChars, numTimes).Length;
					}
					
					i = i + ((endMarkerPos-startMarkerPos) + numChars);
					
					continue;
				} 
				
				total++;
			}
			
			return total;
		}
	
		public static string decompressChunk(string inputChunk, int numChars, int multipleTimes) {

			string charsToMultiply = inputChunk.Substring(0, numChars);
			string charsNotToMultiply = inputChunk.Substring(numChars);
			StringBuilder partlyDecompressedChunk = new StringBuilder();
				
			for(int i = 0; i < multipleTimes; i++) {
				partlyDecompressedChunk.Append(charsToMultiply);
			}
				
			partlyDecompressedChunk.Append(charsNotToMultiply);

			return partlyDecompressedChunk.ToString();
		}
	}
}