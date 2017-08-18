using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Bower
{
    /// <summary>
    /// Bower runner settings
    /// </summary>
    public class BowerRunnerSettings : ToolSettings
    {
        /// <summary>
        /// The command to run
        /// </summary>
        protected readonly string Command;

        /// <summary>
        /// Bower runner settings
        /// </summary>
        /// <param name="command"></param>
        public BowerRunnerSettings(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentNullException(nameof(command));
            Command = command;
        }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            EvaluateCore(args);
        }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
        }
    }
}