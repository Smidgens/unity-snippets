// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_OPERATOR + "Multiply")]
	internal sealed class Math_Multiply : MathOperator
	{
		protected override float Compute(in float rhs) => _LHS * rhs;
	}
}