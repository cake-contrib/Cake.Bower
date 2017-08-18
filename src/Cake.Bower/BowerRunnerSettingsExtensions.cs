using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower runner settings extensions
    /// </summary>
    public static class BowerRunnerSettingsExtensions
    {
        /// <summary>
        /// Set the working directory for the bower runner settings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="settings"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static T UseWorkingDirectory<T>(this T settings, DirectoryPath directory) where T : BowerRunnerSettings
        {
            settings.WorkingDirectory = directory;
            return settings;
        }

        /// <summary>
        /// Add --force to the bower command
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithForce<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.Force = true;
            return settings;
        }

        /// <summary>
        /// Add --json
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithJson<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.Json = true;
            return settings;
        }

        /// <summary>
        /// Sets the log level e.g. --loglevel=warn
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public static T WithLogLevel<T>(this T settings, BowerLogLevel logLevel) where T : BowerRunnerSettings
        {
            settings.LogLevel = logLevel;
            return settings;
        }

        /// <summary>
        /// Add --offline
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithOffline<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.Offline = true;
            return settings;
        }

        /// <summary>
        /// Add --quiet
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithQuiet<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.Quiet = true;
            return settings;
        }

        /// <summary>
        /// Add --silent
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithSilent<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.Silent = true;
            return settings;
        }

        /// <summary>
        /// Add --verbose
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithVerbose<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.Verbose = true;
            return settings;
        }

        /// <summary>
        /// Add --allow-root
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static T WithAllowRoot<T>(this T settings) where T : BowerRunnerSettings
        {
            settings.AllowRoot = true;
            return settings;
        }
    }
}