#tool "GitVersion.CommandLine"
#tool "xunit.runner.console"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solutionPath            = MakeAbsolute(File(Argument("solutionPath", "Cake.Bower.sln")));
var projectName             = Argument("projectName", "Cake.Bower");

var artifacts               = MakeAbsolute(Directory(Argument("artifactPath", "./artifacts")));
var testResultsPath         = MakeAbsolute(Directory(artifacts + "./test-results"));
var testAssemblies          = new List<FilePath> { 
                                MakeAbsolute(File("./src/Cake.Bower.Tests/bin/" + configuration + "/Cake.Bower.Tests.dll"))
                              };
var versionAssemblyInfo     = MakeAbsolute(File(Argument("versionAssemblyInfo", "VersionAssemblyInfo.cs")));

SolutionParserResult solution        = null;
SolutionProject project              = null;
GitVersion versionInfo               = null;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Setup(ctx => {
    CreateDirectory(artifacts);
    
    if(!FileExists(solutionPath)) throw new Exception(string.Format("Solution file not found - {0}", solutionPath.ToString()));
    solution = ParseSolution(solutionPath.ToString());
    project = solution.Projects.FirstOrDefault(x => x.Name == projectName);
    if(project == null || !FileExists(project.Path)) throw new Exception(string.Format("Project not found in solution - {0}", projectName));
});

Task("Clean")
    .Does(() =>
{
    CleanDirectory(artifacts);
    var binDirs = GetDirectories(solutionPath.GetDirectory() + @"\src\**\bin");
    var objDirs = GetDirectories(solutionPath.GetDirectory() + @"\src\**\obj");
    CleanDirectories(binDirs);
    CleanDirectories(objDirs);
});

Task("Update-Version-Info")
    .IsDependentOn("Create-Version-Info")
    .Does(() => 
{
        versionInfo = GitVersion(new GitVersionSettings {
            UpdateAssemblyInfo = true,
            UpdateAssemblyInfoFilePath = versionAssemblyInfo
        });

    if(versionInfo != null) {
        Information("Version: {0}", versionInfo.FullSemVer);
    } else {
        throw new Exception("Unable to determine version");
    }
});

Task("Create-Version-Info")
    .WithCriteria(() => !FileExists(versionAssemblyInfo))
    .Does(() =>
{
    Information("Creating version assembly info");
    CreateAssemblyInfo(versionAssemblyInfo, new AssemblyInfoSettings {
        Version = "0.0.0.0",
        FileVersion = "0.0.0.0",
        InformationalVersion = "",
    });
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solutionPath, new NuGetRestoreSettings());
});

Task("Build")
    .IsDependentOn("Update-Version-Info")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    MSBuild(solutionPath, settings => settings
        .WithProperty("TreatWarningsAsErrors","true")
        .WithProperty("UseSharedCompilation", "false")
        .WithProperty("AutoParameterizationWebConfigConnectionStrings", "false")
        .SetVerbosity(Verbosity.Quiet)
        .SetConfiguration(configuration)
        .WithTarget("Rebuild")
    );
});

Task("Copy-Files")
    .IsDependentOn("Build")
    .Does(() => 
{
    CreateDirectory(artifacts + "/build");
    var files = GetFiles(project.Path.GetDirectory() + "/bin/" + configuration + "/" + project.Name + ".*");
    CopyFiles(files, artifacts +"/build");
});

Task("Package")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-NuGet-Packages")
    .IsDependentOn("Copy-Files")
    .Does(() =>
{
    CreateDirectory(Directory(artifacts + "/packages"));

    var nuspec = project.Path.GetDirectory() + "/" + project.Name + ".nuspec";
    Information("Packing: {0}", nuspec);
    NuGetPack(nuspec, new NuGetPackSettings {
        BasePath = artifacts + "/build",
        NoPackageAnalysis = false,
        OutputDirectory = Directory(artifacts + "/packages"),
        Properties = new Dictionary<string, string>() { { "Configuration", configuration } }
    });
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    CreateDirectory(testResultsPath);

    var settings = new XUnit2Settings {
        XmlReportV1 = true,
        NoAppDomain = true,
        OutputDirectory = testResultsPath,
    };
    settings.ExcludeTrait("Category", "Integration");
    
    XUnit2(testAssemblies, settings);
});

Task("AppVeyor-Update-Build-Number")
    .IsDependentOn("Update-Version-Info")
    .WithCriteria(() => AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
{
    AppVeyor.UpdateBuildVersion(versionInfo.FullSemVer +"|" +AppVeyor.Environment.Build.Number);
});

Task("Appveyor-Upload-Artifacts")
    .IsDependentOn("Package")
    .WithCriteria(() => AppVeyor.IsRunningOnAppVeyor)
    .Does(() =>
{
    foreach(var nupkg in GetFiles(artifacts +"/*.nupkg")) {
        AppVeyor.UploadArtifact(nupkg);
    }
});

Task("AppVeyor")
    .WithCriteria(() => AppVeyor.IsRunningOnAppVeyor)
    .IsDependentOn("AppVeyor-Update-Build-Number")
    .IsDependentOn("AppVeyor-Upload-Artifacts");

Task("CI")
    .IsDependentOn("AppVeyor")
    .IsDependentOn("Default");

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Copy-Files")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Package");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
