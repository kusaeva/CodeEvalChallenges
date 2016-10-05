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
				var input = line.Split ('|');

				var virus = Array.ConvertAll (input [0].Trim ().Split (' '), x => Convert.ToInt32 (x, 16));
				var antivirus = Array.ConvertAll (input [1].Trim ().Split (' '), x => Convert.ToInt32 (x, 2));
				Console.WriteLine (virus.Sum () <= antivirus.Sum ());
			}
	}
}




