using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode {
	
	class Day7 {
		
		public struct InstructionObject {
			public int Action;
			public string[] Data;
			public string OrgLine;
		}
		
		public static int WireOverrideValue;
			
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			Dictionary<string, UInt16> circuitBoardGates = new Dictionary<string, UInt16>();
			List<InstructionObject> arrInstructions = new List<InstructionObject>();
			
			foreach (string instruction in instructions) {
				
				InstructionObject InstObj = new InstructionObject();

				InstObj.OrgLine = instruction;
    			
				if(instruction.Contains("AND")) {
					InstObj.Action = 1;
					InstObj.Data = instruction.Replace(" AND ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("OR")) {
					InstObj.Action = 2;
					InstObj.Data = instruction.Replace(" OR ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("LSHIFT")) {
					InstObj.Action = 3;
					InstObj.Data = instruction.Replace(" LSHIFT ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("RSHIFT")) {
					InstObj.Action = 4;
					InstObj.Data = instruction.Replace(" RSHIFT ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("NOT")) {
					InstObj.Action = 5;
					InstObj.Data = instruction.Replace("NOT ", "").Replace(" -> ", ";").Split(';');
				} else {
					InstObj.Action = 6;
					InstObj.Data = instruction.Replace(" -> ", ";").Split(';');
				}

				arrInstructions.Add(InstObj);
			}    

			while(arrInstructions.Count > 0) {
				for(int i = 0; i < arrInstructions.Count; i++) {
					
					InstructionObject instruction = arrInstructions[i];
					
					bool canBeSolved = true;
					
					UInt16 value = 0;
					UInt16 op1 = 0;
					UInt16 op2 = 0;

					if(circuitBoardGates.ContainsKey(instruction.Data[0])) {
						op1 = circuitBoardGates[instruction.Data[0]];
					} else if (!UInt16.TryParse(instruction.Data[0], out op1)) {
						canBeSolved = false;
					}

					if (instruction.Data.Length > 2) {
						if (circuitBoardGates.ContainsKey(instruction.Data[1])) {
							op2 = circuitBoardGates[instruction.Data[1]];
						} else if (!UInt16.TryParse(instruction.Data[1], out op2)) {
							canBeSolved = false;
						}
					} 

					if (canBeSolved) {
						switch (instruction.Action) {
							
							case 1 : 
								value = (UInt16)(op1 & op2);
								break;
							case 2 :   
								value = (UInt16)(op1 | op2);
								break;
							case 3 : 
								value = (UInt16)(op1 << op2);
								break;
							case 4 : 
								value = (UInt16)(op1 >> op2);
								break;
							case 5 : 
								value = (UInt16)(~op1);
								break;
							case 6 :
								value = op1;
								break;
						}
						
						circuitBoardGates[instruction.Data[instruction.Data.Length-1]] = value;
			
						arrInstructions.Remove(instruction);
					}
				}
			} 

			int signalOnWire = circuitBoardGates["a"];
			WireOverrideValue = signalOnWire;
			
			Console.WriteLine("Answer Part 1 : " + signalOnWire);
		}
		
		public static void Step2(string[] instructions) {

			Dictionary<string, UInt16> circuitBoardGates = new Dictionary<string, UInt16>();
			List<InstructionObject> arrInstructions = new List<InstructionObject>();
			
			foreach (string instruction in instructions) {
				
				InstructionObject InstObj = new InstructionObject();

				InstObj.OrgLine = instruction;
    			
				if(instruction.Contains("AND")) {
					InstObj.Action = 1;
					InstObj.Data = instruction.Replace(" AND ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("OR")) {
					InstObj.Action = 2;
					InstObj.Data = instruction.Replace(" OR ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("LSHIFT")) {
					InstObj.Action = 3;
					InstObj.Data = instruction.Replace(" LSHIFT ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("RSHIFT")) {
					InstObj.Action = 4;
					InstObj.Data = instruction.Replace(" RSHIFT ", ";").Replace(" -> ", ";").Split(';');
				} else if(instruction.Contains("NOT")) {
					InstObj.Action = 5;
					InstObj.Data = instruction.Replace("NOT ", "").Replace(" -> ", ";").Split(';');
				} else {
					InstObj.Action = 6;
					
					string[] overrideInstructionControl = instruction.Replace(" -> ", ";").Split(';');
					
					if(overrideInstructionControl[1] == "b") {
						overrideInstructionControl[0] = WireOverrideValue.ToString();
					}
					
					InstObj.Data = overrideInstructionControl;
				}

				arrInstructions.Add(InstObj);
			} 
			
			while(arrInstructions.Count > 0) {
				for(int i = 0; i < arrInstructions.Count; i++) {
					
					InstructionObject instruction = arrInstructions[i];
					
					bool canBeSolved = true;
					
					UInt16 value = 0;
					UInt16 op1 = 0;
					UInt16 op2 = 0;

					if(circuitBoardGates.ContainsKey(instruction.Data[0])) {
						op1 = circuitBoardGates[instruction.Data[0]];
					} else if (!UInt16.TryParse(instruction.Data[0], out op1)) {
						canBeSolved = false;
					}

					if (instruction.Data.Length > 2) {
						if (circuitBoardGates.ContainsKey(instruction.Data[1])) {
							op2 = circuitBoardGates[instruction.Data[1]];
						} else if (!UInt16.TryParse(instruction.Data[1], out op2)) {
							canBeSolved = false;
						}
					} 

					if (canBeSolved) {
						switch (instruction.Action) {
							
							case 1 : 
								value = (UInt16)(op1 & op2);
								break;
							case 2 :   
								value = (UInt16)(op1 | op2);
								break;
							case 3 : 
								value = (UInt16)(op1 << op2);
								break;
							case 4 : 
								value = (UInt16)(op1 >> op2);
								break;
							case 5 : 
								value = (UInt16)(~op1);
								break;
							case 6 :
								value = op1;
								break;
						}
						
						circuitBoardGates[instruction.Data[instruction.Data.Length-1]] = value;
			
						arrInstructions.Remove(instruction);
					}
				}
			} 

			int signalOnWire = circuitBoardGates["a"];
			Console.WriteLine("Answer Part 2 : " + signalOnWire);
		}
	}
}