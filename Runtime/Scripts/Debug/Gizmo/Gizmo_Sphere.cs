// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.DEBUG_GIZMO + "Sphere")]
	[UnityDocumentation("Gizmos.DrawSphere")]
	internal class Gizmo_Sphere : Gizmo
	{
		protected override sealed void OnDraw()
		{
			Gizmos.DrawSphere(GetPosition(), GetScaledRadius());
		}

		protected virtual System.Action<Vector3,float> GetDrawFn()
		{
			return Gizmos.DrawSphere;
		}

		private float GetScaledRadius() => transform.lossyScale.x * _radius;

		[SerializeField] internal float _radius = 0.5f;

	}
}