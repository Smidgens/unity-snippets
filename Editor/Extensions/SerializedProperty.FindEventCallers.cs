// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	internal static partial class SerializedProperty_
	{
		// UnityEvent helper, get list of callers
		public static SerializedProperty FindEventCallers(this SerializedProperty p)
		{
			return p.FindPropertyRelative("m_PersistentCalls.m_Calls");
		}
	}
}

#endif