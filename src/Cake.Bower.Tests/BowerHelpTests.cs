using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerHelpTests
    {
        private const string TestCommandName = "test-command-name";
        private readonly BowerHelpFixture fixture;

        public BowerHelpTests()
        {
            fixture = new BowerHelpFixture();
        }

        [Fact]
        public void No_Help_Settings_Should_Use_Correct_Argument_Provided_In_BowerHelpSettings()
        {
            fixture.Command = null;

            var result = fixture.Run();

            result.Args.ShouldBe("help");
        }

        [Fact]
        public void For_Command_Settings_Should_Use_Correct_Argument_Provided_In_BowerHelpSettings()
        {
            fixture.Command = TestCommandName;

            var result = fixture.Run();

            result.Args.ShouldBe($"help {TestCommandName}");
        }
    }
}