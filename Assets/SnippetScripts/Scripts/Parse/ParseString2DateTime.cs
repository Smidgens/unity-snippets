namespace Smidgenomics.Parse
{
	using UnityEngine;
	using System;

	[AddComponentMenu("Smidgenomics/Parse/String to DateTime")]
	internal class ParseString2DateTime : ParseX2Y<string, DateTime>
	{
		[Serializable] private class ParsedEvent : UnityEngine.Events.UnityEvent<DateTime>{}
		[SerializeField] private ParsedEvent _onParsed = null;

		protected override bool TryParse(string x, out DateTime y)
		{
			return DateTime.TryParse(x, out y);
		}

		protected override void Invoke(DateTime y)
		{
			_onParsed.Invoke(y);
		}
	}
}