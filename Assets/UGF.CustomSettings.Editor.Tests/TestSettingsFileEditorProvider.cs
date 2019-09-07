using JetBrains.Annotations;
using UGF.CustomSettings.Runtime.Tests;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsFileEditorProvider
    {
        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/File", TestSettingsFile.Settings, SettingsScope.Project);
        }
    }
}
