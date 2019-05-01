namespace Smidgenomics.Parse
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Parse/String to Int")]
	internal class ParseStringToInt : ParseX2Y<string, int>
	{
		[System.Serializable] private class IntEvent : UnityEngine.Events.UnityEvent<int>{}
		[SerializeField] private IntEvent _onParsed = null;

		protected override bool TryParse(string x, out int y)
		{
			return int.TryParse(x, out y);
		}

		protected override void Invoke(int y)
		{
			_onParsed.Invoke(y);
		}
	}
}