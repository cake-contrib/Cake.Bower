using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerLoginTests
    {
        private const string TestToken = "a2eb43af648042a1b376d296dda551d4";
        private readonly BowerLoginFixture fixture = new BowerLoginFixture();

        [Fact]
        public void No_Token_Should_Use_Correct_Argument_Provided_In_BowerLoginSettings()
        {
            fixture.Token= null;
            var result = fixture.Run();
            result.Args.ShouldBe("login");
        }

        [Fact]
        public void With_Token_Should_Use_Correct_Argument_Provided_In_BowerLoginSettings()
        {
            fixture.Token = TestToken;
            var result = fixture.Run();
            result.Args.ShouldBe($"login {BowerOptions.Login.Token} {TestToken}");
        }
    }
}