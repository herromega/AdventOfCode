using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2017 {
	class Day2 {

        public static string xxxx = "";
        public static void Main(string[] args) {

            string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 02/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

            int spreadsheetCellSum = 0;

            foreach (string spreadsheetRow in instructions) {
				int[] spreadSheetCells = spreadsheetRow.Split('\t').Select(int.Parse).OrderByDescending(x => x).ToArray();

                spreadsheetCellSum += (spreadSheetCells.First() - spreadSheetCells.Last());
            }

            Console.WriteLine("Answer Part 1 : " + spreadsheetCellSum);
		}
		
		public static void Step2(string[] instructions) {

            int spreadsheetCellSum = 0;

            foreach (string spreadsheetRow in instructions) {
                int[] spreadSheetCells = spreadsheetRow.Split('\t').Select(int.Parse).OrderByDescending(x => x).ToArray();

                for(int i = 0; i < spreadSheetCells.Length; i++) {
                    for (int j = 0; j < spreadSheetCells.Length; j++) {

                        if (i == j) { continue; }

                        if (spreadSheetCells[i] % spreadSheetCells[j] == 0) {
                            spreadsheetCellSum += (spreadSheetCells[i] / spreadSheetCells[j]);
                        }
                    }
                }

            }

            Console.WriteLine("Answer Part 2 : " + spreadsheetCellSum);
		}
	}
}