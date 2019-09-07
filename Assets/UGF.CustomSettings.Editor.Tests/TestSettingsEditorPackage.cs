using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPackage
    {
        public static CustomSettingsEditorPackage<TestSettingsEditorData> Settings { get; } = new CustomSettingsEditorPackage<TestSettingsEditorData>("com.test.editor.package");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Package", Settings, SettingsScope.Project);
        }
    }
}
