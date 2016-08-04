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

Task("Default")
    .IsDependentOn("Build");

RunTarget(target);