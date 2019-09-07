using JetBrains.Annotations;
using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsPrefs
    {
        private static readonly CustomSettingsPrefs<TestSettingsData> m_settings = new CustomSettingsPrefs<TestSettingsData>("test.settings");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/Prefs", m_settings, SettingsScope.Project);
        }
    }
}
