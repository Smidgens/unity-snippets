// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Lerp))]
	internal sealed class _Lerp : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			_duration.PropertyField();
			EditorGUILayout.Space();
			_tabs.DisplayLayout();
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _duration = null;
		private TabbedEvents _tabs = null;

		private static readonly (string, string)[] _TABS =
		{
			("Start", nameof(Lerp._onStart)),
			("Step", nameof(Lerp._onStep)),
			("Exit", nameof(Lerp._onExit)),
			("Abort", nameof(Lerp._onAbort)),
		};


		private void OnEnable()
		{
			_duration = serializedObject.FindProperty(nameof(Lerp._duration));
			_tabs = new TabbedEvents(serializedObject, _TABS);
		}
	}
}
#endif






#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	
	internal class _Lerpx : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();

			EditorGUILayout.Space();

			EditorGUILayout.PropertyField(_duration);

			EditorGUILayout.Space();
			// todo: clean up this mess
			string[] tabs = new string[]{
				string.Format("Start ({0})", _startCount.arraySize),
				string.Format("Step ({0})", _stepCount.arraySize),
				string.Format("Exit ({0})", _doneCount.arraySize),
				string.Format("Abort ({0})", _cancelCount.arraySize)
			};

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);

			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch (_activeTab)
			{
				case 0: p = _onStart; break;
				case 1: p = _onStep; break;
				case 2: p = _onDone; break;
				case 3: p = _onCancel; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _duration, _onStart = null, _onStep = null, _onDone = null, _onCancel = null;
		private SerializedProperty _startCount = null, _stepCount = null, _doneCount = null, _cancelCount = null;

		private static int _activeTab = 0;

		private void OnEnable()
		{
			_onStart = serializedObject.FindProperty(nameof(Lerp._onStart));
			_onStep = serializedObject.FindProperty(nameof(Lerp._onStep));
			_onDone = serializedObject.FindProperty(nameof(Lerp._onExit));
			_onCancel = serializedObject.FindProperty(nameof(Lerp._onAbort));

			_startCount = serializedObject.FindProperty($"{_onStart.name}.m_PersistentCalls.m_Calls");
			_stepCount = serializedObject.FindProperty($"{_onStep.name}.m_PersistentCalls.m_Calls");
			_doneCount = serializedObject.FindProperty($"{_onDone.name}.m_PersistentCalls.m_Calls");
			_cancelCount = serializedObject.FindProperty($"{_onCancel.name}.m_PersistentCalls.m_Calls");
		}

	}
}
#endif