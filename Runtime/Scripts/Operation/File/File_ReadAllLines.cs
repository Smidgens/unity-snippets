// smidgens @ github


namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.FILE_READ + "Read All Lines")]
	[CSharpDocumentation("system.io.file.readalllines")]
	internal sealed class File_ReadAllLines : File_Read<string[]>
	{
		protected override string[] Get(string path) => File.ReadAllLines(path);
	}
}