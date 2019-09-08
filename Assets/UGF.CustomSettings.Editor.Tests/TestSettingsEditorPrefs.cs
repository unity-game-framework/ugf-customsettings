using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPrefs
    {
        public static CustomSettingsEditorPrefs<TestSettingsEditorData> Settings { get; } = new CustomSettingsEditorPrefs<TestSettingsEditorData>
        (
            "test.editor.settings"
        );

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Prefs", Settings, SettingsScope.Project);
        }
    }
}
