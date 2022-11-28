using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Y2016 {
	class Day8 {
		
		public static char[,] display;
		public static int displayWidth  = 50;
		public static int displayHeight = 6;
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			initDisplay();
        	
			foreach(string instruction in instructions) {
        		
				string[] instructionData;
        		
				if(instruction.Contains("rect")) {
					instructionData = instruction.Replace("rect ", "").Split('x');
        			
					int x = Convert.ToInt16(instructionData[0]);
					int y = Convert.ToInt16(instructionData[1]);
        			
					addDisplayPixels(x, y);
				}
        		
				if(instruction.Contains("rotate row")) {
					instructionData = instruction.Replace("rotate row y=", "").Replace(" by ", "x").Split('x');
        			
					int y = Convert.ToInt16(instructionData[0]);
					int by = Convert.ToInt16(instructionData[1]);
        			
					for (int yb = 0; yb < by; yb++) {
						rotateDisplayRow(y);
					}
				}
        		
				if(instruction.Contains("rotate column")) {
					instructionData = instruction.Replace("rotate column x=", "").Replace(" by ", "x").Split('x');
        			
					int x = Convert.ToInt16(instructionData[0]);
					int by = Convert.ToInt16(instructionData[1]);
        			
					for (var xb = 0; xb < by; xb++) {
						rotateDisplayColumn(x);
					}
				}
			}
        
			int numPixelsLit = getActiveDisplayPixels();
        	
			Console.WriteLine("Answer Part 1 : " + numPixelsLit);
		}
		
		public static void Step2(string[] instructions) {
			
			Console.WriteLine("Answer Part 2 : " );
			drawDisplay();
		}
		
		public static void initDisplay() {
			display = new char[displayHeight + 1, displayWidth + 1];
            
			for (int x = 0; x < displayHeight; x++) {
				for (int y = 0; y < displayWidth; y++) {
					display[x, y] = ' ';
				}
			}
		}
        
		public static void addDisplayPixels(int width, int height) {
			for (int x = 0; x < height; x++) {
				for (var y = 0; y < width; y++) {
					display[x, y] = 'X';
				}
			}
		}
        
		public static void rotateDisplayRow(int rowNumber) {
			char[,] tmpDisplay = display;
            
			for (int x = displayWidth-1; x >= 0; x--) {
				tmpDisplay[rowNumber, x + 1] = display[rowNumber, x];
			}
            
			tmpDisplay[rowNumber, 0] = display[rowNumber, displayWidth];
            
			display = tmpDisplay;
		}

		public static void rotateDisplayColumn(int colNumber) {
			char[,] tmpDisplay = display;
            
			for (int y = displayHeight-1; y >= 0; y--) {
				tmpDisplay[y + 1, colNumber] = display[y, colNumber];
			}
            
			tmpDisplay[0, colNumber] = display[displayHeight, colNumber];
            
			display = tmpDisplay;
		}
        
		public static int getActiveDisplayPixels() {
        	
			int returnPixels = 0;
        	
			for (int x = 0; x < displayHeight; x++) {
				for (int y = 0; y < displayWidth; y++) {
					if(display[x, y] == 'X'){
						returnPixels++;
					}
				}
			}
        	
			return returnPixels;
		}
        
		public static void drawDisplay() {
			for (int x = 0; x < displayHeight; x++) {
				for (var y = 0; y < displayWidth; y++) {
					Console.Write(display[x, y]);
				}
				
				Console.Write('\n');
			}
		}
	}
}