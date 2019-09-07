using JetBrains.Annotations;
using UGF.CustomSettings.Runtime.Tests;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    internal static class TestSettingsPackageEditorProvider
    {
        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/Package", TestSettingsPackage.Settings, SettingsScope.Project);
        }
    }
}
