namespace UGF.CustomSettings.Runtime.Tests
{
    public static class TestSettingsPackage
    {
        public static CustomSettingsPackage<TestSettingsData> Settings { get; } = new CustomSettingsPackage<TestSettingsData>
        (
            "UGF.Test.Package",
            "TestPackageSettings"
        );
    }
}
