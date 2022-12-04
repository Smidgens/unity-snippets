// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_UNARY + "Multiply")]
	internal class Math_Multiply : OnInputOutput<float, float, float>
	{
		protected override float Compute(in float lhs, in float rhs) => lhs * rhs;
	}
}