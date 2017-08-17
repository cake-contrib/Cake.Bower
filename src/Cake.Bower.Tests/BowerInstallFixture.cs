using System;
using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerInstallFixture : ToolFixture<BowerInstallSettings>
    {
        public BowerInstallFixture() : base("bower") { }

        public Action<BowerInstallSettings> InstallSettings { get; set; }
        public string Package { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);

            if (string.IsNullOrWhiteSpace(Package))
                tool.Install(InstallSettings);
            else
                tool.Install(Package, InstallSettings);
        }
    }
}
