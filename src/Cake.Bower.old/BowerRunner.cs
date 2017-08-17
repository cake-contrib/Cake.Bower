using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Bower
{
    public class BowerRunner : Tool<BowerRunnerSettings>, IBowerRunnerCommands, IBowerRunnerConfiguration
    {
        private readonly IFileSystem _fileSystem;
        private DirectoryPath _workingDirectoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="BowerRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="toolLocator">The tool locator</param>
        public BowerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _fileSystem = fileSystem;
        }

        public IBowerRunnerCommands FromPath(DirectoryPath path)
        {
            _workingDirectoryPath = path;
            return this;
        }

        protected override string GetToolName() => "Bower Runner";

        protected override IEnumerable<string> GetToolExecutableNames() => new[] {"bower.cmd", "bower"};

#region install
        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="configure">options when running 'bower install'</param>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower-FromPath")
        ///     .Does(() =>
        /// {
        ///     Bower.FromPath("./dir-with-bowerjson").Install();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower-Install")
        ///     .Does(() =>
        /// {
        ///     Bower.Install();
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Install(Action<BowerInstallSettings> configure = null)
        {
            var settings = new BowerInstallSettings();
            configure?.Invoke(settings);

            var args = GetBowerInstallArguments(settings);

            Run(settings, args);
            return this;
        }

        private static ProcessArgumentBuilder GetBowerInstallArguments(BowerInstallSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }
#endregion

        /// <summary>
        /// Gets the working directory from the BowerRunnerSettings
        ///             Defaults to the currently set working directory.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// The working directory for the tool.
        /// </returns>
        protected override DirectoryPath GetWorkingDirectory(BowerRunnerSettings settings)
        {
            if (_workingDirectoryPath == null)
                return base.GetWorkingDirectory(settings);

            if (!_fileSystem.Exist(_workingDirectoryPath))
                throw new DirectoryNotFoundException(
                    $"Working directory path not found [{_workingDirectoryPath.FullPath}]");

            return _workingDirectoryPath;
        }
    }
}