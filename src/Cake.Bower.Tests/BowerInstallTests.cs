using Shouldly;
using Xunit;

namespace Cake.Bower.Tests
{
    public class BowerInstallTests
    {
        private const string _testPackageName = "test-package-name";
        private readonly BowerInstallFixture _fixture = new BowerInstallFixture();

        private static string GetPackageString(string package) => string.IsNullOrWhiteSpace(package)
            ? null
            : $" {package}";

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void No_Install_Settings_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = null;

            var result = _fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)}");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void Save_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = s => s.WithSave();

            var result = _fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --save");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void SaveDev_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = s => s.WithSaveDev();

            var result = _fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --save-dev");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void SaveExact_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = s => s.WithSaveExact();

            var result = _fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --save-exact");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void Production_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = s => s.ForProduction();

            var result = _fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --production");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void Force_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = s => s.WithForceLatest();

            var result = _fixture.Run();

            result.Args.ShouldBe($"install{GetPackageString(package)} --force-latest");
        }

        [Theory]
        [InlineData(null)]
        [InlineData(_testPackageName)]
        public void Multiple_Settings_Should_Use_Correct_Argument_Provided_In_BowerInstallSettings(string package)
        {
            _fixture.Package = package;
            _fixture.InstallSettings = s => s
                .WithSaveDev()
                .WithForceLatest()
                .WithSave()
                .WithSaveExact()
                .ForProduction();

            var result = _fixture.Run();
            result.Args.ShouldBe($"install{GetPackageString(package)} --save --save-dev --save-exact --force-latest --production");
        }
    }
}