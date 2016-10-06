using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var prevIndex = -1;

		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line

				var index = line.IndexOf('C');
				char current;
				if (index != -1) {
					current = 'C';
				} else {
					index = line.IndexOf('_');
					current = '_';
				}
				char direction;
				if (prevIndex == -1 || prevIndex == index) {
					direction = '|';
				} else {
					direction = (prevIndex > index) ? '/' : '\\';
				}
				prevIndex = index;
				var result = line.Replace(current, direction);

				Console.WriteLine (result);
			}
	}
}


