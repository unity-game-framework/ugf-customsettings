using UGF.CustomSettings.Runtime;
using UGF.CustomSettings.Runtime.Tests;
using UnityEditor;

namespace UGF.CustomSettings.Editor.Tests
{
    public class TestSettingsPackageWindow : CustomSettingsWindow<TestSettingsData>
    {
        [MenuItem("Tests/TestSettingsPackageWindow")]
        private static void Menu()
        {
            GetWindow<TestSettingsPackageWindow>(false, "Settings");
        }

        protected override CustomSettings<TestSettingsData> OnGetSettings()
        {
            return TestSettingsPackage.Settings;
        }
    }
}
