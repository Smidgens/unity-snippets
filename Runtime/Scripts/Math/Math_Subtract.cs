// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_UNARY + "Subtract")]
	internal class Math_Subtract : OnInputOutput<float, float, float>
	{
		protected override float Compute(in float lhs, in float rhs) => lhs - rhs;
	}
}