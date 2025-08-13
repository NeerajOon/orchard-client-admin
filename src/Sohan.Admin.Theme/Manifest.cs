using OrchardCore.DisplayManagement.Manifest;
using OrchardCore.Modules.Manifest;

[assembly: Theme(
    Name = "The Sohan Theme",
    Author = "Sohan Maali",
    Website = "https://sohan.com",
    Version = "1.0.0",
    Description = "The Sohan Admin theme.",
    Dependencies = 
    [
        "OrchardCore.Themes",
    ],
    Tags =
    [
        ManifestConstants.AdminTag,
    ]
)]
