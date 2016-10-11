using System;
using System.IO;
using System.Collections.Generic;

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
				var index = line.IndexOf(')');
				var point1 = Array.ConvertAll(line.Substring(1, index - 1).Split(','), Int32.Parse);
				var point2 = Array.ConvertAll(line.Substring (index + 3, line.Length - index - 4).Split(','), Int32.Parse);

				var distance = Math.Sqrt (Math.Pow((point1[0] - point2[0]), 2) + Math.Pow((point1[1] - point2[1]), 2));
				var result = distance.ToString();
				Console.WriteLine (result);
			}
	}
}
