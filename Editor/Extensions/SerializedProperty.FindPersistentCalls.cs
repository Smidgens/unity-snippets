// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	
	internal static partial class SerializedProperty_
	{
		// unity event helper
		public static SerializedProperty FindPersistentCalls(this SerializedProperty p)
		{
			return p.FindPropertyRelative("m_PersistentCalls.m_Calls");
		}
	}
}

#endif



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
			if(p == null) { return; }
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


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	internal static partial class SerializedProperty_
	{
		// unity event helper
		public static void PropertyFields(this SerializedProperty[] props)
		{
			foreach(SerializedProperty p in props)
			{
				if(p == null)
				{
					EditorGUILayout.Space();
					continue;
				}
				p.PropertyField();
			}
		}
	}
}

#endif