// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;
	using UnityEngine.Events;

	internal abstract class File_Read<TOut> : MonoBehaviour
	{
		public void In(string path)
		{
			if (File.Exists(path)) { _out.Invoke(Get(path)); }
			else { _fail.Invoke(); }
		}

		protected abstract TOut Get(string path);

		[SerializeField] internal UnityEvent<TOut> _out = null;
		[SerializeField] internal UnityEvent _fail = null;
	}
}

#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CanEditMultipleObjects]
	[CustomEditor(typeof(File_Read<>), true)]
	internal sealed class _File_Read : __BasicEditor
	{
		protected override string[] GetEventFields() => _TABS;

		private static readonly string[] _TABS =
		{
			nameof(File_Read<string>._out),
			nameof(File_Read<string>._fail),
		};
	}
}
#endif