using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

namespace AdventOfCode.Y2022 {
	class Day6 {

        public static string xxxx = "";
        public static void Main(string[] args) {
        	
			string instructions = System.IO.File.ReadAllText(@"../../../Day 06/input.txt");
				
			Step1(instructions);
			Step2(instructions);
        	
			Console.ReadKey(true);
		}

		public static void Step1(string instructions) {

			int StartOfPacketMarkerFoundAt = 0;

            for (int packetMarkerCounter = 3; packetMarkerCounter < instructions.Length; packetMarkerCounter++) {

                string packetMarkerTestBatch = instructions.Substring(packetMarkerCounter - 3, 4);

				if(packetMarkerTestBatch.Distinct().Count() == 4) {
                    StartOfPacketMarkerFoundAt = packetMarkerCounter + 1;
					break;
                }
            }

            Console.WriteLine("Answer Part 1 : " + StartOfPacketMarkerFoundAt);
		}
		
		public static void Step2(string instructions) {

            int StartOfPacketMarkerFoundAt = 0;

            for (int packetMarkerCounter = 13; packetMarkerCounter < instructions.Length; packetMarkerCounter++) {

                string packetMarkerTestBatch = instructions.Substring(packetMarkerCounter - 13, 14);

                if (packetMarkerTestBatch.Distinct().Count() == 14)
                {
                    StartOfPacketMarkerFoundAt = packetMarkerCounter + 1;
                    break;
                }
            }

            Console.WriteLine("Answer Part 2 : " + StartOfPacketMarkerFoundAt);
		}
	}
}