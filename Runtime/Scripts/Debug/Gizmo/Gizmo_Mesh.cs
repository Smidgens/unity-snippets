// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	/// <summary>
	/// Draws gizmo cube in editor
	/// </summary>
	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Mesh")]
	internal sealed class Gizmo_Mesh : Gizmos_Draw
	{
		protected override void DrawSolid()
		{
			Draw(Gizmos.DrawMesh);
		}

		protected override void DrawWire()
		{
			Draw(Gizmos.DrawWireMesh);
		}

		private void Draw(System.Action<Mesh, int, Vector3, Quaternion, Vector3> drawFn)
		{
			if (!_mesh) { return; }

			Vector3 scale = transform.lossyScale;
			Vector3 position = transform.position;
			Quaternion rotation = transform.rotation;

			if (!_allSubmeshes)
			{
				if(_submesh < 0 || _submesh >= _mesh.subMeshCount) { return; }
				drawFn.Invoke(_mesh, _submesh, position, rotation, scale);
			}

			for (int i = 0; i < _mesh.subMeshCount; i++)
			{
				drawFn.Invoke(_mesh, i, position, rotation, scale);
			}
		}

#if UNITY_EDITOR
		[SerializeField] internal Mesh _mesh = default;
		[SerializeField] internal bool _allSubmeshes = true;

		[Min(0)]
		[SerializeField] internal int _submesh = 0;

#endif

	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Gizmo_Mesh))]
	internal sealed class _Gizmo_Mesh : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Gizmos_Draw._color),
			nameof(Gizmos_Draw._wire),
			null,
			nameof(Gizmo_Mesh._mesh),
			nameof(Gizmo_Mesh._allSubmeshes),
			nameof(Gizmo_Mesh._submesh),
		};
		protected override string[] GetFieldNames() => _FNAMES;
	}
}

#endif