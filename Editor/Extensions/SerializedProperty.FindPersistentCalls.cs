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