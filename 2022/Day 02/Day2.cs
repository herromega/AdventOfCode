using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode.Y2022 {
	class Day2 {

        public static string xxxx = "";
        public static void Main(string[] args) {

            string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 02/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int totalPoints = 0;

			foreach (string gameRound in instructions) {

				string[] playerDrawnShape = gameRound.Split(' ');

				int opponentPoints = getShapePoints(playerDrawnShape[0]);
				int myPoints = getShapePoints(playerDrawnShape[1]);

				switch (DidIWinOrLoose(playerDrawnShape[1], playerDrawnShape[0])) {
					case "WIN":
                        totalPoints += myPoints + 6;
						break;
					case "LOSE":
						totalPoints += myPoints;
						break;
					case "TIE":
						totalPoints += myPoints + 3;
						break;
					default: 
						break;
				}
            }
			
			Console.WriteLine("Answer Part 1 : " + totalPoints);
		}
		
		public static void Step2(string[] instructions) {

            int totalPoints = 0;

            foreach (string gameRound in instructions)
            {

                string[] playerDrawnShape = gameRound.Split(' ');

                string whatShoudWePlayInstead = WhatShouldIPlay(playerDrawnShape[1], playerDrawnShape[0]);

                int opponentPoints = getShapePoints(playerDrawnShape[0]);
                int myPoints = getShapePoints(whatShoudWePlayInstead);

                switch (DidIWinOrLoose(whatShoudWePlayInstead, playerDrawnShape[0]))
                {
                    case "WIN":
                        totalPoints += myPoints + 6;
                        break;
                    case "LOSE":
                        totalPoints += myPoints;
                        break;
                    case "TIE":
                        totalPoints += myPoints + 3;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Answer Part 2 : " + totalPoints);
		}

		public static int getShapePoints(string shape) {
			switch (shape) {
                case "A": return 1;
                case "B": return 2;
                case "C": return 3;

                case "X": return 1;
				case "Y": return 2;
				case "Z": return 3;

				default: return 0;
			}
		}

        public static string DidIWinOrLoose(string MyShape, string OpponentShape) => 
			(MyShape, OpponentShape) switch {
		        ("X", "A") => "TIE",
				("Y", "B") => "TIE",
				("Z", "C") => "TIE",
				("X", "C") => "WIN",
                ("Z", "B") => "WIN",
                ("Y", "A") => "WIN",
                _ => "LOSE"
		};

        public static string WhatShouldIPlay(string MyShape, string OpponentShape) =>
            (MyShape, OpponentShape) switch {
                ("X", "A") => "Z",
                ("X", "B") => "X",
                ("X", "C") => "Y",
                ("Y", "A") => "X",
                ("Y", "B") => "Y",
                ("Y", "C") => "Z",
                ("Z", "A") => "Y",
                ("Z", "B") => "Z",
                ("Z", "C") => "X",
            };
    }
}