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
				var input = Array.ConvertAll(line.Split(' '), Int32.Parse);

				var n = input [1];
				var searchCount = input [0];
				var result = 0;

				for (int i = 1; i <= n; i++) {
					var b = Convert.ToString (i, 2);
					int count = b.Split ('0').Length - 1;
					if (count == searchCount) {
						result++;
					}
				}

				Console.WriteLine (result);
			}
	}
}
