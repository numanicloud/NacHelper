using NacHelpers.FilePath2.Interfaces;

namespace NacHelpers.FilePath2
{
	record RelativeDirectoryPath(string PathString) : IRelativeDirectoryPath;

	record AbsoluteDirectoryPath(string PathString) : IAbsoluteDirectoryPath;

	record RelativeFilePath(string PathString) : IRelativeFilePath;

	record AbsoluteFilePath(string PathString) : IAbsoluteFilePath;

	record PathWithExtension(string PathBase, FileExtension Extension)
	{
		public string PathString => PathBase + Extension.WithDot;
	}

	record RelativeFilePathExt(string PathBase, FileExtension Extension)
		: PathWithExtension(PathBase, Extension), IRelativeFilePathExt;

	record AbsoluteFilePathExt(string PathBase, FileExtension Extension)
		: PathWithExtension(PathBase, Extension), IAbsoluteFilePathExt;
}
