namespace Smidgenomics.Handle
{
	using System;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Handle/Player Prefs Handle")]
	internal class PlayerPrefsHandle : MonoBehaviour
	{
		public void SetString(string v)
		{
			if(_type == KeyType.String) { PlayerPrefs.SetString(_key, v); }
		}
		public void SetInt(int v)
		{
			if(_type == KeyType.Int) { PlayerPrefs.SetInt(_key, v); }
		}
		public void SetFloat(float v)
		{
			if(_type == KeyType.Float) { PlayerPrefs.SetFloat(_key, v); }
		}

		public void RetrieveValue()
		{
			switch(_type)
			{
				case KeyType.String: _onString.Invoke(PlayerPrefs.GetString(_key, _defaultString)); return; 
				case KeyType.Int: _onInt.Invoke(PlayerPrefs.GetInt(_key, _defaultInt)); return; 
				case KeyType.Float: _onFloat.Invoke(PlayerPrefs.GetFloat(_key, _defaultFloat)); return; 
			}
		}

		private enum KeyType { String, Float, Int }
		[Serializable] private class IntEvent : UnityEvent<int> {}
		[Serializable] private class StringEvent : UnityEvent<string> {}
		[Serializable] private class FloatEvent : UnityEvent<float> {}
		[SerializeField] private string _defaultString = null;
		[SerializeField] private int _defaultInt = 0;
		[SerializeField] private float _defaultFloat = 0f;
		[SerializeField] private KeyType _type = KeyType.String;
		[SerializeField] private string _key = "";
		[SerializeField] private IntEvent _onInt = null;
		[SerializeField] private StringEvent _onString = null;
		[SerializeField] private FloatEvent _onFloat = null;
	}
}

#if UNITY_EDITOR
namespace Smidgenomics.Handle
{
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(PlayerPrefsHandle))]
	internal class Editor_PlayerPrefsHandle : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			
			SerializedProperty vp = null;
			SerializedProperty dv = null;
			var t = _type.enumValueIndex;
			if(t == 0) { dv = _defaultString; vp = _onString; }
			else if(t == 1) { dv = _defaultFloat; vp = _onFloat; }
			else if(t == 2) { dv = _defaultInt; vp = _onInt; }
			EditorGUILayout.PropertyField(_key);
			EditorGUILayout.PropertyField(_type);
			EditorGUILayout.PropertyField(dv, new GUIContent("Default Value"));
			EditorGUILayout.HelpBox("Call retrieve method from script to send current value to listeners.", MessageType.Info);
			EditorGUILayout.PropertyField(vp, new GUIContent("Receivers", "Listeners that receive current value when 'Retrive' method is called from script."));
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _key = null;
		private SerializedProperty _type = null;
		private SerializedProperty _onString = null, _onFloat = null, _onInt = null;
		private SerializedProperty _defaultString = null, _defaultFloat = null, _defaultInt = null;

		private void OnEnable()
		{
			_key = serializedObject.FindProperty("_key");
			_type = serializedObject.FindProperty("_type");
			_onString = serializedObject.FindProperty("_onString");
			_onFloat = serializedObject.FindProperty("_onFloat");
			_onInt = serializedObject.FindProperty("_onInt");
			_defaultString = serializedObject.FindProperty("_defaultString");
			_defaultFloat = serializedObject.FindProperty("_defaultFloat");
			_defaultInt = serializedObject.FindProperty("_defaultInt");
		}
	}
}

#endif