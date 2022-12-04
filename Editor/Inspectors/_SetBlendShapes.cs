// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using UnityEditorInternal;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(SMR_SetBlendShapes))]
	internal sealed class _SetBlendShapes : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			_list.DoLayoutList();
			serializedObject.ApplyModifiedProperties();
		}

		private ReorderableList _list = null;
		private SerializedProperty _blendShapes = null;
		private void OnEnable()
		{
			_blendShapes = serializedObject.FindProperty(nameof(SMR_SetBlendShapes._shapes));
			_list = new ReorderableList(serializedObject, _blendShapes, true, true, true, true);
			_list.drawElementCallback = DrawListItem;
			_list.elementHeight = EditorGUIUtility.singleLineHeight * 1.5f;
			_list.drawHeaderCallback = r =>
			{
				EditorGUI.LabelField(r, _blendShapes.displayName);
			};
		}

		private void DrawListItem(Rect rect, int index, bool isActive, bool isFocused)
		{
			Vector2 center = rect.center;
			rect.height = EditorGUIUtility.singleLineHeight;
			rect.center = center;
			var p = _blendShapes.GetArrayElementAtIndex(index);
			EditorGUI.PropertyField(rect, p, GUIContent.none);
		}

	}
}

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CustomPropertyDrawer(typeof(SMR_SetBlendShapes.BlendShapeReference))]
	internal class _BlendShapeReference : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Rect lRect, pRect;
			{
				Vector2 lSize = EditorStyles.label.CalcSize(label);
				if (label != GUIContent.none) { lSize.x = EditorGUIUtility.labelWidth; }

				lRect = position;
				lRect.width = lSize.x;
				pRect = position;
				pRect.x += lRect.width;
				pRect.width -= lRect.width;
			}

			EditorGUI.BeginProperty(position, label, property);
			if (lRect.width > 0) { EditorGUI.LabelField(lRect, label); }
			int t = EditorGUI.indentLevel;
			if (EditorGUI.indentLevel > 0) { EditorGUI.indentLevel = 0; }

			DrawProperty(pRect, property);
			EditorGUI.indentLevel = t;
			EditorGUI.EndProperty();

		}

		private static void DrawProperty(Rect area, SerializedProperty property)
		{
			var indexProp = property.FindPropertyRelative("_index");
			var rendererProp = property.FindPropertyRelative("_renderer");
			Rect l, r;
			{
				l = area;
				l.width *= 0.5f;
				r = l;
				r.x += l.width;

			}
			l.width -= 2;

			EditorGUI.PropertyField(l, rendererProp, GUIContent.none);
			DrawIndexDrawer(r, rendererProp, indexProp);
		}

		private static void DrawIndexDrawer(Rect area, SerializedProperty rendererProp, SerializedProperty indexProp)
		{
			GUIContent label = new GUIContent("");
			if (rendererProp.objectReferenceValue)
			{
				var renderer = (SkinnedMeshRenderer)rendererProp.objectReferenceValue;
				if (renderer.sharedMesh)
				{
					if (indexProp.intValue >= 0 && indexProp.intValue < renderer.sharedMesh.blendShapeCount)
					{
						label.text = renderer.sharedMesh.GetBlendShapeName(indexProp.intValue);
					}

					if (GUI.Button(area, label, EditorStyles.popup))
					{
						GenericMenu m = new GenericMenu();
						for (int i = 0; i < renderer.sharedMesh.blendShapeCount; i++)
						{
							int current = i;
							m.AddItem(new GUIContent(renderer.sharedMesh.GetBlendShapeName(i)), current == indexProp.intValue, () =>
							{
								indexProp.intValue = current;
								indexProp.serializedObject.ApplyModifiedProperties();
							});
						}
						m.ShowAsContext();
					}
				}
			}
			else
			{
				bool t = GUI.enabled;
				GUI.enabled = false;
				GUI.Box(area, label, EditorStyles.popup);
				GUI.enabled = t;
			}
		}

	}
}


#endif