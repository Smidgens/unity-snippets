// smidgens @ github


namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.FILE_READ + "Read All Text")]
	internal sealed class File_ReadAllText : File_Read<string>
	{
		protected override string Get(string path) => File.ReadAllText(path);
	}
}