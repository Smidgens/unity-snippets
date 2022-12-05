// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.VARIABLE + "Color")]
	internal sealed class Variable_Color : Variable<Color> { }

	[Serializable]
	internal sealed class Wrapped_Color : WrappedValue<Color, Variable_Color>
	{
		public Wrapped_Color() { }
		public Wrapped_Color(Color defaultValue) : base(defaultValue) { }
	}
}