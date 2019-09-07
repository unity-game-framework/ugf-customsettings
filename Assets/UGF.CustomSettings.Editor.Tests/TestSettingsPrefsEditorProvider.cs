using JetBrains.Annotations;
using UGF.CustomSettings.Runtime.Tests;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    internal static class TestSettingsPrefsEditorProvider
    {
        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/Prefs", TestSettingsPrefs.Settings, SettingsScope.Project);
        }
    }
}
