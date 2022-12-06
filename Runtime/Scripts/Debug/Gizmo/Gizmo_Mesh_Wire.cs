// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	/// <summary>
	/// Draws gizmo cube in editor
	/// </summary>
	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Wire Mesh")]
	[UnityDocumentation("Gizmos.DrawWireMesh")]
	internal sealed class Gizmo_Mesh_Wire : Gizmo_Mesh
	{
		protected override DrawFn GetDrawFn() => Gizmos.DrawWireMesh;
	}
}
