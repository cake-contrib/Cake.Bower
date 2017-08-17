using Cake.Core.IO;

namespace Cake.Bower
{
    public static class BowerRunnerSettingsExtensions
    {
        public static T UseWorkingDirectory<T>(this T settings, DirectoryPath directory) where T : BowerRunnerSettings
        {
            settings.WorkingDirectory = directory;
            return settings;
        }
    }
}