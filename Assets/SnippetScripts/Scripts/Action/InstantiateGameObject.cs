namespace Smidgenomics.Action
{
	using UnityEngine;

	public class InstantiateGameObject : MonoBehaviour
	{
		public void Instantiate(Vector3 position)
		{
			if(_gameObject) { DoInstantiate(_gameObject, position, _rotation, _sameName); }
		}
		
		public void SetPosition(Vector3 p) { _position = p; }
		public void SetRotation(Vector3 r) { _rotation = r; }
		public void SetObject(GameObject ob) { _gameObject = ob; }

		[SerializeField] private Vector3 _rotation = Vector3.zero;
		[SerializeField] private Vector3 _position = Vector3.zero; 
		[SerializeField] private GameObject _gameObject = null;
		[SerializeField] private bool _sameName = true;

		private static void DoInstantiate(GameObject ob, Vector3 rotation, Vector3 position, bool sameName)
		{
			GameObject o = Instantiate(ob, position, Quaternion.Euler(rotation));
			if(sameName) { o.name = ob.name; }
		}
	}
}