using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional for evaluating a byte expression in LevvionSimple.
	/// </summary>
	/// <seealso cref="LevvionSimple.LevvionConditional" />
	public class ByteConditional : LevvionConditional
	{
		/// <summary>
		/// The ID of the byte in the state.
		/// </summary>
		protected string ID;
		/// <summary>
		/// The value of the byte in the state.
		/// </summary>
		protected byte Value;
		/// <summary>
		/// How to compare the real value and the desired value.
		/// </summary>
		protected ComparisonType ComparisonType;

		/// <summary>
		/// Initializes a new instance of the <see cref="ByteConditional"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparisontype">The comparisontype.</param>
		public ByteConditional(string id, byte value, ComparisonType comparisontype)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ByteConditional"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparisontype">The comparisontype.</param>
		/// <param name="action">The action.</param>
		public ByteConditional(string id, byte value, ComparisonType comparisontype, Action action) : base(action)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ByteConditional"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="value">The value.</param>
		/// <param name="comparisontype">The comparisontype.</param>
		/// <param name="actions">The actions.</param>
		public ByteConditional(string id, byte value, ComparisonType comparisontype, List<Action> actions) : base(actions)
		{
			ID = id;
			Value = value;
			ComparisonType = comparisontype;
		}

		/// <summary>
		/// Evaluates the conditional this list represents.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception">Comparison type '" + ComparisonType + "' is not supported in ByteConditional.Evaluate.</exception>
		public override bool Evaluate()
		{
			switch (ComparisonType)
			{
				case ComparisonType.Equals:
					return State.GetByte(ID) == Value;
				case ComparisonType.NotEquals:
					return State.GetByte(ID) != Value;
				case ComparisonType.LessThan:
					return State.GetByte(ID) < Value;
				case ComparisonType.GreaterThan:
					return State.GetByte(ID) > Value;
				case ComparisonType.LessThanOrEquals:
					return State.GetByte(ID) <= Value;
				case ComparisonType.GreaterThanOrEquals:
					return State.GetByte(ID) >= Value;
				default:
					throw new Exception("Comparison type '" + ComparisonType + "' is not supported in ByteConditional.Evaluate.");
			}
		}
	}
}
