using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Sohan.Client.Theme;
public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{

	private static readonly ResourceManifest _manifest = new();

	static ResourceManagementOptionsConfiguration()
	{
		
		_manifest
			.DefineScript("TestTheme")
			.SetUrl("~/Sohan.Client.Theme/js/main.js", "~/Sohan.Client.Theme/js/main.js");
	}

	public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
}
