using JetBrains.Annotations;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPackageExternal
    {
        public static CustomSettingsEditorPackage<TestSettingsEditorData> Settings { get; } = new CustomSettingsEditorPackage<TestSettingsEditorData>
        (
            "UGF.Test.Editor.Package.External",
            "TestEditorPackageExternalSettings",
            CustomSettingsEditorUtility.DEFAULT_PACKAGE_EXTERNAL_FOLDER
        );

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Package External", Settings, SettingsScope.Project);
        }
    }
}
