namespace UGF.CustomSettings.Runtime.Tests
{
    public static class TestSettingsFile
    {
        public static CustomSettingsFile<TestSettingsData> Settings { get; } = new CustomSettingsFile<TestSettingsData>("Assets/StreamingAssets/test.settings.json");
    }
}
