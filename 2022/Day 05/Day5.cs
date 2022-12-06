using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Security.AccessControl;
using System.ComponentModel;
using System.Collections;

namespace AdventOfCode.Y2022 {
	class Day5 {

        public static string stackTopCrates;

        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 05/input.txt");
				
			Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

            List<Stack<string>> crateStacks = new List<Stack<string>>();
            
			List<string> crateStacksDrawing = new List<string>();
            List<(int numCrates, int fromStack, int toStack)> crateMovement = new List<(int numCrates, int fromStack, int toStack)>();

			foreach (string instructionRow in instructions) {

                if (instructionRow.StartsWith("move")) {
					string[] breakdownMovement = instructionRow.Split(' ');
                    crateMovement.Add((int.Parse(breakdownMovement[1]), int.Parse(breakdownMovement[3]), int.Parse(breakdownMovement[5])));

				} else if (!string.IsNullOrWhiteSpace(instructionRow)) {
                    crateStacksDrawing.Add(instructionRow);

                }
            }

            crateStacksDrawing.RemoveAt(crateStacksDrawing.Count -1);
            crateStacksDrawing.Reverse();

            int numOfCrateStacks = ((crateStacksDrawing[0].Length + 1) / 4);

            for (int numstack = 0; numstack < numOfCrateStacks; numstack++) {
                crateStacks.Add(new Stack<string>()); 
            }

            for(int crateStacksDrawingRow = 0; crateStacksDrawingRow < crateStacksDrawing.Count; crateStacksDrawingRow++) {

                int crateStacksDrawingStack = 0;

                for (int i = 0; i < (crateStacksDrawing[crateStacksDrawingRow].Length - 1); i=i+4) { 

                    if (crateStacksDrawing[crateStacksDrawingRow].Substring(i+1, 1) != " ") {
                        crateStacks[crateStacksDrawingStack].Push(crateStacksDrawing[crateStacksDrawingRow].Substring(i+1, 1));
                    }


                    crateStacksDrawingStack++;
                }
			}

            foreach ((int numCrates, int fromStack, int toStack) in crateMovement) {
                for (var i = 0; i < numCrates; i++) {

                    string crateContent = crateStacks[fromStack - 1].Pop();

                    crateStacks[toStack - 1].Push(crateContent);
                }
            }

            stackTopCrates = "";

            for (var i = 0; i < numOfCrateStacks; i++) {
                stackTopCrates += crateStacks[i].Peek();
            }


            Console.WriteLine("Answer Part 1 : " + stackTopCrates);
		}
		
		public static void Step2(string[] instructions) {

            List<Stack<string>> crateStacks = new List<Stack<string>>();

            List<string> crateStacksDrawing = new List<string>();
            List<(int numCrates, int fromStack, int toStack)> crateMovement = new List<(int numCrates, int fromStack, int toStack)>();

            foreach (string instructionRow in instructions) {

                if (instructionRow.StartsWith("move")) {
                    string[] breakdownMovement = instructionRow.Split(' ');
                    crateMovement.Add((int.Parse(breakdownMovement[1]), int.Parse(breakdownMovement[3]), int.Parse(breakdownMovement[5])));

                }
                else if (!string.IsNullOrWhiteSpace(instructionRow)) {
                    crateStacksDrawing.Add(instructionRow);

                }
            }

            crateStacksDrawing.RemoveAt(crateStacksDrawing.Count - 1);
            crateStacksDrawing.Reverse();

            int numOfCrateStacks = ((crateStacksDrawing[0].Length + 1) / 4);

            for (int numstack = 0; numstack < numOfCrateStacks; numstack++) { 
                crateStacks.Add(new Stack<string>()); 
            }

            for (int crateStacksDrawingRow = 0; crateStacksDrawingRow < crateStacksDrawing.Count; crateStacksDrawingRow++) { 

                int crateStacksDrawingStack = 0;

                for (int i = 0; i < (crateStacksDrawing[crateStacksDrawingRow].Length - 1); i = i + 4) { 

                    if (crateStacksDrawing[crateStacksDrawingRow].Substring(i + 1, 1) != " ") {
                        crateStacks[crateStacksDrawingStack].Push(crateStacksDrawing[crateStacksDrawingRow].Substring(i + 1, 1));
                    }

                    crateStacksDrawingStack++;
                }
            }

            foreach ((int numCrates, int fromStack, int toStack) in crateMovement) {
                List<string> multipleCrateMove = new List<string>();

                for (var i = 0; i < numCrates; i++) {
                    multipleCrateMove.Add(crateStacks[fromStack - 1].Pop());
                }

                multipleCrateMove.Reverse();   

                for (var i = 0; i < multipleCrateMove.Count; i++) {
                    crateStacks[toStack - 1].Push(multipleCrateMove[i]);
                }
                
            }

            stackTopCrates = "";

            for (var i = 0; i < numOfCrateStacks; i++) {
                stackTopCrates += crateStacks[i].Peek();
            }

            Console.WriteLine("Answer Part 2 : " + stackTopCrates);
		}
	}
}

