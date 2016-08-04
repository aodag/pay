var target = Argument("target", "Default");

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore("./src/");
    DotNetCoreRestore("./test/");
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    DotNetCoreBuild("./src/Pay.Client");
    DotNetCoreBuild("./src/Pay.Client.Example");
    DotNetCoreBuild("./test/Pay.Client.Test");
});

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest("./test/Pay.Client.Test");
});

Task("Pack")
    .IsDependentOn("Build")
    .Does(() => 
{
    var settings = new DotNetCorePackSettings
    {
        Configuration = "Release",
        OutputDirectory = "./artifacts"
    };
    DotNetCorePack("./src/Pay.Client", settings);
});

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);