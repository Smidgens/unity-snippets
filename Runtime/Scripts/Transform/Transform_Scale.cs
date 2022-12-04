// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Scale")]
	internal class Transform_Scale : MonoBehaviour
	{
		public void Tick(Vector3 scale)
		{
			Vector3 newScale = transform.localScale;
			newScale.x *= scale.x;
			newScale.y *= scale.y;
			newScale.z *= scale.z;
			transform.localScale = newScale;
		}
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Transform_Scale))]
	internal class _Transform_Scale : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Invoked through Tick method", MessageType.Info);
		}
	}
}
#endif