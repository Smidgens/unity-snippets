// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CAST_STRING + "→ String[]")]
	internal sealed class SplitString : OnInputOutput<string, string[]>
	{
		protected override string[] Compute(in string v)
		{
			return v.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
		}

	}
}