// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_UNARY + "Sin")]
	internal class Math_Sin : OnInputOutput<float, float>
	{
		protected override float In(in float v) => Mathf.Sin(v);
	}
}