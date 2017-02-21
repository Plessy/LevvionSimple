using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating a timer in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class TimerConditional : LevvionConditional
	{
		/// <summary>
		/// The current time.
		/// </summary>
		protected float CurrentTime;
		/// <summary>
		/// The target time.
		/// </summary>
		protected float TargetTime;
		/// <summary>
		/// Whether or not to reset the time to 0 upon activation.
		/// </summary>
		protected bool Reset;
		/// <summary>
		/// Ensures the timer is global.
		/// </summary>
		protected bool GlobalTimer;

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerConditional" /> class.
		/// </summary>
		/// <param name="initialoffset">The initial time to set the timer to.</param>
		/// <param name="targettime">The time between the timer evaluating as true.</param>
		/// <param name="reset">Whether or not the timer should reset to zero when it passes as true. If false, it will subtract current time from target time and keep going.</param>
		/// <param name="globaltimer">Whether or not to keep the timer as global.</param>
		public TimerConditional(float initialoffset, float targettime, bool reset, bool globaltimer)
		{
			CurrentTime = initialoffset;
			TargetTime = targettime;
			Reset = reset;
			GlobalTimer = globaltimer;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerConditional"/> class.
		/// </summary>
		/// <param name="initialoffset">The initial time to set the timer to.</param>
		/// <param name="targettime">The time between the timer evaluating as true.</param>
		/// <param name="reset">Whether or not the timer should reset to zero when it passes as true. If false, it will subtract current time from target time and keep going.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		/// <param name="globaltimer">Whether or not to keep the timer as global.</param>
		public TimerConditional(float initialoffset, float targettime, bool reset, bool globaltimer, Action action) : base(action)
		{
			CurrentTime = initialoffset;
			TargetTime = targettime;
			Reset = reset;
			GlobalTimer = globaltimer;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerConditional" /> class.
		/// </summary>
		/// <param name="initialoffset">The initial time to set the timer to.</param>
		/// <param name="targettime">The time between the timer evaluating as true.</param>
		/// <param name="reset">Whether or not the timer should reset to zero when it passes as true. If false, it will subtract current time from target time and keep going.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		/// <param name="globaltimer">Whether or not to keep the timer as global.</param>
		public TimerConditional(float initialoffset, float targettime, bool reset, bool globaltimer, List<Action> actions) : base(actions)
		{
			CurrentTime = initialoffset;
			TargetTime = targettime;
			Reset = reset;
			GlobalTimer = globaltimer;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		public override bool Evaluate()
		{
			if (CurrentTime >= TargetTime)
			{
				if (Reset)
				{
					CurrentTime = 0;
				}
				else
				{
					if (GlobalTimer)
					{
						while (CurrentTime > TargetTime)
						{
							CurrentTime -= TargetTime;
						}
					}
					else
					{
						CurrentTime -= TargetTime;
					}
				}

				return true;
			}

			return false;
		}

		/// <summary>
		/// Update the conditional if necessary.
		/// </summary>
		/// <param name="deltatime">The deltatime.</param>
		public override void Update(float deltatime)
		{
			base.Update(deltatime);

			CurrentTime += deltatime;
		}
	}
}
