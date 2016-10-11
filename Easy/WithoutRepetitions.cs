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

				var chars = line.ToCharArray();

				var prev = line[0];
				var result = prev.ToString();
				for (var i = 1; i < line.Length; i++) {
					if (line[i] != prev) {
						result += line[i].ToString();
						prev = line[i];
					}
				}

				Console.WriteLine (result);
			}
	}
}






