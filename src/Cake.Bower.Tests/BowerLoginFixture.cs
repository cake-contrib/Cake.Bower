using Cake.Testing.Fixtures;

namespace Cake.Bower.Tests
{
    public class BowerLoginFixture : ToolFixture<BowerLoginSettings>
    {
        public BowerLoginFixture() : base("bower") { }

        public string Token { get; set; }

        protected override void RunTool()
        {
            var tool = new BowerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Login(Token);
        }
    }
}