namespace NacHelpers.FilePath.Interfaces
{
	public interface IFilePathWithoutExtension : IFilePath
	{
		IFilePathWithExtension WithExtension(string extensionWithoutDot);
	}
}
