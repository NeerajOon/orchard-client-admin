using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Sohan.Admin.Theme;

public sealed class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
{
    private static readonly ResourceManifest _manifest;

    static ResourceManagementOptionsConfiguration()
    {
        _manifest = new ResourceManifest();

        _manifest
            .DefineScript("admin")
            .SetDependencies("bootstrap", "admin-main", "theme-manager", "jQuery", "Sortable")
            .SetUrl("~/Sohan.Admin.Theme/js/TheAdmin.min.js", "~/Sohan.Admin.Theme/js/TheAdmin.js")
            .SetVersion("1.0.0");

        _manifest
            .DefineScript("admin-main")
            .SetUrl("~/Sohan.Admin.Theme/js/TheAdmin-main.min.js", "~/Sohan.Admin.Theme/js/TheAdmin-main.js")
            .SetDependencies("theme-head", "js-cookie")
            .SetVersion("1.0.0");

        _manifest
            .DefineStyle("admin")
            .SetUrl("~/Sohan.Admin.Theme/css/TheAdmin.min.css", "~/Sohan.Admin.Theme/css/TheAdmin.css")
            .SetVersion("1.0.0");
    }

    public void Configure(ResourceManagementOptions options)
    {
        options.ResourceManifests.Add(_manifest);
    }
}
