// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using UnityEditorInternal;

	internal sealed class DraggableDisplayList
	{
		public DraggableDisplayList(SerializedProperty prop)
		{
			_prop = prop;
			_list = new ReorderableList(_prop.serializedObject, _prop, true, true, true, true);
			_list.drawElementCallback = DrawListItem;
			_list.elementHeightCallback = GetHeight;
			_list.drawHeaderCallback = DrawLabel;
		}

		private ReorderableList _list = null;
		private SerializedProperty _prop = null;

		private void DrawLabel(Rect r) => EditorGUI.LabelField(r, _prop.displayName);

		private float GetHeight(int i)
		{
			var p = _prop.GetArrayElementAtIndex(i);
			return EditorGUI.GetPropertyHeight(p);
			//return EditorGUIUtility.singleLineHeight * 1.5f;
		}

		private void DrawListItem(Rect rect, int index, bool isActive, bool isFocused)
		{
			int t = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;
			var p = _prop.GetArrayElementAtIndex(index);
			EditorGUI.PropertyField(rect, p, GUIContent.none);
			EditorGUI.indentLevel = t;
		}

		public void DoLayoutList()
		{
			_list.DoLayoutList();
		}

	}
}
#endif