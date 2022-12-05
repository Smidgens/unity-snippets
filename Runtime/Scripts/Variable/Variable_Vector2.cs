// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.VARIABLE + "Vector2")]
	internal sealed class Variable_Vector2 : Variable<Vector2> { }

	[Serializable]
	internal sealed class Wrapped_Vector2 : WrappedValue<Vector2, Variable_Vector2>
	{
		public Wrapped_Vector2() { }
		public Wrapped_Vector2(Vector2 defaultValue) : base(defaultValue) { }
	}
}