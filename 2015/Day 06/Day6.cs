using System;
using System.Linq;

namespace AdventOfCode.Y2015 {
	class Day6 {
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			int lightsOn = 0;
			
			int[,] grid = new int[1000,1000];
			
			foreach (string la in instructions) {

				string lightAction = la;
    
				int whatToDo = 0;
    
				if(lightAction.Contains("turn on")) {
					whatToDo = 1;
					lightAction = lightAction.Replace("turn on ", "");
				} 
    
				if(lightAction.Contains("turn off")) {
					whatToDo = 2;
					lightAction = lightAction.Replace("turn off ", "");
				} 
    
				if(lightAction.Contains("toggle")) {
					whatToDo = 3;
					lightAction = lightAction.Replace("toggle ", "");
				}
    
				lightAction = lightAction.Replace(" through ", ",");
    
				int[] actionCordinates = Array.ConvertAll(lightAction.Split(','), int.Parse);
        
				for (int x = actionCordinates[0]; x <= actionCordinates[2]; x++) {
					for (int y = actionCordinates[1]; y <= actionCordinates[3]; y++) { 
			
						if(whatToDo == 1) {
							if(grid[x, y] != 1) {
								grid[x, y] = 1;
								lightsOn++;
							}
						}

						if(whatToDo == 2) {
							if(grid[x, y] == 1) {
    							grid[x, y] = 0;
								lightsOn--;
							}
						}

						if(whatToDo == 3) {
							if(grid[x, y] == 1) { 
    							grid[x, y] = 0;
								lightsOn--;
							} else {
    							grid[x, y] = 1;
								lightsOn++;
							}
						}
					}
				}
			}
			
			Console.WriteLine("Answer Part 1 : " + lightsOn);
		}
		
		public static void Step2(string[] instructions) {

			int totalBrightness = 0;
			
			int[,] grid = new int[1000,1000];
			
			foreach (string la in instructions) {

				string lightAction = la;
    
				int whatToDo = 0;
    
				if(lightAction.Contains("turn on")) {
					whatToDo = 1;
					lightAction = lightAction.Replace("turn on ", "");
				} 
    
				if(lightAction.Contains("turn off")) {
					whatToDo = 2;
					lightAction = lightAction.Replace("turn off ", "");
				} 
    
				if(lightAction.Contains("toggle")) {
					whatToDo = 3;
					lightAction = lightAction.Replace("toggle ", "");
				}
    
				lightAction = lightAction.Replace(" through ", ",");
    
				int[] actionCordinates = Array.ConvertAll(lightAction.Split(','), int.Parse);
        
				for (int x = actionCordinates[0]; x <= actionCordinates[2]; x++) {
					for (int y = actionCordinates[1]; y <= actionCordinates[3]; y++) { 
			
						if(whatToDo == 1) {
							grid[x, y]++;
							totalBrightness++;
						}

						if(whatToDo == 2) {
							if(grid[x, y] > 0) {
								grid[x, y]--;
								totalBrightness--;
							}
						}

						if(whatToDo == 3) {
    						grid[x, y] += 2;
    						totalBrightness += 2;
						}
					}
				}
			}
			
			
			Console.WriteLine("Answer Part 2 : " + totalBrightness);
		}
	}
}