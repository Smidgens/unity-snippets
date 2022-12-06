// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System;
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.CAST_STRING + "→ String[]")]
	[CSharpDocumentation("system.string.split")]
	internal sealed class String_Split : OnInputOutput<string, string[]>
	{
		protected override string[] Get(in string v)
		{
			return v.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
		}

	}
}