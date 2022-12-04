// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;
	
	[RequireComponent(typeof(Collider))]
	internal abstract class OnTrigger : MonoBehaviour
	{
		protected void Invoke(Collider c)
		{
			if (ShouldIgnore(c)) { return; }
			_onEvent.Invoke(c);
		}

		[SerializeField] internal UnityEvent<Collider> _onEvent = null;
		[SerializeField] internal LayerMask _layers = -1;

		private bool ShouldIgnore(Collider c)
		{
			if (!_layers.HasLayer(c.gameObject.layer)) { return true; }
			return false;
		}
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnTrigger), true)]
	internal sealed class _OnTrigger : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(OnTrigger._layers),
			null,
			nameof(OnTrigger._onEvent),
		};

		private const string _TRIGGER_WARNING = "'Is Trigger' property on Collider needs to be enabled for Trigger to work.";

		protected override string[] GetFieldNames() => _FNAMES;

		protected override MessageType GetMessageType() => MessageType.Warning;

		protected override string GetMessageText() => !_collider.isTrigger ? _TRIGGER_WARNING : null;

		private Collider _collider = null;

		protected override void OnInit()
		{
			_collider = ((MonoBehaviour)target).GetComponent<Collider>();
		}
	}
}

#endif