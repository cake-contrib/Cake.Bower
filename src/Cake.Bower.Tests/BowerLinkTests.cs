using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerLinkTests
    {
        private const string _testName = "test-name";
        private const string _testLocalName = "test-local-name";
        private readonly BowerLinkFixture _fixture = new BowerLinkFixture();

        [Fact]
        public void No_Install_Settings_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            _fixture.LinkSettings = null;
            var result = _fixture.Run();
            result.Args.ShouldBe("link");
        }

        [Fact]
        public void Name_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            _fixture.LinkSettings = s => s.WithName(_testName);
            var result = _fixture.Run();
            result.Args.ShouldBe($"link {_testName}");
        }

        [Fact]
        public void Name_And_LocalName_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            _fixture.LinkSettings = s => s.WithName(_testName).WithLocalName(_testLocalName);
            var result = _fixture.Run();
            result.Args.ShouldBe($"link {_testName} {_testLocalName}");
        }

        [Fact]
        public void LocalName_Only_Should_Ignore_Additional_Arguments_Provided_In_BowerLinkSettings()
        {
            _fixture.LinkSettings = s => s.WithLocalName(_testLocalName);
            var result = _fixture.Run();
            result.Args.ShouldBe($"link");
        }
    }
}