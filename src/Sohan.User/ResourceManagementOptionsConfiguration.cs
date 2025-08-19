using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Sohan.User;
public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{

	private static readonly ResourceManifest _manifest = new();

	static ResourceManagementOptionsConfiguration()
	{
		// jQuery
		_manifest
		.DefineScript("jquery")
		.SetCdn("https://code.jquery.com/jquery-3.7.1.min.js")
		.SetVersion("3.7.1");

		// jQuery Validation
		_manifest
		.DefineScript("jquery-validate")
		.SetCdn("https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/jquery.validate.min.js")
		.SetDependencies("jquery")
		.SetVersion("1.19.5");

		// Your registration form script (depends on validation)
		_manifest
			.DefineScript("Registration-Validation")
			.SetUrl("~/Sohan.User/js/registration-validation.js", "~/Sohan.User/js/registration-validation.js")
			.SetDependencies("jquery-validate");

		_manifest
			.DefineScript("userLogin-Validation")
			.SetUrl("~/Sohan.User/js/login-validation.js", "~/Sohan.User/js/login-validation.js")
			.SetDependencies("jquery-validate");

			_manifest
			.DefineScript("user")
			.SetUrl("~/Sohan.User/js/main.js", "~/Sohan.User/js/main.js")
			.SetDependencies("jquery-validate");
	}
	public void Configure(ResourceManagementOptions options) => options.ResourceManifests.Add(_manifest);
}
