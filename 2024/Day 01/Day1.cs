using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Immutable;
using System.Collections;

namespace AdventOfCode.Y2024
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

            int sumDistance = 0;

            List<int> extractedPrimaryLocationIds = new List<int>();
            List<int> extractedSecondaryLocationIds = new List<int>();

            foreach (string locationData in instructions) {

                int extractedPrimaryLocation = int.Parse(locationData.Split(' ')[0]);
                int extractedSecondaryLocation = int.Parse(locationData.Split(' ')[3]);


                extractedPrimaryLocationIds.Add(extractedPrimaryLocation);
                extractedSecondaryLocationIds.Add(extractedSecondaryLocation);
            }

            extractedPrimaryLocationIds.Sort();
            extractedSecondaryLocationIds.Sort();

            for (int i =0; i < extractedPrimaryLocationIds.Count; i++) {
                int distance = 0;

                if (extractedPrimaryLocationIds[i] > extractedSecondaryLocationIds[i])
                {
                    distance = extractedPrimaryLocationIds[i] - extractedSecondaryLocationIds[i];
                }
                else {
                    distance = extractedSecondaryLocationIds[i] - extractedPrimaryLocationIds[i];
                }

                sumDistance += distance;
            }

            Console.WriteLine("Answer Part 1 : " + sumDistance);
        }

        public static void Step2(string[] instructions) {

            int sumDistance = 0;

            List<int> extractedPrimaryLocationIds = new List<int>();
            List<int> extractedSecondaryLocationIds = new List<int>();

            foreach (string locationData in instructions)
            {

                int extractedPrimaryLocation = int.Parse(locationData.Split(' ')[0]);
                int extractedSecondaryLocation = int.Parse(locationData.Split(' ')[3]);


                extractedPrimaryLocationIds.Add(extractedPrimaryLocation);
                extractedSecondaryLocationIds.Add(extractedSecondaryLocation);
            }

            for (int i = 0; i < extractedPrimaryLocationIds.Count; i++)
            {
                int numLocationOccurance = extractedSecondaryLocationIds.Count(x => x == extractedPrimaryLocationIds[i]);

                sumDistance += (extractedPrimaryLocationIds[i] * numLocationOccurance);
            }

            Console.WriteLine("Answer Part 2 : " + sumDistance);
        }
    }
}