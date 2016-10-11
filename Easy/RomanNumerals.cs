using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

class Program
{
	static void Main(string[] args)
	{
		var romans = new NameValueCollection {
			{ "1000", "M" }, { "900", "CM" },
			{ "500", "D" }, { "400", "CD" },
			{ "100", "C" }, { "90", "XC" },
			{ "50", "L" }, { "40", "XL" },
			{ "10", "X" }, { "9", "IX" },
			{ "5", "V" }, { "4", "IV" },
			{ "1", "I" }
		};

		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line
				var decim = Int32.Parse (line);
				var result = "";
				for (int i = 0; i < romans.Count; i++) {
					var current = Int32.Parse (romans.GetKey (i));
					while (decim >= current) {
						result += romans.Get (i);
						decim -= current;
					}
				}

				Console.WriteLine (result);
			}
	}
}






