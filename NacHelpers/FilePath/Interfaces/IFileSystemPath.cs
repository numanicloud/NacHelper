namespace NacHelpers.FilePath.Interfaces
{
	public interface IFileSystemPath
	{
		string ToStringRepresentation();
		IDirectoryPath GetParentDirectoryPath();
		IAbsolutePath ToAbsolutePath();
	}
}
