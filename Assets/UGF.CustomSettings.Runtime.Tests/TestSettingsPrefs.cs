namespace UGF.CustomSettings.Runtime.Tests
{
    public static class TestSettingsPrefs
    {
        public static CustomSettingsPrefs<TestSettingsData> Settings { get; } = new CustomSettingsPrefs<TestSettingsData>("test.settings");
    }
}
