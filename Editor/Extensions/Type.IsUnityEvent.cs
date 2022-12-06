// smidgens @ github


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using System;

	internal static partial class Type_
	{
		public static bool IsUnityEvent(this Type type)
		{
			return type.Name.StartsWith("UnityE");
		}
	}

}

#endif