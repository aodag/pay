var target = Argument("target", "Default");

Task("Default")
    .Does(() =>
{
    Information("Hello, world!");
});

RunTarget(target);