// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	internal static partial class SerializedProperty_
	{
		public static bool IsUnityEvent(this SerializedProperty p)
		{
			return
			p != null
			&& !p.isArray
			&& p.FindPropertyRelative("m_PersistentCalls") != null;
		}
	}
}

#endif