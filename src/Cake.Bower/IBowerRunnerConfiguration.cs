using Cake.Core.IO;

namespace Cake.Bower
{
    public interface IBowerRunnerConfiguration
    {
        /// <summary>
        /// Sets the working directory for bower commands
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        IBowerRunnerCommands FromPath(DirectoryPath path);
    }
}