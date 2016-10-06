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

				var arr = line.Split (' ');
				var word = arr [0].ToCharArray();
				var binary = arr [1];

				for (int i = 0; i < word.Length; i++) {
					if (binary [i] == '1') {
						word [i] = char.ToUpper (word [i]);
					}
				}
				var result = string.Join("", word);

				Console.WriteLine (result);
			}
	}
}



