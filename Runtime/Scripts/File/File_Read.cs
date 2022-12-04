// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class File_Read<TOut> : MonoBehaviour
	{
		public void Read(string path)
		{
			if (File.Exists(path)) { _onSuccess.Invoke(Get(path)); }
			else { _onFail.Invoke(); }
		}

		protected abstract TOut Get(string path);

		[SerializeField] private UnityEvent<TOut> _onSuccess = null;
		[SerializeField] private UnityEvent _onFail = null;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(File_Read<>), true)]
	internal sealed class _File_Read : Editor
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
			("Success", "_onSuccess"),
			("Fail", "_onFail"),
		};

		private void OnEnable()
		{
			_tabs = new TabbedEvents(serializedObject, _TABS);
		}
	}
}
#endif