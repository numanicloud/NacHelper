using NacHelpers.FilePath2.Interfaces;

namespace NacHelpers.FilePath2.Routing
{
	interface IAbsolutePath : IFileSystemPath
	{
		IRouting IFileSystemPath.RoutingInfo => new AbsoluteRoute();
	}
}
