// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_OPERATOR + "Add")]
	internal sealed class Math_Add : MathOperator
	{
		protected override float Compute(in float rhs) => _LHS + rhs;
	}
}