using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection.PortableExecutable;

namespace AdventOfCode.Y2017 {
	class Day1 {

		public static string xxxx = "";
		public static void Main(string[] args) {
        	
			string instructions = System.IO.File.ReadAllText(@"../../../Day 01/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string instructions) {

            int captcha = 0;

            for (int i = 0; i < instructions.Length; i++) {
                if (instructions[i] == instructions[(i + 1) % instructions.Length]) {
                    captcha += Int32.Parse(instructions[i].ToString());
                }
            }

            Console.WriteLine("Answer Part 1 : " + captcha);
		}
		
		public static void Step2(string instructions) {

            int captcha = 0;

            for (int i = 0; i < instructions.Length; i++) {
                if (instructions[i] == instructions[(i + instructions.Length / 2) % instructions.Length]) {
                    captcha += Int32.Parse(instructions[i].ToString());
                }
            }

            Console.WriteLine("Answer Part 2 : " + captcha);
		}
	}
}