namespace Smidgenomics.Transform
{
	using UnityEngine;
	[AddComponentMenu("Smidgenomics/Transform/Scale")]
	internal class Scale : MonoBehaviour
	{
		public void SetLocalX(float value) { var s = transform.localScale; s.x = value; transform.localScale = s; }
		public void SetLocalY(float value) { var s = transform.localScale; s.y = value; transform.localScale = s; }
		public void SetLocalZ(float value) { var s = transform.localScale; s.z = value; transform.localScale = s; }
		public void SetLocal(float value) { SetLocal(new Vector3(value, value, value)); }
		public void SetLocal(Vector3 scale) { transform.localScale = scale; }
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Transform
{
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Scale))]
	internal class Editor_Scale : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Controlled through script.", MessageType.Info);
		}
	}
}
#endif