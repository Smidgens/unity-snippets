// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_CONTROL + "Branch")]
	internal sealed class Flow_Branch : Snippet
	{
		// invoke default
		public void In(bool v)
		{
			UnityEvent e = v ? _true : _false;
			e.Invoke();
		}

		[SerializeField] private UnityEvent _true = null;
		[SerializeField] private UnityEvent _false = null;
		
	}
}