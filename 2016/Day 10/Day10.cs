using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Y2016 {
	class Day10 {
		
		public struct BotObject {
			public int id;
			public List<int> valueCollection;
		
			public int lowValueToId;
			public int highValueToId;
			
			public bool outputLow;
			public bool outputHigh;
		}
		
		public struct outputObject {
			public int id;
			public int value;
		}
		
		public static List<BotObject> bots;
		public static List<BotObject> botsWithTwoValues;
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			setupBots(instructions);
			addValuesToBots(instructions);
			runBotTransactions();
			
			int responisbleBot = bots.First(bot => bot.valueCollection.Contains(17) && bot.valueCollection.Contains(61)).id;
			
			Console.WriteLine("Answer Part 1 : " + responisbleBot);
		}
		
		public static void Step2(string[] instructions) {
					
			setupBots(instructions);
			addValuesToBots(instructions);
			runBotTransactions();

			int multipliedValues = multiplyOutputs();

			Console.WriteLine("Answer Part 2 : " + multipliedValues);
		}

		public static void setupBots(string[] instructions) {
			
			bots = new List<BotObject>();
			
			foreach(string instruction in instructions) {
				if(instruction.StartsWith("bot")) {
					string[] botData = instruction.Split(' ');
					
					BotObject bot = new BotObject();
					
					bot.id = int.Parse(botData[1]);
					bot.lowValueToId = int.Parse(botData[6]);
					bot.highValueToId = int.Parse(botData[11]);
					bot.valueCollection = new List<int>();

					if (botData[5] == "output") {
						bot.outputLow = true;
					}
					
					if (botData[10] == "output") {
						bot.outputHigh = true;
					}
                	
					bots.Add(bot);
				}
			}
		}
		
		public static void addValuesToBots(string[] instructions) {
			foreach (string instruction in instructions) {
				if (instruction.StartsWith("value")) {
					string[] botData = instruction.Split(' ');
                    
					int value = int.Parse(botData[1]);
					int botId = int.Parse(botData[5]);

					BotObject tmpBot = bots.First(bot => bot.id == botId);
                    
					tmpBot.valueCollection.Add(value);	
				}
			}
		}
		
		public static void runBotTransactions() {
			bool allTransactionsDone = false;
			
			while (!allTransactionsDone) {
				
				if(bots.Count(b => b.valueCollection.Count == 2) == bots.Count) {
					allTransactionsDone = true;
				}
				
				botsWithTwoValues = bots.Where(b => b.valueCollection.Count == 2).ToList();
				
				foreach (BotObject bot in botsWithTwoValues) {
					
					if(bot.valueCollection.Count == 2) {
						
						if (!bot.outputLow) {
							BotObject receiverBot = bots.First(b => b.id == bot.lowValueToId);
							
							if(receiverBot.valueCollection.Count < 2) {
								receiverBot.valueCollection.Add(bot.valueCollection.Min());
							}
						}
	
						if (!bot.outputHigh) {
							BotObject receiverBot = bots.First(b => b.id == bot.highValueToId);
							
							if(receiverBot.valueCollection.Count < 2) {
								receiverBot.valueCollection.Add(bot.valueCollection.Max());
							}
						}
					}
				}
			}
		}
		
		public static int multiplyOutputs() {

			List<outputObject> botsOutput = new List<outputObject>();
			 
			foreach(BotObject bot in bots) {
				
				if(bot.outputLow || bot.outputHigh) {
					outputObject tmpBotsOutput = new outputObject();
					
					if(bot.outputLow) {
						tmpBotsOutput.id = bot.lowValueToId;
						tmpBotsOutput.value = bot.valueCollection.Min();
					} else if(bot.outputHigh) {
						tmpBotsOutput.id = bot.highValueToId;
						tmpBotsOutput.value = bot.valueCollection.Max();
					}
					
					botsOutput.Add(tmpBotsOutput);
				}
			}
			
			int multipliedAnswer = 1;
			foreach(outputObject output in botsOutput) {
				if(output.id == 0 || output.id == 1 || output.id == 2) {
					multipliedAnswer *= output.value;
				}
			}
			
			return multipliedAnswer;
		}
	}
}