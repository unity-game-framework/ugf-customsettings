using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsEditorPackageExternalUser
    {
        public static CustomSettingsEditorPackage<TestSettingsEditorData> Settings { get; } = new CustomSettingsEditorPackage<TestSettingsEditorData>
        (
            "UGF.Test.Editor.Package.External",
            "TestEditorPackageExternalUserSettings",
            CustomSettingsEditorUtility.DEFAULT_PACKAGE_EXTERNAL_USER_FOLDER
        );

        [SettingsProvider]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsEditorData>("Project/Test/Editor Package External User", Settings, SettingsScope.Project);
        }
    }
}
