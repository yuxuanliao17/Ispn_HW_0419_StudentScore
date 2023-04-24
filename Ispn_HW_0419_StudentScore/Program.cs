using System.Text;

namespace Ispn_HW_0419_StudentScore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Student john = new Student("Johnn", 55, 87, 63, 0, 0);
			Console.WriteLine(john.GetStudentReportCard());
		}

		public class Subject
		{
			public string Name { get; set; }
			public int Score { get; set; }
			public Subject(string name, int score)
			{
				Name = name;
				Score = score;
			}
		}

		public class Student
		{
			public string Name { get; set; }
			public Subject Chinese { get; set; }
			public Subject Math { get; set; }
			public Subject English { get; set; }
			public int Totle { get; set; }
			public double Average { get; set; }
			public int MaxScore { get; set; }
			public int MinScore { get; set; }

			public Student(string name, int chineseScore, int mathScore, int englishScore, int totleScore, double averageScore)
			{
				Name = name;
				Chinese = new Subject("Chinese", chineseScore);
				Math = new Subject("Math", mathScore);
				English = new Subject("English", englishScore);
				List<int> scores = new List<int> { chineseScore, mathScore, englishScore };
				Totle = scores.Sum();
				Average = scores.Average();
			}

			public Subject HighestSubject(Subject[] subjects) => subjects.OrderByDescending(s => s.Score).First();

			public Subject LowestSubject(Subject[] subjects) => subjects.OrderBy(s => s.Score).First();

			public string GetStudentReportCard()
			{
				var sb = new StringBuilder();

				sb.AppendLine($"ReportCard");
				sb.AppendLine();
				sb.AppendLine($"姓名：{Name}");
				sb.AppendLine($"-----------------------------------");
				sb.AppendLine($"Chinese：{Chinese.Score} ");
				sb.AppendLine($"Math：{Math.Score} ");
				sb.AppendLine($"English：{English.Score} ");
				sb.AppendLine($"-----------------------------------");
				sb.AppendLine($"Totle：{Totle} ");
				sb.AppendLine($"Average：{Average.ToString("F2")} ");
				sb.AppendLine($"-----------------------------------");
				sb.AppendLine($"HighestSubject：{HighestSubject(new[] { Chinese, Math, English }).Name}\r\nScore：{HighestSubject(new[] { Chinese, Math, English }).Score} \r\n");
				sb.AppendLine($"LowestSubject：{LowestSubject(new[] { Chinese, Math, English }).Name}\r\nScore：{LowestSubject(new[] { Chinese, Math, English }).Score}\r\n ");
				return sb.ToString();
			}

		}

	}
}