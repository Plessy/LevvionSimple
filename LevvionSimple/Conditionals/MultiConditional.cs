using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A complex conditional for an action in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class MultiConditional : LevvionConditional
	{
		/// <summary>
		/// The conditionals to be managed.
		/// </summary>
		protected List<LevvionConditional> Conditionals;

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiConditional"/> class.
		/// </summary>
		public MultiConditional()
		{
			Conditionals = new List<LevvionConditional>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiConditional"/> class.
		/// </summary>
		/// <param name="conditionals">The conditionals.</param>
		public MultiConditional(List<LevvionConditional> conditionals)
		{
			Conditionals = conditionals;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiConditional"/> class.
		/// </summary>
		/// <param name="action">The action.</param>
		public MultiConditional(Action action) : base(action)
		{
			Conditionals = new List<LevvionConditional>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiConditional"/> class.
		/// </summary>
		/// <param name="conditionals">The conditionals.</param>
		/// <param name="action">The action.</param>
		public MultiConditional(List<LevvionConditional> conditionals, Action action) : base(action)
		{
			Conditionals = conditionals;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiConditional"/> class.
		/// </summary>
		/// <param name="conditionals">The conditionals.</param>
		/// <param name="actions">The actions.</param>
		public MultiConditional(List<LevvionConditional> conditionals, List<Action> actions) : base(actions)
		{
			Conditionals = conditionals;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiConditional"/> class.
		/// </summary>
		/// <param name="actions">The actions.</param>
		public MultiConditional(List<Action> actions) : base(actions)
		{
			Conditionals = new List<LevvionConditional>();
		}

		/// <summary>
		/// Adds a conditional to the list of conditionals to manage.
		/// </summary>
		/// <param name="conditional">The conditional.</param>
		public void Add(LevvionConditional conditional)
		{
			Conditionals.Add(conditional);
			conditional.SetState(State);
		}

		/// <summary>
		/// Sets the state to be used for evaluation.
		/// </summary>
		/// <param name="state">The state.</param>
		public override void SetState(LevvionState state)
		{
			base.SetState(state);

			foreach (var conditional in Conditionals)
			{
				conditional.SetState(state);
			}
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		public override bool Evaluate()
		{
			foreach (var conditional in Conditionals)
			{
				if (!conditional.Evaluate())
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Update the conditional if necessary.
		/// </summary>
		/// <param name="deltatime">The deltatime.</param>
		public override void Update(float deltatime)
		{
			base.Update(deltatime);

			foreach (var conditional in Conditionals)
			{
				conditional.Update(deltatime);
			}
		}
	}
}
