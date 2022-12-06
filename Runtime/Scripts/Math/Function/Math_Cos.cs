// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "Cos")]
	[UnityDocumentation("Mathf.Cos")]
	internal sealed class Math_Cos : OnInputOutput<float,float>
	{
		protected override float Get(in float v) => Mathf.Cos(v);
	}
}