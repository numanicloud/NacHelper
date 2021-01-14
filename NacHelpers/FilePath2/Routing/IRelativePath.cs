using NacHelpers.FilePath2.Interfaces;

namespace NacHelpers.FilePath2.Routing
{
	interface IRelativePath : IFileSystemPath
	{
		IRouting IFileSystemPath.RoutingInfo => new RelativeRoute();
	}
}
