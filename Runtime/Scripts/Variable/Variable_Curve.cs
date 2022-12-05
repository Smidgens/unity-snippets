// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.VARIABLE + "Curve")]
	internal sealed class Variable_Curve : Variable<AnimationCurve> { }

	[Serializable]
	internal sealed class Wrapped_Curve : WrappedValue<AnimationCurve, Variable_Curve>
	{
		public Wrapped_Curve() { }
		public Wrapped_Curve(AnimationCurve defaultValue) : base(defaultValue) { }
	}
}