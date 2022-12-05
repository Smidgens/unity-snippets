// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.VARIABLE + "Bool")]
	internal sealed class Variable_Bool : Variable<bool> { }

	[Serializable]
	internal sealed class Wrapped_Bool : WrappedValue<bool, Variable_Bool>
	{
		public Wrapped_Bool() { }
		public Wrapped_Bool(bool defaultValue) : base(defaultValue) { }
	}
}