using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerCacheTests
    {
        private const string _packageTestName = "package-test-name";
        private readonly BowerCacheFixture _fixture = new BowerCacheFixture();

        [Fact]
        public void No_Install_Settings_Should_Use_Correct_Argument_Provided_In_BowerCacheSettings()
        {
            _fixture.CacheSettings = null;

            var result = _fixture.Run();

            result.Args.ShouldBe("cache");
        }

        [Fact]
        public void Clean_Should_Use_Correct_Argument_Provided_In_BowerCacheSettings()
        {
            _fixture.CacheSettings = s => s.Clean();

            var result = _fixture.Run();

            result.Args.ShouldBe("cache clean");
        }

        [Fact]
        public void List_Should_Use_Correct_Argument_Provided_In_BowerCacheSettings()
        {
            _fixture.CacheSettings = s => s.List();

            var result = _fixture.Run();

            result.Args.ShouldBe("cache list");
        }

        [Fact]
        public void Clean_With_Package_Should_Use_Correct_Arguments_Provided_In_BowerCacheSettings()
        {
            _fixture.CacheSettings = s => s.Clean().WithPackage(_packageTestName);

            var result = _fixture.Run();

            result.Args.ShouldBe($"cache clean {_packageTestName}");
        }

        [Fact]
        public void List_With_Package_Should_Use_Correct_Arguments_Provided_In_BowerCacheSettings()
        {
            _fixture.CacheSettings = s => s.List().WithPackage(_packageTestName);

            var result = _fixture.Run();

            result.Args.ShouldBe($"cache list {_packageTestName}");
        }

        [Fact]
        public void No_SubCommand_With_Package_Should_Use_Ignore_Package_In_BowerCacheSettings()
        {
            _fixture.CacheSettings = s => s.WithPackage(_packageTestName);

            var result = _fixture.Run();

            result.Args.ShouldBe("cache");
        }
    }
}