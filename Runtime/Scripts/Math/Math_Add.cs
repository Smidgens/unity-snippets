// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_UNARY + "Add")]
	internal class Math_Add : OnInputOutput<float,float,float>
	{
		protected override float Compute(in float lhs, in float rhs) => lhs + rhs;
	}
}