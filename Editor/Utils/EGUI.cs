// smidgens @ github

#if UNITY_EDITOR

#pragma warning disable IDE0059

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using System;

	/// <summary>
	/// Editor GUI
	/// </summary>
	internal static class EGUI
	{
		public static void Message(string msg, MessageType t = MessageType.Info)
		{
			Color tcolor = GUI.color;
			if(t == MessageType.Warning)
			{
				GUI.color = Color.yellow * 1f;
			}
			EditorGUILayout.LabelField(msg, _WARN_LABEL.Value);
			GUI.color = tcolor;
		}

		public static void Link(GUIContent label, string link)
		{
			bool open = false;
			GUIStyle style = _LINK_LABEL.Value;
			Rect pos = EditorGUILayout.GetControlRect();
			Rect labelPos = SliceLabelRight(pos, label.text, style);
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

		private static readonly Lazy<GUIStyle> _WARN_LABEL = new Lazy<GUIStyle>(() =>
		{
			GUIStyle s = new GUIStyle(EditorStyles.miniBoldLabel);
			s.alignment = TextAnchor.MiddleCenter;
			s.richText = true;
			return s;
		});

	}
}

#endif