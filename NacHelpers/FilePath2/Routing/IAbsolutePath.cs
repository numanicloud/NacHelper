using NacHelpers.FilePath2.Interfaces;

namespace NacHelpers.FilePath2.Routing
{
	public interface IAbsolutePath : IFileSystemPath
	{
		IRouting IFileSystemPath.RoutingInfo => new AbsoluteRoute();
	}
}
