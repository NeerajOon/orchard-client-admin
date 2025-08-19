using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Data;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;
using Sohan.User.Helpers;
using Sohan.User.Indexes;

namespace Sohan.User;

public class Startup : StartupBase
{
	public override void ConfigureServices(IServiceCollection services)
	{

		services.AddDataMigration<Migrations>();
		services.AddIndexProvider<CustomerIndexProvider>();
		services.AddScoped<ICustomerHelper, CustomerHelper>();
		services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
	}
}
