using System;
using System.Media;
using System.Threading;

namespace CountdownTimer
{
	class Program
	{
		static string userInput;
		static int iuserInput;
		static Thread thread1 = new Thread(new ThreadStart(timer));
		static Thread thread2 = new Thread(new ThreadStart(timer));
		static Thread thread3 = new Thread(new ThreadStart(timer));
		static Thread thread4 = new Thread(new ThreadStart(timer));
		static int timerLength;
		static string timerMessage;
		public static SoundPlayer alarmSound = new SoundPlayer();

		static void Main(string[] args)
		{
			alarmSound.SoundLocation = Environment.CurrentDirectory + "\\alarm.wav";
			bool retry = true;

			Console.WriteLine("Welcome to the countdown timer UI.");

			do
			{
				Console.WriteLine("1 - Create a new timer." +
					"\n2 - Remove a timer." +
					"\n3 - Pause/Resume a timer." +
					"\n4 - Exit application.");
				userInput = Console.ReadLine();
				int.TryParse(userInput, out iuserInput);

				switch ( iuserInput )
				{
					case 1:
						createTimer();
						break;
					case 2:
						removeTimer();
						break;
					case 3:
						pauseTimer();
						break;
					case 4:
						if (thread1.IsAlive || thread2.IsAlive || thread3.IsAlive || thread4.IsAlive)
						{
							Console.WriteLine("Don't leave me now, you still have timers running! :(");
						}
						else
						{
							retry = false;
						}
						break;
					default:
						break;
				}

			} while (retry);
			Console.WriteLine("Goodbye!");

		}

		public static void createTimer()
		{
			Console.WriteLine("How long would you like the timer to last in seconds?");
			userInput = Console.ReadLine();
			int.TryParse(userInput, out timerLength);
			Console.WriteLine("What would you like the timer to say when it completes?");
			timerMessage = Console.ReadLine();

			if (!thread1.IsAlive)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYour timer has been created on THREAD 1, and will notify you in " + timerLength.ToString() + " seconds.\n");
				Console.ForegroundColor = ConsoleColor.Gray;
				thread1 = new Thread(new ThreadStart(timer));
				thread1.Start();
			}
			else if (!thread2.IsAlive)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYour timer has been created on THREAD 2, and will notify you in " + timerLength.ToString() + " seconds.\n");
				Console.ForegroundColor = ConsoleColor.Gray;
				thread2 = new Thread(new ThreadStart(timer));
				thread2.Start();
			}
			else if (!thread3.IsAlive)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYour timer has been created on THREAD 3, and will notify you in " + timerLength.ToString() + " seconds.\n");
				Console.ForegroundColor = ConsoleColor.Gray;
				thread3 = new Thread(new ThreadStart(timer));
				thread3.Start();
			}
			else if (!thread4.IsAlive)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nYour timer has been created on THREAD 4, and will notify you in " + timerLength.ToString() + " seconds.\n");
				Console.ForegroundColor = ConsoleColor.Gray;
				thread4 = new Thread(new ThreadStart(timer));
				thread4.Start();
			}
			else
			{
				Console.BackgroundColor = ConsoleColor.Red;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("\n***** You've reached the maximum amount of timers. Your timer has not been created. *****\n");
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.BackgroundColor = ConsoleColor.Black;
			}

		}

		public static void pauseTimer()
		{
			Console.WriteLine("What thread would you like to pause/resume?");
			userInput = Console.ReadLine();
			int.TryParse(userInput, out iuserInput);

			switch (iuserInput)
			{
				case 1:
					if (thread1.IsAlive && thread1.ThreadState != ThreadState.Suspended)
					{
						thread1.Suspend();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 1 and the timer associated with it has been paused.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else if (thread1.IsAlive)
					{
						thread1.Resume();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 1 and the timer associated with it has been resumed.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					break;
				case 2:
					if (thread2.IsAlive && thread2.ThreadState != ThreadState.Suspended)
					{
						thread2.Suspend();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 2 and the timer associated with it has been paused.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else if (thread2.IsAlive)
					{
						thread1.Resume();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 2 and the timer associated with it has been resumed.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					break;
				case 3:
					if (thread3.IsAlive && thread3.ThreadState != ThreadState.Suspended)
					{
						thread3.Suspend();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 3 and the timer associated with it has been paused.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else if (thread3.IsAlive)
					{
						thread1.Resume();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 3 and the timer associated with it has been resumed.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					break;
				case 4:
					if (thread4.IsAlive && thread4.ThreadState != ThreadState.Suspended)
					{
						thread4.Suspend();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 4 and the timer associated with it has been paused.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else if (thread4.IsAlive)
					{
						thread1.Resume();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 4 and the timer associated with it has been resumed.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.WriteLine("\nThat thread does not exist.\n");
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.BackgroundColor = ConsoleColor.Black;
					break;

			}
		}

		public static void removeTimer()
		{
			Console.WriteLine("What thread would you like to terminate?");
			userInput = Console.ReadLine();
			int.TryParse(userInput, out iuserInput);

			switch (iuserInput)
			{
				case 1:
					if (thread1.IsAlive)
					{
						thread1.Abort();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 1 and the timer associated with it has been terminated.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine("\nThat thread is not active.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
						Console.BackgroundColor = ConsoleColor.Black;
					}
					break;
				case 2:
					if (thread2.IsAlive)
					{
						thread2.Abort();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 2 and the timer associated with it has been terminated.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine("\nThat thread is not active.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
						Console.BackgroundColor = ConsoleColor.Black;
					}
					break;
				case 3:
					if (thread3.IsAlive)
					{
						thread3.Abort();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 3 and the timer associated with it has been terminated.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine("\nThat thread is not active.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
						Console.BackgroundColor = ConsoleColor.Black;
					}
					break;
				case 4:
					if (thread4.IsAlive)
					{
						thread4.Abort();
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\nTHREAD 4 and the timer associated with it has been terminated.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else
					{
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine("\nThat thread is not active.\n");
						Console.ForegroundColor = ConsoleColor.Gray;
						Console.BackgroundColor = ConsoleColor.Black;
					}
					break;
				default:
					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.WriteLine("\nThat thread does not exist.\n");
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.BackgroundColor = ConsoleColor.Black;
					break;

			}
		}

		public static void timer()
		{
			Timer thrdTimer = new Timer(timerLength, timerMessage);
		}

	}
}
