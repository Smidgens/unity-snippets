// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[Serializable]
	internal sealed class Wrapped_Float : WrappedValue<float, Variable_Float>
	{
		public Wrapped_Float() { }
		public Wrapped_Float(float defaultValue) : base(defaultValue) { }
	}

	[AddComponentMenu(Constants.ACM.VARIABLE + "Float")]
	internal sealed class Variable_Float : Variable<float> { }
}