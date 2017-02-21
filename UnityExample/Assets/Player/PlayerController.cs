using Assets.Common;
using UnityEngine;

namespace Assets.Player
{
	/// <summary>
	/// A basic player controller for a shmup.
	/// </summary>
	/// <seealso cref="Assets.Common.StatsScript" />
	public class PlayerController : StatsScript
	{
		/// <summary>
		/// The speed the player moves at.
		/// </summary>
		public int Speed = 5;
		/// <summary>
		/// The limits of where the player can move onscreen.
		/// </summary>
		public Vector2 MovementConstraints = new Vector2(5, 3.5f);

		/// <summary>
		/// The timer tracking the current time between shots.
		/// </summary>
		protected float ShotTimer;
		/// <summary>
		/// The time between shots.
		/// </summary>
		public float MaxShotTimer = .5f;

		/// <summary>
		/// The game object that the projectiles will spawn into.
		/// </summary>
		public GameObject ShotManager;
		/// <summary>
		/// The prefab of the player's shot.
		/// </summary>
		public GameObject ShotPrefab;

		/// <summary>
		/// Initializes a new instance of the <see cref="PlayerController"/> class.
		/// </summary>
		public PlayerController()
		{
			SetHP(600);
		}

		/// <summary>
		/// Runs the fixed update.
		/// </summary>
		public void FixedUpdate()
		{
			//Handle Movement
			Vector3 input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

			if (input != Vector3.zero)
			{
				input.Normalize();
			}

			transform.localPosition += input*Speed * Time.fixedDeltaTime;

			//Cap position

			if (transform.position.x < -MovementConstraints.x)
			{
				transform.position = new Vector3(-MovementConstraints.x, transform.position.y, transform.position.z); 
			}

			if (transform.position.x > MovementConstraints.x)
			{
				transform.position = new Vector3(MovementConstraints.x, transform.position.y, transform.position.z);
			}

			if (transform.position.y < -MovementConstraints.y)
			{
				transform.position = new Vector3(transform.position.x, -MovementConstraints.y, transform.position.z);
			}

			if (transform.position.y > MovementConstraints.y)
			{
				transform.position = new Vector3(transform.position.x, MovementConstraints.y, transform.position.z);
			}

			//Shoot
			ShotTimer -= Time.fixedDeltaTime;

			if (ShotTimer < 0)
			{
				ShotTimer = 0;
			}

			if (ShotTimer == 0)
			{
				if (Input.GetKey("space"))
				{
					var obj = (GameObject) Instantiate(ShotPrefab);
					obj.transform.parent = ShotManager.transform;
					obj.transform.localPosition = transform.localPosition;
					ShotTimer = MaxShotTimer;
				}
			}
		}
	}
}
