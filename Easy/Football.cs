using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line

				var dict = new Dictionary<int, List<int>> ();
				var input = line.Split ('|');

				for (var i = 0; i < input.Length; i++) {
					var country = i + 1;
					var teams = Array.ConvertAll (input [i].Trim().Split (' '), Int32.Parse);

					List<int> countries;
					foreach(var team in teams) {
						if (dict.TryGetValue (team, out countries)) {
							dict.Remove (team);
						} else {
							countries = new List<int> ();
						}
						countries.Add (country);
						dict.Add (team, countries);
					}
				}

				var keys = dict.Keys.ToArray();
				Array.Sort(keys);

				var result = "";
				foreach(var team in keys) {
					List<int> countries;
					dict.TryGetValue (team, out countries);
					result += string.Format("{0}:{1}; ", team, string.Join(",", countries.ToArray()));
				}

				result = result.Trim ();
				Console.WriteLine (result);
			}
	}
}







