// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.TRANSFORM + "Translate")]
	internal class Transform_Translate : MonoBehaviour
	{

		public void AddLocalY(float t)
		{
			Vector3 pos = transform.localPosition;
			pos.y += t;
			transform.localPosition = pos;
		}

		public void SetLocalY(float v)
		{
			Vector3 pos = transform.localPosition;
			pos.y = v;
			transform.localPosition = pos;
		}

	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Transform_Translate))]
	internal class _Transform_Translate : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Controlled through script.", MessageType.Info);
		}
	}
}
#endif