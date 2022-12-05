// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_CONTROL + "Switch")]
	internal sealed class Switch : MonoBehaviour
	{
		// invoke default
		public void In(int i)
		{
			i += _offset;
			if (i < 0 || i >= _out.Length)
			{
				_default.Invoke();
				return;
			}
			_out[i].Invoke();
		}

		[SerializeField] private int _offset = 0;
		[SerializeField] internal UnityEvent[] _out = { };
		[SerializeField] internal UnityEvent _default = default;
	}
}