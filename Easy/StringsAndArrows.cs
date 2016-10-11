using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var leftArrow = "<--<<";
		var rightArrow = ">>-->";
		var arrowLength = leftArrow.Length;

		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line
				var index = 0;
				var count = 0;

				while (index < line.Length) {
					var leftArrowIndex = line.IndexOf (leftArrow, index);
					var rightArrowIndex = line.IndexOf (rightArrow, index);

					bool leftFound = leftArrowIndex > -1;
					bool rightFound = rightArrowIndex > -1;

					if (!leftFound && !rightFound)
						break;

					count++;
					if (!leftFound) {
						index = rightArrowIndex;
					} else if (!rightFound) {
						index = leftArrowIndex;
					} else
						index = Math.Min (leftArrowIndex, rightArrowIndex);

					index = index + arrowLength - 1;
				}
				Console.WriteLine (count);
			}
	}
}


