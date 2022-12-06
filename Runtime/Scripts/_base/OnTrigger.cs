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
			_out.Invoke(c);
		}

		[SerializeField] private LayerMask _layers = -1;
		[Space]
		[SerializeField] private UnityEvent<Collider> _out = null;

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
	internal sealed class _OnTrigger : __Inspector
	{
		private static readonly string _TRIGGER_WARNING = "- Collider is not a Trigger -".ToUpper();
		private Collider _collider = null;

		protected override string GetWarning() => !_collider.isTrigger ? _TRIGGER_WARNING : null;
		protected override void OnAfterEnable() => _collider = ((MonoBehaviour)target).GetComponent<Collider>();
	}
}

#endif