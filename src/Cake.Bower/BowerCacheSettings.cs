using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    public class BowerCacheSettings : BowerRunnerSettings
    {
        public BowerCacheSettings() : base("cache") { }

        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (clean)
                args.Append("clean");
            if (list)
                args.Append("list");
            if (clean || list && !string.IsNullOrWhiteSpace(Package))
                args.Append(Package);
        }

        private bool clean;
        private bool list;
        public string Package { get; internal set; }

        public BowerCacheSettings Clean()
        {
            clean = true;
            list = false;
            return this;
        }

        public BowerCacheSettings List()
        {
            clean = false;
            list = true;
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