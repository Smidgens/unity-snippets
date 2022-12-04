// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Child Of")]
	internal sealed class Transform_ChildOf : MonoBehaviour
	{
		public void Tick()
		{
			if (!_target) { return; }
			Vector3 newPos = _target.transform.TransformPoint(_offsetPosition);
			transform.position = newPos;
		}

		// TODO: support offset rotation and scale

		[SerializeField] private Transform _target = null;
		[SerializeField] private Vector3 _offsetPosition = Vector3.zero;
	}
}