// smidgens @ github

namespace Smidgenomics.Unity.Snippets
{
	using System.IO;
	using UnityEngine;

	[AddComponentMenu(Constants.ACM.FILE_READ + "Read All Bytes")]
	internal sealed class File_ReadAllBytes : File_Read<byte[]>
	{
		protected override byte[] Get(string path) => File.ReadAllBytes(path);
	}
}