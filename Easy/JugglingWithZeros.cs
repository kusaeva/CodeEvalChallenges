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

				var input = line.Split (' ');

				var binary = "";
				for (int i = 0; i < input.Length - 1; i+=2) {
					if (input [i].Length == 1) {
						binary += input [i + 1];
					} else {
						var ones = new string ('1', input [i + 1].Length);
						binary += ones;
					}
				}
				var result = Convert.ToInt64(binary,2).ToString();

				Console.WriteLine (result);
			}
	}
}




