using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional evaluating a range for a float.
	/// </summary>
	/// <seealso cref="LevvionSimple.Conditionals.MultiConditional" />
	public class FloatRangeConditional : MultiConditional
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="FloatRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		public FloatRangeConditional(string id, float minvalue, float maxvalue, bool includeendpoints)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloatRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public FloatRangeConditional(string id, float minvalue, float maxvalue, bool includeendpoints, Action action) : base(action)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FloatRangeConditional"/> class.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public FloatRangeConditional(string id, float minvalue, float maxvalue, bool includeendpoints, List<Action> actions) : base(actions)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Sets the range.
		/// </summary>
		/// <param name="id">The ID of the float in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		private void SetRange(string id, float minvalue, float maxvalue, bool includeendpoints)
		{
			if (includeendpoints)
			{
				Add(new FloatConditional(id, minvalue, ComparisonType.GreaterThanOrEquals));
				Add(new FloatConditional(id, maxvalue, ComparisonType.LessThanOrEquals));
			}
			else
			{
				Add(new FloatConditional(id, minvalue, ComparisonType.GreaterThan));
				Add(new FloatConditional(id, maxvalue, ComparisonType.LessThan));
			}
		}
	}
}
