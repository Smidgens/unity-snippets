// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;
	using UnityEngine.Events;

	[DrawEventsAsTabs]
	internal abstract class File_Read<TOut> : Snippet
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