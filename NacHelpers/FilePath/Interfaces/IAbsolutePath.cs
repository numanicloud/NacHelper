namespace NacHelpers.FilePath.Interfaces
{
	public interface IAbsolutePath : IFileSystemPath
	{
		IAbsolutePath IFileSystemPath.ToAbsolutePath() => this;
		IDirectoryPath IFileSystemPath.GetParentDirectoryPath() => GetParentAbsoluteDirectoryPath();
		AbsoluteDirectoryPath GetParentAbsoluteDirectoryPath();
	}
}
