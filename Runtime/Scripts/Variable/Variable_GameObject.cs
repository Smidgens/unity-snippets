// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;
	
	[AddComponentMenu(Constants.ACM.VARIABLE + "Game Object")]
	internal sealed class Variable_GameObject : Variable<GameObject> { }

	[Serializable]
	internal sealed class Wrapped_GameObject : WrappedValue<GameObject, Variable_GameObject>
	{
		public Wrapped_GameObject() { }
		public Wrapped_GameObject(GameObject defaultValue) : base(defaultValue) { }
	}
}