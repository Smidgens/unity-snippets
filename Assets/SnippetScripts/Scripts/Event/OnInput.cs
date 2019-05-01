#pragma warning disable 0168 // var declared, unused
#pragma warning disable 0219 // var assigned, unused
#pragma warning disable 0414 // private var assigned, unused
#pragma warning disable 0649 // never assigned, unused


namespace Smidgenomics.Event
{
	using UnityEngine;
	using UnityEngine.Events;
	
	[DisallowMultipleComponent]
	[AddComponentMenu("Smidgenomics/Event/On Input")]
	internal class OnInput : MonoBehaviour
	{
		public void CheckInput()
		{
			if(_input.Active) { _onInput.Invoke(); }
		}
		[SerializeField] private InputReference _input;
		[SerializeField] private UnityEvent _onInput = null;
	}
}


namespace Smidgenomics.Event
{
	using UnityEngine;
	
	[System.Serializable]
	internal struct InputReference
	{
		public bool Active { get { return _inputType == InputType.Key ? GetKeyActive() : GetButtonActive(); } }

		private enum InputEvent { Down, Up, Hold } 
		private enum InputType { Key, Button }
		[SerializeField] private InputEvent _inputEvent;
		[SerializeField] private InputType _inputType;
		[SerializeField] private string _button;
		[SerializeField] private KeyCode _key;

		private bool GetKeyActive()
		{
			switch(_inputEvent)
			{
				case InputEvent.Down: return Input.GetKeyDown(_key);
				case InputEvent.Up: return Input.GetKeyUp(_key);
				case InputEvent.Hold: return Input.GetKey(_key);
			}
			return false;
		}

		private bool GetButtonActive()
		{
			switch(_inputEvent)
			{
				case InputEvent.Down: return Input.GetButtonDown(_button);
				case InputEvent.Up: return Input.GetButtonUp(_button);
				case InputEvent.Hold: return Input.GetButton(_button);
			}
			return false;
		}
	}

}


#if UNITY_EDITOR

namespace Smidgenomics.Event
{
	using UnityEngine;
	using UnityEditor;

	[CustomPropertyDrawer(typeof(InputReference))]
	internal class PD_InputReference : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			Rect lRect, pRect;
			{
				Vector2 lSize = EditorStyles.label.CalcSize(label);
				if(label != GUIContent.none) { lSize.x = EditorGUIUtility.labelWidth; }

				lRect = position;
				lRect.width = lSize.x;
				pRect = position;
				pRect.x += lRect.width;
				pRect.width -= lRect.width;
			}

			EditorGUI.BeginProperty(position, label, property);
			if(lRect.width > 0) { EditorGUI.LabelField(lRect, label); }
			int t = EditorGUI.indentLevel;
			if(EditorGUI.indentLevel > 0) { EditorGUI.indentLevel = 0; }
			
			DrawProperty(pRect, property);
			EditorGUI.indentLevel = t;
			EditorGUI.EndProperty();

		}

		private static void DrawProperty(Rect area, SerializedProperty property)
		{
			area.width += 5f;
			area.x -= 5f;
			var tRect = new Rect(area.x, area.y, 60f, area.height);
			var eRect = new Rect(area.x + tRect.width, area.y, 50f, area.height);
			var vRect = new Rect(area.x + eRect.width + tRect.width + 2f, area.y, (area.width  - (tRect.width + eRect.width)) - 2f, area.height);
			var tProp = property.FindPropertyRelative("_inputType");
			var eProp = property.FindPropertyRelative("_inputEvent");
			var vProp = property.FindPropertyRelative(tProp.enumValueIndex == 0 ? "_key" : "_button");
			EditorGUI.PropertyField(tRect, tProp, GUIContent.none);
			EditorGUI.PropertyField(eRect, eProp, GUIContent.none);
			EditorGUI.PropertyField(vRect, vProp, GUIContent.none);

		}
	}
}
#endif


#if UNITY_EDITOR

namespace Smidgenomics.Event
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(OnInput))]
	internal class Editor_OnInput : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			EditorGUILayout.PropertyField(_input, GUIContent.none);
			EditorGUILayout.EndVertical();
			EditorGUILayout.PropertyField(_onInput);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onInput = null, _input = null;

		private void OnEnable()
		{
			_onInput = serializedObject.FindProperty("_onInput");
			_input = serializedObject.FindProperty("_input");
		}
	}
}
#endif