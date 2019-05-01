namespace Smidgenomics.Transform
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Transform/Rotate")]
	internal class Rotate : MonoBehaviour
	{
		public void ResetRotation() { transform.localRotation = Quaternion.identity; }

		public void RotateLocalX(float v)
		{
			if(!enabled) { return; }
			Vector3 rot = transform.localRotation.eulerAngles;
			rot.x += v;
			transform.localRotation = Quaternion.Euler(rot);
		}

		public void RotateLocalY(float v)
		{
			if(!enabled) { return; }
			Vector3 rot = transform.localRotation.eulerAngles;
			rot.y += v;
			transform.localRotation = Quaternion.Euler(rot);
		}

		public void RotateLocalZ(float v)
		{
			if(!enabled) { return; }
			Vector3 rot = transform.localRotation.eulerAngles;
			rot.z += v;
			transform.localRotation = Quaternion.Euler(rot);
		}
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Transform
{
	using UnityEngine;
	using UnityEditor;
	[CanEditMultipleObjects]
	[CustomEditor(typeof(Rotate))]
	internal class Editor_Rotate : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.HelpBox("Controlled through script.", MessageType.Info);
		}
	}
}
#endif