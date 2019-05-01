namespace Smidgenomics.Event
{
	using UnityEngine;
	using UnityEngine.Events;
	
	[AddComponentMenu("Smidgenomics/Event/Trigger")]
	[RequireComponent(typeof(Collider))]
	internal class Trigger : MonoBehaviour
	{
		[System.Serializable] private class ColliderEvent : UnityEvent<Collider>{}
		[SerializeField] private ColliderEvent _onEnter = null, _onExit = null, _onStay = null;

		private void OnTriggerEnter(Collider other)
		{
			_onEnter.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			_onExit.Invoke(other);
		}

		private void OnTriggerStay(Collider other)
		{
			_onStay.Invoke(other);
		}
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Event
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Trigger))]
	internal class Editor_Trigger : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();

			if(!_collider.isTrigger)
			{
				EditorGUILayout.HelpBox("'Is Trigger' property on Collider needs to be enabled for Trigger to work.", MessageType.Warning);
			}

			string[] tabs = new string[]{ 
				string.Format("Enter ({0})", _onEnterCount.arraySize), 
				string.Format("Stay ({0})", _onStayCount.arraySize),
				string.Format("Exit ({0})", _onExitCount.arraySize)
			};
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
			{
				case 0: p = _onEnter; break;
				case 1: p = _onStay; break;
				case 2: p = _onExit; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _onEnter = null, _onExit = null, _onStay = null;
		private SerializedProperty _onEnterCount = null, _onExitCount = null, _onStayCount = null;
		private static int _activeTab = 0;
		private Collider _collider = null;

		private void OnEnable()
		{
			_onEnter = serializedObject.FindProperty("_onEnter");
			_onExit = serializedObject.FindProperty("_onExit");
			_onStay = serializedObject.FindProperty("_onStay");
			_onEnterCount = serializedObject.FindProperty("_onEnter.m_PersistentCalls.m_Calls");
			_onExitCount = serializedObject.FindProperty("_onExit.m_PersistentCalls.m_Calls");
			_onStayCount = serializedObject.FindProperty("_onStay.m_PersistentCalls.m_Calls");
			_collider = ((Trigger)target).GetComponent<Collider>();
		}
	}
}
#endif