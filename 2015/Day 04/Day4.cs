using System;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode.Y2015 {
	class Day4 {
		public static void Main(string[] args) {
			
			string key = System.IO.File.ReadAllText(@"../../input.txt");
				
			Step1(key);
			Step2(key);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string key) {
			bool foundIt = false;
			int i = 0;
			MD5 hasher = MD5.Create();
				
			while(!foundIt) {
				string tempkey = key + i.ToString();
				
				byte[] hashData = hasher.ComputeHash(Encoding.UTF8.GetBytes(tempkey));
				
				StringBuilder hashString = new StringBuilder();
				for (int x = 0; x < hashData.Length; x++) {
					hashString.Append(hashData[x].ToString("x2"));
				}
				
				if(hashString.ToString().Substring(0,5).Equals("00000")) {
					foundIt = true;
				} else {
					i++;
				}
			}
			
			Console.WriteLine("Answer Part 1 : " + i);
		}
		
		public static void Step2(string key) {
			bool foundIt = false;
			int i = 0;
			MD5 hasher = MD5.Create();
				
			while(!foundIt) {
				string tempkey = key + i.ToString();
				
				byte[] hashData = hasher.ComputeHash(Encoding.UTF8.GetBytes(tempkey));
				
				StringBuilder hashString = new StringBuilder();
				for (int x = 0; x < hashData.Length; x++) {
					hashString.Append(hashData[x].ToString("x2"));
				}
				
				if(hashString.ToString().Substring(0,6).Equals("000000")) {
					foundIt = true;
				} else {
					i++;
				}
			}	
				
			Console.WriteLine("Answer Part 2 : " + i);
		}
	}
}