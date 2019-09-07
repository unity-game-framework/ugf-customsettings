using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPackage
    {
        private static readonly CustomSettingsEditorPackage<TestSettingsEditorData> m_settings = new CustomSettingsEditorPackage<TestSettingsEditorData>("com.test.editor.package");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Package", m_settings, SettingsScope.Project);
        }
    }
}
