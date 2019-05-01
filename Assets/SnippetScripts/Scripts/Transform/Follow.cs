namespace Smidgenomics.Transform
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Transform/Follow")]
	internal class Follow : MonoBehaviour
	{
		public Transform target = null;
		public Vector3 offset = Vector3.zero;
		public void UpdateFollow()
		{
			if(target) { transform.position = target.position + offset; }
		}

		public void SetOffsetX(float v) { offset.x = v; }
		public void SetOffsetY(float v) { offset.y = v; }
		public void SetOffsetZ(float v) { offset.z = v; }
	}
}