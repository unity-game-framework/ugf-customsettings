using UnityEngine;

namespace UGF.CustomSettings.Runtime.Tests
{
    public static class TestSettingsFile
    {
        public static CustomSettingsFile<TestSettingsData> Settings { get; } = new CustomSettingsFile<TestSettingsData>
        (
            $"{Application.streamingAssetsPath}/test.settings.json"
        );
    }
}
