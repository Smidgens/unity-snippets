// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Rotate")]
	internal class Transform_Rotate : MonoBehaviour
	{
		public void Tick(Vector3 rot)
		{
			transform.localRotation *= Quaternion.Euler(rot);
		}
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Transform_Rotate))]
	internal class _Rotate : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Invoked through Tick method", MessageType.Info);
		}
	}
}
#endif