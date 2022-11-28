using System;

namespace AdventOfCode.Y2015 {
	class Day1 {

		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
				
			Step1(instructions[0]);
			Step2(instructions[0]);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string instructions) {
			
			int floor = 0;
			
			for (int i = 0; i < instructions.Length; i++) {
				if(instructions[i].Equals('(')) { floor++; }
				if(instructions[i].Equals(')')) { floor--; }
			}
			
			Console.WriteLine("Answer Part 1 : " + floor);
		}
		
		public static void Step2(string instructions) {
		
			int floor = 0;
			int visitedBasementAtInstruction = 0;
			bool visitedBasement = false;
			
			for (int i = 0; i < instructions.Length; i++) {
				if(instructions[i].Equals('(')) { floor++; }
				if(instructions[i].Equals(')')) { floor--; }
				
				if(!visitedBasement) {
					visitedBasementAtInstruction++; 
					
					if(floor == -1) {
						visitedBasement = true;
					}
				}
			}
			
			Console.WriteLine("Answer Part 2 : " + visitedBasementAtInstruction);
		}
	}
}