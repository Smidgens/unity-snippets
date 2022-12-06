// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	//[AddComponentMenu(Constants.ACM.ROOT + "Editor/Editor : Free Rotation Handle")]
	[AddComponentMenu("")]
	internal class Editor_Handle_Rotate_Free : MonoBehaviour
	{
		[Min(0f)]
		[SerializeField] internal float _radius = 0.5f;
		[SerializeField] internal Color _color = Color.white;
		[SerializeField] internal Transform _target = null;
	}
}