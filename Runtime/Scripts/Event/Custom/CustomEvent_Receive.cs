// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.EVENT_CUSTOM + "Receive")]
	internal sealed class CustomEvent_Receive : MonoBehaviour
	{
		[SerializeField] internal string _event = "";
		[SerializeField] internal UnityEvent _onEvent = null;

		private void OnEnable() => CustomEvent.onMessage += OnEvent;

		private void OnDisable() => CustomEvent.onMessage += OnEvent;

		private void OnEvent(string msg)
		{
			if(_event.Length == 0 || msg != _event) { return; }
			_onEvent.Invoke();
		}
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(CustomEvent_Receive), true)]
	internal sealed class _CustomEvent_Receive : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(CustomEvent_Receive._event),
			null,
			nameof(CustomEvent_Receive._onEvent),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif