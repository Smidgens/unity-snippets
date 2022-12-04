// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[RequireComponent(typeof(Collider))]
	internal abstract class OnCollisionEvent : MonoBehaviour
	{
		protected void Invoke(Collision c)
		{
			if (ShouldIgnore(c.collider)) { return; }
			_onEvent.Invoke(c);
		}

		[SerializeField] internal UnityEvent<Collision> _onEvent = null;
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
	[CustomEditor(typeof(OnCollisionEvent), true)]
	internal sealed class _OnCollisionEvent : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(OnTrigger._layers),
			null,
			nameof(OnTrigger._onEvent),
		};

		protected override string[] GetFieldNames() => _FNAMES;
	}
}

#endif