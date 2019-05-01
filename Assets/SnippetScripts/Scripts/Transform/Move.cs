namespace Smidgenomics.Transform
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Transform/Move")]
	internal class Move : MonoBehaviour
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
namespace Smidgenomics.Transform
{
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Move))]
	internal class Editor_Move : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Controlled through script.", MessageType.Info);
		}
	}
}
#endif