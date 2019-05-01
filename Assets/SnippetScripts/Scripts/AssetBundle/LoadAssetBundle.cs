namespace Smidgenomics.AssetBundle
{
	using System;
	using System.IO;
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Asset Bundle/Load Asset Bundle")]
	internal class LoadAssetBundle : MonoBehaviour
	{
		public void Load()
		{
			DoLoad();
		}

		public static AssetBundle LoadBundle(string bundleURI)
		{
			string rootPath = Application.dataPath;
			if(Application.isEditor) { rootPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6); }
			string fullPath = Path.Combine(rootPath, bundleURI);
			return AssetBundle.LoadFromFile(fullPath);
		}

		[SerializeField] private string _assetBundleURI = "";
		[SerializeField] private BundleEvent _onBundleLoad = null;

		[System.Serializable] private class BundleEvent : UnityEngine.Events.UnityEvent<AssetBundle>{}

		private void DoLoad()
		{
			_onBundleLoad.Invoke(LoadBundle(_assetBundleURI));
		}
	}
}



#if UNITY_EDITOR
namespace Smidgenomics.AssetBundle
{
	using UnityEngine;
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(LoadAssetBundle))]
	internal class Editor_LoadAssetBundle : Editor
	{
		public override void OnInspectorGUI()
		{
			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(_assetBundleURI);
			EditorGUILayout.PropertyField(_onBundleLoad);
			serializedObject.ApplyModifiedProperties();
		}

		private SerializedProperty _assetBundleURI = null;
		private SerializedProperty _onBundleLoad = null;

		private void OnEnable()
		{
			_assetBundleURI = serializedObject.FindProperty("_assetBundleURI");
			_onBundleLoad = serializedObject.FindProperty("_onBundleLoad");
		}
	}
}
#endif