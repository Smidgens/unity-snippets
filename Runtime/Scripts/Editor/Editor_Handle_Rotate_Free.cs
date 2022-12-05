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

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CustomEditor(typeof(Editor_Handle_Rotate_Free))]
	internal sealed class _Editor_Handle : Editor
	{
		public void OnSceneGUI()
		{
			Editor_Handle_Rotate_Free t = ((Editor_Handle_Rotate_Free)target);
			Transform ob = t._target;
			if (!ob) { return; }

			Handles.color = t._color;

			EditorGUI.BeginChangeCheck();
			Quaternion rot = Handles.FreeRotateHandle(ob.rotation, ob.position, t._radius);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(ob, "Free Rotate");
				ob.rotation = rot;
			}
		}
	}
}


#endif