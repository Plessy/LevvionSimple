using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating a double expression in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class DoubleConditional : LevvionConditional
	{
		/// <summary>
		/// The ID of the double in the state.
		/// </summary>
		protected string ID;
		/// <summary>
		/// The value of the double in the state.
		/// </summary>
		protected double Value;
		/// <summary>
		/// How to compare the real value and the desired value.
		/// </summary>
		protected ComparisonType ComparisonType;

		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="value">The desired value of the double in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		public DoubleConditional(string id, double value, ComparisonType comparisontype)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="value">The desired value of the double in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public DoubleConditional(string id, double value, ComparisonType comparisontype, Action action) : base(action)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="value">The desired value of the double in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public DoubleConditional(string id, double value, ComparisonType comparisontype, List<Action> actions) : base(actions)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception">Comparison type '" + ComparisonType + "' is not supported in DoubleConditional.Evaluate.</exception>
		public override bool Evaluate()
		{
			switch (ComparisonType)
			{
				case ComparisonType.Equals:
					return State.GetDouble(ID) == Value;
				case ComparisonType.NotEquals:
					return State.GetDouble(ID) != Value;
				case ComparisonType.LessThan:
					return State.GetDouble(ID) < Value;
				case ComparisonType.GreaterThan:
					return State.GetDouble(ID) > Value;
				case ComparisonType.LessThanOrEquals:
					return State.GetDouble(ID) <= Value;
				case ComparisonType.GreaterThanOrEquals:
					return State.GetDouble(ID) >= Value;
				default:
					throw new Exception("Comparison type '" + ComparisonType + "' is not supported in DoubleConditional.Evaluate.");
			}
		}
	}
}
