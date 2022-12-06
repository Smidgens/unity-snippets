// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	using System.Reflection;
	using System.Collections.Generic;

	/// <summary>
	/// Base class to render default inspector
	/// </summary>
	internal abstract class __Inspector : Editor
	{
		public override sealed void OnInspectorGUI()
		{
			// display docs
			DrawDocumentation();

			// display warnings if any
			DisplayMessage(GetWarning(), MessageType.Warning);
			EditorGUILayout.Space();


			serializedObject.UpdateIfRequiredOrScript();
			
			DrawFields();
			DrawLists();
			DrawEventTabs();

			serializedObject.ApplyModifiedProperties();
		}
		protected virtual string GetWarning() => null;
		// init
		protected virtual void OnAfterEnable() { }

		private List<SerializedProperty> _fields = null;
		private DocumentationHeader _documentation = null;
		private EventTabs _eventTabs = null;
		private List<DraggableDisplayList> _dragLists = null;

		private void OnEnable()
		{

			_documentation = new DocumentationHeader(target.GetType());

			FindFields
			(
				serializedObject,
				out _fields,
				out _dragLists,
				out List<SerializedProperty> tabbedProps
			);

			if(tabbedProps != null)
			{
				_eventTabs = new EventTabs(tabbedProps);
			}

			OnAfterEnable();
		}


		private static void FindFields
		(
			SerializedObject serializedObject,
			out List<SerializedProperty> fields,
			out List<DraggableDisplayList> lists,
			out List<SerializedProperty> eventFields
		)
		{
			// script type
			System.Type type = serializedObject.targetObject.GetType();

			fields = new List<SerializedProperty>();

			// show events in tabs?
			bool eventsAsTabs = type.GetCustomAttribute<DrawEventsAsTabsAttribute>() != null;
			eventFields = eventsAsTabs
			? new List<SerializedProperty>()
			: null;

			// render arrays as drag lists?
			bool arraysAsLists = type.GetCustomAttribute<DrawArraysAsListsAttribute>() != null;
			lists = arraysAsLists
			? new List<DraggableDisplayList>()
			: null;
			
			foreach (var f in type.FindInspectorFields())
			{
				SerializedProperty prop = serializedObject.FindProperty(f.Name);

				// render array as list
				if (arraysAsLists && f.FieldType.IsArray)
				{
					DraggableDisplayList pl = new DraggableDisplayList(prop);
					lists.Add(pl);
					continue;
				}

				// display event in tab view
				if (eventsAsTabs && f.FieldType.IsUnityEvent())
				{
					eventFields.Add(prop);
					continue;
				}

				// treat as regular field
				fields.Add(serializedObject.FindProperty(f.Name));
			}

		}


		private void DrawDocumentation()
		{
			_documentation.DrawLayout();
		}


		private void DrawLists()
		{
			if (_dragLists == null) { return; }
			EditorGUILayout.Space();
			foreach (DraggableDisplayList l in _dragLists)
			{
				l.DoLayoutList();
			}
		}

		private void DrawEventTabs()
		{
			if (_eventTabs == null) { return; }
			EditorGUILayout.Space();
			_eventTabs?.DisplayLayout();
		}


		private void DrawFields()
		{
			if(_fields == null) { return; }
			foreach (SerializedProperty p in _fields)
			{
				p.PropertyField();
			}
		}

		private static void DisplayMessage(string msg, in MessageType type)
		{
			if (string.IsNullOrEmpty(msg)) { return; }
			EGUI.Message(msg, type);
			//EditorGUILayout.Space();
		}
	}
}
#endif

