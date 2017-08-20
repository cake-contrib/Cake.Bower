using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower home settings
    /// </summary>
    public class BowerHomeSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower home settings
        /// </summary>
        public BowerHomeSettings() : base("home") { }

        /// <summary>
        /// Bower home settings
        /// </summary>
        /// <param name="package"></param>
        public BowerHomeSettings(string package) : this()
        {
            ForPackage(package);
        }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Package))
                args.Append(Package);

            base.EvaluateCore(args);
        }

        /// <summary>
        /// The package to open the home page of
        /// </summary>
        public string Package { get; internal set; }

        /// <summary>
        /// Set the package to open the home page of
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public BowerHomeSettings ForPackage(string package)
        {
            Package = package;
            return this;
        }
    }
}