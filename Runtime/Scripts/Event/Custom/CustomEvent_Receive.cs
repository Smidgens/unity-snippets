// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.EVENT_CUSTOM + "Receive")]
	internal sealed class CustomEvent_Receive : Snippet
	{
		[SerializeField] internal string _event = "";
		[SerializeField] internal UnityEvent _out = null;

		private void OnEnable() => CustomEvent.onMessage += OnEvent;

		private void OnDisable() => CustomEvent.onMessage += OnEvent;

		private void OnEvent(string msg)
		{
			if(_event.Length == 0 || msg != _event) { return; }
			_out.Invoke();
		}
	}
}