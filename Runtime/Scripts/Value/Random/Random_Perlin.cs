// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.RANDOM + "Perlin")]
	internal sealed class Random_Perlin : MonoBehaviour
	{
		public void Invoke(Vector2 input) => _onOutput.Invoke(GetPerlin(input));

		[SerializeField] internal UnityEvent<float> _onOutput = default;

		private static float GetPerlin(Vector2 input) => Mathf.PerlinNoise(input.x, input.y);
	}
}