using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPackage
    {
        private static readonly CustomSettingsEditorPackage<TestSettingsData> m_settings = new CustomSettingsEditorPackage<TestSettingsData>("com.test.editor.package");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/Editor Package", m_settings, SettingsScope.Project);
        }
    }
}
