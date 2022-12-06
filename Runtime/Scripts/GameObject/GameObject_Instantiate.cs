// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.GAMEOBJECT + "Instantiate")]
	[UnityDocumentation("Object.Instantiate")]
	internal sealed class GameObject_Instantiate : Snippet
	{
		public void In()
		{
			GameObject prefab = _object?.GetValue();
			if (!prefab) { return; }
			GameObject go = Spawn(prefab);
			_out.Invoke(go);
		}

		public void In(Vector3 pos)
		{
			GameObject prefab = _object?.GetValue();
			if (!prefab) { return; }
			GameObject go = Spawn(prefab);
			go.transform.localPosition = pos;
			go.SetActive(_initialState);
			_out.Invoke(go);
		}

		[SerializeField] private Wrapped_GameObject _object = default;
		[SerializeField] private Wrapped_GameObject _parent = default;
		[SerializeField] private Wrapped_Bool _initialState = new Wrapped_Bool(true);

		[Space]
		[SerializeField] private UnityEvent<GameObject> _out = default;

		private GameObject Spawn(GameObject go)
		{
			GameObject parent = _parent?.GetValue();
			if (!parent)
			{
				return Instantiate(go);
			}
			return Instantiate(go, parent.transform);
		}

	}
}