using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower login settings
    /// </summary>
    public class BowerLoginSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower login settings
        /// </summary>
        public BowerLoginSettings() : base("login") { }

        /// <summary>
        /// Bower login settings
        /// </summary>
        public BowerLoginSettings(string token) : this()
        {
            Token = token;
        }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Token))
                args.Append($"{BowerOptions.Login.Token} {Token}");
            base.EvaluateCore(args);
        }

        /// <summary>
        /// Pass an existing GitHub auth token rather than prompting for username and password
        /// </summary>
        public string Token { get; internal set; }
    }
}