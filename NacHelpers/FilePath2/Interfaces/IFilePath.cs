using System.IO;

namespace NacHelpers.FilePath2.Interfaces
{
	interface IFilePath : IFileSystemPath
	{
		public bool Exists() => File.Exists(PathString);
		public FileStream Create() => File.Create(PathString);
		public FileStream OpenRead() => File.OpenRead(PathString);
		public FileStream OpenWrite() => File.OpenWrite(PathString);

		public IFilePathWithExtension WithExtension(IFilePath filePath, FileExtension extension)
		{
			return filePath.RoutingInfo
				.GetFilePathWithExtension(filePath.PathString, extension);
		}
	}
}
