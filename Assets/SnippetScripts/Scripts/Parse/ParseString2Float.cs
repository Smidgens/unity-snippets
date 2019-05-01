namespace Smidgenomics.Parse
{
	using UnityEngine;

	[AddComponentMenu("Smidgenomics/Parse/String to Float")]
	internal class ParseString2Float : ParseX2Y<string, float>
	{
		[System.Serializable] private class FloatEvent : UnityEngine.Events.UnityEvent<float>{}
		[SerializeField] private FloatEvent _onParsed = null;
		protected override bool TryParse(string x, out float y)
		{
			return float.TryParse(x, out y);
		}

		protected override void Invoke(float y)
		{
			_onParsed.Invoke(y);
		}
	}
}