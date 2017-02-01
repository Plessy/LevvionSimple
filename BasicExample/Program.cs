using System;
using System.Threading;
using LevvionSimple;
using LevvionSimple.Conditionals;

namespace BasicExample
{
	class Program
	{
		static void Main(string[] args)
		{
			//Create a new manager
			var ai = new LevvionManager();

			//Check for bool.
			ai.Add(new BoolConditional("test", true, BoolWorked));

			//Check for int.
			ai.Add(new IntConditional("test", 10, ComparisonType.Equals, IntWorked));

			//Check multiconditional. Works if int is greater than 3, and less than 8, and also if the bool is true.
			var multi = new MultiConditional(MultiWorked);
			multi.Add(new IntRangeConditional("test", 3, 8, false));
			multi.Add(new BoolConditional("test", true));
			ai.Add(multi);

			//Check timer
			ai.Add(new TimerConditional(3, true, TimerWorked));

			//Run the loop now
			int frame = 0;

			bool boolstate = false;
			int intstate = 0;

			while (true)
			{
				frame++;

				//Update test state.
				boolstate = !boolstate;
				intstate++;

				if (intstate > 10)
				{
					intstate = 0;
				}

				//Update AI state
				ai.State.SetBool("test", boolstate);
				ai.State.SetInt("test", intstate);

				//Run stuff.
				Console.Clear();
				Console.WriteLine("Frame " + frame);

				ai.Update(1);

				Thread.Sleep(1000);
			}

			//Free the events when done.
			ai.Free();
		}

		private static void BoolWorked()
		{
			Console.WriteLine("Bool worked!");
		}

		private static void IntWorked()
		{
			Console.WriteLine("Int worked!");
		}

		private static void MultiWorked()
		{
			Console.WriteLine("Multi worked!");
		}

		private static void TimerWorked()
		{
			Console.WriteLine("Timer worked!");
		}
	}
}
