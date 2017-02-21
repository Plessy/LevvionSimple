using UnityEngine;

namespace Assets.Common
{
	/// <summary>
	/// A script for doing a simple health bar.
	/// </summary>
	/// <seealso cref="UnityEngine.MonoBehaviour" />
	public class HealthBarScript : MonoBehaviour
	{
		/// <summary>
		/// The stats script that it should check.
		/// </summary>
		public StatsScript Stats;
		/// <summary>
		/// The texture to be used for the bar.
		/// </summary>
		public GUITexture Texture;

		/// <summary>
		/// Runs the fixed update.
		/// </summary>
		public void FixedUpdate()
		{
			//Modifying the pixelInset changes the width of the texture. We will scale it by HP.
			Texture.pixelInset = new Rect(Texture.pixelInset.xMin, Texture.pixelInset.yMin, (int)(500 * (Stats.HP / (float)Stats.HPMax)), Texture.pixelInset.height);
		}
	}
}
