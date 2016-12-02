using System;
using System.Linq;


namespace AdventOfCode {
	class Day2 {
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
				
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			int requiredWrappingpaper = 0;
			
			foreach (string measurements in instructions) {
				
				string[] measurement = measurements.Split('x');
				
				int l = Int32.Parse(measurement[0]);
				int w = Int32.Parse(measurement[1]);
				int h = Int32.Parse(measurement[2]);
	
				int[] sides = {l*w, w*h, h*l};
				
				requiredWrappingpaper += (2 * sides.Sum()) + sides.Min();
			}
			
			Console.WriteLine("Answer Part 1 : " + requiredWrappingpaper);
		}
		
		public static void Step2(string[] instructions) {
		
			int requiredRibbon = 0;
			
			foreach (string measurements in instructions) {
				
				string[] measurement = measurements.Split('x');
				
				int l = Int32.Parse(measurement[0]);
				int w = Int32.Parse(measurement[1]);
				int h = Int32.Parse(measurement[2]);
				
				int[] lengths = {l, w, h};
				int[] sides = {l*w, w*h, h*l};
				
				int shortestDistance = 2 * (lengths.Sum() - lengths.Max());
          		
				requiredRibbon += shortestDistance + l * w * h;
			}
			
			Console.WriteLine("Answer Part 2 : " + requiredRibbon);
		}
	}
}