using JetBrains.Annotations;

namespace UGF.CustomSettings.Runtime.Tests
{
    public static class TestSettingsPackage
    {
        private static readonly CustomSettingsPackage<TestSettingsPackageData> m_settings = new CustomSettingsPackage<TestSettingsPackageData>("com.test.package2");

#if UNITY_EDITOR
        [UnityEditor.SettingsProvider, UsedImplicitly]
        private static UnityEditor.SettingsProvider GetSettingsProvider()
        {
            return new Editor.CustomSettingsProvider<TestSettingsPackageData>("Project/Test/Runtime Package", m_settings, UnityEditor.SettingsScope.Project);
        }
#endif
    }
}
