using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating an int expression in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class IntConditional : LevvionConditional
	{
		/// <summary>
		/// The ID of the integer in the state.
		/// </summary>
		protected string ID;
		/// <summary>
		/// The value of the integer in the state.
		/// </summary>
		protected int Value;
		/// <summary>
		/// How to compare the real value and the desired value.
		/// </summary>
		protected ComparisonType ComparisonType;

		/// <summary>
		/// Initializes a new instance of the <see cref="IntConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="value">The desired value of the integer in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		public IntConditional(string id, int value, ComparisonType comparisontype)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="value">The desired value of the integer in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public IntConditional(string id, int value, ComparisonType comparisontype, Action action) : base(action)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="value">The desired value of the integer in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public IntConditional(string id, int value, ComparisonType comparisontype, List<Action> actions) : base(actions)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception">Comparison type '" + ComparisonType + "' is not supported in IntConditional.Evaluate.</exception>
		public override bool Evaluate()
		{
			switch (ComparisonType)
			{
				case ComparisonType.Equals:
					return State.GetInt(ID) == Value;
				case ComparisonType.NotEquals:
					return State.GetInt(ID) != Value;
				case ComparisonType.LessThan:
					return State.GetInt(ID) < Value;
				case ComparisonType.GreaterThan:
					return State.GetInt(ID) > Value;
				case ComparisonType.LessThanOrEquals:
					return State.GetInt(ID) <= Value;
				case ComparisonType.GreaterThanOrEquals:
					return State.GetInt(ID) >= Value;
				default:
					throw new Exception("Comparison type '" + ComparisonType + "' is not supported in IntConditional.Evaluate.");
			}
		}
	}
}
