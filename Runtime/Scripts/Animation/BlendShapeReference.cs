// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using UnityEngine;

	// wrapper around skinned mesh renderer and shape key
	[Serializable]
	internal struct BlendShapeReference
	{
		public float Value
		{
			set => _renderer.SetBlendShapeWeight(_index, Mathf.Clamp01(value));
			get => _renderer.GetBlendShapeWeight(_index);
		}

		public float NormalizedValue
		{
			get => _renderer.GetBlendShapeWeight(_index) / 100f;
			set => _renderer.SetBlendShapeWeight(_index, Mathf.Clamp01(value) * 100f);
		}

		[SerializeField] internal SkinnedMeshRenderer _renderer;
		[SerializeField] internal int _index;
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	[CustomPropertyDrawer(typeof(BlendShapeReference))]
	internal sealed class _BlendShapeReference : PropertyDrawer
	{

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Vector3 center = position.center;

			position.height = EditorGUIUtility.singleLineHeight;
			position.center = center;


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
			var indexProp = property.FindPropertyRelative(nameof(BlendShapeReference._index));
			var rendererProp = property.FindPropertyRelative(nameof(BlendShapeReference._renderer));

			Rect left = area.SliceLeft(area.width * 0.5f); // left col
			area.SliceLeft(2f); // spacing

			EditorGUI.PropertyField(left, rendererProp, GUIContent.none);
			DrawIndexDrawer(area, rendererProp, indexProp);
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