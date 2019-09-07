#load nuget:?package=Cake.Recipe&version=1.0.0
#load "docs-prep.cake"

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            title: "Cake.Bower",
                            repositoryOwner: "cake-contrib",
                            repositoryName: "Cake.Bower",
                            appVeyorAccountName: "cakecontrib",
                            shouldRunCodecov: false,
                            shouldRunDotNetCorePack: true,
                            shouldRunGitVersion: true);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);
Build.RunDotNetCore();
