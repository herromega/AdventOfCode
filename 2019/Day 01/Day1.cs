using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2019 {
	class Day1 {

        public static string xxxx = "";
        public static void Main(string[] args) {

            string[] instructions = System.IO.File.ReadAllLines(@"../../../Day 01/input.txt");

            Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string[] instructions) {

			double fuelReqiurementsPerModule = 0;
			double fuelRequirementInTotal = 0;

			foreach (string moduleMass in instructions) {

				fuelReqiurementsPerModule = (Math.Floor(double.Parse(moduleMass) / 3) - 2);

                fuelRequirementInTotal += fuelReqiurementsPerModule;
            }

            Console.WriteLine("Answer Part 1 : " + fuelRequirementInTotal);
		}
		
		public static void Step2(string[] instructions) {

            double fuelReqiurementsPerModule = 0;
            double fuelAdditionalRequirementsPerModule = 0;
            double fuelRequirementInTotal = 0;

            foreach (string moduleMass in instructions) {

                fuelReqiurementsPerModule = (Math.Floor(double.Parse(moduleMass) / 3) - 2);
                fuelAdditionalRequirementsPerModule = fuelReqiurementsPerModule;


                while (fuelAdditionalRequirementsPerModule > 0) {
                    fuelAdditionalRequirementsPerModule = (Math.Floor(fuelAdditionalRequirementsPerModule / 3) - 2);

                    if (fuelAdditionalRequirementsPerModule >= 0 ) {
                        fuelReqiurementsPerModule += fuelAdditionalRequirementsPerModule;
                    }
                }

                fuelRequirementInTotal += fuelReqiurementsPerModule;
            }
		}
	}
}