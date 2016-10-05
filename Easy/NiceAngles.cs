using System;
using System.IO;
using System.Collections.Generic;

//	How to convert degrees,minutes,seconds to decimal degrees:
//	One degree is equal to 60 minutes and equal to 3600 seconds:
//	1° = 60' = 3600"
//	One minute is equal to 1/60 degrees:
//	1' = (1/60)° = 0.01666667°
//	One second is equal to 1/3600 degrees:
//	1" = (1/3600)° = 2.77778e-4° = 0.000277778°

class Program
{
	static void Main (string[] args)
	{
		using (StreamReader reader = File.OpenText (args [0]))
			while (!reader.EndOfStream) {
				string line = reader.ReadLine ();
				if (null == line)
					continue;
				var angle = double.Parse (line);
				var wholePart = Math.Floor (angle);
				var fracPart = angle - wholePart;
				var seconds = Math.Floor (fracPart * 3600);
				var minutes = Math.Floor (seconds / 60);
				seconds = seconds - minutes * 60;

				Console.WriteLine (string.Format ("{0}.{1:00}'{2:00}\"", wholePart, minutes, seconds));
			}
	}
}




