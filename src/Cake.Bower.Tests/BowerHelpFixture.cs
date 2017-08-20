using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerHelpFixture : ToolFixture<BowerHelpSettings>
    {
        public BowerHelpFixture() : base("bower") { }

        public string Command { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Help(Command);
        }
    }
}