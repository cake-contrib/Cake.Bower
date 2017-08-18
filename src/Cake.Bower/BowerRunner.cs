using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Bower
{
    /// <summary>
    /// A wrapper around the Bower package manager
    /// </summary>
    public class BowerRunner : Tool<BowerRunnerSettings>, IBowerRunnerCommands{

        /// <summary>
        /// Initializes a new instance of the <see cref="BowerRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="toolLocator">The tool locator</param>
        public BowerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator toolLocator)
            : base(fileSystem, environment, processRunner, toolLocator) { }

        /// <summary>
        /// Gets the name of the tool
        /// </summary>
        /// <returns>the name of the tool</returns>
        protected override string GetToolName() => "Bower Runner";

        /// <summary>
        /// Gets the name of the tool executable
        /// </summary>
        /// <returns>The tool executable name</returns>
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
        ///     Bower.Install(s => s.UseWorkingDirectory("./dir-with-bower.json/");
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

            return Install(settings);
        }


        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="settings">options when running 'bower install'</param>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerInstallSettings()
        ///         .WithSave()
        ///         .ForProduction();
        ///     Bower.Install(settings));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Install(BowerInstallSettings settings)
        {
            var args = GetBowerSettingsArguments(settings);
            Run(settings, args);
            return this;
        }

        /// <summary>
        /// execute 'bower install' for a particular package
        /// </summary>
        /// <param name="package">endpoint/package to install when using 'bower install'</param>
        /// <param name="configure">options when running 'bower install'</param>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Install("jquery"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Install(string package, Action<BowerInstallSettings> configure = null)
        {
            var settings = new BowerInstallSettings();
            settings.WithPackage(package);
            configure?.Invoke(settings);
            return Install(settings);
        }

        /// <summary>
        /// execute 'bower install' for a particular package
        /// </summary>
        /// <param name="package">endpoint/package to install when using 'bower install'</param>
        /// <param name="settings">options when running 'bower install'</param>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerInstallSettings();
        ///     settings.WithSave();
        ///     Bower.Install("jquery", settings));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Install(string package, BowerInstallSettings settings)
        {
            settings.WithPackage(package);
            return Install(settings);
        }
        #endregion

        #region cache
        /// <summary>
        /// execute 'bower cache' for a particular package
        /// </summary>
        /// <param name="configure">options when running 'bower install'</param>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerInstallSettings();
        ///     settings.WithSave();
        ///     Bower.Install("jquery", settings));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Cache(Action<BowerCacheSettings> configure = null)
        {
            var settings = new BowerCacheSettings();
            configure?.Invoke(settings);

            return Cache(settings);
        }

        /// <summary>
        /// execute 'bower cache' for a particular package
        /// </summary>
        /// <param name="settings">options when running 'bower install'</param>
        /// <example>
        /// <para>Run 'bower install'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerInstallSettings();
        ///     settings.WithSave();
        ///     Bower.Install("jquery", settings));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Cache(BowerCacheSettings settings)
        {
            var args = GetBowerSettingsArguments(settings);
            Run(settings, args);
            return this;
        }
        #endregion

        private static ProcessArgumentBuilder GetBowerSettingsArguments(BowerRunnerSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }
    }
}