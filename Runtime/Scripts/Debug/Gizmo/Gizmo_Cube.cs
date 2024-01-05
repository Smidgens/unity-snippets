// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	/// <summary>
	/// Draws gizmo cube in editor
	/// </summary>
	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Cube")]
	[UnityDocumentation("Gizmos.DrawCube")]
	internal class Gizmo_Cube : Gizmo
	{

		protected delegate void DrawFn(Vector3 pos, Vector3 size);

		protected override sealed void OnDraw()
		{
			Gizmos.DrawCube(GetPosition(), GetScaledSize());
		}

		protected virtual DrawFn GetDrawFn() => Gizmos.DrawCube;

		private Vector3 GetScaledSize()
		{
			Vector3 size = _size;
			size.x *= transform.lossyScale.x;
			size.y *= transform.lossyScale.y;
			size.z *= transform.lossyScale.z;
			return size;
		}

		[SerializeField] private Vector3 _size = Vector3.one; // box size

	}
}
