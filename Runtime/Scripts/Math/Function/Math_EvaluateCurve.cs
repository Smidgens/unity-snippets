// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.MATH_FUNCTION + "Evaluate Curve")]
	[UnityDocumentation("AnimationCurve.Evaluate")]
	internal sealed class Math_EvaluateCurve : Snippet
	{
		public void In(float t) => _out.Invoke(_curve.GetValue().Evaluate(t));

		[SerializeField] private Wrapped_Curve
		_curve = new Wrapped_Curve(AnimationCurve.EaseInOut(0f,0f,1f,1f));

		[Space]
		[SerializeField] private UnityEvent<float> _out = null;
	}
}