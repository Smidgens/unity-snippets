// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using UnityEngine.Events;

	[AddComponentMenu(Constants.ACM.INPUT_KEY + "Keys (Vector2)")]
	[UnityDocumentation("Input.GetKey")]
	internal sealed class Input_OnKeysVector2 : Snippet
	{
		public void In() => _out.Invoke(GetKeys());

		[SerializeField] private KeyCode
		_up = KeyCode.W,
		_down = KeyCode.S,
		_left = KeyCode.A,
		_right = KeyCode.D;

		[Space]
		[SerializeField] private bool _invertX = false;
		[SerializeField] private bool _invertY = false;

		[Space]
		[SerializeField] private UnityEvent<Vector2> _out = null;

		[SerializeField]
		private Vector2 GetKeys()
		{
			int up = Input.GetKey(_up) ? 1 : 0;
			int down = Input.GetKey(_down) ? -1 : 0;
			int left = Input.GetKey(_left) ? 1 : 0;
			int right = Input.GetKey(_right) ? -1 : 0;
			int x = (left + right) * (_invertX ? -1 : 1);
			int y = (up + down) * (_invertY ? -1 : 1);
			return new Vector2(x, y);
		}

	}
}