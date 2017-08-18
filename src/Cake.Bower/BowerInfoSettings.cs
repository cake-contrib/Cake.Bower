using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    /// <summary>
    /// Bower info settings
    /// </summary>
    public class BowerInfoSettings : BowerRunnerSettings
    {
        /// <summary>
        /// Bower info settings
        /// </summary>
        public BowerInfoSettings() : base("info") { }

        /// <summary>
        /// Evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Package))
            {
                args.Append(Package);

                if (!string.IsNullOrWhiteSpace(Property))
                    args.Append(Property);
            }
        }

        /// <summary>
        /// The package to get info for
        /// </summary>
        public string Package { get; internal set; }

        /// <summary>
        /// The property to get the info of
        /// </summary>
        public string Property { get; internal set; }

        /// <summary>
        /// Set the command to get info for
        /// </summary>
        /// <param name="commandName"></param>
        /// <returns></returns>
        public BowerInfoSettings ForPackage(string commandName)
        {
            Package = commandName;
            return this;
        }

        /// <summary>
        /// The property to get the info for
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public BowerInfoSettings ForProperty(string property)
        {
            Property = property;
            return this;
        }
    }
}