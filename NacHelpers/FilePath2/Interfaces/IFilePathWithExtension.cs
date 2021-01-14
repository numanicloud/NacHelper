namespace NacHelpers.FilePath2.Interfaces
{
	public interface IFilePathWithExtension : IFilePath
	{
		string PathBase { get; }
		FileExtension Extension { get; }

		public IFilePath RemoveExtension() => PathHelpers.AsFilePath(PathBase);
	}
}
