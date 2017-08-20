using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower list settings
    /// </summary>
    public class BowerListSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower list settings
        /// </summary>
        public BowerListSettings() : base("list") { }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (Paths)
                args.Append(BowerOptions.List.Paths);
            if (Relative)
                args.Append(BowerOptions.List.Relative);

            base.EvaluateCore(args);
        }

        /// <summary>
        /// Generates a simple JSON source mapping
        /// </summary>
        public bool Paths { get; internal set; }
        /// <summary>
        /// Make paths relative to the directory config property, which defaults to bower_components
        /// </summary>
        public bool Relative { get; internal set; }

        /// <summary>
        /// Generates a simple JSON source mapping
        /// </summary>
        /// <returns></returns>
        public BowerListSettings WithPaths()
        {
            Paths = true;
            return this;
        }

        /// <summary>
        /// Make paths relative to the directory config property, which defaults to bower_components
        /// </summary>
        /// <returns></returns>
        public BowerListSettings WithRelative()
        {
            Relative = true;
            return this;
        }
    }
}