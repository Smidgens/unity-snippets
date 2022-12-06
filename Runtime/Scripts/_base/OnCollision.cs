// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[RequireComponent(typeof(Collider))]
	internal abstract class OnCollisionEvent : Snippet
	{
		protected void Invoke(Collision c)
		{
			if (ShouldIgnore(c.collider)) { return; }
			_out.Invoke(c);
		}

		[SerializeField] protected LayerMask _layers = -1;
		[Space]
		[SerializeField] protected UnityEvent<Collision> _out = null;

		private bool ShouldIgnore(Collider c)
		{
			if (!_layers.HasLayer(c.gameObject.layer)) { return true; }
			return false;
		}
	}
}