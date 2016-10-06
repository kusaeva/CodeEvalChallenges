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
				
				var numbers = line.Split (' ');
				var n = numbers.Length;
				var rotated = new string[numbers.Length];
				var N = (int)Math.Sqrt (n);
				var i = 0;
				for (var j = N - 1; j >= 0; j--) {
					for (var k = 0; k < N; k++) {
						rotated [j + k * N] = numbers [i];
						i++;
					}

				}
				var result = string.Join (" ", rotated);

				Console.WriteLine (result);
			}
	}
}







