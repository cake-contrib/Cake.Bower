using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower link settings
    /// </summary>
    public class BowerLinkSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower link settings
        /// </summary>
        public BowerLinkSettings() : base("link") { }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                args.Append(Name);
                if (!string.IsNullOrWhiteSpace(LocalName))
                    args.Append(LocalName);
            }
            base.EvaluateCore(args);
        }

        /// <summary>
        /// Name of the folder to link to
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// LocalName
        /// </summary>
        public string LocalName { get; set; }

        /// <summary>
        /// Set the name to link to
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BowerLinkSettings WithName(string name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// Set the local name
        /// </summary>
        /// <param name="localName"></param>
        /// <returns></returns>
        public BowerLinkSettings WithLocalName(string localName)
        {
            LocalName = localName;
            return this;
        }
    }
}