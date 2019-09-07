using JetBrains.Annotations;
using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsFile
    {
        private static readonly CustomSettingsFile<TestSettingsData> m_settings = new CustomSettingsFile<TestSettingsData>("Assets/StreamingAssets/test.settings.json");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/File", m_settings, SettingsScope.Project);
        }
    }
}
