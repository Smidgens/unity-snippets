// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	/// <summary>
	/// Draws gizmo cube in editor
	/// </summary>
	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Sphere")]
	internal sealed class Gizmo_Sphere : Gizmos_Draw
	{
		protected override void DrawSolid() => Draw(Gizmos.DrawSphere);

		protected override void DrawWire() => Draw(Gizmos.DrawWireSphere);

		private void Draw(System.Action<Vector3, float> drawFn) => drawFn.Invoke(transform.position, GetScaledRadius());

		private float GetScaledRadius() => _radius * transform.lossyScale.x;

#if UNITY_EDITOR
		[Min(0f)]
		[SerializeField] internal float _radius = 0.5f; // circumference of mathy math
#endif

	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Gizmo_Sphere))]
	internal sealed class _Gizmos_Draw : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(Gizmos_Draw._color),
			nameof(Gizmos_Draw._wire),
			null,
			nameof(Gizmo_Sphere._radius),
		};
		protected override string[] GetFieldNames() => _FNAMES;
	}
}

#endif