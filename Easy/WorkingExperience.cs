using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static string[] months = new string[] {
		"Jan",
		"Feb",
		"Mar",
		"Apr",
		"May",
		"Jun",
		"Jul",
		"Aug",
		"Sep",
		"Oct",
		"Nov",
		"Dec"
	};


	class Date {
		public int month { get; private set;}
		public int year { get; private set; }

		public Date (string s) {
			var temp = s.Trim ().Split (' ');
			month = Array.FindIndex(months, m => m == temp[0]);
			year = Int32.Parse(temp[1]);
		}

		public int CompareTo(Date date) {
			if (year == date.year && month == date.month)
				return 0;
			if (year < date.year || (year == date.year && month < date.month))
				return 1;
			return -1;
		}

		public bool Equals(Date date) {
			return this.CompareTo (date) == 0;
		}

		public static bool operator < (Date date1, Date date2) {
			return (date1.CompareTo(date2) == 1);
		}

		public static bool operator > (Date date1, Date date2) {
			return (date1.CompareTo(date2) == -1);
		}

		public int MonthsPassed(Date end) {
			var years = end.year - year;
			var months = end.month - month + years * 12 + 1;
			if (months < 0)
				throw new ArgumentNullException ("months ");
			return months;

		}

		public string ToString() {
			return (string.Format ("{0}/{1}", month, year));
		}

	}

	class Interval {
		public Date start { get; private set; }
		public Date end {get; private set; }

		private int length = -1;
		public int Length {
			get {
				if (length == -1) {
					length = start.MonthsPassed(end);
				}
				return length;
			}
		}

		public Interval(Date s, Date e) {
			start = s;
			end = e;
		}

		public Interval(string s) {
			var temp = s.Trim().Split('-');

			start = new Date(temp[0]);
			end = new Date(temp[1]);
		}

		public string ToString() {
			return (string.Format ("{0}-{1}", start.ToString (), end.ToString ()));
		}
	}

	static void Main(string[] args)
	{
		using (StreamReader reader = File.OpenText(args[0]))
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (null == line)
					continue;
				// do something with line

				var intervals = Array.ConvertAll(line.Split (';'), s =>  new Interval(s));


				Array.Sort(intervals, delegate (Interval x, Interval y) {
					return y.start.CompareTo(x.start);
				});


				var prevInterval = intervals [0];
				var totalWorkExp = prevInterval.Length;
				for(int i = 1; i < intervals.Length; i++) {
					var currentInterval = intervals [i];
					if (currentInterval.start < prevInterval.end) {
						if (currentInterval.end > prevInterval.end) {
							totalWorkExp += (new Interval (prevInterval.end, currentInterval.end).Length - 1);
							prevInterval = currentInterval;
						} 
					} else {
						totalWorkExp += currentInterval.Length;
						prevInterval = currentInterval;
					}


				}

				var result = (totalWorkExp/12).ToString();
				Console.WriteLine (result);
			}
	}
}



