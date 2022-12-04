using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2021 {
	class Day2 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 02/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			int posX = 0;
			int posY = 0;

			foreach (string positionChange in instructions) {
                string[] movement = positionChange.Split(' ');

                switch (movement[0]) {
					case "forward":
						posX = posX + int.Parse(movement[1]);
						break;
					case "down":
                        posY = posY + int.Parse(movement[1]);
                        break;
					case "up":
                        posY = posY - int.Parse(movement[1]);
                        break;
					default:
						break;
				}
            }

            Console.WriteLine("Answer Part 1 : " + (posX * posY));
		}
		
		public static void Step2(string[] instructions) {

            int posX = 0;
            int posY = 0;
            int posAim = 0;

            foreach (string positionChange in instructions)
            {
                string[] movement = positionChange.Split(' ');

                switch (movement[0])
                {
                    case "forward":
                        posX = posX + int.Parse(movement[1]);
                        posY = posY + (posAim * int.Parse(movement[1]));
                        break;
                    case "down":
                        posAim = posAim + int.Parse(movement[1]);
                        break;
                    case "up":
                        posAim = posAim - int.Parse(movement[1]);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Answer Part 2 : " + (posX * posY));
		}
	}
}