using UnityEngine;

namespace Assets.Common
{
	/// <summary>
	/// A script describing something that has stats.
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class StatsScript : MonoBehaviour
	{
		/// <summary>
		/// The amount of damage you can take before dying.
		/// </summary>
		/// <value>
		/// The hp.
		/// </value>
		public int HP { get; private set; }
		/// <summary>
		/// Gets your initial HP value.
		/// </summary>
		/// <value>
		/// Your initial HP value.
		/// </value>
		public int HPMax { get; private set; }

		/// <summary>
		/// Sets HP and HPMax.
		/// </summary>
		/// <param name="value">The value.</param>
		public void SetHP(int value)
		{
			HP = HPMax = value;
		}

		/// <summary>
		/// Lowers HP. You will die if it reaches 0.
		/// </summary>
		/// <param name="value">The value.</param>
		public void LowerHP(int value)
		{
			HP -= value;

			if (HP < 0)
			{
				HP = 0;

				OnDeath();
				Destroy(gameObject);
			}
		}

		/// <summary>
		/// Called when you die.
		/// </summary>
		public virtual void OnDeath()
		{

		}
	}
}
