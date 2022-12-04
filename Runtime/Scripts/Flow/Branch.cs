// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.FLOW_CONDITIONAL + "Branch")]
	internal sealed class Branch : MonoBehaviour
	{
		// invoke default
		public void In(bool v)
		{
			UnityEvent e = v ? _onTrue : _onFalse;
			e.Invoke();
		}

		[SerializeField] internal UnityEvent _onTrue = null;
		[SerializeField] internal UnityEvent _onFalse = null;
		
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(Branch))]
	internal sealed class _Branch : Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			_tabs.DisplayLayout();
			serializedObject.ApplyModifiedProperties();
		}

		private TabbedEvents _tabs = null;

		private static readonly (string, string)[] _TABS =
		{
			("True", nameof(Branch._onTrue)),
			("False", nameof(Branch._onTrue)),
		};

		private void OnEnable()
		{
			_tabs = new TabbedEvents(serializedObject, _TABS);
		}
	}
}
#endif