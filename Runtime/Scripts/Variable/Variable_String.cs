// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[Serializable]
	internal sealed class WrappedValue_String : WrappedValue<string, Variable_String>
	{
		public WrappedValue_String() { }
		public WrappedValue_String(string defaultValue) : base(defaultValue) { }
	}

	[AddComponentMenu(Constants.ACM.VARIABLE + "String")]
	internal sealed class Variable_String : Variable<string> { }
}