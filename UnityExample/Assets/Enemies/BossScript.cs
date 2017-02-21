using Assets.Projectiles;
using LevvionSimple.Conditionals;
using UnityEngine;

namespace Assets.Enemies
{
	/// <summary>
	/// The script that controls the boss.
	/// </summary>
	/// <seealso cref="Assets.Enemies.BaseEnemyScript" />
	public class BossScript : BaseEnemyScript
	{
		/// <summary>
		/// The prefab for the eight way shot bullet.
		/// </summary>
		public GameObject EightWayShot;
		/// <summary>
		/// The prefab for the direct shot bullet.
		/// </summary>
		public GameObject DirectShot;
		/// <summary>
		/// The prefab for the missile.
		/// </summary>
		public GameObject Missile;

		/// <summary>
		/// Initializes a new instance of the <see cref="BossScript"/> class.
		/// </summary>
		public BossScript()
		{
			SetHP(400);

			//Set up the AI script.

			//Phase 1 100%~75% HP Eight Way Shooting
			var multishot1 = new MultiConditional(ShootEightWay);
			multishot1.Add(new FloatRangeConditional("hp%", .75f, 1f, true));
			multishot1.Add(new TimerConditional(0, 1.5f, true, true));
			AI.Add(multishot1);

			var multishot2 = new MultiConditional(ShootEightWay);
			multishot2.Add(new FloatRangeConditional("hp%", .75f, .9f, true));
			multishot2.Add(new TimerConditional(.5f, 1.5f, true, true));
			AI.Add(multishot2);

			var multishot3 = new MultiConditional(ShootEightWay);
			multishot3.Add(new FloatRangeConditional("hp%", .75f, .825f, true));
			multishot3.Add(new TimerConditional(1f, 1.5f, true, true));
			AI.Add(multishot3);

			//Phase 2 50%~75% HP Direct Shooting
			var directshot1 = new MultiConditional(ShootAtPlayer);
			directshot1.Add(new FloatRangeConditional("hp%", .5f, .75f, true));
			directshot1.Add(new TimerConditional(0, .5f, true, true));
			AI.Add(directshot1);

			var directshot2 = new MultiConditional(ShootAtPlayer2);
			directshot2.Add(new FloatRangeConditional("hp%", .5f, .65f, true));
			directshot2.Add(new TimerConditional(0, .5f, true, true));
			AI.Add(directshot2);

			var directshot3 = new MultiConditional(ShootAtPlayer3);
			directshot3.Add(new FloatRangeConditional("hp%", .5f, .55f, true));
			directshot3.Add(new TimerConditional(0, .5f, true, true));
			AI.Add(directshot3);

			//Phase 3 25%~50% HP Missiles
			var missile1 = new MultiConditional(CreateMissile);
			missile1.Add(new FloatRangeConditional("hp%", .25f, .5f, true));
			missile1.Add(new TimerConditional(0, 1.5f, true, true));
			AI.Add(missile1);

			var missile2 = new MultiConditional(CreateMissile);
			missile2.Add(new FloatRangeConditional("hp%", .25f, .4f, true));
			missile2.Add(new TimerConditional(.5f, 1.5f, true, true));
			AI.Add(missile2);

			var missile3 = new MultiConditional(CreateMissile);
			missile3.Add(new FloatRangeConditional("hp%", .25f, .3f, true));
			missile3.Add(new TimerConditional(1, 1.5f, true, true));
			AI.Add(missile3);

			//Phase3 <25%. Full power

			var finalmultishot1 = new MultiConditional(ShootEightWay);
			finalmultishot1.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finalmultishot1.Add(new TimerConditional(0, 1.5f, true, true));
			AI.Add(finalmultishot1);

			var finalmultishot2 = new MultiConditional(ShootEightWay);
			finalmultishot2.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finalmultishot2.Add(new TimerConditional(.5f, 1.5f, true, true));
			AI.Add(finalmultishot2);

			var finalmultishot3 = new MultiConditional(ShootEightWay);
			finalmultishot3.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finalmultishot3.Add(new TimerConditional(1f, 1.5f, true, true));
			AI.Add(finalmultishot3);
			
			var finaldirectshot1 = new MultiConditional(ShootAtPlayer);
			finaldirectshot1.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finaldirectshot1.Add(new TimerConditional(0, .5f, true, true));
			AI.Add(finaldirectshot1);

			var finaldirectshot2 = new MultiConditional(ShootAtPlayer2);
			finaldirectshot2.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finaldirectshot2.Add(new TimerConditional(0, .5f, true, true));
			AI.Add(finaldirectshot2);

			var finaldirectshot3 = new MultiConditional(ShootAtPlayer3);
			finaldirectshot3.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finaldirectshot3.Add(new TimerConditional(0, .5f, true, true));
			AI.Add(finaldirectshot3);
			
			var finalmissile1 = new MultiConditional(CreateMissile);
			finalmissile1.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finalmissile1.Add(new TimerConditional(0, 1.5f, true, true));
			AI.Add(finalmissile1);

			var finalmissile2 = new MultiConditional(CreateMissile);
			finalmissile2.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finalmissile2.Add(new TimerConditional(.5f, 1.5f, true, true));
			AI.Add(finalmissile2);

			var finalmissile3 = new MultiConditional(CreateMissile);
			finalmissile3.Add(new FloatRangeConditional("hp%", .0f, .25f, true));
			finalmissile3.Add(new TimerConditional(1, 1.5f, true, true));
			AI.Add(finalmissile3);

		}

		/// <summary>
		/// Shoots a bullet 8 ways.
		/// </summary>
		private void ShootEightWay()
		{
			CreateBullet(EightWayShot, new Vector2(1, 0));
			CreateBullet(EightWayShot, new Vector2(-1, 0));
			CreateBullet(EightWayShot, new Vector2(0,1));
			CreateBullet(EightWayShot, new Vector2(0, -1));
			CreateBullet(EightWayShot, new Vector2(1, 1));
			CreateBullet(EightWayShot, new Vector2(-1, 1));
			CreateBullet(EightWayShot, new Vector2(1, -1));
			CreateBullet(EightWayShot, new Vector2(-1, -1));
		}

		/// <summary>
		/// Shoots a bullet at the player.
		/// </summary>
		private void ShootAtPlayer()
		{
			CreateBullet(DirectShot, Player.transform.position- transform.position);
		}

		/// <summary>
		/// Shoots two bullets at the player in a minor spread.
		/// </summary>
		private void ShootAtPlayer2()
		{
			CreateBullet(DirectShot, RotateDirection(Player.transform.position - transform.position, -2f));
			CreateBullet(DirectShot, RotateDirection(Player.transform.position - transform.position, 2f));
		}

		/// <summary>
		/// Shoots two bullets at the player in a major spread.
		/// </summary>
		private void ShootAtPlayer3()
		{
			CreateBullet(DirectShot, RotateDirection(Player.transform.position - transform.position, -4f));
			CreateBullet(DirectShot, RotateDirection(Player.transform.position - transform.position, 4f));
		}

		/// <summary>
		/// Creates a missile that seeks the player.
		/// </summary>
		private void CreateMissile()
		{
			CreateBullet(Missile, Vector2.one);
		}

		/// <summary>
		///  Creates a bullet.
		/// </summary>
		/// <param name="bullet">The bullet.</param>
		/// <param name="direction">The direction.</param>
		private void CreateBullet(GameObject bullet, Vector2 direction)
		{
			direction.Normalize();

			var obj = (GameObject)Instantiate(bullet);
			obj.transform.parent = ShotManager.transform;
			obj.transform.localPosition = transform.localPosition;

			var projscript = obj.GetComponent<BaseProjectileController>();
			projscript.Direction = direction;
		}

		/// <summary>
		/// Rotates a vector in a direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		/// <param name="rotation">The rotation.</param>
		/// <returns></returns>
		private Vector2 RotateDirection(Vector2 direction, float rotation)
		{
			//http://answers.unity3d.com/questions/661383/whats-the-most-efficient-way-to-rotate-a-vector2-o.html

			float x = direction.x;
			float y = direction.y;

			float angle = rotation * Mathf.Deg2Rad;
			float cos = Mathf.Cos(angle);
			float sin = Mathf.Sin(angle);

			float x2 = x * cos - y * sin;
			float y2 = x * sin + y * cos;

			return new Vector2(x2, y2);
		}
	}
}
