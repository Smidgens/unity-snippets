// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	/// <summary>
	/// Draws gizmo cube in editor
	/// </summary>
	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Cube")]
	[UnityDocumentation("Gizmos")]
	internal sealed class Gizmo_Cube : Gizmos_Draw
	{
		protected override void DrawSolid() => Draw(Gizmos.DrawCube);

		protected override void DrawWire() => Draw(Gizmos.DrawWireCube);

		private void Draw(System.Action<Vector3, Vector3> drawFn) => drawFn.Invoke(transform.position, GetScaledSize());

		private Vector3 GetScaledSize()
		{
			Vector3 size = _size;
			size.x *= transform.lossyScale.x;
			size.y *= transform.lossyScale.y;
			size.z *= transform.lossyScale.z;
			return size;
		}

#if UNITY_EDITOR
		[SerializeField] internal Vector3 _size = Vector3.one; // box size
#endif

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Gizmo_Cube))]
	internal sealed class _Gizmo_Cube : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Gizmos_Draw._color),
			nameof(Gizmos_Draw._wire),
			null,
			nameof(Gizmo_Cube._size),
		};
		protected override string[] GetFields() => _FNAMES;
	}
}

#endif