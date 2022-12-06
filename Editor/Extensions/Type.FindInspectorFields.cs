// smidgens @ github


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using System;
	using UnityEngine;
	using System.Reflection;
	using System.Collections.Generic;

	internal static partial class Type_
	{
		// find
		public static IEnumerable<FieldInfo> FindInspectorFields(this Type owner)
		{
			List<FieldInfo> fields = new List<FieldInfo>();
			LinkedList<Type> hierarchy = new LinkedList<Type>(); // linked for efficient prepend

			// traverse parent hierarchy, stop at MonoBehaviour
			Type currentType = owner;
			while (currentType != typeof(MonoBehaviour) && currentType != null)
			{
				hierarchy.AddFirst(currentType);
				currentType = currentType.BaseType;
			}

			// append fields in
			// same order as Unity would normally list them
			foreach (Type htype in hierarchy)
			{
				foreach (FieldInfo field in htype.GetFields(_INSTANCE_FIELD))
				{
					if (!IsInspectorField(field)) { continue; }
					fields.Add(field);
				}
			}

			return fields;
		}
	
		// can field be drawn by inspector
		private static bool IsInspectorField(FieldInfo f)
		{
			// explicitly public but non-serialized
			if(f.IsPublic && f.GetCustomAttribute<NonSerializedAttribute>() != null) { return false; }

			// explicitly hidden
			if(f.GetCustomAttribute<HideInInspector>() != null) { return false; }

			// non-public and not serialized
			if (f.GetCustomAttribute<SerializeField>() == null) { return false; }

			return true;
		}

		// instance fields declared by type
		private static BindingFlags _INSTANCE_FIELD =
		BindingFlags.NonPublic
		| BindingFlags.Public
		| BindingFlags.DeclaredOnly
		| BindingFlags.Instance;


	}

}

#endif