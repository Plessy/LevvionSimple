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
		/// Initializes a new instance of the <see cref="TimerConditional"/> class.
		/// </summary>
		/// <param name="targettime">The targettime.</param>
		/// <param name="reset">if set to <c>true</c> [reset].</param>
		public TimerConditional(float targettime, bool reset)
		{
			TargetTime = targettime;
			Reset = reset;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerConditional"/> class.
		/// </summary>
		/// <param name="targettime">The targettime.</param>
		/// <param name="reset">if set to <c>true</c> [reset].</param>
		/// <param name="action">The action.</param>
		public TimerConditional(float targettime, bool reset, Action action) : base(action)
		{
			TargetTime = targettime;
			Reset = reset;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimerConditional"/> class.
		/// </summary>
		/// <param name="targettime">The targettime.</param>
		/// <param name="reset">if set to <c>true</c> [reset].</param>
		/// <param name="actions">The actions.</param>
		public TimerConditional(float targettime, bool reset, List<Action> actions) : base(actions)
		{
			TargetTime = targettime;
			Reset = reset;
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
					CurrentTime -= TargetTime;
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
