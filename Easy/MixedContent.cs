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
				var array = line.Split(',');
				var words = "";
				var digits = "";
				foreach (var element in array) {
					int num;
					if (Int32.TryParse(element, out num)) {
						digits += element;
						digits += ",";
					} else {
						words += element;
						words += ",";
					}
				}
				words = words.Length > 0 ? words.Substring(0,words.Length-1) : "";
				digits = digits.Length > 0 ? digits.Substring(0, digits.Length-1) : "";
				var result = "";
				if (words.Length > 0 && digits.Length > 0) {
					result = words + "|"  + digits;
				} else
					result = words + digits;
				Console.WriteLine(result);
			}
	}
}
