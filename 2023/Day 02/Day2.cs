using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Immutable;
using System.Text;

namespace AdventOfCode.Y2023 {
	class Day2 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 02/input.txt");
				
			Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int gameSum = 0;
            
            foreach (string gameRow in instructions) {

                int gameNumber = int.Parse(gameRow.Split(':')[0].Split(' ')[1].ToString());
                
                string gameRowInfo = gameRow.Split(':')[1];
                string[] gameRowSets = gameRowInfo.Split(';');

                bool isGamePossible = true;

                foreach (string gameRowSet in gameRowSets)
                {
                    var gameRowSetDraws = gameRowSet.Split(',', StringSplitOptions.TrimEntries);

                    foreach (string gameRowSetDraw in gameRowSetDraws)
                    {
                        string gameRowSetDrawColor = gameRowSetDraw.Split(' ', StringSplitOptions.TrimEntries)[1];
                        int gameRowSetDrawNumber = int.Parse(gameRowSetDraw.Split(' ', StringSplitOptions.TrimEntries)[0]);

                        if (gameRowSetDrawColor == "red" && gameRowSetDrawNumber > 12) { isGamePossible = false; }
                        if (gameRowSetDrawColor == "green" && gameRowSetDrawNumber > 13) { isGamePossible = false; }
                        if (gameRowSetDrawColor == "blue" && gameRowSetDrawNumber > 14) { isGamePossible = false; }
                    }
                }

                if (isGamePossible) {
                    gameSum += gameNumber;
                }
                
            }

            Console.WriteLine("Answer Part 1 : " + gameSum);
        }

        public static void Step2(string[] instructions) {

            int gameSum = 0;

            foreach (string gameRow in instructions)
            {

                int gameNumber = int.Parse(gameRow.Split(':')[0].Split(' ')[1].ToString());

                string gameRowInfo = gameRow.Split(':')[1];
                string[] gameRowSets = gameRowInfo.Split(';');

                int gameRowRed = 0;
                int gameRowGreen = 0;
                int gameRowBlue = 0;

                bool isGamePossible = true;

                foreach (string gameRowSet in gameRowSets)
                {
                    var gameRowSetDraws = gameRowSet.Split(',', StringSplitOptions.TrimEntries);

                    foreach (string gameRowSetDraw in gameRowSetDraws)
                    {
                        string gameRowSetDrawColor = gameRowSetDraw.Split(' ', StringSplitOptions.TrimEntries)[1];
                        int gameRowSetDrawNumber = int.Parse(gameRowSetDraw.Split(' ', StringSplitOptions.TrimEntries)[0]);

                        if (gameRowSetDrawColor == "red" && gameRowSetDrawNumber > gameRowRed) { gameRowRed = gameRowSetDrawNumber; }
                        if (gameRowSetDrawColor == "green" && gameRowSetDrawNumber > gameRowGreen) { gameRowGreen = gameRowSetDrawNumber; }
                        if (gameRowSetDrawColor == "blue" && gameRowSetDrawNumber > gameRowBlue) { gameRowBlue = gameRowSetDrawNumber; }
                    }
                }

                if (isGamePossible)
                {
                    gameSum += gameRowRed * gameRowGreen * gameRowBlue;
                }

            }

            Console.WriteLine("Answer Part 2 : " + gameSum);
        }
	}
}