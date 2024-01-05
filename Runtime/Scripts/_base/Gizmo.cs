// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System.Diagnostics;

	// gizmo base class
	internal abstract class Gizmo : Snippet
	{
		[Conditional("UNITY_EDITOR")]
		public void In()
		{
			Gizmos.color = _color;
			OnDraw();
		}

		[Conditional("UNITY_EDITOR")]
		protected abstract void OnDraw();

		protected Vector3 GetPosition()
		{
			return transform.TransformPoint(_offset);
		}

		[SerializeField] private Color _color = Color.green; // gizmo color
		[SerializeField] protected Vector3 _offset = Vector3.zero; // box size
	}
}