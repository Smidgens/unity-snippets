// smidgens @ github

#if UNITY_EDITOR

#pragma warning disable IDE0059

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using System;

	internal static class EIMGUI
	{
		public static void Link(string label, string link)
		{
			bool open = false;
			GUIStyle style = _LINK_LABEL.Value;
			Rect pos = EditorGUILayout.GetControlRect();
			Rect labelPos = SliceLabelRight(pos, label, style);
			EditorGUI.LabelField(labelPos, label, style);
			EditorGUIUtility.AddCursorRect(labelPos, MouseCursor.Link);
			open = GUI.Button(labelPos, GUIContent.none, GUIStyle.none);
			if (open) { Application.OpenURL(link); }
		}

		private static Rect SliceLabelRight(Rect r, string label, GUIStyle s)
		{
			Vector2 size = s.CalcSize(new GUIContent(label));
			float offset = r.width - size.x;
			r.width = size.x;
			r.x += offset;
			return r;
		}

		private static readonly Lazy<GUIStyle> _LINK_LABEL = new Lazy<GUIStyle>(() =>
		{
			GUIStyle s = new GUIStyle(EditorStyles.linkLabel);
			s.fontStyle = FontStyle.Bold;
			s.fontSize -= 2;
			return s;
		});

	}
}

#endif