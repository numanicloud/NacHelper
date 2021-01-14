using System.IO;

namespace NacHelpers.FilePath2.Interfaces
{
	interface IFilePathWithExtension : IFilePath
	{
		FileExtension Extension { get; }

		public IFilePath RemoveExtension(IFilePathWithExtension filePath)
		{
			var newPath = Path.GetFileNameWithoutExtension(filePath.PathString);

			if (Path.HasExtension(newPath))
			{
				var ext = new FileExtension(Path.GetExtension(newPath));
				return filePath.RoutingInfo.GetFilePathWithExtension(Path.GetFileNameWithoutExtension(newPath), ext);
			}

			return filePath.RoutingInfo.GetFilePath(newPath);
		}
	}
}
