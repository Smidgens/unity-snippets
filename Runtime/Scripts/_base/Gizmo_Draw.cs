// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System.Diagnostics;

	// gizmo base class
	internal abstract class Gizmos_Draw : MonoBehaviour
	{
		public void Draw()
		{
			Gizmos.color = _color;
			if (_wire) { DrawWire(); }
			else { DrawSolid(); }
		}

		[Conditional("UNITY_EDITOR")]
		protected abstract void DrawSolid();

		[Conditional("UNITY_EDITOR")]
		protected abstract void DrawWire();

#if UNITY_EDITOR
		[SerializeField] internal bool _wire = false; // draw as wire?
		[SerializeField] internal Color _color = Color.green; // gizmo color
#endif
	}
}