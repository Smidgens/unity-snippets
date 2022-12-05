// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.VARIABLE + "Int")]
	internal sealed class Variable_Int : Variable<int> { }

	[Serializable]
	internal sealed class Wrapped_Int : WrappedValue<int, Variable_Int>
	{
		public Wrapped_Int() { }
		public Wrapped_Int(int defaultValue) : base(defaultValue) { }
	}
}