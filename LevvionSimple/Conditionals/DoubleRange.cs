using System;
using System.Collections.Generic;

namespace LevvionSimple.Conditionals
{
	/// <summary>
	/// A conditional evaluating a range for a double.
	/// </summary>
	/// <seealso cref="LevvionSimple.Conditionals.MultiConditional" />
	public class DoubleRange : MultiConditional
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleRange"/> class.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		public DoubleRange(string id, double minvalue, double maxvalue, bool includeendpoints)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleRange"/> class.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="action">The action to take when the evaluation passes.</param>
		public DoubleRange(string id, double minvalue, double maxvalue, bool includeendpoints, Action action) : base(action)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DoubleRange"/> class.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		/// <param name="actions">The actions to take when the evaluation passes.</param>
		public DoubleRange(string id, double minvalue, double maxvalue, bool includeendpoints, List<Action> actions) : base(actions)
		{
			SetRange(id, minvalue, maxvalue, includeendpoints);
		}

		/// <summary>
		/// Sets the range.
		/// </summary>
		/// <param name="id">The ID of the double in state to check.</param>
		/// <param name="minvalue">The minimum value acceptable.</param>
		/// <param name="maxvalue">The maximum value acceptable.</param>
		/// <param name="includeendpoints">Whether or not to include the endpoints when evaluating the conditional.</param>
		private void SetRange(string id, double minvalue, double maxvalue, bool includeendpoints)
		{
			if (includeendpoints)
			{
				Add(new DoubleConditional(id, minvalue, ComparisonType.GreaterThanOrEquals));
				Add(new DoubleConditional(id, maxvalue, ComparisonType.LessThanOrEquals));
			}
			else
			{
				Add(new DoubleConditional(id, minvalue, ComparisonType.GreaterThan));
				Add(new DoubleConditional(id, maxvalue, ComparisonType.LessThan));
			}
		}
	}
}
