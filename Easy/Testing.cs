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

				var develop = input [0].Substring(0, input[0].Length-1);
				var design  = input [1].Substring(1);

				var bugs = 0;
				for (var i = 0; i < develop.Length; i++) {
					if (develop [i] != design [i])
						bugs++;
				}
				if (bugs == 0) {
					Console.WriteLine ("Done");
				} else if (bugs <= 2) {
					Console.WriteLine ("Low");
				} else if (bugs <= 4) {
					Console.WriteLine ("Medium");
				} else if (bugs <= 6) {
					Console.WriteLine ("High");
				} else
					Console.WriteLine ("Critical");
			}
	}
}





