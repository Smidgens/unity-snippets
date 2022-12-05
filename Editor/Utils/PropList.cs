// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using UnityEditorInternal;

	internal sealed class PropList
	{
		public PropList(SerializedProperty prop)
		{
			_prop = prop;
			_list = new ReorderableList(_prop.serializedObject, _prop, true, true, true, true);
			_list.drawElementCallback = DrawListItem;
			_list.elementHeight = EditorGUIUtility.singleLineHeight * 1.5f;
			_list.drawHeaderCallback = DrawLabel;
		}

		private ReorderableList _list = null;
		private SerializedProperty _prop = null;

		private void DrawLabel(Rect r) => EditorGUI.LabelField(r, _prop.displayName);

		private void DrawListItem(Rect rect, int index, bool isActive, bool isFocused)
		{
			Vector2 center = rect.center;
			rect.height = EditorGUIUtility.singleLineHeight;
			rect.center = center;
			var p = _prop.GetArrayElementAtIndex(index);
			EditorGUI.PropertyField(rect, p, GUIContent.none);
		}


		public void DoLayoutList()
		{
			_list.DoLayoutList();
		}


	}
}
#endif