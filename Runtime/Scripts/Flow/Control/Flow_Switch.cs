// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_CONTROL + "Switch")]
	[DrawArraysAsLists]
	internal sealed class Flow_Switch : Snippet
	{
		// invoke default
		public void In(int i)
		{
			i += _start;
			if (i < 0 || i >= _out.Length)
			{
				_default.Invoke();
				return;
			}
			_out[i].Invoke();
		}

		[SerializeField] private Wrapped_Int _start = new Wrapped_Int(0);
		[Space]
		[SerializeField] private UnityEvent[] _out = { };
		[Space]
		[SerializeField] private UnityEvent _default = default;
	}
}