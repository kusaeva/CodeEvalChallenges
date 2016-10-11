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

				var sum = 0;
				int index = 0;

				while (index < line.Length) {
					index = line.IndexOf ("label", index);

					if (index == -1)
						break;
					
					var idIndex = line.Substring (0, index).LastIndexOf ("id");
					var id = Int32.Parse (line.Substring (idIndex).Split (',') [0].Split (':') [1].Trim ());
					sum += id;

					index += 1;
				}

				var result = sum.ToString ();
				Console.WriteLine (result);
			}
	}
}

