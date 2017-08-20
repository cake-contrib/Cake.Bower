using System;
using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerListFixture : ToolFixture<BowerListSettings>
    {
        public BowerListFixture() : base("bower") { }

        public Action<BowerListSettings> ListSettings { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.List(ListSettings);
        }
    }
}