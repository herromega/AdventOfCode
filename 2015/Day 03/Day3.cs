using System;
using System.Linq;

namespace AdventOfCode.Y2015 {
	class Day3 {
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
				
			Step1(instructions[0]);
			Step2(instructions[0]);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string instructions) {
			
			int x = 100;
			int y = 100;
			
			int uniqueHouses = 1;
			
			int[,] grid = new int[1000,1000];
			
			grid[x, y] = 1;

			for (int i = 0; i < instructions.Length; i++) { 
				string direction = instructions[i].ToString();

				if(direction.Equals("^")) { x++; } 
				else if(direction.Equals("<")) { y--; }
				else if(direction.Equals(">")) { y++; }
				else if(direction.Equals("v")) { x--; }
    		
 				if(grid[x, y] < 1) { 
					uniqueHouses++;
				}
				
				grid[x, y]++;
			}
			
			Console.WriteLine("Answer Part 1 : " + uniqueHouses);
		}
		
		public static void Step2(string instructions) {
		
			int santax = 100;
			int santay = 100;
			
			int robosantax = 100;
			int robosantay = 100;
			
			int uniqueHouses = 1;
			
			int[,] grid = new int[1000,1000];
			
			grid[santax, santay] = 2;

			for (int i = 0; i < instructions.Length; i+=2) { 
				string direction = instructions[i].ToString();

				if(direction.Equals("^")) { santax++; } 
				else if(direction.Equals("<")) { santay--; }
				else if(direction.Equals(">")) { santay++; }
				else if(direction.Equals("v")) { santax--; }
    		
 				if(grid[santax, santay] < 1) { 
					uniqueHouses++;
				}
				
				grid[santax, santay]++;
			}
			
			for (int i = 1; i < instructions.Length; i+=2) { 
				string direction = instructions[i].ToString();

				if(direction.Equals("^")) { robosantax++; } 
				else if(direction.Equals("<")) { robosantay--; }
				else if(direction.Equals(">")) { robosantay++; }
				else if(direction.Equals("v")) { robosantax--; }
    		
 				if(grid[robosantax, robosantay] < 1) { 
					uniqueHouses++;
				}
				
				grid[robosantax, robosantay]++;
			}
			
			Console.WriteLine("Answer Part 2 : " + uniqueHouses);
		}
	}
}