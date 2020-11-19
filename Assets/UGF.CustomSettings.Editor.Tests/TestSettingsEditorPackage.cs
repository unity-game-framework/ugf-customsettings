using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPackage
    {
        public static CustomSettingsEditorPackage<TestSettingsEditorData> Settings { get; } = new CustomSettingsEditorPackage<TestSettingsEditorData>
        (
            "UGF.Test.Editor.Package",
            "TestEditorPackageSettings",
            CustomSettingsEditorUtility.DEFAULT_PACKAGE_FOLDER
        )
        {
            ForceCreation = true
        };

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Package", Settings, SettingsScope.Project);
        }
    }
}
