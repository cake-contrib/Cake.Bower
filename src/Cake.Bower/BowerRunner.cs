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
    public class BowerRunner : Tool<BowerRunnerSettings>, IBowerRunnerCommands
    {

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
        protected override IEnumerable<string> GetToolExecutableNames() => new[] { "bower.cmd", "bower" };

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
            return Run(configure);
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
            return Run(settings);
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
            return Run(settings);
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
            return Run(settings);
        }
        #endregion

        #region cache
        /// <summary>
        /// execute 'bower cache' for a particular package
        /// </summary>
        /// <param name="configure">options when running 'bower cache'</param>
        /// <example>
        /// <para>Run 'bower cache'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Cache(s => s.Clean()));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Cache(Action<BowerCacheSettings> configure = null)
        {
            return Run(configure);
        }

        /// <summary>
        /// execute 'bower cache' for a particular package
        /// </summary>
        /// <param name="settings">options when running 'bower cache'</param>
        /// <example>
        /// <para>Run 'bower cache'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerCacheSettings();
        ///     settings.Clean();
        ///     Bower.Install(settings));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Cache(BowerCacheSettings settings)
        {
            return Run(settings);
        }
        #endregion

        #region help
        /// <summary>
        /// execute 'bower help' for a particular package
        /// </summary>
        /// <param name="command"></param>
        /// <example>
        /// <para>Run 'bower help'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Help("install"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Help(string command)
        {
            var settings = new BowerHelpSettings(command);
            return Run(settings);
        }
        #endregion region

        #region home
        /// <summary>
        /// execute 'bower home' for a particular package
        /// </summary>
        /// <param name="package"></param>
        /// <example>
        /// <para>Run 'bower home'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Home("jquery"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Home(string package)
        {
            var settings = new BowerHomeSettings(package);
            return Run(settings);
        }
        #endregion

        #region info

        /// <summary>
        /// execute 'bower info' for a particular package
        /// </summary>
        /// <param name="package"></param>
        /// <param name="property"></param>
        /// <example>
        /// <para>Run 'bower info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Info("jquery", "main"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Info(string package, string property = null)
        {
            return Info(s => s.ForPackage(package).ForProperty(property));
        }

        /// <summary>
        /// execute 'bower info' for a particular package
        /// </summary>
        /// <example>
        /// <param name="configure"></param>
        /// <para>Run 'bower info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Info(s => s.ForPackage("jquery"));
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Info(Action<BowerInfoSettings> configure = null)
        {
            return Run(configure);
        }

        /// <summary>
        /// execute 'bower info' for a particular package
        /// </summary>
        /// <example>
        /// <param name="settings"></param>
        /// <para>Run 'bower info'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerInfoSettings().ForPackage("jquery");
        ///     Bower.Info(settings);
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Info(BowerInfoSettings settings)
        {
            return Run(settings);
        }
        #endregion

        #region Link
        /// <summary>
        /// execute 'bower link'
        /// </summary>
        /// <example>
        /// <param name="configure"></param>
        /// <para>Run 'bower link'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Link(s => s.UseWorkingDirectory("./folder/").WithName("jquery");
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Link(Action<BowerLinkSettings> configure = null)
        {
            return Run(configure);
        }

        /// <summary>
        /// execute 'bower link'
        /// </summary>
        /// <example>
        /// <param name="settings"></param>
        /// <para>Run 'bower link'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerLinkSettings().WithName("jquery");
        ///     Bower.Link(settings);
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Link(BowerLinkSettings settings)
        {
            return Run(settings);
        }
        #endregion

        #region list
        /// <summary>
        /// execute 'bower list'
        /// </summary>
        /// <example>
        /// <param name="configure"></param>
        /// <para>Run 'bower list'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.List(s => s.WithPaths());
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands List(Action<BowerListSettings> configure = null)
        {
            return Run(configure);
        }

        /// <summary>
        /// execute 'bower list'
        /// </summary>
        /// <example>
        /// <param name="settings"></param>
        /// <para>Run 'bower list'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     var settings = new BowerListSettings().WithPaths();
        ///     Bower.List(settings);
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands List(BowerListSettings settings)
        {
            return Run(settings);
        }
        #endregion

        #region login
        /// <summary>
        /// execute 'bower login'
        /// </summary>
        /// <example>
        /// <param name="token"></param>
        /// <para>Run 'bower login'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Login("a2eb43af648042a1b376d296dda551d4");
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Login(string token = null)
        {
            var settings = new BowerLoginSettings(token);
            return Run(settings);
        }
        #endregion

        #region prune
        /// <summary>
        /// execute 'bower prune'
        /// </summary>
        /// <example>
        /// <para>Run 'bower prune'</para>
        /// <code>
        /// <![CDATA[
        /// Task("Bower")
        ///     .Does(() =>
        /// {
        ///     Bower.Prune();
        /// });
        /// ]]>
        /// </code>
        /// </example>
        public IBowerRunnerCommands Prune()
        {
            return Run<BowerPruneSettings>();
        }
        #endregion

        private static ProcessArgumentBuilder GetBowerSettingsArguments(BowerRunnerSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }

        /// <summary>
        /// Generic runner using settings configurator
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="configure"></param>
        /// <returns></returns>
        private IBowerRunnerCommands Run<TSettings>(Action<TSettings> configure = null) where TSettings : BowerRunnerSettings
        {
            var settings = (TSettings)Activator.CreateInstance(typeof(TSettings));
            configure?.Invoke(settings);
            return Run(settings);
        }

        /// <summary>
        /// Generic runner using settings
        /// </summary>
        /// <typeparam name="TSettings"></typeparam>
        /// <param name="settings"></param>
        /// <returns></returns>
        private IBowerRunnerCommands Run<TSettings>(TSettings settings) where TSettings : BowerRunnerSettings
        {
            var args = GetBowerSettingsArguments(settings);
            Run(settings, args);
            return this;
        }
    }
}