using Cake.Core;
using Cake.Core.IO;

namespace Cake.Bower
{
    public class BowerInstallSettings : BowerRunnerSettings
    {
        public BowerInstallSettings() : base("install") { }

        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Package))
                args.Append(Package);
            if (Save)
                args.Append("--save");
            if (SaveDev)
                args.Append("--save-dev");
            if (SaveExact)
                args.Append("--save-exact");
            if (Force)
                args.Append("--force-latest");
            if (Production)
                args.Append("--production");
        }

        public BowerInstallSettings WithPackage(string package)
        {
            Package = package;
            return this;
        }

        /// <summary>
        /// Applies the --save parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public BowerInstallSettings WithSave(bool enabled = true)
        {
            Save = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --save-dev parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public BowerInstallSettings WithSaveDev(bool enabled = true)
        {
            SaveDev = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --save-exact parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public BowerInstallSettings WithSaveExact(bool enabled = true)
        {
            SaveExact = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --force-latest parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public BowerInstallSettings WithForce(bool enabled = true)
        {
            Force = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --production parameter
        /// </summary>
        /// <param name="enabled"></param>
        /// <returns></returns>
        public BowerInstallSettings ForProduction(bool enabled = true)
        {
            Production = enabled;
            return this;
        }

        /// <summary>
        /// Package to install
        /// See https://bower.io/docs/api/#install for details on package format
        /// </summary>
        public string Package { get; internal set; }
        /// <summary>
        /// Save installed packages into the project’s bower.json dependencies
        /// </summary>
        public bool Save { get; internal set; }
        /// <summary>
        /// Save installed packages into the project’s bower.json devDependencies
        /// </summary>
        public bool SaveDev { get; internal set; }
        /// <summary>
        /// Configure installed packages with an exact version rather than semver
        /// </summary>
        public bool SaveExact { get; internal set; }
        /// <summary>
        /// Force latest version on conflict
        /// </summary>
        public bool Force { get; internal set; }
        /// <summary>
        /// Do not install project devDependencies
        /// </summary>
        public bool Production { get; internal set; }
    }
}