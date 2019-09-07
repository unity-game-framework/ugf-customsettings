using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPrefs
    {
        private static readonly CustomSettingsEditorPrefs<TestSettingsEditorData> m_settings = new CustomSettingsEditorPrefs<TestSettingsEditorData>("test.editor.settings");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Prefs", m_settings, SettingsScope.Project);
        }
    }
}
