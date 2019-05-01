namespace Smidgenomics.Parse
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Parse/Int to Bool")]
	internal class ParseInt2Bool : ParseX2Y<int, bool>
	{
		[System.Serializable] private class BoolEvent : UnityEngine.Events.UnityEvent<bool>{}
		[SerializeField] private BoolEvent _onParsed = null;
		protected override bool TryParse(int x, out bool y)
		{
			y = x == 0 ? false : true;
			return true;
		}

		protected override void Invoke(bool y)
		{
			_onParsed.Invoke(y);
		}
	}
}