using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional evaluating a range for a int.
	/// </summary>
	/// <seealso cref="LevvionSimple.Conditionals.MultiConditional" />
	public class IntRangeConditional : MultiConditional
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IntRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		public IntRangeConditional(string id, int minvalue, int maxvalue, bool includeendpoints)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public IntRangeConditional(string id, int minvalue, int maxvalue, bool includeendpoints, Action action) : base(action)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IntRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public IntRangeConditional(string id, int minvalue, int maxvalue, bool includeendpoints, List<Action> actions) : base(actions)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Sets the range.
		/// </summary>
		/// <param name="id">The ID of the integer in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		private void SetRange(string id, int minvalue, int maxvalue, bool includeendpoints)
		{
			if (includeendpoints)
			{
				Add(new IntConditional(id, minvalue, ComparisonType.GreaterThanOrEquals));
				Add(new IntConditional(id, maxvalue, ComparisonType.LessThanOrEquals));
			}
			else
			{
				Add(new IntConditional(id, minvalue, ComparisonType.GreaterThan));
				Add(new IntConditional(id, maxvalue, ComparisonType.LessThan));
			}
		}
	}
}
