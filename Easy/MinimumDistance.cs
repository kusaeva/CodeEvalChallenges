using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{

	static void Main(string[] args) {
		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;

				var input = Array.ConvertAll (line.Split (' '), Int32.Parse);
				input = input.Skip (1).ToArray ();

				Array.Sort (input);
				var min = input [0];
				var max = input [input.Length - 1];

				int? minSum = null;

				for (int i = min; i <= max; i++) {
					var sum = Array.ConvertAll (input, el => Math.Abs (el - i)).Sum ();

					if (!minSum.HasValue) {
						minSum = sum;
					} else {
						minSum = Math.Min (sum, minSum.Value);
					}
				}

				Console.WriteLine (minSum.Value);
			}
	}
}



