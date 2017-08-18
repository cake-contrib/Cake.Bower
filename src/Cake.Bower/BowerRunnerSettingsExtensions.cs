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
    }
}