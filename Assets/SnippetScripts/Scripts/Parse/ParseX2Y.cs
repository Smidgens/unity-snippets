namespace Smidgenomics.Parse
{
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class ParseX2Y : MonoBehaviour
	{
		[System.Serializable] protected class StringEvent : UnityEvent<string> {}
		[SerializeField] protected StringEvent _onError = new StringEvent();
	}

	internal abstract class ParseX2Y<X, Y> : ParseX2Y
	{
		public void TryParse(X x)
		{
			Y y;
			if(TryParse(x, out y)) { Invoke(y); }
			else { _onError.Invoke("Parsing Failed."); }
		}
		protected abstract bool TryParse(X x, out Y y);
		protected abstract void Invoke(Y y);
	}
}


#if UNITY_EDITOR
namespace Smidgenomics.Parse
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(ParseX2Y), true)]
	internal class Editor_ParseX2Y : Editor
	{
		public sealed override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			string[] tabs = new string[]{ 
				string.Format("Result ({0})", _onParsedCount.arraySize), 
				string.Format("Error ({0})", _onErrorCount.arraySize)
			};
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
			{
				case 0: p = _onParsed; break;
				case 1: p = _onError; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private int _activeTab = 0;
		private SerializedProperty _onParsed = null, _onError = null;
		private SerializedProperty _onParsedCount = null, _onErrorCount = null;

		private void OnEnable()
		{
			_onParsed = serializedObject.FindProperty("_onParsed");
			_onError = serializedObject.FindProperty("_onError");
			_onParsedCount = serializedObject.FindProperty("_onParsed.m_PersistentCalls.m_Calls");
			_onErrorCount = serializedObject.FindProperty("_onError.m_PersistentCalls.m_Calls");
		}
	}
}
#endif