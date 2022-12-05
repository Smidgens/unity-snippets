// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.MATH + "Animation/Math : Evaluate Curve")]
	[UnityDocumentation("AnimationCurve.Evaluate")]
	internal class Math_EvaluateCurve : OnInputOutput<float, AnimationCurve, float>
	{
		protected override float Compute(in AnimationCurve lhs, in float rhs) => lhs.Evaluate(rhs);
	}
}