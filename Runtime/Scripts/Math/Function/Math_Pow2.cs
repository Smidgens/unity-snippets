// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "Pow2")]
	internal sealed class Math_Pow2 : OnInputOutput<float, float>
	{
		protected override float Get(in float v) => v * v;
	}
}