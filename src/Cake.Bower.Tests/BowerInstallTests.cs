using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerInstallTests
    {
        private const string TestPackageName = "test-package-name";
        private readonly BowerInstallFixture fixture = new BowerInstallFixture();

        private static string GetPackageString(string package) => string.IsNullOrWhiteSpace(package)
            ? null
            : $" {package}";

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void No_Install_Settings_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = null;

            var result = fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)}");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void Save_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = s => s.WithSave();

            var result = fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --save");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void SaveDev_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = s => s.WithSaveDev();

            var result = fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --save-dev");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void SaveExact_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = s => s.WithSaveExact();

            var result = fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --save-exact");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void Production_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = s => s.ForProduction();

            var result = fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --production");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void Force_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = s => s.WithForceLatest();

            var result = fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --force-latest");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(TestPackageName)]
        public void Multiple_Settings_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            fixture.Package = package;
            fixture.InstallSettings = s => s
                .WithSaveDev()
                .WithForceLatest()
                .WithSave()
                .WithSaveExact()
                .ForProduction();

            var result = fixture.Run();
            result.Args.ShouldBe($"install{GetPackageString(package)} --save --save-dev --save-exact --force-latest --production");
        }
    }
}