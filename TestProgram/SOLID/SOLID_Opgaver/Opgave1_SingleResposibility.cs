using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.SOLID.SOLID_Opgaver
{
	internal class Opgave1_SingleResposibility
	{
		private class Before
		{
			private class Report
			{
				public string Content { get; set; }
				public void GenerateReport()

				{
					Console.WriteLine("Generating Report...");
				}

				public void SaveToFile(string filename)
				{
					File.WriteAllText(filename, Content);
				}
			}
		}


		private class After
		{
			private class Report
			{
				public string Content { get; private set; }
				private ISaveToFile saveToFile;

				public Report(string content, ISaveToFile saveToFile)
				{
					Content = content;
					this.saveToFile = saveToFile;
				}

				public void GenerateReport()
				{
					Console.WriteLine("Generating Report...");
				}

				public void SaveToFile(string filename)
				{
					saveToFile.SaveToFile(filename, Content);
				}
			}

			private interface ISaveToFile
			{
				void SaveToFile(string filename, string content);
			}

			private class SaveFileToTxt : ISaveToFile
			{
				public void SaveToFile(string filename, string content)
				{
					File.WriteAllText(filename, content);
				}
			}
		}
	}
}
