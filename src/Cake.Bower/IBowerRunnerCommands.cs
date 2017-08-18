using System;

namespace Cake.Bower
{
    /// <summary>
    /// Bower runner command interface
    /// </summary>
    public interface IBowerRunnerCommands
    {
        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="configure">options when running 'bower install'</param>
        IBowerRunnerCommands Install(Action<BowerInstallSettings> configure = null);

        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="settings">options when running 'bower install'</param>
        IBowerRunnerCommands Install(BowerInstallSettings settings);

        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="package">endpoint/package to install</param>
        /// <param name="configure">options when running 'bower install'</param>
        IBowerRunnerCommands Install(string package, Action<BowerInstallSettings> configure = null);

        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="package">endpoint/package to install</param>
        /// /// <param name="settings">options when running 'bower install'</param>
        IBowerRunnerCommands Install(string package, BowerInstallSettings settings);

        /// <summary>
        /// execute 'bower cache' with options
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        IBowerRunnerCommands Cache(Action<BowerCacheSettings> configure = null);
        /// <summary>
        /// execute 'bower cache' with options
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        IBowerRunnerCommands Cache(BowerCacheSettings settings);

        /// <summary>
        /// execute 'bower help'
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        IBowerRunnerCommands Help(string command = null);

        /// <summary>
        /// execute 'bower home'
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        IBowerRunnerCommands Home(string package = null);

        /// <summary>
        /// execute 'bower info'
        /// </summary>
        /// <param name="package"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        IBowerRunnerCommands Info(string package = null, string property = null);
    }
}
