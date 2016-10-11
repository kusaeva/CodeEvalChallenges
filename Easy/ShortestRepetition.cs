using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

				var len = 1;
				var word = line.Substring (0, len);
				var count = 1;
				while (word != line) {
					count = Regex.Matches (line, word).Count;
					if (count * len == line.Length) {
						break;
					}
					len++;
					word = line.Substring (0, len);
				}
				var result = word.Length.ToString();

				Console.WriteLine (result);
			}
	}
}

