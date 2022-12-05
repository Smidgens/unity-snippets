// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[Serializable]
	internal sealed class WrappedFloat : WrappedValue<float, Variable_Float>
	{
		public WrappedFloat() { }
		public WrappedFloat(float defaultValue) : base(defaultValue) { }
	}

	[AddComponentMenu(Constants.ACM.VARIABLE + "Float")]
	internal sealed class Variable_Float : Variable<float> { }
}