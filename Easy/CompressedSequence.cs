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

				var array = line.Split (' ');

				var result = "";
				var prev = array [0];
				var count = 1;

				for (int i = 1; i < array.Length; i++){
					if (array [i] == prev) {
						count++;
					} else {
						result += string.Format("{0} {1} ", count, prev);
						prev = array [i];
						count = 1;
					}
				}

				result += string.Format("{0} {1} ", count, prev);
				result = result.Trim ();

				Console.WriteLine (result);
			}
	}
}


