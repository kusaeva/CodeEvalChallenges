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

				var input = Array.ConvertAll(line.Split (','), Int32.Parse);

				var binary = Convert.ToString (input [0], 2);
				var bit1 = binary [binary.Length - input [1]];
				var bit2 = binary [binary.Length - input [2]];

				Console.WriteLine ( bit1 == bit2 ? "true" : "false");
			}
	}
}




