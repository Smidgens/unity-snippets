// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_CONTROL + "Invert")]
	internal sealed class Flow_Invert : Snippet
	{
		// invoke default
		public void In(bool v) => _out.Invoke(!v);

		[SerializeField] private UnityEvent<bool> _out = null;
	}
}