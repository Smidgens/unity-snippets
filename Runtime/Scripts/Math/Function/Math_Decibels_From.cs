// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "dB → Volume")]
	internal sealed class Math_Decibels_From : OnInputOutput<float, float>
	{
		protected override float Get(in float db) => AudioMath.DecibelsToLinear(db);
	}
}