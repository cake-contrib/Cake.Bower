using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerInfoTests
    {
        private const string _testPackageName = "test-package-name";
        private const string _testPropertyName = "test-property-name";
        private readonly BowerInfoFixture _fixture;

        public BowerInfoTests()
        {
            _fixture = new BowerInfoFixture();
        }

        [Fact]
        public void ForPackage_Should_Use_Correct_Argument_Provided_In_BowerInfoSettings()
        {
            _fixture.InfoSettings = s => s.ForPackage(_testPackageName);

            var result = _fixture.Run();

            result.Args.ShouldBe($"info {_testPackageName}");
        }

        [Fact]
        public void ForProperty_Only_Should_Ignore_Settings_Correct_Argument_Provided_In_BowerInfoSettings()
        {
            _fixture.InfoSettings = s => s.ForProperty(_testPropertyName);

            var result = _fixture.Run();

            result.Args.ShouldBe("info");
        }

        [Fact]
        public void ForProperty_And_ForPackage_Should_Use_Correct_Argument_Provided_In_BowerInfoSettings()
        {
            _fixture.InfoSettings = s => s.ForProperty(_testPropertyName).ForPackage(_testPackageName);

            var result = _fixture.Run();

            result.Args.ShouldBe($"info {_testPackageName} {_testPropertyName}");
        }
    }
}