using System.Collections.Generic;

namespace LevvionSimple
{
	/// <summary>
	/// An AI manager using LevvionSimple.
	/// </summary>
	public class LevvionManager
	{
		/// <summary>
		/// The conditionals to manage.
		/// </summary>
		protected List<LevvionConditional> Conditionals;
		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		public LevvionState State { get; protected set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="LevvionManager"/> class.
		/// </summary>
		public LevvionManager()
		{
			Conditionals = new List<LevvionConditional>();
			State = new LevvionState();
		}

		/// <summary>
		/// Adds the conditional to the list of managed conditionals.
		/// </summary>
		/// <param name="conditional">The conditional.</param>
		public void Add(LevvionConditional conditional)
		{
			Conditionals.Add(conditional);
			conditional.SetState(State);
		}

		/// <summary>
		/// Removes the specified conditional from the list of managed conditionals.
		/// </summary>
		/// <param name="conditional">The conditional.</param>
		public void Remove(LevvionConditional conditional)
		{
			Conditionals.Remove(conditional);
			conditional.SetState(null);
		}

		/// <summary>
		/// Updates and evaluates the conditionals.
		/// </summary>
		/// <param name="deltatime">The deltatime.</param>
		public void Update(float deltatime)
		{
			foreach (var conditional in Conditionals)
			{
				conditional.Update(deltatime);

				if (conditional.Evaluate())
				{
					conditional.CallActions();
				}
			}
		}

		/// <summary>
		/// Frees this instance when you are done with the manager. Use to avoid memory leaks.
		/// </summary>
		public void Free()
		{
			foreach (var conditional in Conditionals)
			{
				conditional.FreeActions();
			}
		}
	}
}
