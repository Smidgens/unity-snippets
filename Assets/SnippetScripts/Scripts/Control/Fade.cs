namespace Smidgenomics.Control
{
	using System;
	using System.Collections;
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu("Smidgenomics/Control/Fade")]
	internal class Fade : MonoBehaviour
	{
		public void DoFade(float duration)
		{
			if(_activeFading > 0) { return; }
			if(!gameObject.activeInHierarchy) { return; }
			_activeFading++;
			StartCoroutine(FadeRoutine(duration));
		}

		public void CancelFade()
		{
			_activeFading = 0;
			StopAllCoroutines();
			_onCancel.Invoke();
		}
		[Serializable] private class ValueEvent : UnityEvent<float>{}
		[SerializeField] private UnityEvent _onStart = null;
		[SerializeField] private ValueEvent _onStep = null;
		[SerializeField] private UnityEvent _onDone = null;
		[SerializeField] private UnityEvent _onCancel = null;
		private int _activeFading = 0;

		private void InvokeListeners(float t)
		{
			_onStep.Invoke(t);
		}

		private IEnumerator FadeRoutine(float fadeTime)
		{
			_onStart.Invoke();
			float start = Time.time;
			yield return null;
			float elapsed = 0;
			while (elapsed < fadeTime)
			{
				elapsed = Time.time - start;
				InvokeListeners(Mathf.Clamp(elapsed / fadeTime, 0, 1));
				yield return null;
			}
			InvokeListeners(1f);
			_activeFading--;
			_onDone.Invoke();
		}
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Control
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Fade))]
	internal class Editor_Fade : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();

			string[] tabs = new string[]{ 
				string.Format("Start ({0})", _startCount.arraySize), 
				string.Format("Step ({0})", _stepCount.arraySize), 
				string.Format("Done ({0})", _doneCount.arraySize),
				string.Format("Cancel ({0})", _cancelCount.arraySize)
			};
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch(_activeTab)
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

		private SerializedProperty _onStart = null, _onStep = null, _onDone = null, _onCancel = null;
		private SerializedProperty _startCount = null, _stepCount = null, _doneCount = null, _cancelCount = null;
		
		private static int _activeTab = 0;

		private void OnEnable()
		{
			_onStart = serializedObject.FindProperty("_onStart");
			_onStep = serializedObject.FindProperty("_onStep");
			_onDone = serializedObject.FindProperty("_onDone");
			_onCancel = serializedObject.FindProperty("_onCancel");
			_startCount = serializedObject.FindProperty("_onStart.m_PersistentCalls.m_Calls");
			_stepCount = serializedObject.FindProperty("_onStep.m_PersistentCalls.m_Calls");
			_doneCount = serializedObject.FindProperty("_onDone.m_PersistentCalls.m_Calls");
			_cancelCount = serializedObject.FindProperty("_onCancel.m_PersistentCalls.m_Calls");
		}
	}
}
#endif