// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "Sqrt")]
	[UnityDocumentation("Mathf.Sqrt")]
	internal sealed class Math_Sqrt : OnInputOutput<float,float>
	{
		protected override float Get(in float v) => Mathf.Sqrt(v);
	}
}