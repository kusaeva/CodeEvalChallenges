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

				var result = "";
				var n = Int32.Parse (line);
				var p = 2;
				var mersenne = Math.Pow (2, p) - 1;
				while (mersenne < n) {
					result += mersenne;
					result += ", ";

					var isPrime = true;
					do {
						p += 1;
						isPrime = true;

						var maxDivisor = (int)Math.Sqrt (p);
						for (int i = 2; i < maxDivisor + 1; i++) {
							if (p % i == 0) {

								isPrime = false;
								break;
							}
						}
					} while (!isPrime);
					mersenne = Math.Pow (2, p) - 1;
				}

				result = result.Substring (0, result.Length - 2);
				Console.WriteLine (result);
			}
	}
}




