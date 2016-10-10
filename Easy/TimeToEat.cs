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

				var timestamps = Array.ConvertAll(line.Split (' '), TimeSpan.Parse);

				Array.Sort (timestamps, delegate(TimeSpan x, TimeSpan y) {
					return y.CompareTo(x);
				});

				var result = string.Join (" ", timestamps);
				Console.WriteLine (result);
			}
	}
}


