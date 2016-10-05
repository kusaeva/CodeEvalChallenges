
using System;
using System.IO;
using System.Collections.Generic;

class Program
{
	static void Main (string[] args)
	{
		using (StreamReader reader = File.OpenText (args [0]))
			while (!reader.EndOfStream) {
				string line = reader.ReadLine ();
				if (null == line)
					continue;
				var input = line.Split ('|');

				var cards = Array.ConvertAll (input [0].Split (' '), s => s.Trim ());
				var trump = input [1].Trim () [0];

				Console.WriteLine (wins (cards [0], cards [1], trump));

			}
	}

	private static string wins(string card1, string card2, char trump) {
		if (isTrump (card1, trump) && !isTrump (card2, trump)) {
			return card1;
		} 
		if (isTrump (card2, trump) && !isTrump (card1, trump)) {
			return card2;
		} 
		return higher (card1, card2);
	}

	private static bool isTrump(string card, char trump) {
		return (card [1].Equals(trump));
	}

	private static string higher(string card1, string card2) {
		var result = "";
		if (cardValue (card1) >= cardValue (card2)) {
			result += card1;
		} 
		if (cardValue (card1) <= cardValue (card2)) {
			result += " ";
			result += card2;
		} 
		return result;
	}

	private static int cardValue(string card) {
		var c = card [0];
		if (c >= '1' && c <= '9') return Int32.Parse(card.Substring(0,card.Length-1));
		switch (c) {
		case 'J':
			return 10;
		case 'Q':
			return 11;
		case 'K':
			return 12;
		case 'A':
			return 13;
		default:
			throw new System.ArgumentException (string.Format ("Card {0} is not valid", card));
		}
	}
}




