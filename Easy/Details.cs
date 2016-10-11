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
				var input = line.Split (',');
				var maxStep = input [0].Length;

				foreach (var row in input) {
					var xLastIndex = row.LastIndexOf ("X");
					var yIndex = row.IndexOf ("Y");
					var pointsCount = row.Substring (xLastIndex + 1, yIndex - xLastIndex - 1).Length;
					maxStep = pointsCount < maxStep ? pointsCount : maxStep;
				}

				var result = maxStep.ToString ();
				Console.WriteLine (result);
			}
	}
}






