using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerLinkTests
    {
        private const string TestName = "test-name";
        private const string TestLocalName = "test-local-name";
        private readonly BowerLinkFixture fixture = new BowerLinkFixture();

        [Fact]
        public void No_Link_Settings_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            fixture.LinkSettings = null;
            var result = fixture.Run();
            result.Args.ShouldBe("link");
        }

        [Fact]
        public void Name_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            fixture.LinkSettings = s => s.WithName(TestName);
            var result = fixture.Run();
            result.Args.ShouldBe($"link {TestName}");
        }

        [Fact]
        public void Name_And_LocalName_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            fixture.LinkSettings = s => s.WithName(TestName).WithLocalName(TestLocalName);
            var result = fixture.Run();
            result.Args.ShouldBe($"link {TestName} {TestLocalName}");
        }

        [Fact]
        public void LocalName_Only_Should_Ignore_Additional_Arguments_Provided_In_BowerLinkSettings()
        {
            fixture.LinkSettings = s => s.WithLocalName(TestLocalName);
            var result = fixture.Run();
            result.Args.ShouldBe($"link");
        }
    }
}