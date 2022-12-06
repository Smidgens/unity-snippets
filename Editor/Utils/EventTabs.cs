// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;
	using System.Collections.Generic;

	/// <summary>
	/// Displays list of UnityEvent fields as tabs
	/// </summary>
	internal sealed class EventTabs
	{
		public EventTabs(List<SerializedProperty> fields)
		{
			_items = new ItemInfo[fields.Count];
			_tabNames = new string[fields.Count];

			for (int i = 0; i < fields.Count; i++)
			{
				SerializedProperty eventProp = fields[i];
				SerializedProperty eventCalls = eventProp.FindEventCallers();

				ItemInfo nItem = new ItemInfo
				{
					eventProp = eventProp,
					eventCalls = eventCalls,
					callCount = eventCalls.arraySize,
				};
				_tabNames[i] = GetTabName(eventProp.displayName, nItem.callCount);
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
					_tabNames[i] = GetTabName(item.eventProp.displayName, item.callCount);
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
			public SerializedProperty eventProp, eventCalls;
			public int callCount;
		}

		private int _activeTab = 0;
		private ItemInfo[] _items = null;
		private string[] _tabNames = null;

	}
}
#endif