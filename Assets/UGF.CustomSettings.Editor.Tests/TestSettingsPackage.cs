using JetBrains.Annotations;
using UGF.CustomSettings.Runtime;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public static class TestSettingsPackage
    {
        private static readonly CustomSettingsPackage<TestSettingsData> m_settings = new CustomSettingsPackage<TestSettingsData>("com.test.package");

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<TestSettingsData>("Project/Test/Package", m_settings, SettingsScope.Project);
        }
    }
}
