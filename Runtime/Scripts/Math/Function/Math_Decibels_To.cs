// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "Volume → dB")]
	internal sealed class Math_Decibels_To : OnInputOutput<float,float>
	{
		protected override float Get(in float linear) => AudioMath.LinearToDecibels(linear);
	}
}