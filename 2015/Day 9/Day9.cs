using System;
using System.Collections.Generic;

namespace AdventOfCode {
	
	class Day9 {
		
		public static List<RouteObject> routeObjects;
		public static List<string> cityObjects;
		public static List<string> possibleRoutes;
		
		public struct RouteObject {
			public string From;
			public string To;
			public int Distance;
		}
		
		public static void Main(string[] args) {
			
			string[] instructions = System.IO.File.ReadAllLines(@"../../input.txt");
			
			Step1(instructions);
			Step2(instructions);
			
			Console.ReadKey(true);
		}
		
		public static void Step1(string[] instructions) {
			
			routeObjects = new List<RouteObject>();
			cityObjects = new List<string>();
			possibleRoutes = new List<string>();
			
			setupRoutes(instructions);
			
			possibleRoutes = getPossibleRoutes(cityObjects);

			int shortestDistance = int.MaxValue;

			foreach (string route in possibleRoutes) {
				
				int routeDistance = getRouteDistance(route);

				if(routeDistance < shortestDistance) {
					shortestDistance = routeDistance;
				}
			}
			
			Console.WriteLine("Answer Part 1 : " + shortestDistance);
		}
		
		public static void Step2(string[] instructions) {

			routeObjects = new List<RouteObject>();
			cityObjects = new List<string>();
			possibleRoutes = new List<string>();
			
			setupRoutes(instructions);
			
			possibleRoutes = getPossibleRoutes(cityObjects);

			int longestDistance = int.MinValue;

			foreach (string route in possibleRoutes) {
				
				int routeDistance = getRouteDistance(route);

				if(routeDistance > longestDistance) {
					longestDistance = routeDistance;
				}
			}
			
			
			Console.WriteLine("Answer Part 2 : " + longestDistance);
		}
		
		public static void setupRoutes(string[] instructions) {
			foreach (string line in instructions) {
				
				string[] routeLine;
				
				routeLine = line.Replace(" to ", ";").Replace(" = ", ";").Split(';');
    
				RouteObject route = new RouteObject();
				route.From = routeLine[0];
				route.To = routeLine[1];
				route.Distance = Convert.ToInt16(routeLine[2]);
				routeObjects.Add(route);
				
				RouteObject reverseRoute = new RouteObject();
				reverseRoute.From = routeLine[1];
				reverseRoute.To = routeLine[0];
				reverseRoute.Distance = Convert.ToInt16(routeLine[2]);
				routeObjects.Add(reverseRoute);

				if(!cityObjects.Contains(routeLine[0])) { 
					cityObjects.Add(routeLine[0]);
				}

				if(!cityObjects.Contains(routeLine[1])) { 
					cityObjects.Add(routeLine[1]);
				}
			}
		}
		
		public static List<string> getPossibleRoutes(List<string> citys) {

			if (citys.Count == 1) {
				return citys;
			}
			
			List<string> tmpPossibleRoutes = new List<string>();
    
			foreach (string city in citys) {  
				List<string> tmpCitys = new List<string>(citys) ;
				List<string> tmpCityRoutes = new List<string>();

				tmpCitys.Remove(city);

				tmpCityRoutes = getPossibleRoutes(tmpCitys);
        
				foreach (string tmpRoute in tmpCityRoutes) {
					tmpPossibleRoutes.Add(city + ";" + tmpRoute);
				}
			}
    
			return tmpPossibleRoutes;
		}

		public static int getRouteDistance(string route) {
			string[] routeParts = route.Split(';');

			int totalLength = 0;
			
			for (int i = 0; i < routeParts.Length-1; i++) { 
				RouteObject tmpObj = routeObjects.Find(x => x.From.Equals(routeParts[i]) && x.To.Equals(routeParts[i+1]));
				totalLength += tmpObj.Distance;
			}

			return totalLength;
		}
	}
}