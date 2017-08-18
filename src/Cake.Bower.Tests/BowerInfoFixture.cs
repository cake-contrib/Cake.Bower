using System;
using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerInfoFixture : ToolFixture<BowerInfoSettings>
    {
        public BowerInfoFixture() : base("bower") { }

        public Action<BowerInfoSettings> InfoSettings { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Info(InfoSettings);
        }
    }
}