// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "Sin")]
	[UnityDocumentation("Mathf.Sin")]
	internal sealed class Math_Sin : OnInputOutput<float, float>
	{
		protected override float Get(in float v) => Mathf.Sin(v);
	}
}