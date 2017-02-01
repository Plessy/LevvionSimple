using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating a string expression in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class StringConditional : LevvionConditional
	{
		/// <summary>
		/// The ID of the string in the state.
		/// </summary>
		protected string ID;
		/// <summary>
		/// The value of the string in the state.
		/// </summary>
		protected string Value;
		/// <summary>
		/// How to compare the real value and the desired value.
		/// </summary>
		protected ComparisonType ComparisonType;

		/// <summary>
		/// Initializes a new instance of the <see cref="StringConditional"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparisontype">The comparisontype.</param>
		public StringConditional(string id, string value, ComparisonType comparisontype)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StringConditional"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparisontype">The comparisontype.</param>
		/// <param name="action">The action.</param>
		public StringConditional(string id, string value, ComparisonType comparisontype, Action action) : base(action)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StringConditional"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparisontype">The comparisontype.</param>
		/// <param name="actions">The actions.</param>
		public StringConditional(string id, string value, ComparisonType comparisontype, List<Action> actions) : base(actions)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception">Comparison type '" + ComparisonType + "' is not supported in StringConditional.Evaluate.</exception>
		public override bool Evaluate()
		{
			switch (ComparisonType)
			{
				case ComparisonType.Equals:
					return State.GetString(ID) == Value;
				case ComparisonType.NotEquals:
					return State.GetString(ID) != Value;
				default:
					throw new Exception("Comparison type '" + ComparisonType + "' is not supported in StringConditional.Evaluate.");
			}
		}
	}
}
