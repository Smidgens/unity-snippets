// smidgens @ github


#if UNITY_EDITOR && SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;
	using System.Linq;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(AssetBundle_LoadAsync))]
	internal sealed class _LoadAssetBundleAsync : Editor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(AssetBundle_LoadAsync._URI),
			nameof(AssetBundle_LoadAsync._priority),
			null,
		};


		public override void OnInspectorGUI()
		{
			serializedObject.UpdateIfRequiredOrScript();
			EditorGUILayout.Space();
			_props.PropertyFields();
			_tabs.DisplayLayout();
			serializedObject.ApplyModifiedProperties();
		}

		private TabbedEvents _tabs = null;

		private SerializedProperty[] _props = null;

		private static readonly (string, string)[] _TABS =
		{
			("Success", nameof(AssetBundle_LoadAsync._onOutput)),
			("Progress", nameof(AssetBundle_LoadAsync._onProgress)),
		};

		private void OnEnable()
		{
			_props = _FNAMES.Select(field => field != null ? serializedObject.FindProperty(field) : null).ToArray();
			_tabs = new TabbedEvents(serializedObject, _TABS);
		}
	}
}

#endif



#if UNITY_EDITOR && SNIPPETS_ASSETBUNDLE_1

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEngine;
	using UnityEditor;

	
	internal class _LoadAssetBundleAsyncx : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_priority);
			EditorGUILayout.PropertyField(_assetBundleURI);

			// todo: clean up mess
			string[] tabs = new string[]{
				string.Format("Done ({0})", _onLoadedCount.arraySize),
				string.Format("Progress ({0})", _onProgressCount.arraySize)
			};

			EditorGUILayout.BeginVertical(EditorStyles.helpBox);
			_activeTab = GUILayout.Toolbar(_activeTab, tabs);

			SerializedProperty p = null;
			switch (_activeTab)
			{
				case 0: p = _onBundleLoad; break;
				case 1: p = _onProgress; break;
			}
			EditorGUILayout.PropertyField(p, GUIContent.none);
			EditorGUILayout.EndVertical();

			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _assetBundleURI = null;
		private SerializedProperty _onBundleLoad = null;
		private SerializedProperty _priority = null;
		private SerializedProperty _onProgress = null;

		private SerializedProperty _onProgressCount = null, _onLoadedCount = null;

		private static int _activeTab = 0;

		private void OnEnable()
		{
			_assetBundleURI = serializedObject.FindProperty(nameof(AssetBundle_LoadAsync._URI));
			_onBundleLoad = serializedObject.FindProperty(nameof(AssetBundle_LoadAsync._onOutput));
			_onProgress = serializedObject.FindProperty(nameof(AssetBundle_LoadAsync._onProgress));
			_priority = serializedObject.FindProperty(nameof(AssetBundle_LoadAsync._priority));
			_onProgressCount = serializedObject.FindProperty($"{_onProgress.name}.m_PersistentCalls.m_Calls");
			_onLoadedCount = serializedObject.FindProperty($"{_onBundleLoad.name}.m_PersistentCalls.m_Calls");
		}
	}
}
#endif