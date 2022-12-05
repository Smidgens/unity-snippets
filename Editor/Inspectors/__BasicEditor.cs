// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	using System.Linq;

	/// <summary>
	/// Base class to render default inspector
	/// </summary>
	internal abstract class __BasicEditor : Editor
	{
		public override sealed void OnInspectorGUI()
		{
			_doc.DrawAvailable();

			EditorGUILayout.Space();

			serializedObject.UpdateIfRequiredOrScript();

			DisplayMessage();
			OnBeforeProps();
			DrawDefaultProps();
			OnAfterProps();

			bool addSpace = _plist != null || _eventTabs != null;

			if (addSpace)
			{
				EditorGUILayout.Space();
			}

			_plist?.DoLayoutList();
			_eventTabs?.DisplayLayout();

			serializedObject.ApplyModifiedProperties();
		}

		protected virtual void OnBeforeProps() { }
		protected virtual void OnAfterProps() { }
		protected virtual string GetListField() => null;
		protected virtual string[] GetFields() => null;

		//protected virtual (string, string)[] GetEventFields() => null;
		protected virtual string[] GetEventFields() => null;


		protected virtual MessageType GetMessageType() => MessageType.Info;

		protected virtual void OnInit() { }

		protected virtual string GetMessageText() => null;

		private SerializedProperty[] _props = null;

		private DocumentationLink _doc = null;

		private TabbedEvents _eventTabs = null;

		private PropList _plist = null;

		private void OnEnable()
		{
			_doc = new DocumentationLink(target.GetType());
			string[] fnames = GetFields();
			if(fnames != null)
			{
				_props = new SerializedProperty[fnames.Length];
				for (int i = 0; i < fnames.Length; i++)
				{
					if (fnames[i] == null) { continue; }
					_props[i] = serializedObject.FindProperty(fnames[i]);
				}
			}

			string[] efnames = GetEventFields();

			if(efnames != null)
			{
				//var tnames = efnames.Select(x => (string.Empty, x)).ToArray();
				_eventTabs = new TabbedEvents(serializedObject, efnames);
			}

			SerializedProperty listProp = serializedObject.FindProperty(GetListField());

			if(listProp != null)
			{
				_plist = new PropList(listProp);
			}

			OnInit();
		}

		private void DrawDefaultProps()
		{
			if(_props == null) { return; }
			foreach (SerializedProperty p in _props)
			{
				p.PropertyField();
			}
		}

		private void DisplayMessage()
		{
			string msg = GetMessageText();
			if (string.IsNullOrEmpty(msg)) { return; }
			EditorGUILayout.HelpBox(msg, GetMessageType());
			EditorGUILayout.Space();
		}
	}
}
#endif