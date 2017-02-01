using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating a bool expression in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class BoolConditional : LevvionConditional
	{
		/// <summary>
		/// The ID of the bool in the state.
		/// </summary>
		protected string ID;
		/// <summary>
		/// The desired value of the bool in the state.
		/// </summary>
		protected bool Value;

		/// <summary>
		/// Initializes a new instance of the <see cref="BoolConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the boolean in state to check.</param>
		/// <param name="value">The desired value of the boolean in state.</param>
		public BoolConditional(string id, bool value)
		{
			ID = id;
			Value = value;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BoolConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the boolean in state to check.</param>
		/// <param name="value">The desired value of the boolean in state.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public BoolConditional(string id, bool value, Action action) : base(action)
		{
			ID = id;
			Value = value;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BoolConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the boolean in state to check.</param>
		/// <param name="value">The desired value of the boolean in state.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public BoolConditional(string id, bool value, List<Action> actions) : base(actions)
		{
			ID = id;
			Value = value;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		public override bool Evaluate()
		{
			return State.GetBool(ID) == Value;
		}
	}
}
