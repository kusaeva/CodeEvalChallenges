using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main (string[] args)
	{
		using (StreamReader reader = File.OpenText (args [0]))
			while (!reader.EndOfStream) {
				string line = reader.ReadLine ();
				if (null == line)
					continue;

				var split = line.Split (':');
				var numbers = split [0].Trim().Split(' ');
				var positions = Array.ConvertAll (
					split [1].Split (','), 
					s => {
						var str = s.Trim();
						var pos = Array.ConvertAll(str.Split('-'), Int32.Parse);
						return pos;
					}
				);

				foreach (var pos in positions) {
					var pos1 = pos [0];
					var pos2 = pos [1];

					var temp = numbers [pos2];
					numbers [pos2] = numbers [pos1];
					numbers [pos1] = temp;
				}

				var result = string.Join (" ", numbers);
				Console.WriteLine (result);
			}
	}
}






