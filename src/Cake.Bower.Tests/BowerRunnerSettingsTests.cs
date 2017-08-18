using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerRunnerSettingsTests
    {
        private readonly BowerCacheFixture _fixture = new BowerCacheFixture(); // Any fixture will do here

        [Fact]
        public void Force_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithForce();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --force");
        }

        [Fact]
        public void Json_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithJson();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --json");
        }

        [Theory]
        [InlineData(BowerLogLevel.Action, "action")]
        [InlineData(BowerLogLevel.Conflict, "conflict")]
        [InlineData(BowerLogLevel.Debug, "debug")]
        [InlineData(BowerLogLevel.Error, "error")]
        [InlineData(BowerLogLevel.Info, "info")]
        [InlineData(BowerLogLevel.Warn, "warn")]
        public void LogLevel_Setting_Adds_Switch_To_Command(BowerLogLevel logLevel, string name)
        {
            _fixture.CacheSettings = s => s.WithLogLevel(logLevel);
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --loglevel={name}");
        }

        public void None_LogLevel_Setting_Does_Not_Add_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithLogLevel(BowerLogLevel.None);
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache");
        }

        [Fact]
        public void Offline_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithOffline();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --offline");
        }

        [Fact]
        public void Quiet_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithQuiet();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --quiet");
        }

        [Fact]
        public void Silent_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithSilent();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --silent");
        }

        [Fact]
        public void Verbose_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithVerbose();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --verbose");
        }

        [Fact]
        public void AllowRoot_Setting_Adds_Switch_To_Command()
        {
            _fixture.CacheSettings = s => s.WithAllowRoot();
            var result = _fixture.Run();
            result.Args.ShouldBe($"cache --allow-root");
        }
    }
}