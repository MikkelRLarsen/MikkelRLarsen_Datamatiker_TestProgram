using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram.Threads
{
	internal class ThreadMain
	{
		public static void newMain()
		{
			var myThread = new Thread(new ThreadStart(SetAMTime));
			myThread.Start();

			//var myThread2 = new Thread(new ThreadStart(SetDanishTime));
			//myThread2.Start();

			//Thread.CurrentThread.Name = "main";

			//Thread thread1 = new Thread(new ThreadStart(()=> CountUp("name")));
			//thread1.Name = "Thread#1";
			//thread1.Start();

			//Thread thread2 = new Thread(new ThreadStart(CountDown));
			//thread2.Name = "Thread#2";
			//thread2.Start();

			////Thread.Sleep(5000);

			////thread2.Interrupt();
			////Console.WriteLine($"{thread2.Name} is Abort");
			//thread1.Join();
			//Console.WriteLine($"{Thread.CurrentThread.Name} is complete");
		}

		public static void CountUp(string name)
		{
			string threadName = Thread.CurrentThread.Name;

			for (int i = 0; i <= 10; i++)
			{
				Console.WriteLine($"{threadName} currentcount is {i}");
				Thread.Sleep(1000);
			}
			Console.WriteLine($"{threadName} is complete");
		}

		public static void CountDown()
		{
			string threadName = Thread.CurrentThread.Name;
			try
			{
				for (int i = 10; i >= 0; i--)
				{
					Console.WriteLine($"{threadName} currentcount is {i}");
					Thread.Sleep(1000);
				}
				Console.WriteLine($"{threadName} is complete");
			}
			catch (Exception)
			{
				return;
			}

		}

		public static void SetDanishTime()
		{
			while (true)
			{
				string formattedTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
				Console.WriteLine(formattedTime);
				Thread.Sleep(5000);
			}
		}


		public static void SetAMTime()
		{
			while (true)
			{
				string formattedTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
				Console.WriteLine(formattedTime);
				Thread.Sleep(1000);
			}
		}

	}
}
