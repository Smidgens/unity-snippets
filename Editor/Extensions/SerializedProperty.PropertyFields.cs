// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	internal static partial class SerializedProperty_
	{
		// unity event helper
		public static void PropertyFields(this SerializedProperty[] props)
		{
			foreach (SerializedProperty p in props)
			{
				if (p == null)
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