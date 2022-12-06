// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_OPERATOR + "Subtract")]
	internal sealed class Math_Subtract : MathOperator
	{
		protected override float Compute(in float rhs) => _LHS - rhs;
	}
}