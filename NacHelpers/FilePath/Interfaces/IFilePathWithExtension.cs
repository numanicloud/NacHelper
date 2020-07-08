using System.IO;

namespace NacHelpers.FilePath.Interfaces
{
	public interface IFilePathWithExtension : IFilePath
	{
		bool Exists() => File.Exists(ToStringRepresentation());
		FileStream Create() => File.Create(ToStringRepresentation());
		FileStream OpenRead() => File.OpenRead(ToStringRepresentation());
		FileStream OpenWrite() => File.OpenWrite(ToStringRepresentation());
		IFilePathWithoutExtension WithoutExtension();
		AbsoluteFilePath ToAbsoluteFilePath();
		string GetExtension() => Path.GetExtension(ToStringRepresentation());
	}
}
