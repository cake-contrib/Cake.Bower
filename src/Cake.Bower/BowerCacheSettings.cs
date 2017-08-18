using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower cache settings
    /// </summary>
    public class BowerCacheSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower cache settings
        /// </summary>
        public BowerCacheSettings() : base("cache") { }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            switch (SubCommand)
            {
                    case SubCommandTypes.Clean:
                        args.Append("clean");
                        break;
                    case SubCommandTypes.List:
                        args.Append("list");
                        break;
            }

            if (SubCommand != SubCommandTypes.None && !string.IsNullOrWhiteSpace(Package))
                args.Append(Package);

            base.EvaluateCore(args);
        }

        /// <summary>
        /// Valid subcommands for the cache command
        /// </summary>
        public enum SubCommandTypes
        {
            /// <summary>
            /// No subcommand to be applied
            /// </summary>
            None,
            /// <summary>
            /// Apply the "clean" subcommand
            /// </summary>
            Clean,
            /// <summary>
            /// Apply the "list" subcommand
            /// </summary>
            List
        }

        /// <summary>
        /// The subcommand to apply
        /// </summary>
        public SubCommandTypes SubCommand { get; internal set; }

        /// <summary>
        /// Name of the package to use. See https://bower.io/docs/api/#install for details
        /// </summary>
        public string Package { get; internal set; }

        /// <summary>
        /// Apply the "clean" subcommand
        /// </summary>
        /// <returns></returns>
        public BowerCacheSettings Clean()
        {
            SubCommand = SubCommandTypes.Clean;
            return this;
        }

        /// <summary>
        /// Apply the "list" subcommand
        /// </summary>
        /// <returns></returns>
        public BowerCacheSettings List()
        {
            SubCommand = SubCommandTypes.List;
            return this;
        }

        /// <summary>
        /// Package to perform the command on
        /// </summary>
        public BowerCacheSettings WithPackage(string package)
        {
            Package = package;
            return this;
        }
    }
}