// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.RANDOM + "Perlin")]
	[UnityDocumentation("Mathf.PerlinNoise")]
	internal sealed class Random_Perlin : Snippet
	{
		public void In(Vector2 input) => _out.Invoke(GetPerlin(input));

		[SerializeField] private UnityEvent<float> _out = default;

		private static float GetPerlin(Vector2 input) => Mathf.PerlinNoise(input.x, input.y);
	}
}