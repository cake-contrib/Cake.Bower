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
            if (Force)
                args.Append("--force");
            if (Json)
                args.Append("--json");
            if (LogLevel != BowerLogLevel.None)
                args.Append($"--loglevel={LogLevel.ToString().ToLowerInvariant()}");
            if (Offline)
                args.Append("--offline");
            if (Quiet)
                args.Append("--quiet");
            if (Silent)
                args.Append("--silent");
            if (Verbose)
                args.Append("--verbose");
            if (AllowRoot)
                args.Append("--allow-root");
        }

        /// <summary>
        /// Makes various commands more forceful
        /// </summary>
        public bool Force { get; internal set; }
        /// <summary>
        /// Output consumable JSON
        /// </summary>
        public bool Json { get; internal set; }
        /// <summary>
        /// What level of logs to report
        /// </summary>
        public BowerLogLevel LogLevel { get; internal set; }
        /// <summary>
        /// Do not use network connection
        /// </summary>
        public bool Offline { get; internal set; }
        /// <summary>
        /// Only output important information. It is an alias for --loglevel=warn
        /// </summary>
        public bool Quiet { get; internal set; }
        /// <summary>
        /// Do not output anything, besides errors. It is an alias for --loglevel=error
        /// </summary>
        public bool Silent { get; internal set; }
        /// <summary>
        /// Makes output more verbose. It is an alias for --loglevel=debug
        /// </summary>
        public bool Verbose { get; internal set; }
        /// <summary>
        /// Allows running commands as root
        /// </summary>
        public bool AllowRoot { get; internal set; }

    }
}