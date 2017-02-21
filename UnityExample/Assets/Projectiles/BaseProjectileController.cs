using Assets.Common;
using UnityEngine;

namespace Assets.Projectiles
{
	/// <summary>
	/// The basic controller for all projectiles.
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class BaseProjectileController : MonoBehaviour
	{
		/// <summary>
		/// The damage the projectile does on his.
		/// </summary>
		public int Damage = 1;
		/// <summary>
		/// The direction the projectile is moving in.
		/// </summary>
		public Vector2 Direction = new Vector2(0, 1);
		/// <summary>
		/// The speed the projectile is moving. Set this to 0 for stationary things like explosions.
		/// </summary>
		public float Speed = 8;
		
		/// <summary>
		/// The area in which the projectile can stay alive.
		/// </summary>
		public Vector2 PositionConstraints = new Vector2(10, 10);

		/// <summary>
		/// The number of hits the projectile can do. Most do just one.
		/// </summary>
		public int NumHits = 1;

		/// <summary>
		/// The time before the projectile destroys itself.
		/// </summary>
		public float TimeToLive = 1;
		/// <summary>
		/// Whether or not to use Time To Live.
		/// </summary>
		public bool UseTimeToLive = false;

		/// <summary>
		/// Runs the fixed update.
		/// </summary>
		public virtual void FixedUpdate()
		{
			//Move the projectile first.
			transform.localPosition += new Vector3(Direction.x * Speed * Time.fixedDeltaTime, Direction.y * Speed * Time.fixedDeltaTime, 0);

			//Destroy it if it's outside of bounds.
			if (transform.position.x < -PositionConstraints.x)
			{
				Destroy(gameObject);
			}

			if (transform.position.x > PositionConstraints.x)
			{
				Destroy(gameObject);
			}

			if (transform.position.y < -PositionConstraints.y)
			{
				Destroy(gameObject);
			}

			if (transform.position.y > PositionConstraints.y)
			{
				Destroy(gameObject);
			}

			//Check time to live.
			if (UseTimeToLive)
			{
				TimeToLive -= Time.fixedDeltaTime;

				if (TimeToLive <= 0)
				{
					Destroy(gameObject);
				}
			}
		}
		/// <summary>
		/// Runs when you collide with an object.
		/// </summary>
		/// <param name="other">The other.</param>
		public virtual void OnTriggerEnter2D(Collider2D other)
		{
			//Get the stat script and lower HP
			var stats = other.gameObject.GetComponent<StatsScript>();

			if (stats != null)
			{
				stats.LowerHP(Damage);	
			}

			//Lower the number of hits.
			NumHits--;

			if (NumHits == 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
