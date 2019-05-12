using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    [Parameter("NuGet API key for push - Default is empty string")]
    readonly string NugetApiKey;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath OutputDirectory => RootDirectory / "output";

    readonly string NuGetSource = IsLocalBuild ? "Local" : "nuget.org";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(OutputDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .SetProperty("PackageVersion", GitVersion.NuGetVersionV2)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .EnableNoRestore());

            DotNetPack(s => s
                .SetConfiguration(Configuration)
                .SetOutputDirectory(OutputDirectory)
                .SetProperty("PackageVersion", GitVersion.NuGetVersionV2)
                .SetInformationalVersion(GitVersion.InformationalVersion)
                .EnableNoBuild()
            );
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var testProjects = GlobFiles(TestsDirectory, "**/*.csproj");

            foreach (var testProject in testProjects)
            {
                DotNetTest(s => s
                    .SetProjectFile(testProject)
                    .SetConfiguration(Configuration)
                    .SetResultsDirectory(OutputDirectory / "TestResults")
                    .SetLogger("trx")
                    .EnableNoBuild()
                );
            }
        });

    Target Publish => _ => _
        .DependsOn(Clean)
        .DependsOn(Compile)
        .DependsOn(Test)
        .Executes(() =>
        {
            if (!IsLocalBuild && string.IsNullOrEmpty(NugetApiKey))
            {
                Logger.Error("NuGet API key was not provided. Unable to push NuGet package.");
                return;
            }

            var nugetPackage = GlobFiles(OutputDirectory, "*.nupkg").First();

            DotNetNuGetPush(s => s
                .SetSource(NuGetSource)
                .SetTargetPath(nugetPackage)
                .SetApiKey(NugetApiKey)
            );
        });
}
