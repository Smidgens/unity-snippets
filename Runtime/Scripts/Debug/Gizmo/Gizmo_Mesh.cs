// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Mesh")]
	[UnityDocumentation("Gizmos.DrawMesh")]
	internal class Gizmo_Mesh : Gizmo
	{
		protected delegate void DrawFn
		(
			Mesh mesh,
			int submeshIndex,
			Vector3 pos,
			Quaternion rot,
			Vector3 scale
		);

		protected override sealed void OnDraw() => Draw(GetDrawFn());

		protected virtual DrawFn GetDrawFn() => Gizmos.DrawMesh;

		private void Draw(DrawFn drawFn)
		{
			if (!_mesh) { return; }
			if (_mesh.subMeshCount == 0) { return; }

			Vector3 scale = transform.lossyScale;
			Vector3 position = GetPosition();
			Quaternion rotation = transform.rotation * Quaternion.Euler(_rotation);

			bool drawAllSubmeshes = _submesh < 0 || _submesh >= _mesh.subMeshCount;

			if (drawAllSubmeshes)
			{
				for (int i = 0; i < _mesh.subMeshCount; i++)
				{
					drawFn.Invoke(_mesh, i, position, rotation, scale);
				}
				return;
			}

			if (_submesh < 0 || _submesh >= _mesh.subMeshCount) { return; }
			drawFn.Invoke(_mesh, _submesh, position, rotation, scale);
		}

		[SerializeField] internal Vector3 _rotation = default;
		[SerializeField] internal Mesh _mesh = default;
		[SerializeField] internal int _submesh = -1;
	}
}