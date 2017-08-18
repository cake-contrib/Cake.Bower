using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower help settings
    /// </summary>
    public class BowerHelpSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower help settings
        /// </summary>
        public BowerHelpSettings() : base("help") {}

        /// <summary>
        /// Bower help settings
        /// </summary>
        /// <param name="commandName"></param>
        public BowerHelpSettings(string commandName) : base("help")
        {
            ForCommand(commandName);
        }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(CommandName))
                args.Append(CommandName);
        }

        /// <summary>
        /// The command to get help for
        /// </summary>
        public string CommandName { get; internal set; }

        /// <summary>
        /// Set the command to get help for
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public BowerHelpSettings ForCommand(string commandName)
        {
            CommandName = commandName;
            return this;
        }
    }
}