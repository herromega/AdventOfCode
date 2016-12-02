using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode {
	class Day1 {
		
		private static Point currentPosition;
        private static List<Point> visitedPositions;
        private static bool haveWeBeenHereBefore;
        private static Point beenHereBeforePosition;
		
		public static void Main(string[] args) {
        	
        	string instructions = System.IO.File.ReadAllText(@"../../input.txt");
			string[] directions = Regex.Split(instructions, ", ");
        	
			// 1 = North (step1)
        	WalkToHQ(directions, 1);
        	
        	// 2 = East (step2)
        	WalkToHQ(directions, 2);
        	
        	Console.ReadKey(true);
        }

        public static void WalkToHQ(string[] directions, int step) {
			
        	currentPosition = new Point(0, 0);
        	visitedPositions = new List<Point>();
        	haveWeBeenHereBefore = false;
        	
        	int direction = step;
        	
			for (int i = 0; i < directions.Length; i++) {
				
				switch(directions[i][0].ToString()) {
						case "R": 
							direction++;
							if (direction > 3) { direction = 0; }
        					break;
						
						case "L": 
							direction--;
							if (direction < 0) { direction = 3; }
        					break;
				}
				
				int numBlocksToWalk = int.Parse(directions[i].Substring(1));
                
                for (int y = 0; y < numBlocksToWalk; y++) {
                	
					if (!haveWeBeenHereBefore) {
	                    foreach (Point visitedPoint in visitedPositions) {
							if (currentPosition == visitedPoint) {
                            	beenHereBeforePosition = visitedPoint;
                            	haveWeBeenHereBefore = true;
                            	
                            	continue;
                        	}
                    	}
                    
                		visitedPositions.Add(currentPosition);
                	}

                	if (direction == 0) { currentPosition.Y++; }
                	else if (direction == 1) { currentPosition.X++; }
                	else if (direction == 2) { currentPosition.Y--; }
                	else if (direction == 3) { currentPosition.X--; }
            	}
            }
			
        	if(step == 2) {
            	Console.WriteLine("Answer Part " + step + ": " + Math.Abs(beenHereBeforePosition.X + beenHereBeforePosition.Y));
        	} else {
        		Console.WriteLine("Answer Part " + step + ": " + Math.Abs(currentPosition.X + currentPosition.Y));
        	}
		}  
	}
}