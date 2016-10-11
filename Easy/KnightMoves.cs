using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	private static bool checkLetter(char letter) {
		return (letter >= 'a' && letter <= 'h');
	}
	private static bool checkDigit(char digit) {
		return (digit >= '1' && digit <= '8');
	}

	static void Main(string[] args)
	{
		var steps = new int[][] {
			new int[] { -2, 1 },
			new int[] { -1, 2 },
			new int[] {  1, 2 },
			new int[] {  2, 1 }
		};

		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line
				var letter = line [0];
				var digit = line [1];
				var result = "";

				foreach (var step in steps) {
					char newLetter = (char)((int)letter + step [0]);
					char newDigit;

					if (checkLetter (newLetter)) {
						newDigit = (char)((int)digit - step [1]);
						if (checkDigit (newDigit)) {
							result += new string (new char[]{ newLetter, newDigit });
							result += " ";
						}
						newDigit = (char)((int)digit + step [1]);
						if (checkDigit (newDigit)) {
							result += new string (new char[]{ newLetter, newDigit });
							result += " ";
						}
					}
				}

				result = result.Trim ();
				Console.WriteLine (result);
			}
	}
}

