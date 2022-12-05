// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_AUDIO + "Linear → Decibels")]
	internal class Linear_Decibels : OnInputOutput<float,float>
	{
		public void Compute(float v) => _onOutput.Invoke(AudioMath.LinearToDecibels(v));
		protected override float In(in float v) => AudioMath.LinearToDecibels(v);
	}
}