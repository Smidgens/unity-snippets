// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	internal sealed class TabbedEvents
	{
		public TabbedEvents(SerializedObject so, (string, string)[] items)
		{
			_items = new ItemInfo[items.Length];
			_tabNames = new string[items.Length];

			for (int i = 0; i < items.Length; i++)
			{
				var (_, propName) = items[i];

				SerializedProperty eventProp = so.FindProperty(propName);
				SerializedProperty eventCalls = eventProp.FindPersistentCalls();

				ItemInfo nItem = new ItemInfo
				{
					label = eventProp.displayName,
					eventProp = eventProp,
					eventCalls = eventCalls,
					callCount = eventCalls.arraySize,
				};
				_tabNames[i] = GetTabName(nItem.label, nItem.callCount);
				_items[i] = nItem;
			}
		}

		public TabbedEvents(SerializedObject so, string[] fields)
		{
			_items = new ItemInfo[fields.Length];
			_tabNames = new string[fields.Length];

			for (int i = 0; i < fields.Length; i++)
			{
				var propName = fields[i];

				SerializedProperty eventProp = so.FindProperty(propName);
				SerializedProperty eventCalls = eventProp.FindPersistentCalls();

				ItemInfo nItem = new ItemInfo
				{
					label = eventProp.displayName,
					eventProp = eventProp,
					eventCalls = eventCalls,
					callCount = eventCalls.arraySize,
				};
				_tabNames[i] = GetTabName(nItem.label, nItem.callCount);
				_items[i] = nItem;
			}
		}

		public void DisplayLayout()
		{
			UpdateTabNames();
			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, _tabNames);
			SerializedProperty currentProp = _items[_activeTab].eventProp;
			EditorGUILayout.PropertyField(currentProp, GUIContent.none);
			EditorGUILayout.EndVertical();
		}

		private void UpdateTabNames()
		{
			int i = 0;
			foreach (ItemInfo item in _items)
			{
				int currentCount = item.eventCalls.arraySize;
				if (item.callCount != currentCount)
				{
					item.callCount = currentCount;
					_tabNames[i] = GetTabName(item.label, item.callCount);
				}
				i++;
			}
		}

		private static string GetTabName(string label, in int count)
		{
			return $"{label} ({count})";
		}

		private class ItemInfo
		{
			public string label;
			public SerializedProperty eventProp, eventCalls;
			public int callCount;
		}

		private int _activeTab = 0;
		private ItemInfo[] _items = null;
		private string[] _tabNames = null;

	}
}
#endif