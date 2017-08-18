using System;
using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerLinkFixture : ToolFixture<BowerLinkSettings>
    {
        public BowerLinkFixture() : base("bower") { }

        public Action<BowerLinkSettings> LinkSettings { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Link(LinkSettings);
        }
    }
}