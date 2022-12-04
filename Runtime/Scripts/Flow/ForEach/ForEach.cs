// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	/// <summary>
	/// Base class for looping through values
	/// </summary>
	internal abstract class ForEach<T> : MonoBehaviour
	{
		public void Invoke(T[] arr)
		{
			// why bother if empty
			if(_onEach.GetPersistentEventCount() == 0) { return; }

			for (int i = 0; i < arr.Length; i++)
			{
				_onEach.Invoke(arr[i]);
			}
		}

		[SerializeField] internal UnityEvent<T> _onEach = null;
	}
}