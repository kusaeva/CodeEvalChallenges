using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var board = new int[256, 256];

		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line

				var operation = line.Split (new char[] {' '}, 2);
				var kind = operation [0];

				switch (kind) {
				case "SetCol": {
						var values = Array.ConvertAll (operation [1].Split (' '), Int32.Parse);
						for (var j = 0; j < 256; j++) {
							board [values [0], j] = values [1];
						}
						break;
					}
				case "SetRow": {
						var values = Array.ConvertAll (operation [1].Split (' '), Int32.Parse);
						for (var j = 0; j < 256; j++) {
							board [j, values [0]] = values [1];
						}
						break;
					}
				case "QueryCol": {
						var value = Int32.Parse(operation [1]);
						var sum = 0;

						for (var j = 0; j < 256; j++) {
							sum += board [value, j];
						}

						Console.WriteLine (sum);

						break;
					}
				case "QueryRow": {
						var value = Int32.Parse(operation [1]);
						var sum = 0;

						for (var j = 0; j < 256; j++) {
							sum += board [j, value];
						}

						Console.WriteLine (sum);

						break;
					}
				}
			}
	}
}


