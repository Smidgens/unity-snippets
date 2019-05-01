namespace Smidgenomics.Parse
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	[AddComponentMenu("Smidgenomics/Parse/Scene to Int")]
	internal class ParseScene2Int : ParseX2Y<Scene, int>
	{
		[System.Serializable] private class ParsedEvent : UnityEngine.Events.UnityEvent<int>{}
		[SerializeField] private ParsedEvent _onParsed = null;

		protected override bool TryParse(Scene x, out int y)
		{
			y = x.buildIndex;
			return x.IsValid();
		}

		protected override void Invoke(int y)
		{
			_onParsed.Invoke(y);
		}
	}
}