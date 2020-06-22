using System;
using System.Threading;

namespace CountdownTimer
{
	class Timer
	{

		public Timer(int len, string msg)
		{
			Thread.Sleep(len * 1000);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\nTIMER COMPLETE: " + msg + "\n");
			Program.alarmSound.Play();
			Console.ForegroundColor = ConsoleColor.Gray;
		}

	}
}
