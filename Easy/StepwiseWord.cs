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
				var array = line.Split (' ');
				var longest = array [0];
				for (var i = 1; i < array.Length; i++) {
					if (array [i].Length > longest.Length) {
						longest = array [i];
					}
				}

				var result = "";
				for (var i = 0; i < longest.Length; i++) {
					result += longest [i].ToString().PadLeft (i + 1, '*');
					result += " ";
				}

				result = result.Trim ();
				Console.WriteLine (result);
			}
	}
}
