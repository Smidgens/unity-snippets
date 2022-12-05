// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.VARIABLE + "Vector3")]
	internal sealed class Variable_Vector3 : Variable<Vector3> { }

	[Serializable]
	internal sealed class Wrapped_Vector3 : WrappedValue<Vector3, Variable_Vector3>
	{
		public Wrapped_Vector3() { }
		public Wrapped_Vector3(Vector3 defaultValue) : base(defaultValue) { }
	}
}