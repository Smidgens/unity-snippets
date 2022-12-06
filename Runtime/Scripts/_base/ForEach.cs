// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	using System.Collections.Generic;

	/// <summary>
	/// Base class for looping through values
	/// </summary>
	internal abstract class ForEach<T> : Snippet
	{
		// array specific iteration
		public void In(T[] arr)
		{
			if(!HasOutputs()) { return; }
			for (int i = 0; i < arr.Length; i++) { _onEach.Invoke(arr[i]); }
		}

		// expose some reasonably common collection types for inspector
		public void In(List<T> l) => In2(l);
		public void In(LinkedList<T> l) => In2(l);
		public void In(IEnumerable<T> l) => In2(l);

		[SerializeField] protected UnityEvent<T> _onEach = null;

		// output handlers > 0
		private bool HasOutputs() => _onEach.GetPersistentEventCount() > 0;

		// generic iterator
		private void In2(IEnumerable<T> collection)
		{
			if (!HasOutputs()) { return; }
			foreach (T item in collection) { _onEach.Invoke(item); }
		}

	}
}