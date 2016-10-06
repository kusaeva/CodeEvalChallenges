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

				var words = line.Split (' ');
				var result = "";

				foreach (var w in words) {
					var word = w.ToArray ();
					var temp = word [0];
					word [0] = word [word.Length - 1];
					word [word.Length - 1] = temp;
					result += (string.Join ("", word));
					result += " ";
				}

				result = result.Trim ();
				Console.WriteLine (result);
			}
	}
}

