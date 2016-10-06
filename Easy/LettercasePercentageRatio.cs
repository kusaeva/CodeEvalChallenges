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

				var letters = line.ToCharArray();
				int lower = 0;
				int upper = 0;

				for (int i = 0; i < letters.Length; i++) {
					if (char.IsLower (letters [i]))
						lower++;
					else
						upper++;
				}

				double lowerPct = (double)lower / letters.Length * 100;
				double upperPct = (double)upper / letters.Length * 100;

				var result = string.Format ("lowercase: {0:0.00} uppercase: {1:0.00}", lowerPct, upperPct);
				Console.WriteLine (result);
			}
	}
}


