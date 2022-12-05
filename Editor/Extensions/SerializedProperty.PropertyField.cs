// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	using UnityEngine;

	internal static partial class SerializedProperty_
	{
		// unity event helper
		public static void PropertyField(this SerializedProperty p, bool label = true)
		{
			//if (p == null) { return; }
			if(p == null)
			{
				EditorGUILayout.Space();
				return;
			}

			if (!label)
			{
				EditorGUILayout.PropertyField(p, GUIContent.none);
				return;
			}
			EditorGUILayout.PropertyField(p);
		}
	}
}

#endif