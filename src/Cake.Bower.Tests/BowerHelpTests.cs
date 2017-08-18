using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerHelpTests
    {
        private const string _testCommandName = "test-command-name";
        private readonly BowerHelpFixture _fixture;

        public BowerHelpTests()
        {
            _fixture = new BowerHelpFixture();
        }

        [Fact]
        public void No_Help_Settings_Should_Use_Correct_Argument_Provided_In_BowerHelpSettings()
        {
            _fixture.Command = null;

            var result = _fixture.Run();

            result.Args.ShouldBe("help");
        }

        [Fact]
        public void For_Command_Settings_Should_Use_Correct_Argument_Provided_In_BowerHelpSettings()
        {
            _fixture.Command = _testCommandName;

            var result = _fixture.Run();

            result.Args.ShouldBe($"help {_testCommandName}");
        }
    }
}