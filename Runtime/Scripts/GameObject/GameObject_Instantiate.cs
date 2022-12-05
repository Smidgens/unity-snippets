// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Instantiate")]
	[UnityDocumentation("Object.Instantiate")]
	internal class GameObject_Instantiate : MonoBehaviour
	{
		public GameObject Object { get => _object; set => _object = value; }
		public Transform Parent { get => _parent; set => _parent = value; }

		public void Invoke()
		{
			if (!_object) { return; }
			_onOutput.Invoke(Instantiate());
		}

		[SerializeField] internal GameObject _object = default;
		[SerializeField] internal Transform _parent = default;
		[SerializeField] internal UnityEvent<GameObject> _onOutput = default;

		private GameObject Instantiate() => Instantiate(_object, _parent);

	}
}


#if UNITY_EDITOR

namespace Smidgenomics.Unity.Snippets.Editor
{
	using UnityEditor;

	[CustomEditor(typeof(GameObject_Instantiate))]
	[CanEditMultipleObjects]
	internal sealed class _GameObject_Instantiate : __BasicEditor
	{
		private static readonly string[] _FNAMES =
		{
			nameof(GameObject_Instantiate._object),
			nameof(GameObject_Instantiate._parent),
			null,
			nameof(GameObject_Instantiate._onOutput),
		};

		protected override string[] GetFields() => _FNAMES;
	}
}

#endif