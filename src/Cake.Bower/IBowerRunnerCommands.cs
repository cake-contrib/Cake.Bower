using System;

namespace Cake.Bower
{
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
        /// <param name="configure">options when running 'bower install'</param>
        IBowerRunnerCommands Install(BowerInstallSettings settings);

        /// <summary>
        /// execute 'bower install' with options
        /// </summary>
        /// <param name="endpoint">endpoint/package to install</param>
        IBowerRunnerCommands Install(string endpoint);
    }
}
