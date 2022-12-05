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
			_out.Invoke(c);
		}

		[SerializeField] internal UnityEvent<Collision> _out = null;
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
			nameof(OnCollisionEvent._layers),
			null,
			nameof(OnCollisionEvent._out),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif