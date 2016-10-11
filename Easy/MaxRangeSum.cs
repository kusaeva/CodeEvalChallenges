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
				var input = line.Split (';');
				var daysCount = Int32.Parse (input [0]);
				var gains = Array.ConvertAll (input [1].Split (' '), Int32.Parse);

				var maxGain = 0;
				for (var i = 0; i < gains.Length - daysCount + 1; i++) {
					var gain = 0;
					for (var j = 0; j < daysCount; j++) {
						gain += gains [i + j];
					}

					maxGain = gain > maxGain ? gain : maxGain;
				}

				var result = maxGain.ToString ();
				Console.WriteLine (result);
			}
	}
}
