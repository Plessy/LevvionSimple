using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating a float expression in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class FloatConditional : LevvionConditional
	{
		/// <summary>
		/// The ID of the float in the state.
		/// </summary>
		protected string ID;
		/// <summary>
		/// The value of the float in the state.
		/// </summary>
		protected float Value;
		/// <summary>
		/// How to compare the real value and the desired value.
		/// </summary>
		protected ComparisonType ComparisonType;

		/// <summary>
		/// Initializes a new instance of the <see cref="FloatConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="value">The desired value of the float in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		public FloatConditional(string id, float value, ComparisonType comparisontype)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloatConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="value">The desired value of the float in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public FloatConditional(string id, float value, ComparisonType comparisontype, Action action) : base(action)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloatConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="value">The desired value of the float in state.</param>
		/// <param name="comparisontype">How to compare the value in state to the desired value.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public FloatConditional(string id, float value, ComparisonType comparisontype, List<Action> actions) : base(actions)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception">Comparison type '" + ComparisonType + "' is not supported in FloatConditional.Evaluate.</exception>
		public override bool Evaluate()
		{
			switch (ComparisonType)
			{
				case ComparisonType.Equals:
					return State.GetFloat(ID) == Value;
				case ComparisonType.NotEquals:
					return State.GetFloat(ID) != Value;
				case ComparisonType.LessThan:
					return State.GetFloat(ID) < Value;
				case ComparisonType.GreaterThan:
					return State.GetFloat(ID) > Value;
				case ComparisonType.LessThanOrEquals:
					return State.GetFloat(ID) <= Value;
				case ComparisonType.GreaterThanOrEquals:
					return State.GetFloat(ID) >= Value;
				default:
					throw new Exception("Comparison type '" + ComparisonType + "' is not supported in FloatConditional.Evaluate.");
			}
		}
	}
}
