// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Destroy")]
	internal class GameObject_Destroy : MonoBehaviour
	{
		public GameObject Object { get => _object; set => _object = value; }

		public void Invoke()
		{
			if (!_object) { return; }
			Destroy(_object);
		}
		[SerializeField] internal GameObject _object = default;
	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CustomEditor(typeof(GameObject_Destroy))]
	[CanEditMultipleObjects]
	internal sealed class _GameObject_Destroy : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(GameObject_Instantiate._object),
			nameof(GameObject_Instantiate._parent),
		};

		protected override string[] GetFieldNames() => _FNAMES;
	}
}

#endif