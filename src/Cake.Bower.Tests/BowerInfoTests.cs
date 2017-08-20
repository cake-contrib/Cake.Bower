using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerInfoTests
    {
        private const string TestPackageName = "test-package-name";
        private const string TestPropertyName = "test-property-name";
        private readonly BowerInfoFixture fixture;

        public BowerInfoTests()
        {
            fixture = new BowerInfoFixture();
        }

        [Fact]
        public void ForPackage_Should_Use_Correct_Argument_Provided_In_BowerInfoSettings()
        {
            fixture.InfoSettings = s => s.ForPackage(TestPackageName);

            var result = fixture.Run();

            result.Args.ShouldBe($"info {TestPackageName}");
        }

        [Fact]
        public void ForProperty_Only_Should_Ignore_Settings_Correct_Argument_Provided_In_BowerInfoSettings()
        {
            fixture.InfoSettings = s => s.ForProperty(TestPropertyName);

            var result = fixture.Run();

            result.Args.ShouldBe("info");
        }

        [Fact]
        public void ForProperty_And_ForPackage_Should_Use_Correct_Argument_Provided_In_BowerInfoSettings()
        {
            fixture.InfoSettings = s => s.ForProperty(TestPropertyName).ForPackage(TestPackageName);

            var result = fixture.Run();

            result.Args.ShouldBe($"info {TestPackageName} {TestPropertyName}");
        }
    }
}