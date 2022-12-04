// smidgens @ github

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	/// <summary>
	/// Base class to render default inspector
	/// </summary>
	internal abstract class __BasicEditor : Editor
	{
		public override sealed void OnInspectorGUI()
		{
			EditorGUILayout.Space();

			DisplayMessage();

			if(_props != null)
			{
				serializedObject.UpdateIfRequiredOrScript();
				foreach (SerializedProperty p in _props)
				{
					// treat null as request for space
					if(p == null)
					{
						EditorGUILayout.Space();
						continue;
					}

					EditorGUILayout.PropertyField(p);
				}
				serializedObject.ApplyModifiedProperties();
			}
		}

		protected virtual string[] GetFieldNames() => null;

		protected virtual MessageType GetMessageType() => MessageType.Info;

		protected virtual void OnInit() { }

		protected virtual string GetMessageText() => null;

		private SerializedProperty[] _props = null;

		private void OnEnable()
		{
			string[] fnames = GetFieldNames();
			if(fnames != null)
			{
				_props = new SerializedProperty[fnames.Length];
				for (int i = 0; i < fnames.Length; i++)
				{
					if (fnames[i] == null) { continue; }
					_props[i] = serializedObject.FindProperty(fnames[i]);
				}
			}
			OnInit();
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