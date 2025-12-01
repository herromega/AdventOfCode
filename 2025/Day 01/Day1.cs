using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Immutable;
using System.Collections;

namespace AdventOfCode.Y2025
{
    class Day1
    {

        public static string xxxx = "";
        public static void Main(string[] args) {

            string[] instructions = System.IO.File.ReadAllLines(@"../../../input.txt");

            Step1(instructions);
            Step2(instructions);

            Console.ReadKey(true);
        }

        public static void Step1(string[] instructions) {

            int dial = 50;
            int zerohits = 0;

            foreach (string rotation in instructions) {

                string direction = rotation.Substring(0,1);
                int clicks = int.Parse(rotation.Substring(1));

                if (direction.StartsWith('L')) {
                    clicks = -clicks;
                } 

                dial = (dial + clicks) % 100;

                if (dial == 0) { zerohits++; }

            }

            Console.WriteLine("Answer Part 1 : " + zerohits);
        }

        public static void Step2(string[] instructions) {

            int dial = 50;
            int zerohits = 0;

            foreach (string rotation in instructions)
            {

                string direction = rotation.Substring(0, 1);
                int clicks = int.Parse(rotation.Substring(1));

                for (int click = 0; click < clicks; click++) {

                    if (direction.StartsWith('L')) {
                        dial = dial - 1;
                    } else {
                        dial = dial + 1;
                    }

                    dial = dial % 100;

                    if (dial == 0) { zerohits++; }

                }
            }

            Console.WriteLine("Answer Part 2 : " + zerohits);
        }
    }
}