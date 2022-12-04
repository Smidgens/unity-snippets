// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_UNARY + "Cos")]
	internal class Math_Cos : OnInputOutput<float,float>
	{
		protected override float Compute(in float v) => Mathf.Cos(v);
	}
}