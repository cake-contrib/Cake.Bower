using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerCacheTests
    {
        private const string PackageTestName = "package-test-name";
        private readonly BowerCacheFixture fixture = new BowerCacheFixture();

        [Fact]
        public void No_Install_Settings_Should_Use_Correct_Argument_Provided_In_BowerCacheSettings()
        {
            fixture.CacheSettings = null;

            var result = fixture.Run();

            result.Args.ShouldBe("cache");
        }

        [Fact]
        public void Clean_Should_Use_Correct_Argument_Provided_In_BowerCacheSettings()
        {
            fixture.CacheSettings = s => s.Clean();

            var result = fixture.Run();

            result.Args.ShouldBe("cache clean");
        }

        [Fact]
        public void List_Should_Use_Correct_Argument_Provided_In_BowerCacheSettings()
        {
            fixture.CacheSettings = s => s.List();

            var result = fixture.Run();

            result.Args.ShouldBe("cache list");
        }

        [Fact]
        public void Clean_With_Package_Should_Use_Correct_Arguments_Provided_In_BowerCacheSettings()
        {
            fixture.CacheSettings = s => s.Clean().WithPackage(PackageTestName);

            var result = fixture.Run();

            result.Args.ShouldBe($"cache clean {PackageTestName}");
        }

        [Fact]
        public void List_With_Package_Should_Use_Correct_Arguments_Provided_In_BowerCacheSettings()
        {
            fixture.CacheSettings = s => s.List().WithPackage(PackageTestName);

            var result = fixture.Run();

            result.Args.ShouldBe($"cache list {PackageTestName}");
        }

        [Fact]
        public void No_SubCommand_With_Package_Should_Use_Ignore_Package_In_BowerCacheSettings()
        {
            fixture.CacheSettings = s => s.WithPackage(PackageTestName);

            var result = fixture.Run();

            result.Args.ShouldBe("cache");
        }
    }
}