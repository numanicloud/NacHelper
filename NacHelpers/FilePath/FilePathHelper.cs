namespace NacHelpers.FilePath
{
	public static class FilePathHelper
	{
		public static RelativeFilePath AsRelativeFilePath(this string path)
		{
			return new RelativeFilePath(path);
		}

		public static RelativeDirectoryPath AsRelativeDirectoryPath(this string path)
		{
			return new RelativeDirectoryPath(path);
		}

		public static RelativeFilePathWithoutExtension AsRelativeFilePathWithoutExtension(this string path)
		{
			return new RelativeFilePathWithoutExtension(path);
		}
		 
		public static AbsoluteFilePath AsAbsoluteFilePath(this string path)
		{
			return new AbsoluteFilePath(path);
		}

		public static AbsoluteDirectoryPath AsAbsoluteDirectoryPath(this string path)
		{
			return new AbsoluteDirectoryPath(path);
		}

		public static AbsoluteFilePathWithoutExtension AsAbsoluteFilePathWithoutExtension(this string path)
		{
			return new AbsoluteFilePathWithoutExtension(path);
		}
	}
}
