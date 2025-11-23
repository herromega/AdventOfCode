using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Y2024
{
    class Day2
    {

        public static string xxxx = "";
        public static void Main(string[] args) {

            string[] instructions = System.IO.File.ReadAllLines(@"../../../input.txt");

            Step1(instructions);
            Step2(instructions);

            Console.ReadKey(true);
        }

        public static void Step1(string[] instructions) {

            int safeReports = 0;

            foreach (string reportLine in instructions) {
                List<int> reportLevel = Array.ConvertAll(reportLine.Split(' '), int.Parse).ToList();

                if (IsReportSafe(reportLevel)) { 
                    safeReports++;
                }
            }

            Console.WriteLine("Answer Part 1 : " + safeReports);
        }

        public static void Step2(string[] instructions) {

            int safeReports = 0;

            foreach (string reportLine in instructions) {

                List<int> reportLevel = Array.ConvertAll(reportLine.Split(' '), int.Parse).ToList();

                if (IsReportSafe(reportLevel)) {
                    safeReports++;
                    continue;
                }

                for (var i = 0; i < reportLevel.Count; i++) {
                    var backupReportLevel = new List<int>(reportLevel);
                    backupReportLevel.RemoveAt(i);
 
                    if (IsReportSafe(backupReportLevel)) {
                        safeReports++;
                        break;
                    }
                }

            }

            Console.WriteLine("Answer Part 2 : " + safeReports);
        }

        public static bool IsReportSafe(List<int> reportLevel)
        {
            bool isReportAscending = reportLevel[0] - reportLevel[1] < 0;
            bool isReportDescending = reportLevel[0] - reportLevel[1] > 0;

            int previousReportLevelItem = reportLevel.First();

            foreach (int reportLevelItem in reportLevel.Skip(1)) {
                int levelDiff = (reportLevelItem - previousReportLevelItem);

                if ((levelDiff < 0 && isReportAscending) || (levelDiff > 0 && isReportDescending) || (Math.Abs(levelDiff) > 3 || levelDiff == 0))
                {
                    return false;
                }

                previousReportLevelItem = reportLevelItem;
            }

            return true;
        }
    }
}