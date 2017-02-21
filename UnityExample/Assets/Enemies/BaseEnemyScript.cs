using Assets.Common;
using LevvionSimple;
using UnityEngine;

namespace Assets.Enemies
{
	/// <summary>
	/// The base script for enemies. Wow, such description.
	/// </summary>
	/// <seealso cref="Assets.Common.StatsScript" />
	public class BaseEnemyScript : StatsScript
	{
		/// <summary>
		/// The AI of the enemy.
		/// </summary>
		protected LevvionManager AI;

		/// <summary>
		/// The reference to the player.
		/// </summary>
		protected GameObject Player;

		/// <summary>
		/// The game object that you spawn shots into.
		/// </summary>
		protected GameObject ShotManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseEnemyScript"/> class.
		/// </summary>
		public BaseEnemyScript()
		{
			AI = new LevvionManager(true);
		}

		/// <summary>
		/// Runs after the constructor.
		/// </summary>
		public void Start()
		{
			Player = GameObject.FindWithTag("Player");
			ShotManager = GameObject.FindWithTag("ShotManager");
		}

		/// <summary>
		/// Runs the fixed update.
		/// </summary>
		public virtual void FixedUpdate()
		{
			//Update the AI state.

			//Set relevant health stuff.
			AI.State.SetInt("hp", HP);
			AI.State.SetFloat("hp%", HP / (float) HPMax);

			//Set distance to player.
			if (Player != null)
			{
				var difference = transform.position - Player.transform.position;

				AI.State.SetFloat("playerdistance", difference.magnitude);
			}
			else
			{
				AI.State.SetFloat("playerdistance", 0);
			}

			//Update the AI itself.
			AI.Update(Time.fixedDeltaTime);
		}
	}
}
