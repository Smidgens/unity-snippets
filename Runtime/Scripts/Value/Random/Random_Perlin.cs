// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.RANDOM + "Perlin")]
	[UnityDocumentation("Mathf.PerlinNoise")]
	internal sealed class Random_Perlin : MonoBehaviour
	{
		public void In(Vector2 input) => _out.Invoke(GetPerlin(input));

		[SerializeField] internal UnityEvent<float> _out = default;

		private static float GetPerlin(Vector2 input) => Mathf.PerlinNoise(input.x, input.y);
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Random_Perlin), true)]
	internal sealed class _Random_Perlin : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Random_Perlin._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}
#endif