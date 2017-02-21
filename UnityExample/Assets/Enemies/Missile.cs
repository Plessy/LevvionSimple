using LevvionSimple;
using LevvionSimple.Conditionals;
using UnityEngine;

namespace Assets.Enemies
{
	/// <summary>
	/// The script for the missile that the boss shoots at you.
	/// </summary>
	/// <seealso cref="Assets.Enemies.BaseEnemyScript" />
	public class Missile : BaseEnemyScript
	{
		/// <summary>
		/// The direction it is moving in.
		/// </summary>
		public Vector2 Direction = new Vector2(0, 1);
		/// <summary>
		/// The speed of the missile.
		/// </summary>
		public float Speed = 1;

		/// <summary>
		/// The prefab for the missile's explosion.
		/// </summary>
		public GameObject Explosion;

		/// <summary>
		/// The time before the missile explodes on its own.
		/// </summary>
		public float TimeToLive = 5f;

		/// <summary>
		/// Initializes a new instance of the <see cref="Missile"/> class.
		/// </summary>
		public Missile()
		{
			SetHP(3);

			AI.Add(new FloatConditional("playerdistance", .3f, ComparisonType.LessThanOrEquals, DestroyAndExplode));
		}

		/// <summary>
		/// Runs the fixed update.
		/// </summary>
		public override void FixedUpdate()
		{
			base.FixedUpdate();

			//Home in on the player
			Direction = Player.transform.position - transform.position;
			Direction.Normalize();
			
			//Move
			transform.localPosition += new Vector3(Direction.x * Speed * Time.fixedDeltaTime, Direction.y * Speed * Time.fixedDeltaTime, 0);

			//Update TTL
			TimeToLive -= Time.fixedDeltaTime;

			if (TimeToLive <= 0)
			{
				DestroyAndExplode();
			}
		}

		/// <summary>
		/// Called when you die.
		/// </summary>
		public override void OnDeath()
		{
			base.OnDeath();
			Explode();
		}

		/// <summary>
		/// Destroys the missile and explodes
		/// </summary>
		private void DestroyAndExplode()
		{
			Explode();
			Destroy(gameObject);
		}

		/// <summary>
		/// Explodes this instance.
		/// </summary>
		private void Explode()
		{
			var obj = (GameObject)Instantiate(Explosion);
			obj.transform.parent = ShotManager.transform;
			obj.transform.localPosition = transform.localPosition;
		}
	}
}
