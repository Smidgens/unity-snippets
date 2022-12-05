// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_AUDIO + "Decibels → Linear")]
	internal class Decibels_Linear : OnInputOutput<float, float>
	{
		protected override float In(in float v) => AudioMath.DecibelsToLinear(v);
	}
}