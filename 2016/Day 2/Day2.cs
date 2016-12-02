using System;

namespace AdventOfCode {
	class Day2 {
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			int[,] keypad = { 
				{ 1, 2, 3 }, 
				{ 4, 5, 6 }, 
				{ 7, 8, 9 } 
			};

			int x = 1;
			int y = 1;
			
			string code = "";
			
			foreach(string line in instructions) {
				foreach (char direction in line) {
					switch (direction) {
						case 'U': y--; break;
						case 'D': y++; break;
						case 'L': x--; break;
						case 'R': x++; break;
 					}

					if (x < 0) { x = 0; }
					if (x > 2) { x = 2; }
					if (y < 0) { y = 0; }
					if (y > 2) { y = 2; }
				}
				
				code += keypad[y, x].ToString();
			}
			
			Console.WriteLine("Answer Part 1 : " + code);
		}
		
		public static void Step2(string[] instructions) {
			
			string[,] keypad = { 
				{ "-", "-", "1", "-", "-" }, 
				{ "-", "2", "3", "4", "-" }, 
				{ "5", "6", "7", "8", "9" },
				{ "-", "A", "B", "C", "-" },
				{ "-", "-", "D", "-", "-" },
			};

			int x = 0;
			int y = 2;
			
			string code = "";
			
			
			foreach(string line in instructions) {
				foreach (char direction in line) {
					
					int tempx = x;
					int tempy = y;
					
					switch (direction) {
						case 'U': tempy--; break;
						case 'D': tempy++; break;
                        case 'L': tempx--; break;
						case 'R': tempx++; break;
					}
					
					if(tempx < 0) { tempx = 0;}
					if(tempx > 4) { tempx = 4;}
					if(tempy < 0) { tempy = 0;}
					if(tempy > 4) { tempy = 4;}
					
					if(keypad[tempy, tempx] != "-") {
						x = tempx;
						y = tempy;
					}
				}

				code += keypad[y, x].ToString();
			}
			
			Console.WriteLine("Answer Part 2 : " + code);
		}
	}
}