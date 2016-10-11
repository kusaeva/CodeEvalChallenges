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
				var isUpper = true;
				var charArray = line.ToCharArray ();
				for (int i = 0; i < charArray.Length; i++) {
					var ch = charArray[i];
					if (char.IsLetter (ch)) {
						charArray[i] = isUpper ? char.ToUpper (ch) : char.ToLower(ch);
						isUpper = !isUpper;
					}
				}
				Console.WriteLine (string.Join("",charArray));
			}
	}
}
