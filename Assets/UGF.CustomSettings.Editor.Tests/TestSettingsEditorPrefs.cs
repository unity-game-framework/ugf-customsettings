using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPrefs
    {
        private static readonly CustomSettingsEditorPrefs<TestSettingsData> m_settings = new CustomSettingsEditorPrefs<TestSettingsData>("test.editor.settings");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/Editor Prefs", m_settings, SettingsScope.Project);
        }
    }
}
