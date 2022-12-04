// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	/// <summary>
	/// Audio related math
	/// </summary>
	internal static class AudioMath
	{
		public static float DecibelsToLinear(in float db) => Mathf.Pow(10.0f, db / 20.0f);
		public static float LinearToDecibels(in float linear) => linear != 0 ? 20.0f * Mathf.Log10(linear) : -144.0f;
	}
}