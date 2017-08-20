using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerListTests
    {
        private readonly BowerListFixture fixture = new BowerListFixture();

        [Fact]
        public void No_List_Settings_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            fixture.ListSettings = null;
            var result = fixture.Run();
            result.Args.ShouldBe("list");
        }

        [Fact]
        public void WithPaths_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            fixture.ListSettings = s => s.WithPaths();
            var result = fixture.Run();
            result.Args.ShouldBe($"list {BowerOptions.List.Paths}");
        }

        public void WithRelative_Should_Use_Correct_Argument_Provided_In_BowerLinkSettings()
        {
            fixture.ListSettings = s => s.WithRelative();
            var result = fixture.Run();
            result.Args.ShouldBe($"list {BowerOptions.List.Relative}");
        }
    }
}