using NacHelpers.FilePath2.Routing;

namespace NacHelpers.FilePath2.Interfaces
{
	public interface IFileSystemPath
	{
		public IRouting RoutingInfo { get; }
		public string PathString { get; }
	}
}
