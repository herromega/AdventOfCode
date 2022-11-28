using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Y2016 {
	class Day3 {
		public static void Main(string[] args) {

			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			int correctTriangles = 0;
			
			foreach(string line in instructions) {	
				int[] lengths = getLengths(line);
				
				correctTriangles += isTriangleValid(lengths);
			}
		
			Console.WriteLine("Answer Part 1 : " + correctTriangles);
		}
		
		public static void Step2(string[] instructions) {
		
			int correctTriangles = 0;
			
			for (int i = 0; i < instructions.Length; i+= 3) {	
				
				int[] row1 = getLengths(instructions[i]);
				int[] row2 = getLengths(instructions[i+1]);
				int[] row3 = getLengths(instructions[i+2]);
				
				int[] lengths1 = {row1[0], row2[0], row3[0]};
				int[] lengths2 = {row1[1], row2[1], row3[1]};
				int[] lengths3 = {row1[2], row2[2], row3[2]};
				
				correctTriangles += isTriangleValid(lengths1);
				correctTriangles += isTriangleValid(lengths2);
				correctTriangles += isTriangleValid(lengths3);
			}
		
			Console.WriteLine("Answer Part 2 : " + correctTriangles);
		}
		
		public static int[] getLengths(string line) {
			int x = Int32.Parse(line.Substring(0,5).Trim());
			int y = Int32.Parse(line.Substring(5,5).Trim());;
			int z = Int32.Parse(line.Substring(10,5).Trim());;
			
			int[] lengths = {x, y, z};
			
			return lengths;
		}
		
		public static int isTriangleValid(int[] lengths) {	
			if((lengths[0] + lengths[1] > lengths[2]) && (lengths[0] + lengths[2] > lengths[1]) && (lengths[1] + lengths[2] > lengths[0])) {
				return 1;
			}
			
			return 0;
		}
	}
}