using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main (string[] args)
	{
		var morseCodeDict = new Dictionary<string, string> ();
		morseCodeDict.Add (".-", "A");
		morseCodeDict.Add ("-...", "B");
		morseCodeDict.Add ("-.-.", "C");
		morseCodeDict.Add ("-..", "D");
		morseCodeDict.Add (".", "E");
		morseCodeDict.Add ("..-.", "F");
		morseCodeDict.Add ("--.", "G");
		morseCodeDict.Add ("....", "H");
		morseCodeDict.Add ("..", "I");
		morseCodeDict.Add (".---", "J");
		morseCodeDict.Add ("-.-", "K");
		morseCodeDict.Add (".-..", "L");
		morseCodeDict.Add ("--", "M");
		morseCodeDict.Add ("-.", "N");
		morseCodeDict.Add ("---", "O");
		morseCodeDict.Add (".--.", "P");
		morseCodeDict.Add ("--.-", "Q");
		morseCodeDict.Add (".-.", "R");
		morseCodeDict.Add ("...", "S");
		morseCodeDict.Add ("-", "T");
		morseCodeDict.Add ("..-", "U");
		morseCodeDict.Add ("...-", "V");
		morseCodeDict.Add (".--", "W");
		morseCodeDict.Add ("-..-", "X");
		morseCodeDict.Add ("-.--", "Y");
		morseCodeDict.Add ("--..", "Z");
		morseCodeDict.Add ("-----", "0");
		morseCodeDict.Add (".----", "1");
		morseCodeDict.Add ("..---", "2");
		morseCodeDict.Add ("...--", "3");
		morseCodeDict.Add ("....-", "4");
		morseCodeDict.Add (".....", "5");
		morseCodeDict.Add ("-....", "6");
		morseCodeDict.Add ("--...", "7");
		morseCodeDict.Add ("---..", "8");
		morseCodeDict.Add ("----.", "9");

		using (StreamReader reader = File.OpenText (args [0]))
			while (!reader.EndOfStream) {
				string line = reader.ReadLine ();
				if (null == line)
					continue;

					var words = line.Split (' ');
					var result = "";
					foreach (var word in words) {
						string decoded;
						var letters = word.Split (' ');
						foreach(var letter in letters) {
							if (morseCodeDict.TryGetValue (letter, out decoded)) {
								result += decoded;

							} else
								result += " ";
						}
					}

				Console.WriteLine (result.Trim ());
			}
	}
}







