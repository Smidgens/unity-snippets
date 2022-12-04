// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using UnityEngine;
	using System;

	[AddComponentMenu(Constants.ACM.CAST_STRING + "→ DateTime")]
	internal class Convert_String_DateTime : Convert<string, DateTime>
	{
		protected override bool TryParse(string x, out DateTime y)
		{
			return DateTime.TryParse(x, out y);
		}
	}
}