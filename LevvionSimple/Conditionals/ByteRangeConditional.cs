﻿using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional evaluating a range for a byte.
	/// </summary>
	/// <seealso cref="LevvionSimple.Conditionals.MultiConditional" />
	public class ByteRangeConditional : MultiConditional
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ByteRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the byte in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		public ByteRangeConditional(string id, byte minvalue, byte maxvalue, bool includeendpoints)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ByteRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the byte in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public ByteRangeConditional(string id, byte minvalue, byte maxvalue, bool includeendpoints, Action action) : base(action)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ByteRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the byte in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public ByteRangeConditional(string id, byte minvalue, byte maxvalue, bool includeendpoints, List<Action> actions) : base(actions)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Sets the range.
		/// </summary>
		/// <param name="id">The ID of the byte in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		private void SetRange(string id, byte minvalue, byte maxvalue, bool includeendpoints)
		{
			if (includeendpoints)
			{
				Add(new ByteConditional(id, minvalue, ComparisonType.GreaterThanOrEquals));
				Add(new ByteConditional(id, maxvalue, ComparisonType.LessThanOrEquals));
			}
			else
			{
				Add(new ByteConditional(id, minvalue, ComparisonType.GreaterThan));
				Add(new ByteConditional(id, maxvalue, ComparisonType.LessThan));
			}
		}
	}
}
